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
            this.plotSurface2D1 = new NPlot.Windows.PlotSurface2D();
            this.plotSurface2D2 = new NPlot.Windows.PlotSurface2D();
            this.checkBox_Cl_ProfileSpeed = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_ActualSpeed = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_Current = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_RefAkim = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_SpeedError = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_PID = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_PID = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_SpeedError = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_RefAkim = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_Current = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_ActualSpeed = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_ProfileSpeed = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_HighLimit = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_HighLimit = new System.Windows.Forms.CheckBox();
            this.checkBox_Op_LowLimit = new System.Windows.Forms.CheckBox();
            this.checkBox_Cl_LowLimit = new System.Windows.Forms.CheckBox();
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
            this.button1.Location = new System.Drawing.Point(96, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 736;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SP1_SendtextBox
            // 
            this.SP1_SendtextBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SP1_SendtextBox.Location = new System.Drawing.Point(8, 136);
            this.SP1_SendtextBox.Multiline = true;
            this.SP1_SendtextBox.Name = "SP1_SendtextBox";
            this.SP1_SendtextBox.Size = new System.Drawing.Size(248, 56);
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
            this.SP1_DisConnectButton.Location = new System.Drawing.Point(184, 72);
            this.SP1_DisConnectButton.Name = "SP1_DisConnectButton";
            this.SP1_DisConnectButton.Size = new System.Drawing.Size(72, 23);
            this.SP1_DisConnectButton.TabIndex = 732;
            this.SP1_DisConnectButton.Text = "Close";
            this.SP1_DisConnectButton.UseVisualStyleBackColor = false;
            this.SP1_DisConnectButton.Click += new System.EventHandler(this.SP1_DisConnectButton_Click);
            // 
            // SP1_IO_Serial_lstCOMPorts
            // 
            this.SP1_IO_Serial_lstCOMPorts.BackColor = System.Drawing.Color.LightBlue;
            this.SP1_IO_Serial_lstCOMPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SP1_IO_Serial_lstCOMPorts.ForeColor = System.Drawing.Color.Black;
            this.SP1_IO_Serial_lstCOMPorts.FormattingEnabled = true;
            this.SP1_IO_Serial_lstCOMPorts.Items.AddRange(new object[] {
            "COM56"});
            this.SP1_IO_Serial_lstCOMPorts.Location = new System.Drawing.Point(87, 69);
            this.SP1_IO_Serial_lstCOMPorts.Name = "SP1_IO_Serial_lstCOMPorts";
            this.SP1_IO_Serial_lstCOMPorts.Size = new System.Drawing.Size(97, 21);
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
            this.SP1_ConnectButton.Location = new System.Drawing.Point(5, 69);
            this.SP1_ConnectButton.Name = "SP1_ConnectButton";
            this.SP1_ConnectButton.Size = new System.Drawing.Size(76, 23);
            this.SP1_ConnectButton.TabIndex = 730;
            this.SP1_ConnectButton.Text = "Connect";
            this.SP1_ConnectButton.UseVisualStyleBackColor = false;
            this.SP1_ConnectButton.Click += new System.EventHandler(this.SP1_ConnectButton_Click);
            // 
            // SP1_textBox_PortName
            // 
            this.SP1_textBox_PortName.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SP1_textBox_PortName.Location = new System.Drawing.Point(176, 104);
            this.SP1_textBox_PortName.Multiline = true;
            this.SP1_textBox_PortName.Name = "SP1_textBox_PortName";
            this.SP1_textBox_PortName.Size = new System.Drawing.Size(80, 26);
            this.SP1_textBox_PortName.TabIndex = 735;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(61, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 19);
            this.label1.TabIndex = 733;
            this.label1.Text = "Interface Connection";
            // 
            // SP1_SendButton
            // 
            this.SP1_SendButton.BackColor = System.Drawing.Color.Transparent;
            this.SP1_SendButton.FlatAppearance.BorderColor = System.Drawing.Color.SteelBlue;
            this.SP1_SendButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.SP1_SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SP1_SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SP1_SendButton.ForeColor = System.Drawing.Color.Black;
            this.SP1_SendButton.Location = new System.Drawing.Point(8, 104);
            this.SP1_SendButton.Name = "SP1_SendButton";
            this.SP1_SendButton.Size = new System.Drawing.Size(75, 23);
            this.SP1_SendButton.TabIndex = 734;
            this.SP1_SendButton.Text = "Send";
            this.SP1_SendButton.UseVisualStyleBackColor = false;
            this.SP1_SendButton.Click += new System.EventHandler(this.SP1_SendButton_Click);
            // 
            // SP1_DatatextBox
            // 
            this.SP1_DatatextBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SP1_DatatextBox.Location = new System.Drawing.Point(8, 200);
            this.SP1_DatatextBox.Multiline = true;
            this.SP1_DatatextBox.Name = "SP1_DatatextBox";
            this.SP1_DatatextBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.SP1_DatatextBox.Size = new System.Drawing.Size(248, 136);
            this.SP1_DatatextBox.TabIndex = 738;
            this.SP1_DatatextBox.Text = "Receive Log";
            // 
            // SP1_richTextBox
            // 
            this.SP1_richTextBox.BackColor = System.Drawing.Color.CornflowerBlue;
            this.SP1_richTextBox.Location = new System.Drawing.Point(8, 344);
            this.SP1_richTextBox.Name = "SP1_richTextBox";
            this.SP1_richTextBox.Size = new System.Drawing.Size(248, 400);
            this.SP1_richTextBox.TabIndex = 737;
            this.SP1_richTextBox.Text = "Receive Log";
            // 
            // plotSurface2D1
            // 
            this.plotSurface2D1.AutoScaleAutoGeneratedAxes = false;
            this.plotSurface2D1.AutoScaleTitle = false;
            this.plotSurface2D1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotSurface2D1.DateTimeToolTip = false;
            this.plotSurface2D1.Legend = null;
            this.plotSurface2D1.LegendZOrder = -1;
            this.plotSurface2D1.Location = new System.Drawing.Point(264, 8);
            this.plotSurface2D1.Name = "plotSurface2D1";
            this.plotSurface2D1.RightMenu = null;
            this.plotSurface2D1.ShowCoordinates = true;
            this.plotSurface2D1.Size = new System.Drawing.Size(1180, 340);
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
            // plotSurface2D2
            // 
            this.plotSurface2D2.AutoScaleAutoGeneratedAxes = false;
            this.plotSurface2D2.AutoScaleTitle = false;
            this.plotSurface2D2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.plotSurface2D2.DateTimeToolTip = false;
            this.plotSurface2D2.Legend = null;
            this.plotSurface2D2.LegendZOrder = -1;
            this.plotSurface2D2.Location = new System.Drawing.Point(264, 384);
            this.plotSurface2D2.Name = "plotSurface2D2";
            this.plotSurface2D2.RightMenu = null;
            this.plotSurface2D2.ShowCoordinates = true;
            this.plotSurface2D2.Size = new System.Drawing.Size(1180, 340);
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
            // checkBox_Cl_ProfileSpeed
            // 
            this.checkBox_Cl_ProfileSpeed.AutoSize = true;
            this.checkBox_Cl_ProfileSpeed.Checked = true;
            this.checkBox_Cl_ProfileSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_ProfileSpeed.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Cl_ProfileSpeed.Location = new System.Drawing.Point(456, 728);
            this.checkBox_Cl_ProfileSpeed.Name = "checkBox_Cl_ProfileSpeed";
            this.checkBox_Cl_ProfileSpeed.Size = new System.Drawing.Size(69, 17);
            this.checkBox_Cl_ProfileSpeed.TabIndex = 741;
            this.checkBox_Cl_ProfileSpeed.Text = "Profil Hizi";
            this.checkBox_Cl_ProfileSpeed.UseVisualStyleBackColor = true;
            // 
            // checkBox_Cl_ActualSpeed
            // 
            this.checkBox_Cl_ActualSpeed.AutoSize = true;
            this.checkBox_Cl_ActualSpeed.Checked = true;
            this.checkBox_Cl_ActualSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_ActualSpeed.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Cl_ActualSpeed.Location = new System.Drawing.Point(552, 728);
            this.checkBox_Cl_ActualSpeed.Name = "checkBox_Cl_ActualSpeed";
            this.checkBox_Cl_ActualSpeed.Size = new System.Drawing.Size(79, 17);
            this.checkBox_Cl_ActualSpeed.TabIndex = 742;
            this.checkBox_Cl_ActualSpeed.Text = "Gercek Hiz";
            this.checkBox_Cl_ActualSpeed.UseVisualStyleBackColor = true;
            // 
            // checkBox_Cl_Current
            // 
            this.checkBox_Cl_Current.AutoSize = true;
            this.checkBox_Cl_Current.Checked = true;
            this.checkBox_Cl_Current.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_Current.ForeColor = System.Drawing.Color.Green;
            this.checkBox_Cl_Current.Location = new System.Drawing.Point(760, 728);
            this.checkBox_Cl_Current.Name = "checkBox_Cl_Current";
            this.checkBox_Cl_Current.Size = new System.Drawing.Size(49, 17);
            this.checkBox_Cl_Current.TabIndex = 743;
            this.checkBox_Cl_Current.Text = "Akim";
            this.checkBox_Cl_Current.UseVisualStyleBackColor = true;
            // 
            // checkBox_Cl_RefAkim
            // 
            this.checkBox_Cl_RefAkim.AutoSize = true;
            this.checkBox_Cl_RefAkim.Checked = true;
            this.checkBox_Cl_RefAkim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_RefAkim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cl_RefAkim.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.checkBox_Cl_RefAkim.Location = new System.Drawing.Point(824, 728);
            this.checkBox_Cl_RefAkim.Name = "checkBox_Cl_RefAkim";
            this.checkBox_Cl_RefAkim.Size = new System.Drawing.Size(95, 17);
            this.checkBox_Cl_RefAkim.TabIndex = 744;
            this.checkBox_Cl_RefAkim.Text = "Referans Akim";
            this.checkBox_Cl_RefAkim.UseVisualStyleBackColor = true;
            // 
            // checkBox_Cl_SpeedError
            // 
            this.checkBox_Cl_SpeedError.AutoSize = true;
            this.checkBox_Cl_SpeedError.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Cl_SpeedError.Checked = true;
            this.checkBox_Cl_SpeedError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_SpeedError.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_Cl_SpeedError.Location = new System.Drawing.Point(656, 728);
            this.checkBox_Cl_SpeedError.Name = "checkBox_Cl_SpeedError";
            this.checkBox_Cl_SpeedError.Size = new System.Drawing.Size(65, 17);
            this.checkBox_Cl_SpeedError.TabIndex = 745;
            this.checkBox_Cl_SpeedError.Text = "Hiz error";
            this.checkBox_Cl_SpeedError.UseVisualStyleBackColor = false;
            // 
            // checkBox_Cl_PID
            // 
            this.checkBox_Cl_PID.AutoSize = true;
            this.checkBox_Cl_PID.Checked = true;
            this.checkBox_Cl_PID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_PID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cl_PID.ForeColor = System.Drawing.Color.DarkViolet;
            this.checkBox_Cl_PID.Location = new System.Drawing.Point(928, 728);
            this.checkBox_Cl_PID.Name = "checkBox_Cl_PID";
            this.checkBox_Cl_PID.Size = new System.Drawing.Size(44, 17);
            this.checkBox_Cl_PID.TabIndex = 746;
            this.checkBox_Cl_PID.Text = "PID";
            this.checkBox_Cl_PID.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_PID
            // 
            this.checkBox_Op_PID.AutoSize = true;
            this.checkBox_Op_PID.Checked = true;
            this.checkBox_Op_PID.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_PID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Op_PID.ForeColor = System.Drawing.Color.DarkViolet;
            this.checkBox_Op_PID.Location = new System.Drawing.Point(928, 352);
            this.checkBox_Op_PID.Name = "checkBox_Op_PID";
            this.checkBox_Op_PID.Size = new System.Drawing.Size(44, 17);
            this.checkBox_Op_PID.TabIndex = 752;
            this.checkBox_Op_PID.Text = "PID";
            this.checkBox_Op_PID.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_SpeedError
            // 
            this.checkBox_Op_SpeedError.AutoSize = true;
            this.checkBox_Op_SpeedError.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_Op_SpeedError.Checked = true;
            this.checkBox_Op_SpeedError.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_SpeedError.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.checkBox_Op_SpeedError.Location = new System.Drawing.Point(648, 352);
            this.checkBox_Op_SpeedError.Name = "checkBox_Op_SpeedError";
            this.checkBox_Op_SpeedError.Size = new System.Drawing.Size(65, 17);
            this.checkBox_Op_SpeedError.TabIndex = 751;
            this.checkBox_Op_SpeedError.Text = "Hiz error";
            this.checkBox_Op_SpeedError.UseVisualStyleBackColor = false;
            // 
            // checkBox_Op_RefAkim
            // 
            this.checkBox_Op_RefAkim.AutoSize = true;
            this.checkBox_Op_RefAkim.Checked = true;
            this.checkBox_Op_RefAkim.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_RefAkim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Op_RefAkim.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.checkBox_Op_RefAkim.Location = new System.Drawing.Point(824, 352);
            this.checkBox_Op_RefAkim.Name = "checkBox_Op_RefAkim";
            this.checkBox_Op_RefAkim.Size = new System.Drawing.Size(95, 17);
            this.checkBox_Op_RefAkim.TabIndex = 750;
            this.checkBox_Op_RefAkim.Text = "Referans Akim";
            this.checkBox_Op_RefAkim.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_Current
            // 
            this.checkBox_Op_Current.AutoSize = true;
            this.checkBox_Op_Current.Checked = true;
            this.checkBox_Op_Current.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_Current.ForeColor = System.Drawing.Color.Green;
            this.checkBox_Op_Current.Location = new System.Drawing.Point(760, 352);
            this.checkBox_Op_Current.Name = "checkBox_Op_Current";
            this.checkBox_Op_Current.Size = new System.Drawing.Size(49, 17);
            this.checkBox_Op_Current.TabIndex = 749;
            this.checkBox_Op_Current.Text = "Akim";
            this.checkBox_Op_Current.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_ActualSpeed
            // 
            this.checkBox_Op_ActualSpeed.AutoSize = true;
            this.checkBox_Op_ActualSpeed.Checked = true;
            this.checkBox_Op_ActualSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_ActualSpeed.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Op_ActualSpeed.Location = new System.Drawing.Point(552, 352);
            this.checkBox_Op_ActualSpeed.Name = "checkBox_Op_ActualSpeed";
            this.checkBox_Op_ActualSpeed.Size = new System.Drawing.Size(79, 17);
            this.checkBox_Op_ActualSpeed.TabIndex = 748;
            this.checkBox_Op_ActualSpeed.Text = "Gercek Hiz";
            this.checkBox_Op_ActualSpeed.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_ProfileSpeed
            // 
            this.checkBox_Op_ProfileSpeed.AutoSize = true;
            this.checkBox_Op_ProfileSpeed.Checked = true;
            this.checkBox_Op_ProfileSpeed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_ProfileSpeed.ForeColor = System.Drawing.Color.Red;
            this.checkBox_Op_ProfileSpeed.Location = new System.Drawing.Point(456, 352);
            this.checkBox_Op_ProfileSpeed.Name = "checkBox_Op_ProfileSpeed";
            this.checkBox_Op_ProfileSpeed.Size = new System.Drawing.Size(69, 17);
            this.checkBox_Op_ProfileSpeed.TabIndex = 747;
            this.checkBox_Op_ProfileSpeed.Text = "Profil Hizi";
            this.checkBox_Op_ProfileSpeed.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_HighLimit
            // 
            this.checkBox_Op_HighLimit.AutoSize = true;
            this.checkBox_Op_HighLimit.Checked = true;
            this.checkBox_Op_HighLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_HighLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Op_HighLimit.ForeColor = System.Drawing.Color.Orange;
            this.checkBox_Op_HighLimit.Location = new System.Drawing.Point(1000, 352);
            this.checkBox_Op_HighLimit.Name = "checkBox_Op_HighLimit";
            this.checkBox_Op_HighLimit.Size = new System.Drawing.Size(72, 17);
            this.checkBox_Op_HighLimit.TabIndex = 753;
            this.checkBox_Op_HighLimit.Text = "High Limit";
            this.checkBox_Op_HighLimit.UseVisualStyleBackColor = true;
            // 
            // checkBox_Cl_HighLimit
            // 
            this.checkBox_Cl_HighLimit.AutoSize = true;
            this.checkBox_Cl_HighLimit.Checked = true;
            this.checkBox_Cl_HighLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_HighLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cl_HighLimit.ForeColor = System.Drawing.Color.Orange;
            this.checkBox_Cl_HighLimit.Location = new System.Drawing.Point(984, 728);
            this.checkBox_Cl_HighLimit.Name = "checkBox_Cl_HighLimit";
            this.checkBox_Cl_HighLimit.Size = new System.Drawing.Size(72, 17);
            this.checkBox_Cl_HighLimit.TabIndex = 754;
            this.checkBox_Cl_HighLimit.Text = "High Limit";
            this.checkBox_Cl_HighLimit.UseVisualStyleBackColor = true;
            // 
            // checkBox_Op_LowLimit
            // 
            this.checkBox_Op_LowLimit.AutoSize = true;
            this.checkBox_Op_LowLimit.Checked = true;
            this.checkBox_Op_LowLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Op_LowLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Op_LowLimit.ForeColor = System.Drawing.Color.DarkOrange;
            this.checkBox_Op_LowLimit.Location = new System.Drawing.Point(1096, 352);
            this.checkBox_Op_LowLimit.Name = "checkBox_Op_LowLimit";
            this.checkBox_Op_LowLimit.Size = new System.Drawing.Size(70, 17);
            this.checkBox_Op_LowLimit.TabIndex = 755;
            this.checkBox_Op_LowLimit.Text = "Low Limit";
            this.checkBox_Op_LowLimit.UseVisualStyleBackColor = true;
            // 
            // checkBox_Cl_LowLimit
            // 
            this.checkBox_Cl_LowLimit.AutoSize = true;
            this.checkBox_Cl_LowLimit.Checked = true;
            this.checkBox_Cl_LowLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Cl_LowLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_Cl_LowLimit.ForeColor = System.Drawing.Color.DarkOrange;
            this.checkBox_Cl_LowLimit.Location = new System.Drawing.Point(1096, 728);
            this.checkBox_Cl_LowLimit.Name = "checkBox_Cl_LowLimit";
            this.checkBox_Cl_LowLimit.Size = new System.Drawing.Size(70, 17);
            this.checkBox_Cl_LowLimit.TabIndex = 756;
            this.checkBox_Cl_LowLimit.Text = "Low Limit";
            this.checkBox_Cl_LowLimit.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1452, 748);
            this.Controls.Add(this.checkBox_Cl_LowLimit);
            this.Controls.Add(this.checkBox_Op_LowLimit);
            this.Controls.Add(this.checkBox_Cl_HighLimit);
            this.Controls.Add(this.checkBox_Op_HighLimit);
            this.Controls.Add(this.checkBox_Op_PID);
            this.Controls.Add(this.checkBox_Op_SpeedError);
            this.Controls.Add(this.checkBox_Op_RefAkim);
            this.Controls.Add(this.checkBox_Op_Current);
            this.Controls.Add(this.checkBox_Op_ActualSpeed);
            this.Controls.Add(this.checkBox_Op_ProfileSpeed);
            this.Controls.Add(this.checkBox_Cl_PID);
            this.Controls.Add(this.checkBox_Cl_SpeedError);
            this.Controls.Add(this.checkBox_Cl_RefAkim);
            this.Controls.Add(this.checkBox_Cl_Current);
            this.Controls.Add(this.checkBox_Cl_ActualSpeed);
            this.Controls.Add(this.checkBox_Cl_ProfileSpeed);
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
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.CheckBox checkBox_Cl_ProfileSpeed;
        private System.Windows.Forms.CheckBox checkBox_Cl_ActualSpeed;
        private System.Windows.Forms.CheckBox checkBox_Cl_Current;
        private System.Windows.Forms.CheckBox checkBox_Cl_RefAkim;
        private System.Windows.Forms.CheckBox checkBox_Cl_SpeedError;
        private System.Windows.Forms.CheckBox checkBox_Cl_PID;
        private System.Windows.Forms.CheckBox checkBox_Op_PID;
        private System.Windows.Forms.CheckBox checkBox_Op_SpeedError;
        private System.Windows.Forms.CheckBox checkBox_Op_RefAkim;
        private System.Windows.Forms.CheckBox checkBox_Op_Current;
        private System.Windows.Forms.CheckBox checkBox_Op_ActualSpeed;
        private System.Windows.Forms.CheckBox checkBox_Op_ProfileSpeed;
        private System.Windows.Forms.CheckBox checkBox_Op_HighLimit;
        private System.Windows.Forms.CheckBox checkBox_Cl_HighLimit;
        private System.Windows.Forms.CheckBox checkBox_Op_LowLimit;
        private System.Windows.Forms.CheckBox checkBox_Cl_LowLimit;
    }
}

