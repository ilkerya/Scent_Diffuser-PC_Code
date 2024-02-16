
//#define DERS 34

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
using NPlot;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Win32;
using System.Text.RegularExpressions;






namespace VOI_DAQ
{

    public partial class Form1 : Form
    {






        // int BaseCounter;
        int Timer_1sec;
        byte Task_Counter;

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

        public void Plot_Init()
        {
            
            NPlot.Grid grid = new NPlot.Grid();
            NPlot.LinePlot Graph1 = new NPlot.LinePlot();
            NPlot.LinePlot Graph2 = new NPlot.LinePlot();
            NPlot.LinePlot Graph3 = new NPlot.LinePlot();
            NPlot.LinePlot Graph4 = new NPlot.LinePlot();

            Graph1.Pen = new Pen(Color.Red, 1);
            Graph2.Pen = new Pen(Color.Blue, 2);
            Graph3.Pen = new Pen(Color.Green, 1);
            Graph4.Pen = new Pen(Color.Gold, 1);   //

            grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
            grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
            grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);
            grid.MinorGridPen = new Pen(Color.LightGray, 1.0f);

            plotSurface2D1.Clear();
            pictureBox2.Visible = false;


        }

        public Form1()
        {
            InitializeComponent();
          //   Plot_Init();

            try
            {
                pictureBox1.Image = Image.FromFile("C:\\Projects\\.Net\\VOI_DAQ\\VOI_DAQ\\Pics\\spinning_wheel3.jpg");
                pictureBox2.BackgroundImage = Image.FromFile("C:\\Projects\\.Net\\VOI_DAQ\\VOI_DAQ\\Pics\\V7_1.png");
                pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error opening the pictures." + "  Please check the path.");
            }

            CheckForIllegalCrossThreadCalls = false;
            SP1_IO_Serial_UpdateCOMPortList();

           SetArrayColors();
            DAQ.Slope = (double)numericUpDown_incline.Value;
            DAQ.Wheel_Diameter = (Int16)numericUpDown_Wheel.Value;

            SP1_textBox_PortName.Text = "No Connection";

        //    richTextBox_Current.Text = DAQ.Current_Simulator.ToString();
       //     richTextBox_Voltage.Text = DAQ.Voltage_Simulator.ToString();
       //     Simulator.ActiveForm.Text = DAQ.Current_Simulator.ToString();

        }
  
        public void SP1_IO_Serial_UpdateCOMPortList()
        {
            /*
            int i; i = 0; bool foundDifference;
            foundDifference = false;
            //   textBox_PortName.Text = PortConnectName;
            //If the number of COM ports is different than the last time we
            //  checked, then we know that the COM ports have changed and we
            //  don't need to verify each entry.
 
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
            String PortPosition = "Not Connected";
            //Add all of the current COM ports to the list
            foreach (string s in SerialPort.GetPortNames())
            {
                SP1_IO_Serial_lstCOMPorts.Items.Add(s);
                if (s == SP1.PortConnectName) PortPosition = SP1.PortConnectName;
                //    SP1_IO_Serial_lstCOMPorts.SelectedIndex = 0;  // 25.04.2014
            }
            if (PortPosition == "Not Connected")
            {

                SP1_DisConnect_Procedure();
            }
            SP1_textBox_PortName.Text = PortPosition;
            */
       
        }
        public String Check_Com_VID_PID()
        {
            List<string> ComPortNames(String VID, String PID)
            {
                String pattern = String.Format("^VID_{0}.PID_{1}", VID, PID);
                Regex _rx = new Regex(pattern, RegexOptions.IgnoreCase);
                List<string> comports = new List<string>();
                RegistryKey rk1 = Registry.LocalMachine;
                RegistryKey rk2 = rk1.OpenSubKey("SYSTEM\\CurrentControlSet\\Enum");
                foreach (String s3 in rk2.GetSubKeyNames())
                {
                    RegistryKey rk3 = rk2.OpenSubKey(s3);
                    foreach (String s in rk3.GetSubKeyNames())
                    {
                        if (_rx.Match(s).Success)
                        {
                            RegistryKey rk4 = rk3.OpenSubKey(s);
                            foreach (String s2 in rk4.GetSubKeyNames())
                            {
                                RegistryKey rk5 = rk4.OpenSubKey(s2);
                                RegistryKey rk6 = rk5.OpenSubKey("Device Parameters");
                                comports.Add((string)rk6.GetValue("PortName"));
                            }
                        }
                    }
                }
                return comports;
            }
            List<string> names = ComPortNames("04D8", "00DD");
            if (names.Count > 0)
            {
                //textBox1.Text = "No Matching Port ";
                foreach (String s in SerialPort.GetPortNames())
                {
                    if (names.Contains(s))
                        //  textBox1.Text = "Port " + s;
                        //  Console.WriteLine("port");
                        return s;
                }
            }
            //  else
            //   Console.WriteLine("No COM ports found");
            // textBox1.Text = "No COM ports found";
            return "No COM ports found";
        }
        public void Serial_UpdateCOMPortList_VID_PID()
        {
            String Newport = Check_Com_VID_PID();
            if (SP1.PortConnectName != Newport) SP1_DisConnect_Procedure();


        }
            void SP1_Connect_Procedure()
        {
            try
            {
                //Get the port name from the application list box.
                //  the PortName attribute is a string name of the COM
                //  port (e.g. - "COM1").
                //      SP1_IO_Serial_lstCOMPorts.SelectedIndex = 2;
                //      SP1_serialPort.PortName = SP1_IO_Serial_lstCOMPorts.Items[SP1_IO_Serial_lstCOMPorts.SelectedIndex].ToString();
                SP1_serialPort.PortName = Check_Com_VID_PID();
                //    SP1_IO_Serial_lstCOMPorts.Items[SP1_IO_Serial_lstCOMPorts.SelectedIndex].ToString()

                SP1.PortConnectName = SP1_serialPort.PortName;
                //      SP1_textBox_PortName.Text = SP1.PortConnectName;
                //Open the COM port.
                //     SP1_serialPort.BaudRate = 9600;
                SP1_serialPort.BaudRate = 57600;
                // SP1_serialPort.BaudRate = 115200;
                //    SP1_serialPort.BaudRate = 128000;

                SP1_textBox_PortName.Text = SP1_serialPort.PortName + DAQ.nl;
                SP1_textBox_PortName.Text += SP1_serialPort.BaudRate.ToString() + " bps" + DAQ.nl;
                SP1_textBox_PortName.Text += "VID " + "04D8" + DAQ.nl;
                SP1_textBox_PortName.Text += "PID " + "00DD";
                SP1_serialPort.Parity = Parity.None;
                SP1_serialPort.StopBits = StopBits.One;
                SP1_serialPort.DataBits = 8;
                SP1_serialPort.Handshake = Handshake.None;
                SP1_serialPort.RtsEnable = true;
                SP1_serialPort.Open();

                SP1_ConnectButton.Text = "Disconnect";
                SP1_IO_Serial_lstCOMPorts.Enabled = false;
                //   btnClose.Enabled = true;
              //  SP1_DisConnectButton.Enabled = true;
                //            textBox1.Clear(); 
                //            textBox1.AppendText("Connected.\r\n");
              startToolStripMenuItem.Enabled = true;

            }
            catch
            {
                SP1_DisConnect_Procedure();
            }
        }

