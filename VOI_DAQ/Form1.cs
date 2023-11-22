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
//namespace MLDC_DataLog
namespace VOI_DAQ
{
    public partial class Form1 : Form
    {
        int BaseCounter;
        int Timer_1sec;
                
        string MaxPointProfileClose;
        string MaxPointProfileOpen;
        Int32 Speed_PID;
        Int32 Final_PID;
        UInt16 SpeedAverage_S_Profile;
        UInt16 Speed_Target;
        byte ProfilePulse_Command;
        UInt16 Speed_Actual;
        byte ProfilePulse_Direction;

        byte ProfilePulse_Mode;
        byte ProfilePulse_Mode_Prev;
        byte MainMode;
       Int16 EncPulse_DoorLength;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SP1_IO_Serial_UpdateCOMPortList();
        }
        public  void SP1_IO_Serial_UpdateCOMPortList()
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

            DAQ.EncPulse_InspectedMax = (Int32)((SP1.ReceiveBuf[0] << SP1.SHIFT24) + (SP1.ReceiveBuf[1] << SP1.SHIFT16) + (SP1.ReceiveBuf[2] << SP1.SHIFT8) + SP1.ReceiveBuf[3]);
            DAQ.EncPulse_Current = (Int32)((SP1.ReceiveBuf[4] << SP1.SHIFT24) + (SP1.ReceiveBuf[5] << SP1.SHIFT16) + (SP1.ReceiveBuf[6] << SP1.SHIFT8) + SP1.ReceiveBuf[7]);
            Speed_PID = (Int16)((SP1.ReceiveBuf[8] << SP1.SHIFT8) + SP1.ReceiveBuf[9]);
            Final_PID = (Int16)((SP1.ReceiveBuf[10] << SP1.SHIFT8) + SP1.ReceiveBuf[11]);
            DAQ.PID = (UInt16)Final_PID;
            ProfilePulse_Mode = SP1.ReceiveBuf[12];
            MainMode = SP1.ReceiveBuf[13];

            EncPulse_DoorLength = (Int16)((SP1.ReceiveBuf[14] << SP1.SHIFT8) + SP1.ReceiveBuf[15]);

            SpeedAverage_S_Profile = (UInt16)((SP1.ReceiveBuf[16] << SP1.SHIFT8) + SP1.ReceiveBuf[17]);
            Speed_Target = (UInt16)((SP1.ReceiveBuf[18] << SP1.SHIFT8) + SP1.ReceiveBuf[19]);
            ProfilePulse_Command = SP1.ReceiveBuf[20];
            Speed_Actual = (UInt16)((SP1.ReceiveBuf[21] << SP1.SHIFT8) + SP1.ReceiveBuf[22]);
            ProfilePulse_Direction = SP1.ReceiveBuf[23];
            DAQ.Current_Setlevel = (UInt16)((SP1.ReceiveBuf[24] << SP1.SHIFT8) + SP1.ReceiveBuf[25]);
            DAQ.Current_Sampled = (UInt16)((SP1.ReceiveBuf[26] << SP1.SHIFT8) + SP1.ReceiveBuf[27]);

            DAQ.Error = (Int16)((SP1.ReceiveBuf[28] << SP1.SHIFT8) + SP1.ReceiveBuf[29]);
   //         MLDC.CurrentError = (Int16)((SP1.ReceiveBuf[30] << SP1.SHIFT8) + SP1.ReceiveBuf[31]);
            DAQ.PID_HIGHLIMT = (UInt16)((SP1.ReceiveBuf[30] << SP1.SHIFT8) + SP1.ReceiveBuf[31]);
            DAQ.PID_LOWLIMT = (UInt16)((SP1.ReceiveBuf[32] << SP1.SHIFT8) + SP1.ReceiveBuf[33]);
        //    UInt16 temp = 500;
            DAQ.Current_Diff = (Int32)(DAQ.Current_Sampled - 524);
            DAQ.Current_Set = (Int32)(DAQ.Current_Setlevel - 524);

