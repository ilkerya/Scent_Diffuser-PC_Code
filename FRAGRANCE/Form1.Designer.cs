

namespace DAQ_VOC
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.SP1_serialPort = new System.IO.Ports.SerialPort(this.components);
            this.Base_Timer1mSec = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SP1_SendtextBox = new System.Windows.Forms.TextBox();
            this.SP1_DisConnectButton = new System.Windows.Forms.Button();
            this.SP1_IO_Serial_lstCOMPorts = new System.Windows.Forms.ComboBox();
            this.SP1_ConnectButton = new System.Windows.Forms.Button();
            this.SP1_textBox_PortName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SP1_SendButton = new System.Windows.Forms.Button();
            this.SP1_DatatextBox = new System.Windows.Forms.TextBox();
            this.SP1_richTextBox = new System.Windows.Forms.RichTextBox();
            this.checkBox_Voc4 = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc3 = new System.Windows.Forms.CheckBox();
            this.checkBox_Temperature = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc2 = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc1 = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotSurface2D1 = new NPlot.Windows.PlotSurface2D();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.checkBox_Humidity = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc4_Median = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc3_Median = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc2_Median = new System.Windows.Forms.CheckBox();
            this.checkBox_Voc1_Median = new System.Windows.Forms.CheckBox();
            this.SP1_textBox_Device = new System.Windows.Forms.TextBox();
            this.richTextBox_BME680 = new System.Windows.Forms.RichTextBox();
            this.richTextBox_BME680_2 = new System.Windows.Forms.RichTextBox();
            this.textBox_FanPWM = new System.Windows.Forms.TextBox();
            this.numericUpDown_PWM = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PWM)).BeginInit();
            this.SuspendLayout();
            // 
            // SP1_serialPort
            // 
            this.SP1_serialPort.BaudRate = 115200;
            this.SP1_serialPort.PortName = "COM2";
            this.SP1_serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SP1_serialPort_DataReceived);
            // 
            // Base_Timer1mSec
            // 
            this.Base_Timer1mSec.Enabled = true;
            this.Base_Timer1mSec.Interval = 16;
            this.Base_Timer1mSec.Tick += new System.EventHandler(this.Base_Timer1mSec_Tick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(258, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 40);
            this.button1.TabIndex = 736;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SP1_SendtextBox
            // 
            this.SP1_SendtextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_SendtextBox.Location = new System.Drawing.Point(11, 179);
            this.SP1_SendtextBox.Multiline = true;
            this.SP1_SendtextBox.Name = "SP1_SendtextBox";
            this.SP1_SendtextBox.Size = new System.Drawing.Size(329, 72);
            this.SP1_SendtextBox.TabIndex = 729;
            this.SP1_SendtextBox.Text = "Send Log";
            // 
            // SP1_DisConnectButton
            // 
            this.SP1_DisConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_DisConnectButton.Enabled = false;
            this.SP1_DisConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_DisConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_DisConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_DisConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_DisConnectButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_DisConnectButton.Location = new System.Drawing.Point(472, 48);
            this.SP1_DisConnectButton.Name = "SP1_DisConnectButton";
            this.SP1_DisConnectButton.Size = new System.Drawing.Size(102, 29);
            this.SP1_DisConnectButton.TabIndex = 732;
            this.SP1_DisConnectButton.Text = "Close";
            this.SP1_DisConnectButton.UseVisualStyleBackColor = false;
            this.SP1_DisConnectButton.Visible = false;
            this.SP1_DisConnectButton.Click += new System.EventHandler(this.SP1_DisConnectButton_Click);
            // 
            // SP1_IO_Serial_lstCOMPorts
            // 
            this.SP1_IO_Serial_lstCOMPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_IO_Serial_lstCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SP1_IO_Serial_lstCOMPorts.ForeColor = System.Drawing.Color.Black;
            this.SP1_IO_Serial_lstCOMPorts.Items.AddRange(new object[] {
            "COM56"});
            this.SP1_IO_Serial_lstCOMPorts.Location = new System.Drawing.Point(595, 53);
            this.SP1_IO_Serial_lstCOMPorts.Name = "SP1_IO_Serial_lstCOMPorts";
            this.SP1_IO_Serial_lstCOMPorts.Size = new System.Drawing.Size(129, 24);
            this.SP1_IO_Serial_lstCOMPorts.TabIndex = 731;
            this.SP1_IO_Serial_lstCOMPorts.Visible = false;
            // 
            // SP1_ConnectButton
            // 
            this.SP1_ConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_ConnectButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_ConnectButton.Location = new System.Drawing.Point(13, 86);
            this.SP1_ConnectButton.Name = "SP1_ConnectButton";
            this.SP1_ConnectButton.Size = new System.Drawing.Size(121, 85);
            this.SP1_ConnectButton.TabIndex = 730;
            this.SP1_ConnectButton.Text = "Connect";
            this.SP1_ConnectButton.UseVisualStyleBackColor = false;
            this.SP1_ConnectButton.Click += new System.EventHandler(this.SP1_ConnectButton_Click);
            // 
            // SP1_textBox_PortName
            // 
            this.SP1_textBox_PortName.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_textBox_PortName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_textBox_PortName.Location = new System.Drawing.Point(142, 86);
            this.SP1_textBox_PortName.Multiline = true;
            this.SP1_textBox_PortName.Name = "SP1_textBox_PortName";
            this.SP1_textBox_PortName.Size = new System.Drawing.Size(108, 85);
            this.SP1_textBox_PortName.TabIndex = 735;
            this.SP1_textBox_PortName.Text = "COM23 \r\n57600 bps\r\nVID.AD4E \r\nPID.EEDE";
            this.SP1_textBox_PortName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 24);
            this.label1.TabIndex = 733;
            this.label1.Text = "Interface Connection";
            this.label1.Visible = false;
            // 
            // SP1_SendButton
            // 
            this.SP1_SendButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_SendButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_SendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_SendButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_SendButton.Location = new System.Drawing.Point(258, 134);
            this.SP1_SendButton.Name = "SP1_SendButton";
            this.SP1_SendButton.Size = new System.Drawing.Size(80, 40);
            this.SP1_SendButton.TabIndex = 734;
            this.SP1_SendButton.Text = "Send";
            this.SP1_SendButton.UseVisualStyleBackColor = false;
            this.SP1_SendButton.Click += new System.EventHandler(this.SP1_SendButton_Click);
            // 
            // SP1_DatatextBox
            // 
            this.SP1_DatatextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_DatatextBox.Location = new System.Drawing.Point(13, 257);
            this.SP1_DatatextBox.Multiline = true;
            this.SP1_DatatextBox.Name = "SP1_DatatextBox";
            this.SP1_DatatextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SP1_DatatextBox.Size = new System.Drawing.Size(329, 272);
            this.SP1_DatatextBox.TabIndex = 738;
            this.SP1_DatatextBox.Text = "Receive Log";
            // 
            // SP1_richTextBox
            // 
            this.SP1_richTextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_richTextBox.Location = new System.Drawing.Point(11, 535);
            this.SP1_richTextBox.Name = "SP1_richTextBox";
            this.SP1_richTextBox.Size = new System.Drawing.Size(329, 379);
            this.SP1_richTextBox.TabIndex = 737;
            this.SP1_richTextBox.Text = "Receive Log";
            // 
            // checkBox_Voc4
            // 
            this.checkBox_Voc4.AutoSize = true;
            this.checkBox_Voc4.Checked = true;
            this.checkBox_Voc4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Voc4.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Voc4.Location = new System.Drawing.Point(346, 779);
            this.checkBox_Voc4.Name = "checkBox_Voc4";
            this.checkBox_Voc4.Size = new System.Drawing.Size(71, 21);
            this.checkBox_Voc4.TabIndex = 752;
            this.checkBox_Voc4.Text = "VOC 4";
            this.checkBox_Voc4.UseVisualStyleBackColor = true;
            // 
            // checkBox_Voc3
            // 
            this.checkBox_Voc3.AutoSize = true;
            this.checkBox_Voc3.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Voc3.Checked = true;
            this.checkBox_Voc3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc3.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Voc3.Location = new System.Drawing.Point(346, 750);
            this.checkBox_Voc3.Name = "checkBox_Voc3";
            this.checkBox_Voc3.Size = new System.Drawing.Size(67, 20);
            this.checkBox_Voc3.TabIndex = 751;
            this.checkBox_Voc3.Text = "VOC 3";
            this.checkBox_Voc3.UseVisualStyleBackColor = false;
            // 
            // checkBox_Temperature
            // 
            this.checkBox_Temperature.AutoSize = true;
            this.checkBox_Temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Temperature.ForeColor = System.Drawing.Color.Pink;
            this.checkBox_Temperature.Location = new System.Drawing.Point(346, 630);
            this.checkBox_Temperature.Name = "checkBox_Temperature";
            this.checkBox_Temperature.Size = new System.Drawing.Size(112, 21);
            this.checkBox_Temperature.TabIndex = 750;
            this.checkBox_Temperature.Text = "Temperature";
            this.checkBox_Temperature.UseVisualStyleBackColor = true;
            this.checkBox_Temperature.CheckedChanged += new System.EventHandler(this.checkBox_Temperature_CheckedChanged);
            // 
            // checkBox_Voc2
            // 
            this.checkBox_Voc2.AutoSize = true;
            this.checkBox_Voc2.Checked = true;
            this.checkBox_Voc2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc2.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Voc2.Location = new System.Drawing.Point(346, 718);
            this.checkBox_Voc2.Name = "checkBox_Voc2";
            this.checkBox_Voc2.Size = new System.Drawing.Size(67, 20);
            this.checkBox_Voc2.TabIndex = 748;
            this.checkBox_Voc2.Text = "VOC 2";
            this.checkBox_Voc2.UseVisualStyleBackColor = true;
            // 
            // checkBox_Voc1
            // 
            this.checkBox_Voc1.AutoSize = true;
            this.checkBox_Voc1.Checked = true;
            this.checkBox_Voc1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc1.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Voc1.Location = new System.Drawing.Point(346, 688);
            this.checkBox_Voc1.Name = "checkBox_Voc1";
            this.checkBox_Voc1.Size = new System.Drawing.Size(67, 20);
            this.checkBox_Voc1.TabIndex = 747;
            this.checkBox_Voc1.Text = "VOC 1";
            this.checkBox_Voc1.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.communicationToolStripMenuItem,
            this.dataLoggerToolStripMenuItem,
            this.chartToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1539, 28);
            this.menuStrip1.TabIndex = 753;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.deviceManagerToolStripMenuItem,
            this.comPortListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.recordToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // comPortListToolStripMenuItem
            // 
            this.comPortListToolStripMenuItem.BackColor = System.Drawing.Color.AliceBlue;
            this.comPortListToolStripMenuItem.Name = "comPortListToolStripMenuItem";
            this.comPortListToolStripMenuItem.Size = new System.Drawing.Size(200, 26);
            this.comPortListToolStripMenuItem.Text = "Com Port List";
            this.comPortListToolStripMenuItem.Click += new System.EventHandler(this.comPortListToolStripMenuItem_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.communicationToolStripMenuItem.Text = "Simulator";
            this.communicationToolStripMenuItem.Click += new System.EventHandler(this.communicationToolStripMenuItem_Click);
            // 
            // dataLoggerToolStripMenuItem
            // 
            this.dataLoggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startToolStripMenuItem,
            this.stopToolStripMenuItem,
            this.openLogFileToolStripMenuItem,
            this.systemTimeToolStripMenuItem});
            this.dataLoggerToolStripMenuItem.Name = "dataLoggerToolStripMenuItem";
            this.dataLoggerToolStripMenuItem.Size = new System.Drawing.Size(106, 24);
            this.dataLoggerToolStripMenuItem.Text = "Data Logger";
            this.dataLoggerToolStripMenuItem.Click += new System.EventHandler(this.dataLoggerToolStripMenuItem_Click);
            // 
            // startToolStripMenuItem
            // 
            this.startToolStripMenuItem.Enabled = false;
            this.startToolStripMenuItem.Name = "startToolStripMenuItem";
            this.startToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            this.openLogFileToolStripMenuItem.Text = "Open Log File";
            // 
            // systemTimeToolStripMenuItem
            // 
            this.systemTimeToolStripMenuItem.Name = "systemTimeToolStripMenuItem";
            this.systemTimeToolStripMenuItem.Size = new System.Drawing.Size(184, 26);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sizeToolStripMenuItem});
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // sizeToolStripMenuItem
            // 
            this.sizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.sizeToolStripMenuItem.Name = "sizeToolStripMenuItem";
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(119, 26);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem2.Text = "10 Seconds";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem3.Text = "20 Seconds";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem4.Text = "1 Minute";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem5.Text = "2 Minutes";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(167, 26);
            this.toolStripMenuItem6.Text = "3 Minutes";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // plotSurface2D1
            // 
            this.plotSurface2D1.AutoScaleAutoGeneratedAxes = false;
            this.plotSurface2D1.AutoScaleTitle = false;
            this.plotSurface2D1.BackColor = System.Drawing.Color.AliceBlue;
            this.plotSurface2D1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.plotSurface2D1.DateTimeToolTip = false;
            this.plotSurface2D1.Legend = null;
            this.plotSurface2D1.LegendZOrder = -1;
            this.plotSurface2D1.Location = new System.Drawing.Point(344, 44);
            this.plotSurface2D1.Name = "plotSurface2D1";
            this.plotSurface2D1.RightMenu = null;
            this.plotSurface2D1.ShowCoordinates = true;
            this.plotSurface2D1.Size = new System.Drawing.Size(1400, 579);
            this.plotSurface2D1.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plotSurface2D1.TabIndex = 739;
            this.plotSurface2D1.Text = "plotSurface2D1";
            this.plotSurface2D1.Title = "";
            this.plotSurface2D1.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plotSurface2D1.XAxis1 = null;
            this.plotSurface2D1.XAxis2 = null;
            this.plotSurface2D1.YAxis1 = null;
            this.plotSurface2D1.YAxis2 = null;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(837, 858);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 18);
            this.label2.TabIndex = 756;
            this.label2.Text = "Wheel Size";
            // 
            // checkBox_Humidity
            // 
            this.checkBox_Humidity.AutoSize = true;
            this.checkBox_Humidity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Humidity.ForeColor = System.Drawing.Color.Black;
            this.checkBox_Humidity.Location = new System.Drawing.Point(344, 657);
            this.checkBox_Humidity.Name = "checkBox_Humidity";
            this.checkBox_Humidity.Size = new System.Drawing.Size(84, 21);
            this.checkBox_Humidity.TabIndex = 757;
            this.checkBox_Humidity.Text = "Humidity";
            this.checkBox_Humidity.UseVisualStyleBackColor = true;
            // 
            // checkBox_Voc4_Median
            // 
            this.checkBox_Voc4_Median.AutoSize = true;
            this.checkBox_Voc4_Median.Checked = true;
            this.checkBox_Voc4_Median.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc4_Median.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Voc4_Median.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Voc4_Median.Location = new System.Drawing.Point(1288, 797);
            this.checkBox_Voc4_Median.Name = "checkBox_Voc4_Median";
            this.checkBox_Voc4_Median.Size = new System.Drawing.Size(75, 21);
            this.checkBox_Voc4_Median.TabIndex = 762;
            this.checkBox_Voc4_Median.Text = "BME_4";
            this.checkBox_Voc4_Median.UseVisualStyleBackColor = true;
            this.checkBox_Voc4_Median.CheckedChanged += new System.EventHandler(this.checkBox_Voc4_Median_CheckedChanged);
            // 
            // checkBox_Voc3_Median
            // 
            this.checkBox_Voc3_Median.AutoSize = true;
            this.checkBox_Voc3_Median.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Voc3_Median.Checked = true;
            this.checkBox_Voc3_Median.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc3_Median.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Voc3_Median.Location = new System.Drawing.Point(1291, 686);
            this.checkBox_Voc3_Median.Name = "checkBox_Voc3_Median";
            this.checkBox_Voc3_Median.Size = new System.Drawing.Size(72, 20);
            this.checkBox_Voc3_Median.TabIndex = 761;
            this.checkBox_Voc3_Median.Text = "BME_3";
            this.checkBox_Voc3_Median.UseVisualStyleBackColor = false;
            this.checkBox_Voc3_Median.CheckedChanged += new System.EventHandler(this.checkBox_Voc3_Median_CheckedChanged);
            // 
            // checkBox_Voc2_Median
            // 
            this.checkBox_Voc2_Median.AutoSize = true;
            this.checkBox_Voc2_Median.Checked = true;
            this.checkBox_Voc2_Median.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc2_Median.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Voc2_Median.Location = new System.Drawing.Point(889, 762);
            this.checkBox_Voc2_Median.Name = "checkBox_Voc2_Median";
            this.checkBox_Voc2_Median.Size = new System.Drawing.Size(72, 20);
            this.checkBox_Voc2_Median.TabIndex = 760;
            this.checkBox_Voc2_Median.Text = "BME_2";
            this.checkBox_Voc2_Median.UseVisualStyleBackColor = true;
            // 
            // checkBox_Voc1_Median
            // 
            this.checkBox_Voc1_Median.AutoSize = true;
            this.checkBox_Voc1_Median.Checked = true;
            this.checkBox_Voc1_Median.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voc1_Median.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Voc1_Median.Location = new System.Drawing.Point(889, 684);
            this.checkBox_Voc1_Median.Name = "checkBox_Voc1_Median";
            this.checkBox_Voc1_Median.Size = new System.Drawing.Size(72, 20);
            this.checkBox_Voc1_Median.TabIndex = 759;
            this.checkBox_Voc1_Median.Text = "BME_1";
            this.checkBox_Voc1_Median.UseVisualStyleBackColor = true;
            // 
            // SP1_textBox_Device
            // 
            this.SP1_textBox_Device.BackColor = System.Drawing.Color.AliceBlue;
            this.SP1_textBox_Device.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SP1_textBox_Device.Location = new System.Drawing.Point(12, 53);
            this.SP1_textBox_Device.Multiline = true;
            this.SP1_textBox_Device.Name = "SP1_textBox_Device";
            this.SP1_textBox_Device.Size = new System.Drawing.Size(326, 27);
            this.SP1_textBox_Device.TabIndex = 763;
            // 
            // richTextBox_BME680
            // 
            this.richTextBox_BME680.BackColor = System.Drawing.Color.AliceBlue;
            this.richTextBox_BME680.Location = new System.Drawing.Point(749, 629);
            this.richTextBox_BME680.Name = "richTextBox_BME680";
            this.richTextBox_BME680.Size = new System.Drawing.Size(241, 219);
            this.richTextBox_BME680.TabIndex = 764;
            this.richTextBox_BME680.Text = "Receive Log";
            // 
            // richTextBox_BME680_2
            // 
            this.richTextBox_BME680_2.BackColor = System.Drawing.Color.AliceBlue;
            this.richTextBox_BME680_2.Location = new System.Drawing.Point(1142, 629);
            this.richTextBox_BME680_2.Name = "richTextBox_BME680_2";
            this.richTextBox_BME680_2.Size = new System.Drawing.Size(241, 219);
            this.richTextBox_BME680_2.TabIndex = 765;
            this.richTextBox_BME680_2.Text = "Receive Log";
            // 
            // textBox_FanPWM
            // 
            this.textBox_FanPWM.Location = new System.Drawing.Point(580, 716);
            this.textBox_FanPWM.Name = "textBox_FanPWM";
            this.textBox_FanPWM.Size = new System.Drawing.Size(71, 22);
            this.textBox_FanPWM.TabIndex = 766;
            // 
            // numericUpDown_PWM
            // 
            this.numericUpDown_PWM.Location = new System.Drawing.Point(581, 744);
            this.numericUpDown_PWM.Maximum = new decimal(new int[] {
            97,
            0,
            0,
            0});
            this.numericUpDown_PWM.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown_PWM.Name = "numericUpDown_PWM";
            this.numericUpDown_PWM.Size = new System.Drawing.Size(70, 22);
            this.numericUpDown_PWM.TabIndex = 767;
            this.numericUpDown_PWM.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(577, 697);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 768;
            this.label3.Text = "FAN PWM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(530, 719);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 769;
            this.label4.Text = "Actual";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(538, 750);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 16);
            this.label5.TabIndex = 770;
            this.label5.Text = "Set";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1539, 844);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_PWM);
            this.Controls.Add(this.textBox_FanPWM);
            this.Controls.Add(this.SP1_textBox_Device);
            this.Controls.Add(this.checkBox_Voc4_Median);
            this.Controls.Add(this.checkBox_Voc3_Median);
            this.Controls.Add(this.checkBox_Voc2_Median);
            this.Controls.Add(this.checkBox_Voc1_Median);
            this.Controls.Add(this.checkBox_Humidity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox_Voc4);
            this.Controls.Add(this.checkBox_Voc3);
            this.Controls.Add(this.checkBox_Temperature);
            this.Controls.Add(this.checkBox_Voc2);
            this.Controls.Add(this.checkBox_Voc1);
            this.Controls.Add(this.SP1_DatatextBox);
            this.Controls.Add(this.SP1_richTextBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.SP1_SendtextBox);
            this.Controls.Add(this.SP1_DisConnectButton);
            this.Controls.Add(this.SP1_IO_Serial_lstCOMPorts);
            this.Controls.Add(this.SP1_ConnectButton);
            this.Controls.Add(this.SP1_textBox_PortName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SP1_SendButton);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.plotSurface2D1);
            this.Controls.Add(this.richTextBox_BME680_2);
            this.Controls.Add(this.richTextBox_BME680);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "VOC Data Acquisition";
            this.TransparencyKey = System.Drawing.Color.Lavender;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PWM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort SP1_serialPort;
        private System.Windows.Forms.Timer Base_Timer1mSec;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox SP1_SendtextBox;
        private System.Windows.Forms.Button SP1_DisConnectButton;
        public System.Windows.Forms.ComboBox SP1_IO_Serial_lstCOMPorts;
        private System.Windows.Forms.Button SP1_ConnectButton;
        public System.Windows.Forms.TextBox SP1_textBox_PortName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SP1_SendButton;
        public System.Windows.Forms.TextBox SP1_DatatextBox;
        private System.Windows.Forms.RichTextBox SP1_richTextBox;
        private NPlot.Windows.PlotSurface2D plotSurface2D1;
        /*
                private System.Windows.Forms.CheckBox checkBox_Cl_ProfileSpeed;
                private System.Windows.Forms.CheckBox checkBox_Cl_ActualSpeed;
                private System.Windows.Forms.CheckBox checkBox_Cl_Current;
                private System.Windows.Forms.CheckBox checkBox_Cl_RefAkim;
                private System.Windows.Forms.CheckBox checkBox_Cl_SpeedError;
                private System.Windows.Forms.CheckBox checkBox_Cl_PID;
        */
        private System.Windows.Forms.CheckBox checkBox_Voc4;
        private System.Windows.Forms.CheckBox checkBox_Voc3;
        private System.Windows.Forms.CheckBox checkBox_Temperature;
        private System.Windows.Forms.CheckBox checkBox_Voc2;
        private System.Windows.Forms.CheckBox checkBox_Voc1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataLoggerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemTimeToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.CheckBox checkBox_Humidity;
        private System.Windows.Forms.CheckBox checkBox_Voc4_Median;
        private System.Windows.Forms.CheckBox checkBox_Voc3_Median;
        private System.Windows.Forms.CheckBox checkBox_Voc2_Median;
        private System.Windows.Forms.CheckBox checkBox_Voc1_Median;
        private System.Windows.Forms.TextBox SP1_textBox_Device;
        private System.Windows.Forms.ToolStripMenuItem deviceManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortListToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox_BME680;
        private System.Windows.Forms.RichTextBox richTextBox_BME680_2;
        private System.Windows.Forms.TextBox textBox_FanPWM;
        private System.Windows.Forms.NumericUpDown numericUpDown_PWM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

