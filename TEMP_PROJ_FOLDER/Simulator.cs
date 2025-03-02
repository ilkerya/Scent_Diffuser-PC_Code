using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//namespace VOI_DAQ
     namespace TemplateProject
{
    public partial class Simulator : Form
    {
        public Simulator()
        {
            InitializeComponent();
        }
        /*
        private void Form1_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("I was closed 1");
        }
        */
        private void Update_TextBox()
        {
          //  richTextBox_Outputs.Text = "Current Adc : " + DAQ.Current_Adc.ToString() + DAQ.nl +
         //                              "Voltage Adc : " + DAQ.Voltage_Adc.ToString() + DAQ.nl;

         //   richTextBox_Outputs.Text += "Rpm Encoder : ";

         //  if (DAQ.Direction == 128) richTextBox_Outputs.Text += "-";
          //  else richTextBox_Outputs.Text += "+";

          //  richTextBox_Outputs.Text +=   DAQ.Enc_Ang_Speed_Abs.ToString();
        }
        public void Init_Text()
        {
            /*
            if (DAQ.Simulator_Init == false)
            {
                DAQ.Simulator_Init = true;
                UInt16.TryParse(richTextBox_Current.Text, out DAQ.Current_Simulator);
                UInt16.TryParse(richTextBox_Voltage.Text, out DAQ.Voltage_Simulator);
            }
            else
            {
                richTextBox_Current.Text = DAQ.Current_Simulator.ToString();
                richTextBox_Voltage.Text = DAQ.Voltage_Simulator.ToString();
            }
            */
        }
public  void Update_Rpm_Sim_Values()
        {
            /*
            Int32 Max_Encoder_Ang_Speed = 703 * 1024; // 2800 
            Max_Encoder_Ang_Speed *= DAQ.Wheel_Diameter;
            Max_Encoder_Ang_Speed /= 13510;
            Int32 Min_Encoder_Ang_Speed = -1 * Max_Encoder_Ang_Speed;
            richTextBox_rpm_min.Text = Min_Encoder_Ang_Speed.ToString();
            richTextBox_rpm_max.Text = Max_Encoder_Ang_Speed.ToString();

            Int16 Angular_Speed;

            Int16.TryParse(richTextBox_Rpm.Text, out Angular_Speed);
            if (Angular_Speed > Max_Encoder_Ang_Speed)
            {
                Angular_Speed = (Int16)Max_Encoder_Ang_Speed;

                richTextBox_Rpm.Text = Max_Encoder_Ang_Speed.ToString();
            }
            if (Angular_Speed < Min_Encoder_Ang_Speed)
            {
                Angular_Speed = (Int16)Min_Encoder_Ang_Speed;

                richTextBox_Rpm.Text = Min_Encoder_Ang_Speed.ToString();
            }
            DAQ.AngularSpeed_Simulator = (UInt16)Math.Abs(Angular_Speed);

        //    if (Angular_Speed >= 0) DAQ.AngularSpeedDirection_Simulator = 0;
        //    else DAQ.AngularSpeedDirection_Simulator = 128;

            if (DAQ.Simulator_Rpm == true)
            {
           //     DAQ.Enc_Ang_Speed_Raw = DAQ.AngularSpeed_Simulator;
          //      DAQ.Direction = DAQ.AngularSpeedDirection_Simulator;
            }
            */
        }
        public void Update_Electrical_Sim_Values()
        {
            /*
              
            UInt16.TryParse(richTextBox_Current.Text, out DAQ.Current_Simulator);
            UInt16.TryParse(richTextBox_Voltage.Text, out DAQ.Voltage_Simulator);

            if (DAQ.Current_Simulator > 4095)
            {
                DAQ.Current_Simulator = 4095;
                richTextBox_Current.Text = "4095";
            }
            DAQ.Current_Adc = DAQ.Current_Simulator;



            if (DAQ.Voltage_Simulator > 4095)
            {
                DAQ.Voltage_Simulator = 4095;
                richTextBox_Voltage.Text = "4095";
            }
            DAQ.Voltage_Adc = DAQ.Voltage_Simulator;
            */
        }
        public void button_Current_Click(object sender, EventArgs e)
        {
        //    Update_Electrical_Sim_Values();
         //   Update_Rpm_Sim_Values();
          //  Update_TextBox();
        }

        private void checkBox_Simulator_State_CheckedChanged(object sender, EventArgs e)
        {
            /*
            if(checkBox_Simulator_State.Checked)
            {
                DAQ.Simulator_Electric = true;
            }
            else
            {
                DAQ.Simulator_Electric = false; 
            }
            */
        }

        private void checkBox_Rpm_Enabled_CheckedChanged(object sender, EventArgs e)
        {
            // Simulator_Electric
           // checkBox_Rpm_Enabled.Checked = true;
           /*
            if (checkBox_Rpm_Enabled.Checked)
            { 
                DAQ.Simulator_Rpm = true;
            }
            else
            {
                DAQ.Simulator_Rpm = false;
            }
            */
        //    Update_Rpm_Sim_Values();
        //   Update_TextBox();

        }

        private void richTextBox_Rpm_TextChanged(object sender, EventArgs e)
        {
            //MessageBox.Show("Changed");
        }
        /*
private void button_Voltage_Click(object sender, EventArgs e)
{

//    Update_TextBox();


}
*/
    }
}
