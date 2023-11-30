namespace VOI_DAQ
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.plotSurface2D2 = new NPlot.Windows.PlotSurface2D();
            this.checkBox_Temperature = new System.Windows.Forms.CheckBox();
            this.checkBox_Voltage = new System.Windows.Forms.CheckBox();
            this.checkBox_Power = new System.Windows.Forms.CheckBox();
            this.checkBox_Current = new System.Windows.Forms.CheckBox();
            this.checkBox_Speed = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataLoggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.plotSurface2D1 = new NPlot.Windows.PlotSurface2D();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.button1.Location = new System.Drawing.Point(128, 128);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 736;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SP1_SendtextBox
            // 
            this.SP1_SendtextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_SendtextBox.Location = new System.Drawing.Point(11, 167);
            this.SP1_SendtextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_SendtextBox.Multiline = true;
            this.SP1_SendtextBox.Name = "SP1_SendtextBox";
            this.SP1_SendtextBox.Size = new System.Drawing.Size(329, 68);
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
            this.SP1_DisConnectButton.Location = new System.Drawing.Point(245, 89);
            this.SP1_DisConnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_DisConnectButton.Name = "SP1_DisConnectButton";
            this.SP1_DisConnectButton.Size = new System.Drawing.Size(96, 28);
            this.SP1_DisConnectButton.TabIndex = 732;
            this.SP1_DisConnectButton.Text = "Close";
            this.SP1_DisConnectButton.UseVisualStyleBackColor = false;
            this.SP1_DisConnectButton.Click += new System.EventHandler(this.SP1_DisConnectButton_Click);
            // 
            // SP1_IO_Serial_lstCOMPorts
            // 
            this.SP1_IO_Serial_lstCOMPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_IO_Serial_lstCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SP1_IO_Serial_lstCOMPorts.ForeColor = System.Drawing.Color.Black;
            this.SP1_IO_Serial_lstCOMPorts.Items.AddRange(new object[] {
            "COM56"});
            this.SP1_IO_Serial_lstCOMPorts.Location = new System.Drawing.Point(116, 85);
            this.SP1_IO_Serial_lstCOMPorts.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_IO_Serial_lstCOMPorts.Name = "SP1_IO_Serial_lstCOMPorts";
            this.SP1_IO_Serial_lstCOMPorts.Size = new System.Drawing.Size(128, 24);
            this.SP1_IO_Serial_lstCOMPorts.TabIndex = 731;
            // 
            // SP1_ConnectButton
            // 
            this.SP1_ConnectButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_ConnectButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_ConnectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_ConnectButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_ConnectButton.Location = new System.Drawing.Point(7, 85);
            this.SP1_ConnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_ConnectButton.Name = "SP1_ConnectButton";
            this.SP1_ConnectButton.Size = new System.Drawing.Size(101, 28);
            this.SP1_ConnectButton.TabIndex = 730;
            this.SP1_ConnectButton.Text = "Connect";
            this.SP1_ConnectButton.UseVisualStyleBackColor = false;
            this.SP1_ConnectButton.Click += new System.EventHandler(this.SP1_ConnectButton_Click);
            // 
            // SP1_textBox_PortName
            // 
            this.SP1_textBox_PortName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_textBox_PortName.Location = new System.Drawing.Point(235, 128);
            this.SP1_textBox_PortName.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_textBox_PortName.Multiline = true;
            this.SP1_textBox_PortName.Name = "SP1_textBox_PortName";
            this.SP1_textBox_PortName.Size = new System.Drawing.Size(105, 31);
            this.SP1_textBox_PortName.TabIndex = 735;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(81, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
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
            this.SP1_SendButton.Location = new System.Drawing.Point(11, 128);
            this.SP1_SendButton.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_SendButton.Name = "SP1_SendButton";
            this.SP1_SendButton.Size = new System.Drawing.Size(100, 28);
            this.SP1_SendButton.TabIndex = 734;
            this.SP1_SendButton.Text = "Send";
            this.SP1_SendButton.UseVisualStyleBackColor = false;
            this.SP1_SendButton.Click += new System.EventHandler(this.SP1_SendButton_Click);
            // 
            // SP1_DatatextBox
            // 
            this.SP1_DatatextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_DatatextBox.Location = new System.Drawing.Point(11, 246);
            this.SP1_DatatextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_DatatextBox.Multiline = true;
            this.SP1_DatatextBox.Name = "SP1_DatatextBox";
            this.SP1_DatatextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SP1_DatatextBox.Size = new System.Drawing.Size(329, 166);
            this.SP1_DatatextBox.TabIndex = 738;
            this.SP1_DatatextBox.Text = "Receive Log";
            // 
            // SP1_richTextBox
            // 
            this.SP1_richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.SP1_richTextBox.Location = new System.Drawing.Point(11, 423);
            this.SP1_richTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.SP1_richTextBox.Name = "SP1_richTextBox";
            this.SP1_richTextBox.Size = new System.Drawing.Size(329, 491);
            this.SP1_richTextBox.TabIndex = 737;
            this.SP1_richTextBox.Text = "Receive Log";
            // 
            // plotSurface2D2
            // 
            this.plotSurface2D2.AutoScaleAutoGeneratedAxes = false;
            this.plotSurface2D2.AutoScaleTitle = false;
            this.plotSurface2D2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotSurface2D2.DateTimeToolTip = false;
            this.plotSurface2D2.Legend = null;
            this.plotSurface2D2.LegendZOrder = -1;
            this.plotSurface2D2.Location = new System.Drawing.Point(367, 785);
            this.plotSurface2D2.Margin = new System.Windows.Forms.Padding(4);
            this.plotSurface2D2.Name = "plotSurface2D2";
            this.plotSurface2D2.RightMenu = null;
            this.plotSurface2D2.ShowCoordinates = true;
            this.plotSurface2D2.Size = new System.Drawing.Size(440, 10);
            this.plotSurface2D2.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            this.plotSurface2D2.TabIndex = 740;
            this.plotSurface2D2.Text = "plotSurface2D2";
            this.plotSurface2D2.Title = "";
            this.plotSurface2D2.TitleFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.plotSurface2D2.XAxis1 = null;
            this.plotSurface2D2.XAxis2 = null;
            this.plotSurface2D2.YAxis1 = null;
            this.plotSurface2D2.YAxis2 = null;
            // 
            // checkBox_Temperature
            // 
            this.checkBox_Temperature.AutoSize = true;
            this.checkBox_Temperature.Checked = true;
            this.checkBox_Temperature.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Temperature.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Temperature.ForeColor = System.Drawing.Color.Gold;
            this.checkBox_Temperature.Location = new System.Drawing.Point(1121, 706);
            this.checkBox_Temperature.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Temperature.Name = "checkBox_Temperature";
            this.checkBox_Temperature.Size = new System.Drawing.Size(112, 21);
            this.checkBox_Temperature.TabIndex = 752;
            this.checkBox_Temperature.Text = "Temperature";
            this.checkBox_Temperature.UseVisualStyleBackColor = true;
            // 
            // checkBox_Voltage
            // 
            this.checkBox_Voltage.AutoSize = true;
            this.checkBox_Voltage.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Voltage.Checked = true;
            this.checkBox_Voltage.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Voltage.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_Voltage.Location = new System.Drawing.Point(907, 707);
            this.checkBox_Voltage.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Voltage.Name = "checkBox_Voltage";
            this.checkBox_Voltage.Size = new System.Drawing.Size(76, 20);
            this.checkBox_Voltage.TabIndex = 751;
            this.checkBox_Voltage.Text = "Voltage";
            this.checkBox_Voltage.UseVisualStyleBackColor = false;
            // 
            // checkBox_Power
            // 
            this.checkBox_Power.AutoSize = true;
            this.checkBox_Power.Checked = true;
            this.checkBox_Power.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Power.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Power.ForeColor = System.Drawing.Color.Purple;
            this.checkBox_Power.Location = new System.Drawing.Point(1004, 710);
            this.checkBox_Power.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Power.Name = "checkBox_Power";
            this.checkBox_Power.Size = new System.Drawing.Size(69, 21);
            this.checkBox_Power.TabIndex = 750;
            this.checkBox_Power.Text = "Power";
            this.checkBox_Power.UseVisualStyleBackColor = true;
            // 
            // checkBox_Current
            // 
            this.checkBox_Current.AutoSize = true;
            this.checkBox_Current.Checked = true;
            this.checkBox_Current.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Current.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Current.Location = new System.Drawing.Point(779, 707);
            this.checkBox_Current.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Current.Name = "checkBox_Current";
            this.checkBox_Current.Size = new System.Drawing.Size(71, 20);
            this.checkBox_Current.TabIndex = 748;
            this.checkBox_Current.Text = "Current";
            this.checkBox_Current.UseVisualStyleBackColor = true;
            // 
            // checkBox_Speed
            // 
            this.checkBox_Speed.AutoSize = true;
            this.checkBox_Speed.Checked = true;
            this.checkBox_Speed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Speed.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Speed.Location = new System.Drawing.Point(651, 707);
            this.checkBox_Speed.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Speed.Name = "checkBox_Speed";
            this.checkBox_Speed.Size = new System.Drawing.Size(70, 20);
            this.checkBox_Speed.TabIndex = 747;
            this.checkBox_Speed.Text = "Speed";
            this.checkBox_Speed.UseVisualStyleBackColor = true;
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
            this.menuStrip1.Size = new System.Drawing.Size(1924, 28);
            this.menuStrip1.TabIndex = 753;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.recordToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // recordToolStripMenuItem
            // 
            this.recordToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.recordToolStripMenuItem.Name = "recordToolStripMenuItem";
            this.recordToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.recordToolStripMenuItem.Text = "Save As";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.communicationToolStripMenuItem.Text = "Communication";
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
            this.startToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.startToolStripMenuItem.Text = "Start";
            this.startToolStripMenuItem.Click += new System.EventHandler(this.startToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Enabled = false;
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.stopToolStripMenuItem.Text = "Stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openLogFileToolStripMenuItem.Text = "Open Log File";
            // 
            // systemTimeToolStripMenuItem
            // 
            this.systemTimeToolStripMenuItem.Name = "systemTimeToolStripMenuItem";
            this.systemTimeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.systemTimeToolStripMenuItem.Text = "System Time";
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
            this.plotSurface2D1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.plotSurface2D1.BackgroundImage = global::VOI_DAQ.Properties.Resources.VOI__20231117_052;
            this.plotSurface2D1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.plotSurface2D1.DateTimeToolTip = false;
            this.plotSurface2D1.Legend = null;
            this.plotSurface2D1.LegendZOrder = -1;
            this.plotSurface2D1.Location = new System.Drawing.Point(360, 40);
            this.plotSurface2D1.Margin = new System.Windows.Forms.Padding(4);
            this.plotSurface2D1.Name = "plotSurface2D1";
            this.plotSurface2D1.RightMenu = null;
            this.plotSurface2D1.ShowCoordinates = true;
            this.plotSurface2D1.Size = new System.Drawing.Size(1538, 600);
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
            this.sizeToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.sizeToolStripMenuItem.Text = "Size";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem2.Text = "300";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem3.Text = "500";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem4.Text = "1000";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem5.Text = "2000";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(224, 26);
            this.toolStripMenuItem6.Text = "5000";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1924, 921);
            this.Controls.Add(this.checkBox_Temperature);
            this.Controls.Add(this.checkBox_Voltage);
            this.Controls.Add(this.checkBox_Power);
            this.Controls.Add(this.checkBox_Current);
            this.Controls.Add(this.checkBox_Speed);
            this.Controls.Add(this.plotSurface2D2);
            this.Controls.Add(this.plotSurface2D1);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "VOI DAQ";
            this.TransparencyKey = System.Drawing.Color.BlueViolet;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private NPlot.Windows.PlotSurface2D plotSurface2D2;
/*
        private System.Windows.Forms.CheckBox checkBox_Cl_ProfileSpeed;
        private System.Windows.Forms.CheckBox checkBox_Cl_ActualSpeed;
        private System.Windows.Forms.CheckBox checkBox_Cl_Current;
        private System.Windows.Forms.CheckBox checkBox_Cl_RefAkim;
        private System.Windows.Forms.CheckBox checkBox_Cl_SpeedError;
        private System.Windows.Forms.CheckBox checkBox_Cl_PID;
*/
        private System.Windows.Forms.CheckBox checkBox_Temperature;
        private System.Windows.Forms.CheckBox checkBox_Voltage;
        private System.Windows.Forms.CheckBox checkBox_Power;
        private System.Windows.Forms.CheckBox checkBox_Current;
        private System.Windows.Forms.CheckBox checkBox_Speed;
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
        //      private System.Windows.Forms.CheckBox checkBox_Cl_LowLimit;
    }
}