        void SP1_DisConnect_Procedure()
        {
            SP1.PortConnectName = "No Connection";
            DAQ.Connect = false;
            SP1_ConnectButton.Text = "Connect";

            //Reset the state of the application objects
            SP1_textBox_PortName.Text =  "No Connection";
            SP1_IO_Serial_lstCOMPorts.Enabled = true;

       //     startToolStripMenuItem.Enabled = false;
      //      stopToolStripMenuItem.Enabled = false;

            DAQ.Index = 0; // index
            DAQ.Offset = 0; // index
            DAQ.Log_Counter = 0;
            DAQ.Log_SampleCounter = 0;
            SP1.ReadSequence = 0;
            try
            {
                if (SP1_serialPort.IsOpen)
                {
                    SP1_serialPort.ReadExisting();
                    SP1_serialPort.DiscardInBuffer();
                    SP1_serialPort.DiscardOutBuffer();
                }
                SP1_serialPort.Close();
            }
            catch { }

            //Dispose the In and Out buffers;
            //    SP1_serialPort.ReadExisting();
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
                        //    SP1.Length = (UInt16)((SP1.Buffer[2] << SP1.SHIFT8) + SP1.Buffer[3]);

                        SP1.Length = SP1.DEFAULT_LENGTH;

                        if (SP1.Preamble == SP1.DEFAULT_PREAMBLE) // CHECK IF PREAMLE IS EQUAL TO THE DEFAULT ONE
                        {
                            SP1.ReadSequence = 1; // PREAMBLE MATCHES WITH THE DEFAULT ONE
                                                  // SP1.Preamble_Fail = 0;
                        }
                        else
                        {
                            SP1.Preamble_Trial++;
                            /*
                            if(SP1.Preamble_Fail > 128)
                            {
                                SP1_DisConnect_Procedure();
                                return;
                            }
                            */
                            //  SP1_serialPort.DiscardInBuffer();
                            SP1.ReadSequence = 0;   // PREAMBLE MATCH FAIL
                                                    //  SP1_serialPort.ReadExisting();
                                                    //   return;
                                                    // SP1.Length = (UInt16)(SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); // default
                            SP1.Length = SP1.DEFAULT_LENGTH;

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
        void SP1_serialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            SP1_ReceiveData_Procedure();
        }

        void SP1_ConnectButton_Click(object sender, EventArgs e)
        {
            if (DAQ.Connect == false)
            {// disconneccted -< connect
                SP1_Connect_Procedure();
                DAQ.Connect = true;
            }
            else
            {
                SP1_DisConnect_Procedure();
                DAQ.Connect = false;
            }

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

        /*              ******************  serial port1 ***********************************************************/
        unsafe void SP1_CalculateRcvData()
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


            for (int i = SP1.PREAMBLE_BYTES; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.Buffer[i];
            }     
            for (int i = 0; i < (MaxLength - SP1.CRC_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.ReceiveBuf[i];
            }

            SP1.CRC_Calc <<= 8;

            for (int i = SP1.PREAMBLE_BYTES; i < (SP1.PREAMBLE_BYTES + SP1.DATALENGTH_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.Buffer[i];
            }
            for (int i = 0; i < (MaxLength - SP1.CRC_BYTES); i++)  //  data crc
            {
                SP1.CRC_Calc ^= SP1.ReceiveBuf[i];
            }

            /*

            */
            if (SP1.CRC_Calc != SP1.CRC_Received)
            {
                SP1.CRC_Error++;
            }
            else
            {
                SP1.CRC_Success++;

                DAQ.Encoder_Abs = (UInt32)((SP1.ReceiveBuf[0] << SP1.SHIFT24) + (SP1.ReceiveBuf[1] << SP1.SHIFT16) +
                                (SP1.ReceiveBuf[2] << SP1.SHIFT8) + SP1.ReceiveBuf[3]);  //32 bit

                DAQ.CPU_Reset = SP1.ReceiveBuf[5]; // reset 
                if(DAQ.CPU_Reset != 55) // cpu reset
                {
                    DAQ.Setup = 0;
                }
                if (DAQ.Setup == 0) // initial function run once
                {
                    DAQ.Setup = 1;
                    DAQ.Encoder_Abs_Init = DAQ.Encoder_Abs;
                }
                if(DAQ.Encoder_Abs_Init > DAQ.Encoder_Abs) //negative
                {
                    DAQ.Encoder_Diff =(Int32) (DAQ.Encoder_Abs_Init - DAQ.Encoder_Abs); // negative
                    DAQ.Encoder_Diff *= -1;
                    DAQ.Encoder_Diff--; 
                }
                else  // positive
                {
                    DAQ.Encoder_Diff = (Int32)(DAQ.Encoder_Abs - DAQ.Encoder_Abs_Init);
                }
                DAQ.Encoder_Tot_Distance = (Int32)(100 * Math.PI * DAQ.Encoder_Diff / 2400); //mm


                
                if (DAQ.Simulator_Rpm == true)
                {
                    DAQ.Enc_Ang_Speed_Raw = DAQ.AngularSpeed_Simulator;
                    DAQ.Direction = DAQ.AngularSpeedDirection_Simulator; // 128->1 negative  else 0

                    byte Temp = SP1.ReceiveBuf[4];
                    Temp = SP1.ReceiveBuf[7];
                    Temp = SP1.ReceiveBuf[6];
                }
                else { 
                    DAQ.Enc_Ang_Speed_Raw = (UInt16)((SP1.ReceiveBuf[6] << SP1.SHIFT8) + SP1.ReceiveBuf[7]);  //32 bit
                    if (SP1.ReceiveBuf[4] == 128) DAQ.Direction = 1;//negative
                    else DAQ.Direction = 0;
                }


                DAQ.Enc_Ang_Speed_Abs = (Int32)DAQ.Enc_Ang_Speed_Raw;
                if (DAQ.Direction == 1)
                {                  
                    DAQ.Enc_Ang_Speed_Abs *= -1;
                //    DAQ.Enc_Ang_Speed_Abs--;
                }

                //           DAQ.Enc_Ang_Speed_Abs /= 82; // /7.8 -> 226rpm 11 km/h 82->203 9.95 km/h //81-> 207 10.14km/h
                //           DAQ.Enc_Ang_Speed_Abs *= 10;

                // 100 msec
           //     DAQ.Enc_Ang_Speed_Abs *= 132;
           //     DAQ.Enc_Ang_Speed_Abs /= 1000; //1.22  DAQ.Enc_Ang_Speed_Abs *= 10;

                // 10 msec
                DAQ.Enc_Ang_Speed_Abs *= 1351 ; // multiply with 1.32
                DAQ.Enc_Ang_Speed_Abs /= 1024; //1.22   1351/1024 = 1.319

                
             //   Int16 Diameter = DAQ.Wheel_Diameter;
          //      Int16 Diameter = (Int16)numericUpDown_Wheel.Value;

                DAQ.Vehicle_Ang_Speed_Abs = DAQ.Enc_Ang_Speed_Abs * 10; // wheel diameter of the encode wheel 10 cm
                DAQ.Vehicle_Ang_Speed_Abs /= DAQ.Wheel_Diameter;

                DAQ.Vehicle_Speed = (float)DAQ.Vehicle_Ang_Speed_Abs;
                DAQ.Vehicle_Speed /= 10000; // first divide to be in the region of floating point numbers !!!
                DAQ.Vehicle_Speed *= DAQ.Wheel_Diameter;
                DAQ.Vehicle_Speed *= 6;
                DAQ.Vehicle_Speed *= (float)Math.PI; // speed = D*pi*rpm*60 = cm/h //1000000 cm-> km so 6/10.000
                                                     // Speed (km/h)= D(cm)*pi*rpm*60 /100.000  
                DAQ.Current_Adc = (UInt16)((SP1.ReceiveBuf[8] << SP1.SHIFT8) + SP1.ReceiveBuf[9]);
                DAQ.Voltage_Adc = (UInt16)((SP1.ReceiveBuf[10] << SP1.SHIFT8) + SP1.ReceiveBuf[11]);
                DAQ.Temperature = (Int16)((SP1.ReceiveBuf[12] << SP1.SHIFT8) + SP1.ReceiveBuf[13]);


                if (DAQ.Simulator_Electric == true) DAQ.Voltage_Adc = DAQ.Voltage_Simulator;
                else DAQ.Voltage_Adc += DAQ.Voltage_Adc_Offset;

                DAQ.Voltage_32 = (Int32)DAQ.Voltage_Adc;
                DAQ.Voltage_32 *= 3300;
                DAQ.Voltage_32 /= 4096;
          //      DAQ.Voltage_32 *= 1848;  // 61K/3K3 = 18.48 
                DAQ.Voltage_32 *= 1965;  // 61K/3K3 = 18.48 
                DAQ.Voltage_32 /= 100;
                DAQ.Voltage = (UInt16)DAQ.Voltage_32;

                DAQ.Voltage_d = (double)DAQ.Voltage_Adc;
                DAQ.Voltage_d *= 0.80566; // 3300/4096

                //      DAQ.Voltage_32 *= 1848;  // 61K/3K3 = 18.48 
        //        DAQ.Voltage_d *= 1965;  // 61K/3K3 = 18.48 
        //        DAQ.Voltage_d /= 100;
       //         DAQ.Voltage_d /= 1000;

                DAQ.Voltage_d *= 0.01965;



                //       DAQ.Voltage += DAQ.Voltage_Offset;
                //     DAQ.Voltage_Dec = (Int16)(Temp % 100);
                //     DAQ.Current_Adc &= 0XFFF7;
                if (DAQ.Simulator_Electric == true) DAQ.Current_Adc = DAQ.Current_Simulator;
                else DAQ.Current_Adc += DAQ.Current_Adc_Offset;

                DAQ.Current_32 = (Int32)DAQ.Current_Adc;


                DAQ.Current_d = (double)DAQ.Current_Adc;
                 DAQ.Current_d *= 0.80566; // 3300/4096
                DAQ.Current_d -= 2500;
        //        DAQ.Current_d *= -24;// LEM 3 parallel connection multiplier , -8.3333 for thre serial
        //        DAQ.Current_d /= 1000;
          //      DAQ.Current_d *= -0.024;
                DAQ.Current_d *= -0.00833333333; // 3 series Lem Conf.

                DAQ.Current_32 *= 3300;
                DAQ.Current_32 /= 4096;
            //    DAQ.Current_32 *= 0.80566;
                DAQ.Current_32 -= 2500;
        //        DAQ.Current_32 *= -24;// LEM 3 parallel connection multiplier , -8.3333 for thre serial
        //       DAQ.Current_32 *= -0.00833333333; // 3 series Lem Conf.
                DAQ.Current_32 *= -83; // 3 series Lem Conf.
                DAQ.Current_32 /= 10; // 3 series Lem Conf.
                DAQ.Current = (Int16)DAQ.Current_32;

                /*
                                Temp = (Int32)DAQ.Current_Adc;
                                Temp *= 3300;
                                Temp /= 4096; // Volt in terms of battery current *1000
                                Temp -= 2500;
                                Temp *= -24;
                DAQ.Current_32 = Temp;
                DAQ.Current= (Int16)(Temp);

                */

                /*
                 // 2500mV -> 3103 Adc  // measured 3124 Adc
                                // 2.5 Volt - > 
                                if (Temp >= 2500) Temp -= 2500; // adc scaling to 2.5 Volt
                                else Temp = -1 * (2500 - Temp);           
                                DAQ.Current = (Int16) (Temp / 42);
                                DAQ.Current *= -1;
                            */

                //  2516 mamp
                //       DAQ.Current = (Int16)(Temp-2500);
                //       DAQ.Current *= -24;  // volt-> Adc 24 // reverse logic




                // 0.041666

                /*
                DAQ.Accelometer_X = (Int32)SP1.ReceiveBuf[14] * 0x00FFFFFF;
                DAQ.Accelometer_X += (Int32)SP1.ReceiveBuf[15] * 0x0000FFFF;
                DAQ.Accelometer_X += (Int32)SP1.ReceiveBuf[16] * 0x000000FF;
                DAQ.Accelometer_X += (Int32)SP1.ReceiveBuf[17];
                DAQ.Accelometer_Xf = ((float)DAQ.Accelometer_X) / 10000;

                DAQ.Accelometer_Y = (Int32)SP1.ReceiveBuf[18] * 0x00FFFFFF;
                DAQ.Accelometer_Y += (Int32)SP1.ReceiveBuf[19] * 0x0000FFFF;
                DAQ.Accelometer_Y += (Int32)SP1.ReceiveBuf[20] * 0x000000FF;
                DAQ.Accelometer_Y += (Int32)SP1.ReceiveBuf[21];
                DAQ.Accelometer_Yf = ((float)DAQ.Accelometer_Y) / 10000;

                DAQ.Accelometer_Z = (Int32)SP1.ReceiveBuf[22] * 0x00FFFFFF;
                DAQ.Accelometer_Z += (Int32)SP1.ReceiveBuf[23] * 0x0000FFFF;
                DAQ.Accelometer_Z += (Int32)SP1.ReceiveBuf[24] * 0x000000FF;
                DAQ.Accelometer_Z += (Int32)SP1.ReceiveBuf[25];
                DAQ.Accelometer_Zf = ((float)DAQ.Accelometer_Z) / 10000;
                */
                //       if (DAQ.Int_Counter == 3) Array_Fill_new();
                //       if (DAQ.Int_Counter == 8) Plot_Chart_new();
                //     Array_Fill();
                //     Plot_Chart();

                DAQ.Int_Counter++;
                if (DAQ.Int_Counter >= 10)
                {
                    DAQ.Int_Counter = 0;        
                //    Array_Fill();
                //   Plot_Chart();
                
                    if (DAQ.Enc_Ang_Speed_Abs > 20)
                    {
                        if (DAQ.Speed_Animation_Latch == 0)
                            try
                            {
                                pictureBox1.Image = Image.FromFile("C:\\Projects\\.Net\\VOI_DAQ\\VOI_DAQ\\Pics\\spinning_wheel.gif");
                                DAQ.Speed_Animation_Latch = 1;
                                DAQ.No_Animation_Latch = 0;
                            }
                            catch { }                   
                    }
                    else {
                        if (DAQ.No_Animation_Latch == 0) {
                            try
                            {
                                pictureBox1.Image = Image.FromFile("C:\\Projects\\.Net\\VOI_DAQ\\VOI_DAQ\\Pics\\spinning_wheel3.jpg");
                                DAQ.No_Animation_Latch = 1;
                                DAQ.Speed_Animation_Latch = 0;
                            }
                             catch { }
                        }
                    }                   
                }
                if (DAQ.Int_Counter == 2) Array_Fill();
                if (DAQ.Int_Counter == 4) Plot_Chart();
                if (DAQ.Int_Counter == 6) Array_Fill();
                if (DAQ.Int_Counter == 8) Plot_Chart();

                if (DAQ.Log_Status == true)
                {
                    if (SP1_serialPort.IsOpen == false)
                    {
                        DAQ.Log_Status = false;
                        MessageBox.Show("Com Port Error!" + DAQ.nl + "Loggging Disabled");
                        DAQ.Log_Counter = 0;
                        startToolStripMenuItem.Enabled = true;
                        stopToolStripMenuItem.Enabled = false;
                    }
                    else
                    {
                        LOG_DataLogProcess(DAQ.Original_Log_File);
                        startToolStripMenuItem.Enabled = false;
                       // stopToolStripMenuItem.Enabled = false;
                    }
                }
            }
        }



        double  Get_Motor_eff()
        {
            DAQ.MotorEff[0] = 28;
            DAQ.MotorEff[1] = 29;
            DAQ.MotorEff[2] = 30;
            DAQ.MotorEff[3] = 31;
            DAQ.MotorEff[4] = 32;
            DAQ.MotorEff[5] = 33;
            DAQ.MotorEff[6] = 34;
            DAQ.MotorEff[7] = 35;
            DAQ.MotorEff[8] = 36;
            DAQ.MotorEff[9] = 37;

            DAQ.MotorEff[10] = 38;
            DAQ.MotorEff[11] = 40;
            DAQ.MotorEff[12] = 45;
            DAQ.MotorEff[13] = 50;
            DAQ.MotorEff[14] = 55;
            DAQ.MotorEff[15] = 60;
            DAQ.MotorEff[16] = 65;
            DAQ.MotorEff[17] = 70;
            DAQ.MotorEff[18] = 75;
            DAQ.MotorEff[19] = 80;
            DAQ.MotorEff[20] = 85;

            DAQ.MotorRpm[0] = 25;
            DAQ.MotorRpm[1] = 30;
            DAQ.MotorRpm[2] = 40;
            DAQ.MotorRpm[3] = 50;
            DAQ.MotorRpm[4] = 60;
            DAQ.MotorRpm[5] = 70;
            DAQ.MotorRpm[6] = 80;
            DAQ.MotorRpm[7] = 90;
            DAQ.MotorRpm[8] = 100;
            DAQ.MotorRpm[9] = 110;

            DAQ.MotorRpm[10] = 120;
            DAQ.MotorRpm[11] = 140;
            DAQ.MotorRpm[12] = 180;
            DAQ.MotorRpm[13] = 190;
            DAQ.MotorRpm[14] = 230;
            DAQ.MotorRpm[15] = 250;
            DAQ.MotorRpm[16] = 320;
            DAQ.MotorRpm[17] = 380;
            DAQ.MotorRpm[18] = 420;
            DAQ.MotorRpm[19] = 620;
            DAQ.MotorRpm[20] = 650;
            for (int i = 0; i < 21; i++)
            {
                if (Math.Abs(DAQ.Vehicle_Ang_Speed_Abs) < (DAQ.MotorRpm[i]))
                {
                  //  DAQ.Motor_Eff = DAQ.MotorEff[i];
                    return DAQ.MotorEff[i];
                }
            }
            return DAQ.MotorEff[20];

        }
        void Calculate_Mechanical()
        {
            DAQ.Motor_Eff  = Get_Motor_eff();


            // = TAN(B5 / 100) * 180 / PI()
            DAQ.Angle = Math.Tan(DAQ.Slope / 100) * 180 / Math.PI;
            //    DAQ.Torque =
            DAQ.Mech_Power = (DAQ.Motor_Eff/100) * DAQ.Power; // eeff 0.1-0,9

            if (DAQ.Vehicle_Ang_Speed_Abs == 0) DAQ.Torque = 0;
            else
            {
                DAQ.Torque = DAQ.Mech_Power * 0.0095488; //Nm     9.5488 kw -> 0.0095488 Watt
                DAQ.Torque /=  DAQ.Vehicle_Ang_Speed_Abs;
            }
/*
                DAQ.Torque = DAQ.Mech_Power * 9.549; //Nm    9.549)
            if (DAQ.Vehicle_Ang_Speed_Abs != 0) DAQ.Torque = DAQ.Torque / DAQ.Vehicle_Ang_Speed_Abs; //Nm     
            else DAQ.Torque = 0;//     DAQ.Weight
*/
            DAQ.Radcalc = DAQ.Angle * (Math.PI / 180) / 100;

            DAQ.Torque_Friction = 2.00; //
            DAQ.Weight1 = DAQ.Torque_Friction / (DAQ.FrictionCoeff * 9.8 * Math.Cos(DAQ.Radcalc));
            DAQ.Torque_Gradient = DAQ.Torque - DAQ.Torque_Friction;
            DAQ.Weight2 = (DAQ.Torque_Gradient / ((double)DAQ.Vehicle_Speed * 9.8 /3.6 * Math.Sin(DAQ.Radcalc)));
            DAQ.Weight = (DAQ.Weight1 + DAQ.Weight2)/2;

            if (DAQ.Weight == 0) DAQ.Weight = 0.01;
            if (DAQ.Weight > 200) DAQ.Weight = 200;

            //    DAQ.Weight1 = ((double)DAQ.Torque_Gradient / ((double)DAQ.Vehicle_Speed * 9.8 * Math.Sin(DAQ.Radcalc)));
            //   DAQ.Weight2 = ((double)DAQ.Torque_Friction / ((double)DAQ.Friction* 9.8 * Math.Cos(DAQ.Radcalc)));
                //    DAQ.Torque_Gradient
                //   DAQ.Torque_Friction = DAQ.Torque - DAQ.Torque_Gradient;

        }
        String MechPower_GetTextData()
        {
            Calculate_Mechanical();
            String Textdata = "Angle " + DAQ.Angle.ToString("#.##") + "°" + DAQ.nl;
            Textdata += "Eff %" + DAQ.Motor_Eff.ToString("#.##")  + DAQ.nl;
            Textdata += "M.Power " + DAQ.Mech_Power.ToString("##.#") + "Watts " + DAQ.nl;
            Textdata += "Torque " + DAQ.Torque.ToString("##.######") + "Nm " + DAQ.nl;
            Textdata += "Weight " + DAQ.Weight.ToString("###") + "Kg " + DAQ.nl;
        //    Textdata += "Torque " + DAQ.Torque.ToString("#.###") + "Nm " + DAQ.nl;
       //     Textdata += "Weight " + DAQ.Weight.ToString("###.#") + "Kg " + DAQ.nl;
            return Textdata;
        }

            // Speed_richTextBox
            String Electical_GetTextData()
        {         
      //      String Textdata =  (DAQ.Current/1000).ToString() + '.' + (DAQ.Current % 1000).ToString("D2") + " Amp" + DAQ.nl;
          
          //  String Textdata = DAQ.Current.ToString("#.#") + " mAmp" + DAQ.nl;
            String Textdata = (DAQ.Current_d).ToString("#.##") + " Amp" + DAQ.nl;
      //      Textdata += DAQ.Voltage.ToString("#.#") +  " mVolt" + DAQ.nl;
            Textdata += (DAQ.Voltage_d ).ToString("#.##") + " Volt" + DAQ.nl;

            //  DAQ.Power = (Int32)((DAQ.Current) * (DAQ.Voltage));
            //        Textdata +=  (DAQ.Power/100).ToString() + '.' + (DAQ.Power % 10000).ToString() + " Watt" + DAQ.nl;
            DAQ.Power = ((DAQ.Voltage_d * DAQ.Current_d));
     //   Textdata += ((DAQ.Voltage* DAQ.Current)/1000000).ToString("#.##") + " Watt" + DAQ.nl;
            Textdata += DAQ.Power.ToString("#.#") + " Watt" + DAQ.nl;
            Textdata += DAQ.PowerConsumption.ToString("#.##") + " Watt/km" + DAQ.nl;
            //  https://stackoverflow.com/questions/164926/how-do-i-display-a-decimal-value-to-2-decimal-places
            return Textdata;
        }
       String Speed_GetTextData()
        {
            //       String Textdata = Math.Round((Diameter * DAQ.Angular_Speed_Wheel  * 6 *  Math.PI / 10000),2).ToString();
            String Textdata = Math.Round(DAQ.Vehicle_Speed, 2).ToString();
            Textdata += " km/h " + System.Environment.NewLine;
            Textdata += DAQ.Vehicle_Ang_Speed_Abs.ToString() + " rpm" + System.Environment.NewLine;
            /*
            if (DAQ.EncoderAccumSign == 1) Textdata += "+";
            else Textdata += "-";
            Textdata +=  ((double)DAQ.TravelAcc / 1000).ToString() + " meters ";
            */
            //Textdata += ((double)DAQ.Encoder_Tot_Distance / 1000).ToString("#.###") + " meters";
            Textdata += DAQ.Encoder_Tot_Distance.ToString() + " mm";
            return Textdata;
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

          //  String Textdata = "Received Data " + System.Environment.NewLine;
            String Textdata = "Preamble " + "0X" + SP1.Preamble.ToString("X") + System.Environment.NewLine;
            Textdata += "Preamble_Sync "  + SP1.Preamble_Trial.ToString( ) + System.Environment.NewLine;


            Textdata += "Data Len:" + SP1.Length.ToString() + System.Environment.NewLine;
            Textdata += "CRC_Recv." + "0X" + SP1.CRC_Received.ToString("X") + System.Environment.NewLine;
            Textdata += "CRC_Calc. " + "0X" + SP1.CRC_Calc.ToString("X") + System.Environment.NewLine;
            Textdata += "CRC_Err. " + SP1.CRC_Error.ToString() + System.Environment.NewLine;
            Textdata += "CRC_Suc.  " + SP1.CRC_Success.ToString() + System.Environment.NewLine;

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



            //     Textdata += "DAQ.Max_Array_Size " + DAQ.Max_Array_Size + DAQ.nl;
            //    Textdata += "DAQ.Index " + DAQ.Index + DAQ.nl; 
            //     Textdata += "DAQ.ChartSize " + DAQ.ChartSize + DAQ.nl;
            //    Textdata += "DAQ.bp " + DAQ.bp + DAQ.nl;
            //    Textdata += "DAQ.sp " + DAQ.sp + DAQ.nl;

            /*
            Textdata += "EncoderAccum: ";

            if (DAQ.EncoderAccumSign == 0) Textdata += "-";
            else Textdata += "+";
            Textdata += DAQ.EncoderAccum.ToString() +  " 0X" + DAQ.EncoderAccum.ToString("X") + System.Environment.NewLine;
       //     Textdata += "EncoderRaw : " + DAQ.EncoderAccumSign.ToString() + " Pulse " + System.Environment.NewLine;
            Textdata += "Encoder : " + DAQ.Encoder.ToString() + " 0X" + DAQ.Encoder.ToString("X") + System.Environment.NewLine;
            Textdata += "EncoderH : " + DAQ.EncoderH.ToString() + " 0X" + DAQ.EncoderH.ToString("X") + System.Environment.NewLine;
            Textdata += "EncoderL : " + DAQ.EncoderL.ToString() + " 0X" + DAQ.EncoderL.ToString("X") + System.Environment.NewLine;
            */

            //    Textdata += "VehicleSpeed : " + DAQ.VehicleSpeed.ToString() + " km/h " + System.Environment.NewLine;

            if (DAQ.Simulator_Electric == true) Textdata += "Electric Simulator On ";
            else Textdata += "Electric Simulator Off";
            Textdata += DAQ.nl;
            if (DAQ.Simulator_Rpm == true) Textdata += "Rpm Simulator On ";
            else Textdata += "Rpm Simulator Off";
            Textdata += DAQ.nl;
            Textdata += "Current " + DAQ.Current_Adc.ToString() + "Adc  " + DAQ.Current_d.ToString("#.##") + " Amp" +  DAQ.nl;
            Textdata += "Voltage " + DAQ.Voltage_Adc.ToString() + "Adc  " + DAQ.Voltage_d.ToString("#.##") + " Volt" + DAQ.nl;

      //      Textdata += "Power : " + DAQ.Power.ToString() + " Watt" + System.Environment.NewLine;
            Textdata += "Temperature : " + DAQ.Temperature.ToString() + " C" + System.Environment.NewLine;

            Textdata += "Encoder Speed: " + DAQ.Enc_Ang_Speed_Abs.ToString() + " rpm " + System.Environment.NewLine;
            Textdata += "Encoder_Abs_Init: " +  " 0X" + DAQ.Encoder_Abs_Init.ToString("X") + System.Environment.NewLine;
            Textdata += "Encoder_Abs : " +  " 0X" + DAQ.Encoder_Abs.ToString("X") + System.Environment.NewLine;
            Textdata += "Encoder_Diff : " + DAQ.Encoder_Diff.ToString() + " 0X" + DAQ.Encoder_Diff.ToString("X") + System.Environment.NewLine;
            Textdata += "Tot Distance  : "  + DAQ.Encoder_Tot_Distance.ToString( ) + " mm "+ System.Environment.NewLine;


            //    Textdata += "pf " + pf + DAQ.nl;
 /*           Textdata += "Accelometer_xP " + DAQ.Accelometer_xP + DAQ.nl;
            Textdata += "Accelometer X " + DAQ.Accelometer_Xf + DAQ.nl;
            Textdata += "Accelometer_yP " + DAQ.Accelometer_yP + DAQ.nl;
            Textdata += "Accelometer Y " + DAQ.Accelometer_Yf + DAQ.nl;
            Textdata += "Accelometer_zP " + DAQ.Accelometer_zP + DAQ.nl;
            Textdata += "Accelometer Z " + DAQ.Accelometer_Zf;
*/
            return Textdata;
        }


        void Base_Timer1mSec_Tick(object sender, EventArgs e)
        {
            Timer_1sec++; // 16mSec
            if (Timer_1sec > 8)
            {
                Timer_1sec = 0;
                   Task_Counter++;
                    if (Task_Counter > 4) Task_Counter = 0;  // 8-> 1 sec                     
                                                             //      Update_Chart = 1;
                                                             //       Plot_Chart();

            //    if (Task_Counter == 1) 
                    SP1_richTextBox.Text = SP1_GetTextdata(); // main informative screen
            //    if (Task_Counter == 2) 
                    SP1_DatatextBox.Text = SP1_GetTextdata2();  // all data in hex format screen
            //  if (Task_Counter == 3)  
                    Speed_richTextBox.Text = Speed_GetTextData(); // main speed rpm / km gauge

                richTextBox_Electrical.Text = Electical_GetTextData();

                Power_richTextBox.Text = MechPower_GetTextData();

                //      SP1_SendtextBox.Text = DAQ.Index.ToString();
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
                 //     plotSurface2D1.BackgroundImage = null;
                    //   Plot_Chart();
                //    pictureBox2.Visible = false;
                }
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
                //      SP1_IO_Serial_UpdateCOMPortList();
                /*
                if (SP1_serialPort.IsOpen)
                    Serial_UpdateCOMPortList_VID_PID();
                */
            }
            catch { }

        }
        void Array_Fill()
        {
            // return;
            if (DAQ.sp >= DAQ.MAX_ARRAY_SIZE - 1) // sp   899 . 900 1799>=1799
            {
                DAQ.sp = DAQ.MAX_ARRAY_SIZE - 1;
                for (int t = 1; t <= DAQ.sp; t++) // sp 0<-1 898<-899  DAQ.MAX_ARRAY_SIZE - 2  0-1798
                {
                    //   DAQ.Index_Arr[t-1] = DAQ.Index_Arr[t];//0
                    DAQ.Speed_Arr[t - 1] = DAQ.Speed_Arr[t];
                    DAQ.Current_Arr[t - 1] = DAQ.Current_Arr[t];
                    DAQ.Voltage_Arr[t - 1] = DAQ.Voltage_Arr[t];
                    //   DAQ.Power_Arr[t] = DAQ.Power_Arr[t];
                    DAQ.Temperature_Arr[t - 1] = DAQ.Temperature_Arr[t];
                }
            }
            else
            {
                DAQ.sp++; // sp  0 - 898
            }
            DAQ.Speed_Arr[DAQ.sp] = DAQ.Vehicle_Speed.ToString();
            double ValTemp = DAQ.Current / 10;
            ValTemp /= 100;
            DAQ.Current_Arr[DAQ.sp] = ValTemp.ToString();
            //      DAQ.Current_Arr[DAQ.sp] = ((double)(DAQ.Current/100)).ToString();
            ValTemp = DAQ.Voltage / 10;
            ValTemp /= 1000;
            //   DAQ.Voltage_Arr[DAQ.sp] = ((double)(DAQ.Voltage/100)).ToString();
            DAQ.Voltage_Arr[DAQ.sp] = ValTemp.ToString();
            DAQ.Temperature_Arr[DAQ.sp] = DAQ.Temperature.ToString();
            // Adjust bp
            if (DAQ.sp >= DAQ.ChartSize) // 300 550 // bp->250
                DAQ.bp = (Int16)(DAQ.sp - DAQ.ChartSize);//1-300
            else DAQ.bp = 0;

        }
        void Plot_Chart()
        {
            //  return;
            if (DAQ.Plot_Init != 32)
            {
                DAQ.Plot_Init = 32;
                // plotSurface2D1.BackgroundImage = null;
                pictureBox2.Visible = false;
            }

            NPlot.Grid grid = new NPlot.Grid();
            NPlot.LinePlot Graph1 = new NPlot.LinePlot();
            NPlot.LinePlot Graph2 = new NPlot.LinePlot();
            NPlot.LinePlot Graph3 = new NPlot.LinePlot();
            NPlot.LinePlot Graph4 = new NPlot.LinePlot();

            Graph1.Pen = new Pen(Color.Red, 1);
            Graph2.Pen = new Pen(Color.Blue, 2);
            Graph3.Pen = new Pen(Color.Green, 1);
            Graph4.Pen = new Pen(Color.Gold, 1);   // 

            List<String> X_Data = new List<String>();
            List<String> Data1 = new List<String>();
            List<String> Data2 = new List<String>();
            List<String> Data3 = new List<String>();
            List<String> Data4 = new List<String>();


            plotSurface2D1.Clear();

            //     Plot_Create_Instance();
            //     Plot_Init();
            X_Data.Clear();
            Data1.Clear();
            Data2.Clear();
            Data3.Clear();
            Data4.Clear();

            //     plotSurface2D1.Clear();
            /*
                        grid.VerticalGridType = NPlot.Grid.GridType.Coarse;
                        grid.HorizontalGridType = NPlot.Grid.GridType.Coarse;
                        grid.MajorGridPen = new Pen(Color.LightGray, 1.0f);
                        grid.MinorGridPen = new Pen(Color.LightGray, 1.0f);
            */
            plotSurface2D1.Add(grid);

            //  float FloatNum;

            for (Int16 t = DAQ.bp; t <= DAQ.sp; t++)
            {
                //   Single.TryParse(DAQ.Index_Arr[t], out FloatNum); X_Data.Add(FloatNum.ToString());
                //    X_Data.Add(DAQ.Index_Arr[t].ToString());
                X_Data.Add(t.ToString());
                //     Single.TryParse(DAQ.Speed_Arr[t], out FloatNum); Data1.Add(FloatNum.ToString());
                Data1.Add(DAQ.Speed_Arr[t].ToString());
                //      Single.TryParse(DAQ.Current_Arr[t], out FloatNum); Data2.Add(FloatNum.ToString());
                Data2.Add(DAQ.Current_Arr[t].ToString());
                //       Single.TryParse(DAQ.Voltage_Arr[t], out FloatNum); Data3.Add(FloatNum.ToString());
                Data3.Add(DAQ.Voltage_Arr[t].ToString());
                //  Single.TryParse(DAQ.Temperature_Arr[t], out FloatNum); Data4.Add(FloatNum.ToString()); // akim se
                Data4.Add(DAQ.Temperature_Arr[t].ToString());
            }


            Graph1.AbscissaData = X_Data;
            Graph1.DataSource = Data1;
            Graph2.AbscissaData = X_Data;
            Graph2.DataSource = Data2;
            Graph3.AbscissaData = X_Data;
            Graph3.DataSource = Data3;
            Graph4.AbscissaData = X_Data;
            Graph4.DataSource = Data4;

            if (checkBox_Speed.Checked == true) plotSurface2D1.Add(Graph1);
            if (checkBox_Current.Checked == true) plotSurface2D1.Add(Graph2);
            if (checkBox_Voltage.Checked == true) plotSurface2D1.Add(Graph3);
            if (checkBox_Temperature.Checked == true) plotSurface2D1.Add(Graph4);

            if (!((checkBox_Speed.Checked == true) || (checkBox_Current.Checked == true) ||
                    (checkBox_Voltage.Checked == true) || (checkBox_Temperature.Checked == true)))
            {
                for (Int16 t = DAQ.bp; t <= DAQ.sp; t++)
                {
                    Data1.Clear();
                    Data1.Add("0");
                }
                plotSurface2D1.Add(Graph1);
            }

            plotSurface2D1.ShowCoordinates = true;
            //      plotSurface2D1.YAxis1.Label = "";
            plotSurface2D1.YAxis1.LabelOffsetAbsolute = true;
            plotSurface2D1.YAxis1.LabelOffset = 0;
            plotSurface2D1.YAxis1.HideTickText = false;

            //     plotSurface2D1.XAxis1.Label = " Test Variables ";
            plotSurface2D1.Padding = 5;
            plotSurface2D1.AutoScaleTitle = true;
            //  plotSurface2D1.BackColor = 
            /*
            if (!((checkBox_Speed.Checked == false) && (checkBox_Current.Checked == false) &&
                    (checkBox_Voltage.Checked == false) && (checkBox_Temperature.Checked == false)))
            {
                plotSurface2D1.Refresh();
            }
            */
            plotSurface2D1.Refresh();
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
            if (Hour < 10) HourZero = "0";// else HourZero = "";
            if (Min < 10) MinZero = "0"; //else MinZero = "";
            if (Sec < 10) SecZero = "0";// else SecZero = "";
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
            startToolStripMenuItem.Enabled = true;

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
            //        DataFile = LOG_ReadStream(sr, path); // read data from file
            DataFile = LOG_ReadStream(sr); // read data from file
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
        //    public String LOG_ReadStream(StreamReader Sr, String path)
        public String LOG_ReadStream(StreamReader Sr)
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
                    {
                        Sw.WriteLine(data + (DAQ.Log_Counter + DAQ.Log_FileCount).ToString() + LOG_PrepareData_2WriteFile_01());
                        DAQ.Log_Counter++;
                    }
                    // ilk sira     
                    else
                    {
                        DAQ.Log_Counter = 1;
                        String Mystring = " Log No,   Date, Time , Speed(rpm), Distance(mm), Voltage(Volt), Current(Amps),Temperature (C)";
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
            Mystring += DAQ.Enc_Ang_Speed_Abs.ToString() + "," + DAQ.Encoder_Tot_Distance.ToString() + "," + DAQ.Voltage_d.ToString() + "," + DAQ.Current_d.ToString() +
                 "," + DAQ.Temperature.ToString() + ",";
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

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
         //   Okyanus.Chart.Play = false;
         //   ChartPlayPause();
            LOG_File_Stop();
            startToolStripMenuItem.Enabled = true;
        }

        public void SetArrayColors()
        {
            toolStripMenuItem2.ForeColor = Color.Black;
            toolStripMenuItem3.ForeColor = Color.Black;
            toolStripMenuItem4.ForeColor = Color.Black;
            toolStripMenuItem5.ForeColor = Color.Black;
            toolStripMenuItem6.ForeColor = Color.Black;

            switch (DAQ.ChartSize)
            {
                case DAQ.SAMPLE_10SEC:
                    toolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                 
                    break;
                case DAQ.SAMPLE_20SEC:
                    toolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                  
                    break;
                case DAQ.SAMPLE_1MIN:
                    toolStripMenuItem4.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    
                    break;
                case DAQ.SAMPLE_2MIN:
                    toolStripMenuItem5.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                    
                    break;
                case DAQ.SAMPLE_3MIN:
                    toolStripMenuItem6.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
                   
                    break;
            }





        //    DAQ.Max_Array_Size = Ref;
        //    if (DAQ.Index > DAQ.Max_Array_Size) DAQ.Index = 0;
       
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_10SEC;
            SetArrayColors();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_20SEC;
            SetArrayColors();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_1MIN;
            SetArrayColors();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            DAQ.ChartSize = DAQ.SAMPLE_2MIN;
            SetArrayColors();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {   
            DAQ.ChartSize = DAQ.SAMPLE_3MIN;
            SetArrayColors();
        }

        private void button_Reset_Distance_Click(object sender, EventArgs e)
        {
              DAQ.Encoder_Abs_Init = DAQ.Encoder_Abs; // First Data read from dspic
        }
        /*
private void label2_Click(object sender, EventArgs e)
{

}

private void pictureBox1_Click(object sender, EventArgs e)
{

}

private void Speed_richTextBox_TextChanged(object sender, EventArgs e)
{

}

private void label2_Click(object sender, EventArgs e)
{

}


private void systemTimeToolStripMenuItem_Click(object sender, EventArgs e)
{

}
*/


        void FuncT() { 
        
        }

        private void numericUpDown_incline_ValueChanged(object sender, EventArgs e)
        {
            DAQ.Slope = (double) numericUpDown_incline.Value;
        }

        private void communicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Simulator form = new Simulator();
            form.Init_Text();
            form.button_Current_Click(sender, e);
            form.Show();
            DAQ.Simulator_Electric = true;
            form.checkBox_Simulator_State.Checked = true;
        }

        private void numericUpDown_Wheel_ValueChanged(object sender, EventArgs e)
        {
            DAQ.Wheel_Diameter = (Int16)numericUpDown_Wheel.Value;
        }
    }


}

