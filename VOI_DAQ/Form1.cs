using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Collections;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Xml.Linq;
//namespace MLDC_DataLog
namespace VOI_DAQ
{
    public partial class Form1 : Form
    {
       // int BaseCounter;
        int Timer_1sec;

      //  string MaxPointProfileClose;
     //  string MaxPointProfileOpen;
      //  Int32 Speed_PID;
     //   Int32 Final_PID;
     //   UInt16 SpeedAverage_S_Profile;
     //   UInt16 Speed_Target;
     //   byte ProfilePulse_Command;
   //     UInt16 Speed_Actual;
   //     byte ProfilePulse_Direction;

     //   byte ProfilePulse_Mode;
    //   byte ProfilePulse_Mode_Prev;
     //   byte MainMode;
 //       Int16 EncPulse_DoorLength;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SP1_IO_Serial_UpdateCOMPortList();
        }
        public void SP1_IO_Serial_UpdateCOMPortList()
        {

            int i; i = 0; bool foundDifference;
            foundDifference = false;
            //   textBox_PortName.Text = PortConnectName;
            //If the number of COM ports is different than the last time we
            //  checked, then we know that the COM ports have changed and we
            //  don't need to verify each entry.
            // if (IO_Serial_lstCOMPorts.Items.Count == SerialPort.GetPortNames().Length)
            if (SP1_IO_Serial_lstCOMPorts.Items.Count == SerialPort.GetPortNames().Length)
            {
                try
                {
                    foreach (string s in SerialPort.GetPortNames())
                    {
                        if (SP1_IO_Serial_lstCOMPorts.Items[i++].Equals(s) == false)
                        {
                            foundDifference = true;

                        }
                    }
                }
                catch { }
            }
            else foundDifference = true;
            if (foundDifference == false) return;
            //If something has changed, then clear the list
            SP1_IO_Serial_lstCOMPorts.Items.Clear();
            String PortPosition = "not found";
            //Add all of the current COM ports to the list
            foreach (string s in SerialPort.GetPortNames())
            {
                SP1_IO_Serial_lstCOMPorts.Items.Add(s);
                if (s == SP1.PortConnectName) PortPosition = SP1.PortConnectName;
                //    SP1_IO_Serial_lstCOMPorts.SelectedIndex = 0;  // 25.04.2014
            }
            if (PortPosition == "not found")
            {

                SP1_DisConnect_Procedure();
            }
            SP1_textBox_PortName.Text = PortPosition;
            //Set the listbox to point to the first entry in the list
            //    SP1_IO_Serial_lstCOMPorts.SelectedIndex = 0;  // 25.04.2014
        }
        /*              ******************  serial port1 ***********************************************************/
        void SP1_CalculateRcvData()
        {

            //      DAQ.EncPulse_InspectedMax = (Int32)((SP1.ReceiveBuf[0] << SP1.SHIFT24) + (SP1.ReceiveBuf[1] << SP1.SHIFT16) + (SP1.ReceiveBuf[2] << SP1.SHIFT8) + SP1.ReceiveBuf[3]);
            //     DAQ.EncPulse_Current = (Int32)((SP1.ReceiveBuf[4] << SP1.SHIFT24) + (SP1.ReceiveBuf[5] << SP1.SHIFT16) + (SP1.ReceiveBuf[6] << SP1.SHIFT8) + SP1.ReceiveBuf[7]);
            //    Speed_PID = (Int16)((SP1.ReceiveBuf[8] << SP1.SHIFT8) + SP1.ReceiveBuf[9]);
            //     Final_PID = (Int16)((SP1.ReceiveBuf[10] << SP1.SHIFT8) + SP1.ReceiveBuf[11]);
            //      DAQ.PID = (UInt16)Final_PID;
            /*

            ProfilePulse_Mode = SP1.ReceiveBuf[12];
            MainMode = SP1.ReceiveBuf[13];

            EncPulse_DoorLength = (Int16)((SP1.ReceiveBuf[14] << SP1.SHIFT8) + SP1.ReceiveBuf[15]);

            SpeedAverage_S_Profile = (UInt16)((SP1.ReceiveBuf[16] << SP1.SHIFT8) + SP1.ReceiveBuf[17]);
            Speed_Target = (UInt16)((SP1.ReceiveBuf[18] << SP1.SHIFT8) + SP1.ReceiveBuf[19]);
            ProfilePulse_Command = SP1.ReceiveBuf[20];
            Speed_Actual = (UInt16)((SP1.ReceiveBuf[21] << SP1.SHIFT8) + SP1.ReceiveBuf[22]);
            ProfilePulse_Direction = SP1.ReceiveBuf[23];
            */

            /*
            DAQ.Current_Setlevel = (UInt16)((SP1.ReceiveBuf[24] << SP1.SHIFT8) + SP1.ReceiveBuf[25]);
            DAQ.Current_Sampled = (UInt16)((SP1.ReceiveBuf[26] << SP1.SHIFT8) + SP1.ReceiveBuf[27]);

            DAQ.Error = (Int16)((SP1.ReceiveBuf[28] << SP1.SHIFT8) + SP1.ReceiveBuf[29]);
   //         MLDC.CurrentError = (Int16)((SP1.ReceiveBuf[30] << SP1.SHIFT8) + SP1.ReceiveBuf[31]);
            DAQ.PID_HIGHLIMT = (UInt16)((SP1.ReceiveBuf[30] << SP1.SHIFT8) + SP1.ReceiveBuf[31]);
            DAQ.PID_LOWLIMT = (UInt16)((SP1.ReceiveBuf[32] << SP1.SHIFT8) + SP1.ReceiveBuf[33]);
        //    UInt16 temp = 500;
            DAQ.Current_Diff = (Int32)(DAQ.Current_Sampled - 524);
            DAQ.Current_Set = (Int32)(DAQ.Current_Setlevel - 524);
            */
            UInt16 MaxLength = (UInt16)(SP1.Length - (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));
            SP1.CRC_Received = (UInt16)((SP1.ReceiveBuf[(MaxLength - 2)] << SP1.SHIFT8) + SP1.ReceiveBuf[MaxLength - 1]);
            //      SP1.CRC_Received = (UInt16)((SP1.ReceiveBuf[34] << SP1.SHIFT8) + SP1.ReceiveBuf[35]);




            SP1.CRC_Calc = SP1.DEFAULT_CRC_INIT;
            /*
                        for (int i = 0; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)  //  data crc
                        {
                            SP1.CRC_Calc ^= SP1.Buffer[i];
                        }
            */
            for (int i = SP1.PREAMBLE_BYTES; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.Buffer[i];
            }


            for (int i = 0; i < (MaxLength - SP1.CRC_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.ReceiveBuf[i];
            }

            if (SP1.CRC_Calc != SP1.CRC_Received)
            {
                SP1.CRC_Error++;
            }
            else
            {
                SP1.CRC_Success++;

                //       DAQ.Speed = (UInt16)((SP1.ReceiveBuf[4] << SP1.SHIFT8) + SP1.ReceiveBuf[5]);
          //      DAQ.Speed = SP1.ReceiveBuf[0] ;
          //      DAQ.Speed *= 256;
          //      DAQ.Speed += (UInt16)SP1.ReceiveBuf[1];

                DAQ.Speed = (UInt16)((SP1.ReceiveBuf[0] << SP1.SHIFT8) + SP1.ReceiveBuf[1]);
                DAQ.Current = (UInt16)((SP1.ReceiveBuf[2] << SP1.SHIFT8) + SP1.ReceiveBuf[3]);
                DAQ.Voltage = (UInt16)((SP1.ReceiveBuf[4] << SP1.SHIFT8) + SP1.ReceiveBuf[5]);
                DAQ.Power = (UInt16)((SP1.ReceiveBuf[6] << SP1.SHIFT8) + SP1.ReceiveBuf[7]);
                DAQ.Temperature = (Int16)((SP1.ReceiveBuf[8] << SP1.SHIFT8) + SP1.ReceiveBuf[9]);

                // correct datas
                Array_Fill();
                Plot_Chart();
                //Simulate();
            }
        }
        void Array_Fill()
        {
            if (DAQ.Index < DAQ.MAX_ARRAY_SIZE)
            {
               DAQ.Offset = DAQ.Index;
                DAQ.Index_Arr[DAQ.Index] = DAQ.Index.ToString();
                DAQ.Speed_Arr[DAQ.Index] = DAQ.Speed.ToString();
                DAQ.Current_Arr[DAQ.Index] = DAQ.Current.ToString();
                DAQ.Voltage_Arr[DAQ.Index] = DAQ.Voltage.ToString();
                DAQ.Power_Arr[DAQ.Index] = DAQ.Power.ToString();
                DAQ.Temperature_Arr[DAQ.Index] = DAQ.Temperature.ToString();
            }
            else
            {
                for (int t = 0; t < DAQ.MAX_ARRAY; t++)
                {
                    DAQ.Index_Arr[t] = DAQ.Index_Arr[t + 1];
                    DAQ.Speed_Arr[t] = DAQ.Speed_Arr[t + 1];
                    DAQ.Current_Arr[t] = DAQ.Current_Arr[t + 1];
                    DAQ.Voltage_Arr[t] = DAQ.Voltage_Arr[t + 1];
                    DAQ.Power_Arr[t] = DAQ.Power_Arr[t + 1];
                    DAQ.Temperature_Arr[t] = DAQ.Temperature_Arr[t + 1];
                }
                DAQ.Offset = DAQ.MAX_ARRAY;

                DAQ.Index_Arr[DAQ.MAX_ARRAY] = DAQ.Index.ToString();
                
                DAQ.Speed_Arr[DAQ.MAX_ARRAY] = DAQ.Speed.ToString();
                DAQ.Current_Arr[DAQ.MAX_ARRAY] = DAQ.Current.ToString();
                DAQ.Voltage_Arr[DAQ.MAX_ARRAY] = DAQ.Voltage.ToString();
                DAQ.Power_Arr[DAQ.MAX_ARRAY] = DAQ.Power.ToString();
                DAQ.Temperature_Arr[DAQ.MAX_ARRAY] = DAQ.Temperature.ToString();


            }



            DAQ.Index++;

            

               
            /*
            if (ProfilePulse_Mode == ProfilePulse_Mode_Prev) MaxPointProfileOpen = "0";
                else MaxPointProfileOpen = (SpeedAverage_S_Profile / 10).ToString();
                ProfilePulse_Mode_Prev = ProfilePulse_Mode;
                DAQ.ProfileArr[DAQ.Index] = MaxPointProfileOpen;
            }
            */
            //   DAQ.Index_Previous = DAQ.Index;

        }




            void Plot_Chart()
            {
                NPlot.Grid grid = new NPlot.Grid();
                plotSurface2D1.Clear();
                grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
                grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
                grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);
                grid.MinorGridPen = new Pen(Color.LightGray, 1.0f);
                plotSurface2D1.Add(grid);
                // plotSurface2D1.Clear();
                NPlot.LinePlot Graph1 = new NPlot.LinePlot();
                NPlot.LinePlot Graph2 = new NPlot.LinePlot();
                NPlot.LinePlot Graph3 = new NPlot.LinePlot();
                NPlot.LinePlot Graph4 = new NPlot.LinePlot();
                NPlot.LinePlot Graph5 = new NPlot.LinePlot();
                NPlot.LinePlot Graph6 = new NPlot.LinePlot();

                Graph1.Pen = new Pen(Color.Red, 1);
                Graph2.Pen = new Pen(Color.Blue, 2);
                Graph3.Pen = new Pen(Color.Green, 1);
                Graph4.Pen = new Pen(Color.Purple, 1);   // 
                Graph5.Pen = new Pen(Color.Gold, 1);   // 
                Graph6.Pen = new Pen(Color.White, 1);   // 


                List<String> Data1 = new List<String>();
                List<String> Data2 = new List<String>();
                List<String> Data3 = new List<String>();
                List<String> Data4 = new List<String>();
                List<String> Data5 = new List<String>(); // 
                List<String> Data6 = new List<String>(); // 

            List<String> X_Data = new List<String>();
                List<String> Y_Profile = new List<String>();
                List<String> X_Profile = new List<String>();

                float FloatNum;

                for (int t = 0; t < DAQ.Offset; t++)
                {
                 Single.TryParse(DAQ.Index_Arr[t], out FloatNum); X_Data.Add(FloatNum.ToString());
          

                    Single.TryParse(DAQ.Speed_Arr[t], out FloatNum); Data1.Add(FloatNum.ToString());
                    Single.TryParse(DAQ.Current_Arr[t], out FloatNum); Data2.Add(FloatNum.ToString());
                    Single.TryParse(DAQ.Voltage_Arr[t], out FloatNum); Data3.Add(FloatNum.ToString());
                    Single.TryParse(DAQ.Power_Arr[t], out FloatNum); Data4.Add(FloatNum.ToString()); // akim
                    Single.TryParse(DAQ.Temperature_Arr[t], out FloatNum); Data5.Add(FloatNum.ToString()); // akim se

                //   Single.TryParse(DAQ.Temperature_Arr[t], out FloatNum); Data6.Add(FloatNum.ToString()); // aki
                
               // if(t%2 == 0)Data6.Add(100.ToString());
                //else 
                    Data6.Add(0.ToString());
            }

                NPlot.PointPlot GraphProfileMode = new NPlot.PointPlot();
          
            //     GraphProfileMode.Pen = new Pen(Color.Black, 1);   // pid     
            GraphProfileMode.DataSource = Y_Profile;
                GraphProfileMode.AbscissaData = X_Profile;


                Graph1.AbscissaData = X_Data;
                Graph1.DataSource = Data1;
                Graph2.AbscissaData = X_Data;
                Graph2.DataSource = Data2;
                Graph3.AbscissaData = X_Data;
                Graph3.DataSource = Data3;
                Graph4.AbscissaData = X_Data;
                Graph4.DataSource = Data4;
                Graph5.AbscissaData = X_Data;
                Graph5.DataSource = Data5;
                Graph6.AbscissaData = X_Data;
                Graph6.DataSource = Data6;


            //        Scale Max Max Inspected Pulse
            NPlot.LinePlot GraphMaxEncoderPulse = new NPlot.LinePlot();
                GraphMaxEncoderPulse.Pen = new Pen(Color.Black, 0);
                ArrayList YMaxScale = new ArrayList();
                GraphMaxEncoderPulse.DataSource = YMaxScale;
                ArrayList XMaxScale = new ArrayList();
          //      int k;
                for (int i = 0; i < 2; i++)
                {
                    //      k = 10000; // max encoder pulse
                   // k = DAQ.EncPulse_InspectedMax; // max encoder pulse
                  //  YMaxScale.Add(i * 50).ToString();
                   // XMaxScale.Add(k).ToString();
                }
                GraphMaxEncoderPulse.AbscissaData = XMaxScale;

                NPlot.LinePlot GraphMinEncoderPulse = new NPlot.LinePlot();
                GraphMinEncoderPulse.Pen = new Pen(Color.Black, 0);
                ArrayList YMinScale = new ArrayList();
                GraphMinEncoderPulse.DataSource = YMinScale;
                ArrayList XMinScale = new ArrayList();
                YMinScale.Add(80).ToString();
                XMinScale.Add(0).ToString();
                GraphMinEncoderPulse.AbscissaData = XMinScale;

            /*
            plotSurface2D1.Add(Graph1);
     //       plotSurface2D1.Add(Graph2);
            plotSurface2D1.Add(Graph3);
            plotSurface2D1.Add(Graph4);
            plotSurface2D1.Add(Graph5);
                */

            //        Scale Max Max Inspected Pulse
            plotSurface2D1.Add(Graph6);
            if (checkBox_Speed.Checked == true) plotSurface2D1.Add(Graph1);
                if (checkBox_Current.Checked == true) plotSurface2D1.Add(Graph2);
                if (checkBox_Voltage.Checked == true) plotSurface2D1.Add(Graph3);
                if (checkBox_Power.Checked == true) plotSurface2D1.Add(Graph4);
                if (checkBox_Temperature.Checked == true) plotSurface2D1.Add(Graph5);


            /*
                            plotSurface2D1.Add(GraphMaxEncoderPulse);
                            plotSurface2D1.Add(GraphMinEncoderPulse);
                            plotSurface2D1.Add(GraphProfileMode);

            */
            plotSurface2D1.ShowCoordinates = true;
                plotSurface2D1.YAxis1.Label = "";
                plotSurface2D1.YAxis1.LabelOffsetAbsolute = true;
                plotSurface2D1.YAxis1.LabelOffset = 0;
                plotSurface2D1.YAxis1.HideTickText = false;

                plotSurface2D1.XAxis1.Label = " Test Variables ";
                plotSurface2D1.Padding = 5;
                plotSurface2D1.AutoScaleTitle = true;
                //  plotSurface2D1.BackColor = 
                plotSurface2D1.Refresh();


            }

        
            void Plot_Chart_Close()
            {
            /*
                NPlot.Grid grid = new NPlot.Grid();
                plotSurface2D2.Clear();
                grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
                grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
                grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);
                grid.MinorGridPen = new Pen(Color.LightGray, 1.0f);
                plotSurface2D2.Add(grid);
                NPlot.LinePlot Graph1 = new NPlot.LinePlot();
                NPlot.LinePlot Graph2 = new NPlot.LinePlot();
                NPlot.LinePlot Graph3 = new NPlot.LinePlot();
                NPlot.LinePlot Graph4 = new NPlot.LinePlot();
                NPlot.LinePlot Graph5 = new NPlot.LinePlot();

                Graph1.Pen = new Pen(Color.Blue, 1);
                Graph2.Pen = new Pen(Color.Black, 2);
                Graph3.Pen = new Pen(Color.Red, 1);
                Graph4.Pen = new Pen(Color.Green, 1);   // akim
                Graph5.Pen = new Pen(Color.OliveDrab, 1);   // akim


                List<String> Y_Profile = new List<String>();
                List<String> Data1 = new List<String>();
                List<String> Data2 = new List<String>();
                List<String> Data3 = new List<String>();
                List<String> Data4 = new List<String>(); // akim 
                List<String> Data5 = new List<String>(); // akimset
                List<String> X_Data = new List<String>();
                List<String> X_Profile = new List<String>();

                float FloatNum;
                int t = 0;

                //   for (int t = 0; t < DAQ.EncPulseSample_Close; t++)
                //  {
                Single.TryParse(DAQ.Speed_Arr[t], out FloatNum); Data1.Add(FloatNum.ToString());
                Single.TryParse(DAQ.Voltage_Arr[t], out FloatNum); Data2.Add(FloatNum.ToString());
                Single.TryParse(DAQ.Current_Arr[t], out FloatNum); Data3.Add(FloatNum.ToString()); // akim set

                Single.TryParse(DAQ.Power_Arr[t], out FloatNum); Data4.Add(FloatNum.ToString()); // akim
                Single.TryParse(DAQ.Temperature_Arr[t], out FloatNum); Data5.Add(FloatNum.ToString());

                Single.TryParse(DAQ.Encoder_Arr[t], out FloatNum); X_Data.Add(FloatNum.ToString());



                //        MaxPointProfile;
                //        string str = MaxPointProfile;
                //    if (DAQ.ProfileArr[t] != "0")
                //   {
                //      Single.TryParse(DAQ.ProfileArr[t], out  FloatNum); Y_Profile.Add(FloatNum.ToString());
                //      Single.TryParse(DAQ.EncoderPulseArr[t], out  FloatNum); X_Profile.Add(FloatNum.ToString());
                //   }

                //       Single.TryParse(MLDC.CurrentErrorArr[t], out  FloatNum); Data8.Add(FloatNum.ToString()); // error set
                //        CurrentSampled
                //


                //    NPlot.LinePlot GraphProfileMode = new NPlot.LinePlot();
                NPlot.PointPlot GraphProfileMode = new NPlot.PointPlot();
                //     GraphProfileMode.Pen = new Pen(Color.Black, 0);   // pid
                //        List<String> YProfileModeScale = new List<String>(); // 



                //      ArrayList YProfileModeScale = new ArrayList();
                //      ArrayList XProfileModeScale = new ArrayList();

                //    int gh;
 

                GraphProfileMode.DataSource = Y_Profile;
                GraphProfileMode.AbscissaData = X_Profile;
              

                Graph1.AbscissaData = X_Data;
                Graph1.DataSource = Data1;
                Graph2.AbscissaData = X_Data;
                Graph2.DataSource = Data2;
                Graph3.AbscissaData = X_Data;
                Graph3.DataSource = Data3;
                Graph4.AbscissaData = X_Data;
                Graph4.DataSource = Data4;
                Graph5.AbscissaData = X_Data;
                Graph5.DataSource = Data5;


                //        Scale Max Max Inspected Pulse
                NPlot.LinePlot GraphMaxEncoderPulse = new NPlot.LinePlot();
                GraphMaxEncoderPulse.Pen = new Pen(Color.Black, 0);
                ArrayList YMaxScale = new ArrayList();
                GraphMaxEncoderPulse.DataSource = YMaxScale;
                ArrayList XMaxScale = new ArrayList();

              //  int k;
                for (int i = 0; i < 2; i++)
                {
                    //      k = 10000; // max encoder pulse
                    // k = DAQ.EncPulse_InspectedMax; // max encoder pulse
                    YMaxScale.Add(i * 50).ToString();
                 //   XMaxScale.Add(k).ToString();
                }
                GraphMaxEncoderPulse.AbscissaData = XMaxScale;



                NPlot.LinePlot GraphMinEncoderPulse = new NPlot.LinePlot();
                GraphMinEncoderPulse.Pen = new Pen(Color.Black, 0);
                ArrayList YMinScale = new ArrayList();
                GraphMinEncoderPulse.DataSource = YMinScale;
                ArrayList XMinScale = new ArrayList();
                YMinScale.Add(80).ToString();
                XMinScale.Add(0).ToString();
                GraphMinEncoderPulse.AbscissaData = XMinScale;




                //          plotSurface2D2.Add(Graph2);

                if (checkBox_Speed.Checked == true) plotSurface2D2.Add(Graph1);
                if (checkBox_Current.Checked == true) plotSurface2D2.Add(Graph2);

                if (checkBox_Voltage.Checked == true) plotSurface2D2.Add(Graph2);
                if (checkBox_Power.Checked == true) plotSurface2D2.Add(Graph4);
                if (checkBox_Temperature.Checked == true) plotSurface2D2.Add(Graph5);

                //       if (checkBox_Cl_CurErr.Checked == true) plotSurface2D2.Add(Graph8);   
                //       if (checkBox_Cl_HighLimit.Checked == true) plotSurface2D2.Add(Graph8);
                //         if (checkBox_Cl_LowLimit.Checked == true) plotSurface2D2.Add(Graph9);

             //  plotSurface2D2.Add(GraphMinEncoderPulse);
             //   plotSurface2D2.Add(GraphMaxEncoderPulse);

                plotSurface2D2.Add(GraphProfileMode);
                //        Scale Max Max Inspected Pulse

                plotSurface2D2.ShowCoordinates = true;
                plotSurface2D2.YAxis1.Label = "";
                plotSurface2D2.YAxis1.LabelOffsetAbsolute = true;
                plotSurface2D2.YAxis1.LabelOffset = 0;
                plotSurface2D2.YAxis1.HideTickText = false;

                plotSurface2D2.XAxis1.Label = "Encoder Pulse (Kapama Profili) -->> ";
                plotSurface2D2.Padding = 5;
                plotSurface2D2.AutoScaleTitle = true;
                //  plotSurface2D1.BackColor = 
                plotSurface2D2.Refresh();
            */
            }

