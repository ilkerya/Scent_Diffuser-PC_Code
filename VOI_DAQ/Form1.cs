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
using System.IO;
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

           SetArrayColors(DAQ.Max_Array_Size);
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
                if (DAQ.Log_Status == true)
                {
                    if (SP1_serialPort.IsOpen == false)
                    {
                        DAQ.Log_Status = false;
                        MessageBox.Show("Com Port Error!" + DAQ.nl + "Loggging Disabled");
                        DAQ.Log_Counter = 0;
                        startToolStripMenuItem.Enabled = true;
                    }
                    else
                    {
                        LOG_DataLogProcess(DAQ.Original_Log_File);
                        startToolStripMenuItem.Enabled = false;
                    }
                }


                //Simulate();
            }
        }
        public void LOG_DataLogProcess(String FileName)
        {
            //       if (LOG_SampleCount() != 0) return;

            String path = FileName;
            //				path= Environment::SpecialFolder::MyDocuments;
            if (!(File.Exists(path)))
            {
                try
                {
                    FileStream fs = File.Create(path);
                    //	delete fs;
                }
                catch (IOException) { return; }
            }
            // create a strem reader
            StreamReader sr;
            try { sr = new StreamReader(path); }
            catch (IOException) { DAQ.Log_Error = true; return; }

            String DataFile;
            DataFile = LOG_ReadStream(sr, path); // read data from file
            if (DataFile == "false") return;
            if (LOG_DeleteStreamReader(sr) == "false") return;	 //
            // create a stream writer
            StreamWriter sw;
            try { sw = new StreamWriter(path); }
            catch (IOException) { DAQ.Log_Error = true; return; }
            // wite 2 stream
            if (LOG_WriteStream(sw, path, DataFile) == "false") return;	 // write  data to file
            if (LOG_DeleteStreamWriter(sw) == "false") return;	 // write  data to file
            /*
            String fr;
            if (Okyanus.Variables.Log_Counter >= Okyanus.Chart.MAXLOGCOUNT)
            {			 // DEFAULT_LOGMAXHOUR

                Okyanus.Variables.Log_FileCount += Okyanus.Variables.Log_Counter;
                Okyanus.Variables.Log_Counter = 0;
                Okyanus.Variables.Log_Original_Log_File_post_add++;

                if (Okyanus.Variables.Log_Original_Log_File_post_add < 10) fr = "00";
                else if (Okyanus.Variables.Log_Original_Log_File_post_add < 100) fr = "0";
                else fr = "";
                //      Okyanus.Definitions.WorkDrive + 
                Okyanus.Definitions.Original_Log_File = Okyanus.Definitions.Original_Log_File_Base + fr + Okyanus.Variables.Log_Original_Log_File_post_add.ToString();	 // add 

            }
            else
            {

                Okyanus.Variables.Log_Counter++;
            }
            */
        }
        public String LOG_ReadStream(StreamReader Sr, String path)
        {
            try
            {
                if (Sr != null)
                {     // hata dosya aciksa kitleniyor burada
                    return Sr.ReadToEnd();
                }
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; }
            return "false";
        }
        public String LOG_WriteStream(StreamWriter Sw, String path, String data)
        {
            try
            {
                if (Sw != null)
                    if (DAQ.Log_Counter != 0) 
                        Sw.WriteLine(data + (DAQ.Log_Counter + DAQ.Log_FileCount).ToString() + LOG_PrepareData_2WriteFile_01());
                    // ilk sira     
                    else
                    {
                        DAQ.Log_Counter = 1;
                        String Mystring = " Log No,   Date   , Time , Speed , Voltage, Current,  Power,Temperature";
                        /*
                        for (int i = 0; i < DAQ.RawIndex; i++)
                        {
                            Mystring += DAQ.Variables_Name[i] + ",";
                        }
                        */
                        Sw.WriteLine(data + Mystring);
                    }
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; };
            return "true";
        }
        public String LOG_PrepareData_2WriteFile_01()
        {

            DateTime d1 = DateTime.Now;

            int Hour = d1.Hour; int Min = d1.Minute; int Sec = d1.Second; int Day = d1.Day; int Month = d1.Month; int Year = d1.Year;
            String HourZero = "";
            String MinZero = "";
            String SecZero = "";
            if (Hour < 10) HourZero = "0"; else HourZero = "";
            if (Min < 10) MinZero = "0"; else MinZero = "";
            if (Sec < 10) SecZero = "0"; else SecZero = "";

            String Mystring = ",";
            Mystring += Day.ToString() + "." + Month.ToString() + "." + Year.ToString() + ",";
            Mystring += HourZero + Hour.ToString() + ":" + MinZero + Min.ToString() + ":" + SecZero + Sec.ToString();
            Mystring += ",";
            /*
            for (int i = 0; i < DAQ.RawIndex; i++)
            {
                Mystring += DAQ.Variables_Data[i] + ",";
            }
            */
            Mystring += DAQ.Speed.ToString() + "," + DAQ.Voltage.ToString() + "," + DAQ.Current.ToString() + "," +
                DAQ.Power.ToString() + "," + DAQ.Temperature.ToString() + ",";

       


            return Mystring;
        }
        public String LOG_DeleteStreamWriter(StreamWriter Sw)
        {
            try
            {
                if (Sw != null)
                {

                    Sw.Close();

                }
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; };
            return "true";
        }
        public String LOG_DeleteStreamReader(StreamReader Sr)
        {
            try
            {
                if (Sr != null)	//delete Sr;
                    Sr.Close();
            }
            catch (IOException) { DAQ.Log_Error = true; return "false"; }
            return "true";
        }
        void Array_Fill()
        {
            UInt16 MaxArray = DAQ.Max_Array_Size;
            MaxArray--;
            if (DAQ.Index < DAQ.Max_Array_Size)
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
                for (int t = 0; t < MaxArray; t++)
                {
                    DAQ.Index_Arr[t] = DAQ.Index_Arr[t + 1];
                    DAQ.Speed_Arr[t] = DAQ.Speed_Arr[t + 1];
                    DAQ.Current_Arr[t] = DAQ.Current_Arr[t + 1];
                    DAQ.Voltage_Arr[t] = DAQ.Voltage_Arr[t + 1];
                    DAQ.Power_Arr[t] = DAQ.Power_Arr[t + 1];
                    DAQ.Temperature_Arr[t] = DAQ.Temperature_Arr[t + 1];
                }
                DAQ.Offset = MaxArray;

                DAQ.Index_Arr[MaxArray] = DAQ.Index.ToString();

                DAQ.Speed_Arr[MaxArray] = DAQ.Speed.ToString();
                DAQ.Current_Arr[MaxArray] = DAQ.Current.ToString();
                DAQ.Voltage_Arr[MaxArray] = DAQ.Voltage.ToString();
                DAQ.Power_Arr[MaxArray] = DAQ.Power.ToString();
                DAQ.Temperature_Arr[MaxArray] = DAQ.Temperature.ToString();


            }
            DAQ.Index++;

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
                startToolStripMenuItem.Enabled = true;
            }
            catch
            {
                //If there was an exception, then close the handle to 
                //  the device and assume that the device was removed
                //  button_Close_Click(this, null);

                SP1_DisConnect_Procedure();
                SP1.PortConnectName = "NoConnection";
                startToolStripMenuItem.Enabled = false;
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

            startToolStripMenuItem.Enabled = false;
            stopToolStripMenuItem.Enabled = false;

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
            Textdata += "CRC_Error " + SP1.CRC_Error.ToString() + System.Environment.NewLine;
            Textdata += "CRC_Success " + SP1.CRC_Success.ToString() + System.Environment.NewLine;

            if (SP1.CRC_Success != 0)
            {
                float ErroRate = SP1.CRC_Error * 100000 / SP1.CRC_Success;
                if (ErroRate > 0) {
                    Textdata += "Error Rate : %" + (ErroRate / 1000).ToString();
                }
                else Textdata += "Error Rate : %0.0000";
            }
            else Textdata += "Error Rate : % 0.0000";

            Textdata += System.Environment.NewLine + System.Environment.NewLine;

            Textdata += "Speed : " + DAQ.Speed.ToString() + " rpm " + System.Environment.NewLine;
            Textdata += "Current " + DAQ.Current.ToString() + " Amper" + System.Environment.NewLine;
            Textdata += "Voltage " + DAQ.Voltage.ToString() + " Volt" + System.Environment.NewLine;
            Textdata += "Power : " + DAQ.Power.ToString() + " Watt" + System.Environment.NewLine;
            Textdata += "Temperature : " + DAQ.Temperature.ToString() + " C" + System.Environment.NewLine;
            Textdata += "DAQ.Max_Array_Size " + DAQ.Max_Array_Size + DAQ.nl;
            Textdata += "DAQ.Index " + DAQ.Index + DAQ.nl; ;
            Textdata += "DAQ.Offset " + DAQ.Offset;
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
            //TrialFunc();

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
                /*
                                if( dataLoggerToolStripMenuItem.Checked == true )
                                    systemTimeToolStripMenuItem.Text = " System Time & Date: " + COMMON_GetDateTime();
                */
                if (DAQ.Enable_Menu_Time_Update == true)
                    systemTimeToolStripMenuItem.Text = "Time & Date: " + COMMON_GetDateTime();

            }
            if (DAQ.EnableInitTimer == true)
            {
                DAQ.InitTimer++;
                if (DAQ.InitTimer > 75) {
                    DAQ.EnableInitTimer = false;
                    plotSurface2D1.BackgroundImage = null;
                    Plot_Chart();
                }
            }
            else
            {


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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Exit form = new Exit();
            //    form.MdiParent = this;
            //     form.ShowDialog();
            //  form.BackColor = Color.
            form.Show();
        }

        private void dataLoggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DAQ.Enable_Menu_Time_Update = true;
            // systemTimeToolStripMenuItem.Text = "Time & Date: " + COMMON_GetDateTime();
        }
        public String COMMON_GetDateTime()
        {
            //	DateTime oldDate = DateTime.Parse("11/9/03 12:00");

            DateTime d1 = DateTime.Now;
            int Hour = d1.Hour; int Min = d1.Minute; int Sec = d1.Second; int Day = d1.Day; int Month = d1.Month; int Year = d1.Year;
            String HourZero = ""; String MinZero = ""; String SecZero = "";
            if (Hour < 10) HourZero = "0"; else HourZero = "";
            if (Min < 10) MinZero = "0"; else MinZero = "";
            if (Sec < 10) SecZero = "0"; else SecZero = "";
            //		   String ^ Mystring = Day.ToString() + "." +  Month.ToString() + "."+ Year.ToString() + ",";
            //			Mystring += HourZero +  Hour.ToString()+":"+MinZero+Min.ToString()+":"+SecZero+Sec.ToString() ;

            String Mystring = HourZero + Hour.ToString() + ":" + MinZero + Min.ToString() + ":" + SecZero + Sec.ToString() + "    ";
            Mystring += Day.ToString() + "." + Month.ToString() + "." + Year.ToString();
            return Mystring;

        }
        public void LOG_SaveLogFile() { 
            if (LOG_File_SaveAs() == false) return;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //LOG_SaveLogFile();
            if (LOG_File_SaveAs() == false) return;
        }
        public bool LOG_File_SaveAs()
        {
            if (SP1_serialPort.IsOpen == false) { 
                MessageBox.Show("Com Port Not Open"); 
                return false; 
            }
      //   ((   if (Okyanus.Variables.Log_Status == true) { MessageBox.Show("First Stop Logging "); return false; }

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = DAQ.WorkDrive + DAQ.Log_Directory;
            saveFileDialog1.Title = "Select  a File to Log Data";
            /*
            if (!(Directory.Exists(DAQ.WorkDrive + DAQ.Log_Directory)))
            { // directory yoksa my documents dan basliyor
                try { Directory.CreateDirectory(DAQ.WorkDrive + DAQ.Log_Directory); }
                catch (IOException)
                {
                    DAQ.Log_Error = true;
                    MessageBox.Show("Log Save Error !!");
                    //    return;
                }// e->GetType()->Name ;
            }
            */
            String str = LOG_GetTime() + ".csv";
         //   String str =  ".csv";
            saveFileDialog1.FileName = str;
            saveFileDialog1.Filter = "Txt files (*.txt)|*.txt | Csv files (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    if ((myStream = saveFileDialog1.OpenFile()) != null)
                    {     // hata dosya aciksa kitleniyor burad            
                       DAQ.Original_Log_File = saveFileDialog1.FileName; //secilen isimle dosya ismini tut
                       DAQ.Original_Log_File_Base = DAQ.Original_Log_File; // Okyanus.Definitions.WorkDrive +
                       DAQ.Log_Status = true;
                       DAQ.Log_Error = false;
                        myStream.Close();
                    }
                }
                catch (IOException)
                {
                           DAQ.Log_Error = true;
                           DAQ.Log_Status = false;
                    MessageBox.Show("File Error !!"  + "Close File If Open");
                    return false;
                }

                LOG_LogStatusUpdate();
                stopToolStripMenuItem.Enabled = true;
            }
            
                DAQ.Log_SampleCounter = 0;
            return true;
        }
        public void LOG_File_Stop()
        {
            
            if (DAQ.Log_Status == false) { MessageBox.Show("No Log File to Stop "); return; }
            DAQ.Log_Status = false;

            DAQ.Log_Counter = 0;
            LOG_LogStatusUpdate();
            DAQ.Log_SampleCounter = 0;
            stopToolStripMenuItem.Enabled = false;

        }
        public void LOG_LogStatusUpdate()
        {
            String Str;
            if (DAQ.Log_Status == true)
            {
                if (DAQ.Log_Error == true)
                {
                    Str = "Stopped @: " + COMMON_GetDateTime() + "Did You Open the File?";
                  //  startTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
                }
                else
                {
                    Str = "Started @ " + COMMON_GetDateTime() + " to " + DAQ.Original_Log_File;
                 //   startTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Green;
                }
           //     startTimeToolStripMenuItem1.Text = Str;
           //     dataLogOnOffToolStripMenuItem1.Text = "Logging to : " + DAQ.Original_Log_File;
           //     dataLogOnOffToolStripMenuItem1.ForeColor = System.Drawing.Color.Green;
           //     stopTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                if (DAQ.Log_Error == true) { Str = "Stopped @: " + COMMON_GetDateTime() + "  Is  File Already Open?"; }
                else { Str = "Stopped @: " + COMMON_GetDateTime() + " to " + DAQ.Original_Log_File; }
           //     stopTimeToolStripMenuItem1.Text = Str;
           //     dataLogOnOffToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
           //     dataLogOnOffToolStripMenuItem1.Text = "Logging Off   ";
           //     stopTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Red;
            //    startTimeToolStripMenuItem1.ForeColor = System.Drawing.Color.Black;
            }
        }
        public String LOG_GetTime()
        {
            DateTime d1 = DateTime.Now;
            int Day = d1.Day; int Month = d1.Month; int Year = d1.Year; int Hour = d1.Hour; int Min = d1.Minute;

            String Mystring = "";
            if (Day < 10) Mystring += "0"; else Mystring += "";
            Mystring += Day.ToString() + ".";
            if (Month < 10) Mystring += "0"; else Mystring += "";
            Mystring += Month.ToString() + ".";
            Mystring += Year.ToString() + "__";
            if (Hour < 10) Mystring += "0"; else Mystring += "";
            Mystring += Hour.ToString() + ".";
            if (Min < 10) Mystring += "0"; else Mystring += "";
            Mystring += Min.ToString();
            return Mystring;
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   Okyanus.Chart.Play = false;
         //   ChartPlayPause();
            LOG_File_Stop();
            startToolStripMenuItem.Enabled = true;
        }
        /*
        public void LOG_StopLog()
        {
         //   Okyanus.Chart.Play = false;
         //   ChartPlayPause();
          //  LOG_File_Stop();
        }
        */
        public void SetArrayColors(UInt16 Ref)
        {
            toolStripMenuItem2.ForeColor = Color.Black;
            toolStripMenuItem3.ForeColor = Color.Black;
            toolStripMenuItem4.ForeColor = Color.Black;
            toolStripMenuItem5.ForeColor = Color.Black;
            toolStripMenuItem6.ForeColor = Color.Black;

            switch (Ref)
            {
                case 300:
                    toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                 
                    break;
                case 500:
                    toolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                  
                    break;
                case 1000:
                    toolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    
                    break;
                case 2000:
                    toolStripMenuItem5.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    
                    break;
                case 5000:
                    toolStripMenuItem6.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                   
                    break;
            }
            DAQ.Max_Array_Size = Ref;
            if (DAQ.Index > DAQ.Max_Array_Size) DAQ.Index = 0;
         //   else DAQ.Index = DAQ.Max_Array_Size - DAQ.Index;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            SetArrayColors(300);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            SetArrayColors(500);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            SetArrayColors(1000);
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            SetArrayColors(2000);
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            SetArrayColors(5000);
        }
    }

    }