            UInt16 MaxLength = (UInt16)(SP1.Length  -  (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES));
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
                // correct datas
                Array_Fill_Open();
                Array_Fill_Close();
            }
        }
        void Array_Fill_Open(){
            if (ProfilePulse_Command == Definition.CLOSE) return;
            if (ProfilePulse_Command == Definition.STOP)  DAQ.EncPulseSample = 0;
                if (DAQ.EncPulse_Current_Previous != DAQ.EncPulse_Current)
                {       
                    DAQ.EncoderPulseArr[DAQ.EncPulseSample] = DAQ.EncPulse_Current.ToString();
                    DAQ.SpeedActual_Arr[DAQ.EncPulseSample] = Speed_Actual.ToString();
                    DAQ.SpeedTarget_Arr[DAQ.EncPulseSample] = (Speed_Target / 10).ToString();
                    DAQ.SpeedAverageSProfile_Arr[DAQ.EncPulseSample] = (SpeedAverage_S_Profile / 10).ToString();
                  DAQ.ErrorArr[DAQ.EncPulseSample] = ((DAQ.Error*1)+40).ToString();

          //        ushort t;
           //       if (ProfilePulse_Mode == ProfilePulse_Mode_Prev) t = 0;
           //       else t = 50;
         //         ProfilePulse_Mode_Prev = ProfilePulse_Mode;
         //         MLDC.ProfileArr[MLDC.EncPulseSample] = t.ToString();

       //           MLDC.CurrentErrorArr[MLDC.EncPulseSample] = (MLDC.PID_LIMT / 10).ToString();
                  DAQ.PIDHighLimitArr[DAQ.EncPulseSample] = (DAQ.PID_HIGHLIMT / 10).ToString();
                  DAQ.PIDLowLimitArr[DAQ.EncPulseSample] = (DAQ.PID_LOWLIMT / 10).ToString();

         //         MLDC.CurrentErrorArr[MLDC.EncPulseSample] = ((MLDC.CurrentError / 10) + 0).ToString();
                  DAQ.PIDArr[DAQ.EncPulseSample] = (DAQ.PID / 10).ToString();
           //       Int32 k = MLDC.Current_Diff ;
          //          if (k > 120) k = 120;
          //          MLDC.CurrentDiffArr[MLDC.EncPulseSample] = k.ToString();

                  if (DAQ.Current_Diff > DAQ.Current_Set) DAQ.CurrentDiffArr[DAQ.EncPulseSample] = DAQ.Current_Set.ToString();
                  else DAQ.CurrentDiffArr[DAQ.EncPulseSample] = DAQ.Current_Diff.ToString();

                    DAQ.CurrentSetArr[DAQ.EncPulseSample] = DAQ.Current_Set.ToString();    
                    DAQ.EncPulseSample++;

                    if (ProfilePulse_Mode == ProfilePulse_Mode_Prev) MaxPointProfileOpen = "0";
                    else MaxPointProfileOpen = (SpeedAverage_S_Profile / 10).ToString();
                    ProfilePulse_Mode_Prev = ProfilePulse_Mode;
                    DAQ.ProfileArr[DAQ.EncPulseSample] = MaxPointProfileOpen;
                }
               DAQ.EncPulse_Current_Previous = DAQ.EncPulse_Current;



    }
        void Array_Fill_Close()
        {

            if (ProfilePulse_Direction == Definition.OPEN) return;
            if (ProfilePulse_Command == Definition.STOP) DAQ.EncPulseSample_Close = 0;    
            if (DAQ.EncPulse_Current_Previous != DAQ.EncPulse_Current)
            {      
                    DAQ.EncoderPulseArr[DAQ.EncPulseSample_Close] = DAQ.EncPulse_Current.ToString();
                    DAQ.SpeedActual_Arr[DAQ.EncPulseSample_Close] = Speed_Actual.ToString();
                    DAQ.SpeedTarget_Arr[DAQ.EncPulseSample_Close] = (Speed_Target / 10).ToString();
                    DAQ.SpeedAverageSProfile_Arr[DAQ.EncPulseSample_Close] = (SpeedAverage_S_Profile / 10).ToString();
                   DAQ.ErrorArr[DAQ.EncPulseSample_Close] = ((DAQ.Error*1)+40).ToString();
              //     MLDC.CurrentErrorArr[MLDC.EncPulseSample_Close] = (MLDC.PID_LIMT / 10).ToString();
                   DAQ.PIDHighLimitArr[DAQ.EncPulseSample_Close] = (DAQ.PID_HIGHLIMT / 10).ToString();
                   DAQ.PIDLowLimitArr[DAQ.EncPulseSample_Close] = (DAQ.PID_LOWLIMT / 10).ToString();


           //        MLDC.CurrentErrorArr[MLDC.EncPulseSample_Close] = ((MLDC.CurrentError / 10) + 0).ToString();
                   DAQ.PIDArr[DAQ.EncPulseSample_Close] = (DAQ.PID / 10).ToString();
           //         Int32 k = MLDC.Current_Diff;
             //       if (k > 120) k = 120;
                //    MLDC.CurrentDiffArr[MLDC.EncPulseSample_Close] = k.ToString();
                    if (DAQ.Current_Diff > DAQ.Current_Set) DAQ.CurrentDiffArr[DAQ.EncPulseSample_Close] = DAQ.Current_Set.ToString();
                    else DAQ.CurrentDiffArr[DAQ.EncPulseSample_Close] = DAQ.Current_Diff.ToString();
                    DAQ.CurrentSetArr[DAQ.EncPulseSample_Close] = DAQ.Current_Set.ToString();    

        
                    DAQ.EncPulseSample_Close++;

                    if (ProfilePulse_Mode == ProfilePulse_Mode_Prev) MaxPointProfileClose = "0";
                    else MaxPointProfileClose = (SpeedAverage_S_Profile / 10).ToString();
                    ProfilePulse_Mode_Prev = ProfilePulse_Mode;
                    DAQ.ProfileArr[DAQ.EncPulseSample_Close] = MaxPointProfileClose;
               }
                DAQ.EncPulse_Current_Previous = DAQ.EncPulse_Current;
        }

        
        void Simulate()
        {
            if (DAQ.EncPulseSample > 10000) return;  // max array boyutu asilmismi
            ProfilePulse_Direction = Definition.OPEN;

            DAQ.EncPulse_Current++;
            DAQ.EncPulse_Current += 10;
            Speed_Actual += 1;
            Speed_Target += 2;
            SpeedAverage_S_Profile += 3;

            Array_Fill_Open();
        }
        void Plot_Chart_Open()
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

            Graph1.Pen = new Pen(Color.Blue, 1);
            Graph2.Pen = new Pen(Color.Black, 2);
            Graph3.Pen = new Pen(Color.Red, 1);
            Graph4.Pen = new Pen(Color.Green, 1);   // akim


            List<String> Data1 = new List<String>();
            List<String> Data2 = new List<String>();
            List<String> Data3 = new List<String>();
            List<String> Data4 = new List<String>();
            List<String> X_Data = new List<String>();
            List<String> Y_Profile = new List<String>();
            List<String> X_Profile = new List<String>();


            NPlot.LinePlot Graph5 = new NPlot.LinePlot();
            Graph5.Pen = new Pen(Color.OliveDrab, 1);   // akim
            List<String> Data5 = new List<String>(); // akimset

            NPlot.LinePlot Graph6 = new NPlot.LinePlot();
            Graph6.Pen = new Pen(Color.DarkSlateGray, 1);   // error
            List<String> Data6 = new List<String>(); // 

            NPlot.LinePlot Graph7 = new NPlot.LinePlot();
            Graph7.Pen = new Pen(Color.DarkViolet, 1);   // pid
            List<String> Data7 = new List<String>(); // 

            NPlot.LinePlot Graph8 = new NPlot.LinePlot();
            Graph8.Pen = new Pen(Color.Orange, 1);   // pid
            List<String> Data8 = new List<String>(); // 

            NPlot.LinePlot Graph9 = new NPlot.LinePlot();
            Graph9.Pen = new Pen(Color.DarkOrange, 1);   // pid
            List<String> Data9 = new List<String>(); // 

            float FloatNum;
            
           for (int t = 0; t< DAQ.EncPulseSample; t++)
            {
                Single.TryParse(DAQ.SpeedActual_Arr[t], out  FloatNum); Data1.Add(FloatNum.ToString());
                Single.TryParse(DAQ.SpeedTarget_Arr[t], out  FloatNum); Data2.Add(FloatNum.ToString());
                Single.TryParse(DAQ.SpeedAverageSProfile_Arr[t], out  FloatNum); Data3.Add(FloatNum.ToString());
                Single.TryParse(DAQ.EncoderPulseArr[t], out  FloatNum); X_Data.Add(FloatNum.ToString());
                Single.TryParse(DAQ.CurrentDiffArr[t], out  FloatNum); Data4.Add(FloatNum.ToString()); // akim
                Single.TryParse(DAQ.CurrentSetArr[t], out  FloatNum); Data5.Add(FloatNum.ToString()); // akim set
                Single.TryParse(DAQ.ErrorArr[t], out  FloatNum); Data6.Add(FloatNum.ToString()); // error set
                Single.TryParse(DAQ.PIDArr[t], out  FloatNum); Data7.Add(FloatNum.ToString()); // error set
          //      Single.TryParse(MLDC.CurrentErrorArr[t], out  FloatNum); Data8.Add(FloatNum.ToString()); // error set
         //       Single.TryParse(MLDC.ProfileArr[t], out  FloatNum); Y_Profile.Add(FloatNum.ToString());
 
                Single.TryParse(DAQ.PIDHighLimitArr[t], out  FloatNum); Data8.Add(FloatNum.ToString()); // error set
                Single.TryParse(DAQ.PIDLowLimitArr[t], out  FloatNum); Data9.Add(FloatNum.ToString()); // error set

                if (DAQ.ProfileArr[t] != "0")
                {
                    Single.TryParse(DAQ.ProfileArr[t], out  FloatNum); Y_Profile.Add(FloatNum.ToString());
                    Single.TryParse(DAQ.EncoderPulseArr[t], out  FloatNum); X_Profile.Add(FloatNum.ToString());
                }

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
            Graph7.AbscissaData = X_Data;
            Graph7.DataSource = Data7;

            Graph8.AbscissaData = X_Data;
            Graph8.DataSource = Data8;

            Graph9.AbscissaData = X_Data;
            Graph9.DataSource = Data9;
/*
            Graph2.AbscissaData = XTimes;
            Graph2.DataSource = Data2;

            Graph2.AbscissaData = XTimes;
            Graph2.DataSource = Data3;
*/
            //        Scale Max Max Inspected Pulse
            NPlot.LinePlot GraphMaxEncoderPulse = new NPlot.LinePlot();
            GraphMaxEncoderPulse.Pen = new Pen(Color.Black, 0);
            ArrayList YMaxScale = new ArrayList();
            GraphMaxEncoderPulse.DataSource = YMaxScale;
            ArrayList XMaxScale = new ArrayList();
            int k;
            for (int i = 0; i < 2; i++)
            {
                //      k = 10000; // max encoder pulse
                k = DAQ.EncPulse_InspectedMax; // max encoder pulse
                YMaxScale.Add(i * 50).ToString();
                XMaxScale.Add(k).ToString();
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

            if (checkBox_Op_ProfileSpeed.Checked == true) plotSurface2D1.Add(Graph3);
            if (checkBox_Op_ActualSpeed.Checked == true) plotSurface2D1.Add(Graph1);
            if (checkBox_Op_Current.Checked == true) plotSurface2D1.Add(Graph4);
            if (checkBox_Op_RefAkim.Checked == true) plotSurface2D1.Add(Graph5);
            if (checkBox_Op_SpeedError.Checked == true) plotSurface2D1.Add(Graph6);
            if (this.checkBox_Op_PID.Checked == true) plotSurface2D1.Add(Graph7);
     //       if (this.checkBox_Op_HighLimit.Checked == true) plotSurface2D1.Add(Graph8); 
            if (checkBox_Op_HighLimit.Checked == true) plotSurface2D1.Add(Graph8);
            if (checkBox_Op_LowLimit.Checked == true) plotSurface2D1.Add(Graph9);

            plotSurface2D1.Add(GraphMaxEncoderPulse);
            plotSurface2D1.Add(GraphMinEncoderPulse);
            plotSurface2D1.Add(GraphProfileMode);
            

            plotSurface2D1.ShowCoordinates = true;
            plotSurface2D1.YAxis1.Label = "";
            plotSurface2D1.YAxis1.LabelOffsetAbsolute = true;
            plotSurface2D1.YAxis1.LabelOffset = 0;
            plotSurface2D1.YAxis1.HideTickText = false;

            plotSurface2D1.XAxis1.Label = "Encoder Pulse  <<-- (Acma Profili)";
            plotSurface2D1.Padding = 5;
            plotSurface2D1.AutoScaleTitle = true;
            //  plotSurface2D1.BackColor = 
            plotSurface2D1.Refresh();


        }
        void Plot_Chart_Close(){
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

            NPlot.LinePlot Graph6 = new NPlot.LinePlot();
            Graph6.Pen = new Pen(Color.DarkSlateGray, 1);   // error
            List<String> Data6 = new List<String>(); // 

            NPlot.LinePlot Graph7 = new NPlot.LinePlot();
            Graph7.Pen = new Pen(Color.DarkViolet, 1);   // pid
            List<String> Data7 = new List<String>(); // 


            NPlot.LinePlot Graph8 = new NPlot.LinePlot();
            Graph8.Pen = new Pen(Color.Orange, 1);   // pid
            List<String> Data8 = new List<String>(); // 

            NPlot.LinePlot Graph9 = new NPlot.LinePlot();
            Graph9.Pen = new Pen(Color.DarkOrange, 1);   // pid
            List<String> Data9 = new List<String>(); // 







            List<String> Y_Profile = new List<String>();
            List<String> Data1 = new List<String>();
            List<String> Data2 = new List<String>();
            List<String> Data3 = new List<String>();
            List<String> Data4 = new List<String>(); // akim 
            List<String> Data5 = new List<String>(); // akimset
            List<String> X_Data = new List<String>();
            List<String> X_Profile = new List<String>();

            float FloatNum;


            for (int t = 0; t < DAQ.EncPulseSample_Close; t++)
            {
                Single.TryParse(DAQ.CurrentSetArr[t], out  FloatNum); Data5.Add(FloatNum.ToString()); // akim set
                Single.TryParse(DAQ.CurrentDiffArr[t], out  FloatNum); Data4.Add(FloatNum.ToString()); // akim
                Single.TryParse(DAQ.SpeedActual_Arr[t], out  FloatNum); Data1.Add(FloatNum.ToString());
                Single.TryParse(DAQ.SpeedTarget_Arr[t], out  FloatNum); Data2.Add(FloatNum.ToString());
                Single.TryParse(DAQ.SpeedAverageSProfile_Arr[t], out  FloatNum); Data3.Add(FloatNum.ToString());

                Single.TryParse(DAQ.EncoderPulseArr[t], out  FloatNum); X_Data.Add(FloatNum.ToString());

                Single.TryParse(DAQ.ErrorArr[t], out  FloatNum); Data6.Add(FloatNum.ToString()); // error set
                Single.TryParse(DAQ.PIDArr[t], out  FloatNum); Data7.Add(FloatNum.ToString()); // error set
                Single.TryParse(DAQ.PIDHighLimitArr[t], out  FloatNum); Data8.Add(FloatNum.ToString()); // error set
                Single.TryParse(DAQ.PIDLowLimitArr[t], out  FloatNum); Data9.Add(FloatNum.ToString()); // error set

        //        MaxPointProfile;
        //        string str = MaxPointProfile;
                if (DAQ.ProfileArr[t] != "0")
                {
                    Single.TryParse(DAQ.ProfileArr[t], out  FloatNum); Y_Profile.Add(FloatNum.ToString());
                    Single.TryParse(DAQ.EncoderPulseArr[t], out  FloatNum); X_Profile.Add(FloatNum.ToString());
                }
               
         //       Single.TryParse(MLDC.CurrentErrorArr[t], out  FloatNum); Data8.Add(FloatNum.ToString()); // error set
        //        CurrentSampled
            }



        //    NPlot.LinePlot GraphProfileMode = new NPlot.LinePlot();
            NPlot.PointPlot GraphProfileMode = new NPlot.PointPlot();
       //     GraphProfileMode.Pen = new Pen(Color.Black, 0);   // pid
            //        List<String> YProfileModeScale = new List<String>(); // 



      //      ArrayList YProfileModeScale = new ArrayList();
      //      ArrayList XProfileModeScale = new ArrayList();

            //    int gh;
  /*          for (int i = 0; i < MLDC.EncPulseSample_Close; i++)
            {

                if (ProfilePulse_Mode != ProfilePulse_Mode_Prev)
                {
                    YProfileModeScale.Add(50).ToString();
                }
                else YProfileModeScale.Add(0).ToString();
                ProfilePulse_Mode_Prev = ProfilePulse_Mode;
            }
*/

            GraphProfileMode.DataSource = Y_Profile;
            GraphProfileMode.AbscissaData = X_Profile;
            /*    
                         Single.TryParse(MLDC.SpeedActual_Arr [MLDC.EncPulseSample], out  FloatNum); Data1.Add(FloatNum.ToString());
                         Single.TryParse(MLDC.SpeedTarget_Arr[ MLDC.EncPulseSample], out  FloatNum); Data2.Add(FloatNum.ToString());
                         Single.TryParse(MLDC.SpeedAverageSProfile_Arr[ MLDC.EncPulseSample], out  FloatNum); Data3.Add(FloatNum.ToString());
                         Single.TryParse(MLDC.EncoderPulseArr [MLDC.EncPulseSample], out  FloatNum); X_Data.Add(FloatNum.ToString());
         */

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
            Graph7.AbscissaData = X_Data;
            Graph7.DataSource = Data7;

            Graph8.AbscissaData = X_Data;
            Graph8.DataSource = Data8;

            Graph9.AbscissaData = X_Data;
            Graph9.DataSource = Data9;



            /*
                        Graph1.AbscissaData = XTimes;
                        Graph1.DataSource = Data1;

                        Graph2.AbscissaData = XTimes;
                        Graph2.DataSource = Data2;

                        Graph2.AbscissaData = XTimes;
                        Graph2.DataSource = Data3;
            */

            //        Scale Max Max Inspected Pulse
            NPlot.LinePlot GraphMaxEncoderPulse = new NPlot.LinePlot();
            GraphMaxEncoderPulse.Pen = new Pen(Color.Black, 0);
            ArrayList YMaxScale = new ArrayList();
            GraphMaxEncoderPulse.DataSource = YMaxScale;
            ArrayList XMaxScale = new ArrayList();

            int k;
            for (int i = 0; i < 2; i++)
            {
                //      k = 10000; // max encoder pulse
                k = DAQ.EncPulse_InspectedMax; // max encoder pulse
                YMaxScale.Add(i * 50).ToString();
                XMaxScale.Add(k).ToString();
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

            if (checkBox_Cl_ProfileSpeed.Checked == true) plotSurface2D2.Add(Graph3);
            if (checkBox_Cl_ActualSpeed.Checked == true) plotSurface2D2.Add(Graph1);
            if (checkBox_Cl_Current.Checked == true) plotSurface2D2.Add(Graph4);
            if(checkBox_Cl_RefAkim.Checked == true)plotSurface2D2.Add(Graph5);
            if (checkBox_Cl_SpeedError.Checked == true) plotSurface2D2.Add(Graph6);
            if (checkBox_Cl_PID.Checked == true) plotSurface2D2.Add(Graph7);
     //       if (checkBox_Cl_CurErr.Checked == true) plotSurface2D2.Add(Graph8);   
            if (checkBox_Cl_HighLimit.Checked == true) plotSurface2D2.Add(Graph8);
            if (checkBox_Cl_LowLimit.Checked == true) plotSurface2D2.Add(Graph9);

            plotSurface2D2.Add(GraphMinEncoderPulse);
            plotSurface2D2.Add(GraphMaxEncoderPulse);







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
            String Textdata = "";
            
            Textdata = "Received Data " + System.Environment.NewLine;
            Textdata += "Preamble :" + " 0 X" + SP1.Preamble.ToString("X") + System.Environment.NewLine;
            Textdata += "DataLength : " + SP1.Length.ToString() + System.Environment.NewLine;
            Textdata += "SP1.CRC_Received " + SP1.CRC_Received.ToString() + " / 0 X" + SP1.CRC_Received.ToString("X") + System.Environment.NewLine;
            Textdata += "SP1.CRC_Calc " + SP1.CRC_Calc.ToString() + " / 0 X" + SP1.CRC_Calc.ToString("X") + System.Environment.NewLine;
            Textdata += "SP1.CRC_Error " + SP1.CRC_Error.ToString() + " / 0 X" + SP1.CRC_Error.ToString("X") + System.Environment.NewLine + System.Environment.NewLine + System.Environment.NewLine;

            Textdata += "Kapi Boyu : " + EncPulse_DoorLength.ToString() + " mm " + System.Environment.NewLine;
            Textdata += "Tanitma Max Pulse : " + DAQ.EncPulse_InspectedMax.ToString() +System.Environment.NewLine;
            Textdata += "EncoderPulse: " + DAQ.EncPulse_Current.ToString() + System.Environment.NewLine + System.Environment.NewLine;
       
            Textdata += "Speed_PID " + (Speed_PID).ToString() + System.Environment.NewLine;
            Textdata += "Final_PID " + (Final_PID).ToString() + System.Environment.NewLine + System.Environment.NewLine;

            Textdata += "Hesaplanan Profil Hizi : " + (SpeedAverage_S_Profile/10).ToString() + " cm/S"  + System.Environment.NewLine;
             Textdata += "Hedef Hiz : " + (Speed_Target / 10).ToString() + " cm/S" + System.Environment.NewLine;
             Textdata += "Gercek Hiz : " + Speed_Actual.ToString() + " cm/S" + System.Environment.NewLine;
             Textdata += " Hiz Farki : " + ((Int16)((Speed_Target/10) - Speed_Actual)).ToString() + " cm/S" + System.Environment.NewLine + System.Environment.NewLine;
             Textdata += " Hiz Error : " + DAQ.Error.ToString()  + System.Environment.NewLine;



             Textdata += " Akim Farki : " + DAQ.Current_Diff.ToString() + " adc" + System.Environment.NewLine;
             Textdata += "Aktif Set Max. Akim : " + DAQ.Current_Setlevel.ToString() + " adc" + System.Environment.NewLine;
             Textdata += "Olculen Akim :" + DAQ.Current_Sampled.ToString() + " adc" + System.Environment.NewLine + System.Environment.NewLine;

            String str="OPEN";

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

            return Textdata;
        }
        private void SP1_serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SP1_ReceiveData_Procedure();
        }

        private void SP1_ConnectButton_Click(object sender, EventArgs e)
        {
            SP1_Connect_Procedure();
        }

        private void SP1_SendButton_Click(object sender, EventArgs e)
        {
            SP1_SendData_Procedure();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SP1_richTextBox.Clear();
            SP1_DatatextBox.Clear();
            SP1.CRC_Error = 0;
        }

        private void SP1_DisConnectButton_Click(object sender, EventArgs e)
        {
            SP1_DisConnect_Procedure();
        }

        private void Base_Timer1mSec_Tick(object sender, EventArgs e)
        {

            if (ProfilePulse_Direction == Definition.OPEN) if (ProfilePulse_Command == Definition.OPEN) Plot_Chart_Open();
               if (ProfilePulse_Direction == Definition.CLOSE) if (ProfilePulse_Command == Definition.CLOSE)  Plot_Chart_Close();



            Timer_1sec++;
            if (Timer_1sec > 8)
            {
                Timer_1sec = 0;
          //      Update_Chart = 1;
         //       Plot_Chart();
       //         textBox_DateTime.Text = LOG_GetDateTime();
                SP1_richTextBox.Text = SP1_GetTextdata();
                SP1_DatatextBox.Text = SP1_GetTextdata2();

                SP1_SendtextBox.Text = DAQ.EncPulseSample.ToString();
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
            BaseCounter++;
            BaseCounter = 0;
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
    }
}