            void SP1_Connect_Procedure()
            {
                try
                {
                    //Get the port name from the application list box.
                    //  the PortName attribute is a string name of the COM
                    //  port (e.g. - "COM1").
                    SP1_serialPort.PortName = SP1_IO_Serial_lstCOMPorts.Items[SP1_IO_Serial_lstCOMPorts.SelectedIndex].ToString();
                    SP1.PortConnectName = SP1_serialPort.PortName;
                    SP1_textBox_PortName.Text = SP1.PortConnectName;
                //Open the COM port.


                //SP1_serialPort.BaudRate = 9600;
                //SP1_serialPort.BaudRate = 38400;
                SP1_serialPort.BaudRate = 115200;
                SP1_serialPort.Parity = Parity.None;
                SP1_serialPort.StopBits = StopBits.One;
                SP1_serialPort.DataBits = 8;
                SP1_serialPort.Handshake = Handshake.None;
                SP1_serialPort.RtsEnable = true;
                SP1_serialPort.Open();

                    //Change the state of the application objects
                    //   btnConnect.Enabled = false;
                    SP1_ConnectButton.Enabled = false;
                    SP1_IO_Serial_lstCOMPorts.Enabled = false;
                    //   btnClose.Enabled = true;
                    SP1_DisConnectButton.Enabled = true;
                    //            textBox1.Clear(); 
                    //            textBox1.AppendText("Connected.\r\n");

                }
                catch
                {
                    //If there was an exception, then close the handle to 
                    //  the device and assume that the device was removed
                    //  button_Close_Click(this, null);

                    SP1_DisConnect_Procedure();
                    SP1.PortConnectName = "NoConnection";
                }

            }

            void SP1_DisConnect_Procedure()
            {
                //Reset the state of the application objects
                SP1.PortConnectName = "NoConnection";
                SP1_textBox_PortName.Text = SP1.PortConnectName;
                SP1_DisConnectButton.Enabled = false;
                SP1_ConnectButton.Enabled = true;
                SP1_IO_Serial_lstCOMPorts.Enabled = true;

                //This section of code will try to close the COM port.
                //  Please note that it is important to use a try/catch
                //  statement when closing the COM port.  If a USB virtual
                //  COM port is removed and the PC software tries to close
                //  the COM port before it detects its removal then
                //  an exeception is thrown.  If the execption is not in a
                //  try/catch statement this could result in the application
                //  crashing.
                try
                {
                    //Dispose the In and Out buffers;
                    SP1_serialPort.DiscardInBuffer();
                    SP1_serialPort.DiscardOutBuffer();

                    //Close the COM port
                    SP1_serialPort.Close();
                }
                //If there was an exeception then there isn't much we can
                //  do.  The port is no longer available.
                catch { }
            }

            void SP1_ReceiveData_Procedure()
            {
                try
                {
                
                    if (SP1.ReadSequence == 0)
                    {
                        if (SP1_serialPort.BytesToRead >= (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES)) // READ PREAMBLE AND LENGTH BYTES
                        {
                            SP1_serialPort.Read(SP1.Buffer, 0, (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));

                            SP1.Preamble = (UInt16)((SP1.Buffer[0] << SP1.SHIFT8) + SP1.Buffer[1]);
                            SP1.Length = (UInt16)((SP1.Buffer[2] << SP1.SHIFT8) + SP1.Buffer[3]);

        

                        if (SP1.Preamble == SP1.DEFAULT_PREAMBLE) // CHECK IF PREAMLE IS EQUAL TO THE DEFAULT ONE
                            {
                                SP1.ReadSequence = 1; // PREAMBLE MATCHES WITH THE DEFAULT ONE
                            }
                            else
                            {
                                SP1.ReadSequence = 0;   // PREAMBLE MATCH FAIL
                                SP1.Length = (UInt16)(SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); // default
                                                                                                  //        SP1_serialPort.ReadExisting();
                            }
                        }
                    }
                    if (SP1.ReadSequence == 1) // IF MATCH SUCCESFULL GO ON READING THE REMAINING
                    {
                        if (SP1_serialPort.BytesToRead >= SP1.Length - (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES)) // READ REMAINING CRC AND DATA BYTES IF ALL AT BUFFER
                        {
                            SP1_serialPort.Read(SP1.ReceiveBuf, 0, (int)SP1.Length - (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));  // READ REMAINING CRC AND DATA BYTES
                            SP1.ReadSequence = 2;
                            SP1_CalculateRcvData();
                            SP1.ReadSequence = 0;
                        }
                    }
                    
                /*
                SP1_serialPort.Read(SP1.Buffer, 0, (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));
                SP1.Preamble = (UInt16)((SP1.Buffer[0] << SP1.SHIFT8) + SP1.Buffer[1]);
                //SP1.Preamble = SP1.Buffer[0];
                SP1.Length = (UInt16)((SP1.Buffer[2] << SP1.SHIFT8) + SP1.Buffer[3]);
                */

            }
                catch
                {
                    SP1_DisConnect_Procedure();
                    //       TxtData = "hata";
                    //;  TrigDisp = 1;
                    SP1.ReadSequence = 0;
                }
            }

            void SP1_SendData_Procedure()
            {
                try
                {
                    //               SP1_CalculateSendData();
                    //             SP1_serialPort.Write(SP1_SendBuf, 0, (int)SP1.DEFAULT_LENGTH);
                    //             SP1_SendtextBox.Text = SP1_SendTextData();
                    //             SP1_DataRcvtextBox.Text = SP1_PrintSendText();


                }
                catch
                {
                    SP1_DisConnect_Procedure();
                }
            }

            String SP1_GetTextdata2()
            {

                String Textdata = "";
                try
                {
                    for (int i = 0; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)
                    {
                        //  Textdata += i.ToString() + " : " + SP1_Buffer[i].ToString() + " / 0 X" + SP1_Buffer[i].ToString("X") + System.Environment.NewLine;
                        Textdata += i.ToString() + "." + SP1.Buffer[i].ToString() + "  ";
                    }
                    Textdata += System.Environment.NewLine;
                    int k = 0; int j = 0;
                    for (int i = (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i < SP1.Length; i++)
                    {

                        // Textdata += i.ToString() + " : " + SP1_ReceiveBuf[k].ToString() +  " / 0 X"+SP1_ReceiveBuf[k].ToString("X") + System.Environment.NewLine;
                        Textdata += i.ToString() + "." + SP1.ReceiveBuf[k].ToString() + "  ";
                        k++;
                        j++;
                        if (j > 4)
                        {
                            Textdata += System.Environment.NewLine;
                            j = 0;
                        }
                    }

                }
                catch { }
                return Textdata;
            }
            String SP1_GetTextdata()
            {
                //String Textdata = "";

            String Textdata = "Received Data " + System.Environment.NewLine;
                Textdata += "Preamble :" + " 0 X" + SP1.Preamble.ToString("X") + System.Environment.NewLine;
                Textdata += "DataLength : " + SP1.Length.ToString() + System.Environment.NewLine;
                Textdata += "CRC_Received " + SP1.CRC_Received.ToString() + " / 0 X" + SP1.CRC_Received.ToString("X") + System.Environment.NewLine;
                Textdata += "CRC_Calc " + SP1.CRC_Calc.ToString() + " / 0 X" + SP1.CRC_Calc.ToString("X") + System.Environment.NewLine;
                Textdata += "CRC_Error " + SP1.CRC_Error.ToString() + " / 0 X" + SP1.CRC_Error.ToString("X") + System.Environment.NewLine;

            if (SP1.CRC_Success != 0)
            {
                Textdata += "Error Rate : % " + (SP1.CRC_Error  / SP1.CRC_Success).ToString();
            }
                else Textdata += "Error Rate : % 0";

                    Textdata += System.Environment.NewLine + System.Environment.NewLine;


                Textdata += "Speed : " + DAQ.Speed.ToString() + " rpm " + System.Environment.NewLine;
                Textdata += "Current " + DAQ.Current.ToString() + " Amper" + System.Environment.NewLine;
                Textdata += "Voltage " + DAQ.Voltage.ToString() + " Volt" +  System.Environment.NewLine;
                Textdata += "Power : " + DAQ.Power.ToString() + " Watt" + System.Environment.NewLine;
                Textdata += "Temperature : " + DAQ.Temperature.ToString() + " C" + System.Environment.NewLine;
               
                //    Textdata += " Hiz Error : " + DAQ.Error.ToString()  + System.Environment.NewLine;



                //   Textdata += " Akim Farki : " + DAQ.Current_Diff.ToString() + " adc" + System.Environment.NewLine;
                //   Textdata += "Aktif Set Max. Akim : " + DAQ.Current_Setlevel.ToString() + " adc" + System.Environment.NewLine;
                //   Textdata += "Olculen Akim :" + DAQ.Current_Sampled.ToString() + " adc" + System.Environment.NewLine + System.Environment.NewLine;
                /*
                String str = "OPEN";

                if (ProfilePulse_Command == Definition.OPEN) str = "Acma";
                if (ProfilePulse_Command == Definition.CLOSE) str = "Kapama";
                if (ProfilePulse_Command == Definition.STOP) str = " Yok ";
                Textdata += "Aktif Komut :" + str + System.Environment.NewLine;

                if (ProfilePulse_Direction == Definition.OPEN) str = "Acmada";
                if (ProfilePulse_Direction == Definition.CLOSE) str = "Kapamada";
                if (ProfilePulse_Direction == Definition.STOP) str = "Duruyor";
                Textdata += "Calisma Yonu  : " + str + System.Environment.NewLine;

                if (MainMode == Definition.ZERO_POINT_LOCATE_1) str = "ACMADA SIFIR POZ. BULMA";
                if (MainMode == Definition.ZERO_POINT_LOCATE_2) str = "KAPAMADA SIFIR POZ. BULMA";
                if (MainMode == Definition.OPERATE) str = "NORMAL CALISMA";
                if (MainMode == Definition.MANUEL) str = "MANUEL";
                if (MainMode == Definition.REVISION) str = "REVIZYON";
                if (MainMode == Definition.PROG_USER) str = "REVIZYON_KULLANICI";
                if (MainMode == Definition.PROG_MAN) str = "REVIZYON_FABRIKA";
                if (MainMode == Definition.FAULTMODE_01) str = "FAULTMODE_01";
                if (MainMode == Definition.FAULTMODE_02) str = "FAULTMODE_02";

                Textdata += "Calisma Modu :" + str + System.Environment.NewLine;
                //  String str="OPEN";

                if (ProfilePulse_Mode == Definition.ZONE_UNKNOWN) str = "Bilinmiyor";
                if (ProfilePulse_Mode == Definition.ZONE_AC_LIMIT_ASIMI) str = "Acmada Limitte";
                if (ProfilePulse_Mode == Definition.ZONE_KASIKAC) str = "Kasik Acma";
                if (ProfilePulse_Mode == Definition.ZONE_P03_1) str = "P03_1";
                if (ProfilePulse_Mode == Definition.ZONE_P03_2) str = "P03_2";
                if (ProfilePulse_Mode == Definition.ZONE_POPEN) str = "Acma Max Hiz";
                if (ProfilePulse_Mode == Definition.ZONE_P04_1) str = "P04_1";
                if (ProfilePulse_Mode == Definition.ZONE_P04_2) str = "P04_2";
                if (ProfilePulse_Mode == Definition.ZONE_P05) str = "P05";
                if (ProfilePulse_Mode == Definition.ZONE_KASIKKAPA) str = "Kasik Kapama";
                if (ProfilePulse_Mode == Definition.ZONE_P11) str = "P11";
                if (ProfilePulse_Mode == Definition.ZONE_P10_1) str = "P10_1";
                if (ProfilePulse_Mode == Definition.ZONE_P10_2) str = "P10_2";
                if (ProfilePulse_Mode == Definition.ZONE_PCLOSE) str = "Kapama max Hiz";
                if (ProfilePulse_Mode == Definition.ZONE_P09_1) str = "P09_1";
                if (ProfilePulse_Mode == Definition.ZONE_P09_2) str = "P09_2";
                if (ProfilePulse_Mode == Definition.ZONE_KAPA_LIMIT_ASIMI) str = "Kapamada  Limitte";
                Textdata += "Aktif Bolge :" + str + System.Environment.NewLine;
            */
                return Textdata;
            }
             void SP1_serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
            {
                SP1_ReceiveData_Procedure();
            }

            void SP1_ConnectButton_Click(object sender, EventArgs e)
            {
                SP1_Connect_Procedure();
            }

            void SP1_SendButton_Click(object sender, EventArgs e)
            {
                SP1_SendData_Procedure();
            }

            void button1_Click(object sender, EventArgs e)
            {
                SP1_richTextBox.Clear();
                SP1_DatatextBox.Clear();
                SP1.CRC_Error = 0;
            }

            void SP1_DisConnectButton_Click(object sender, EventArgs e)
            {
                SP1_DisConnect_Procedure();
            }

            void Base_Timer1mSec_Tick(object sender, EventArgs e)
            {

            //    if (ProfilePulse_Direction == Definition.OPEN) if (ProfilePulse_Command == Definition.OPEN) 
             //   if (ProfilePulse_Direction == Definition.CLOSE) if (ProfilePulse_Command == Definition.CLOSE) Plot_Chart_Close();

         //   Plot_Chart_Open();

            Timer_1sec++;
                if (Timer_1sec > 8)
                {
                    Timer_1sec = 0;
                    //      Update_Chart = 1;
                    //       Plot_Chart();
                    //         textBox_DateTime.Text = LOG_GetDateTime();
                    SP1_richTextBox.Text = SP1_GetTextdata();
                    SP1_DatatextBox.Text = SP1_GetTextdata2();

                    SP1_SendtextBox.Text = DAQ.Index.ToString();
                    //   Simulate();

                }


                try
                {
                    if (SP1_serialPort.BytesToRead != 0)
                    {
                        SP1.ComTimeout++;

                    }
                    else SP1.ComTimeout = 0;
                    if (SP1.ComTimeout > 2)
                    {
                        // clear buffer
                        SP1_serialPort.ReadExisting();
                        SP1.ErrorCount++;
                    }
                }
                catch { }
                //BaseCounter++;
               // BaseCounter = 0;
                //   if (TrigDisp == 1){
                if (SP1.ReadSequence == 2)
                {
                    //        SP1.ReadSequence = 0;

                    //          SP1_CalculateRcvData();

                }
                try
                {
                    SP1_IO_Serial_UpdateCOMPortList();
                    //      SP2_IO_Serial_UpdateCOMPortList();
                }
                catch { }

            }
        /*
        private void checkBox_Power_CheckedChanged(object sender, EventArgs e)
        {

        }
        */
    }

    }

