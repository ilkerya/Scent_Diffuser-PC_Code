namespace TemplateProject
{
    partial class Simulator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Simulator));
            this.richTextBox_Current = new System.Windows.Forms.RichTextBox();
            this.button_Update = new System.Windows.Forms.Button();
            this.richTextBox_Outputs = new System.Windows.Forms.RichTextBox();
            this.richTextBox_Voltage = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox_Simulator_State = new System.Windows.Forms.CheckBox();
            this.richTextBox_Rpm = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox_Rpm_Enabled = new System.Windows.Forms.CheckBox();
            this.richTextBox_rpm_max = new System.Windows.Forms.RichTextBox();
            this.richTextBox_rpm_min = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_Current
            // 
            this.richTextBox_Current.Location = new System.Drawing.Point(16, 31);
            this.richTextBox_Current.Name = "richTextBox_Current";
            this.richTextBox_Current.Size = new System.Drawing.Size(76, 24);
            this.richTextBox_Current.TabIndex = 0;
            this.richTextBox_Current.Text = "2358";
            // 
            // button_Update
            // 
            this.button_Update.Location = new System.Drawing.Point(200, 97);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(149, 48);
            this.button_Update.TabIndex = 1;
            this.button_Update.Text = "Update";
            this.button_Update.UseVisualStyleBackColor = true;
            this.button_Update.Click += new System.EventHandler(this.button_Current_Click);
            // 
            // richTextBox_Outputs
            // 
            this.richTextBox_Outputs.Location = new System.Drawing.Point(200, 31);
            this.richTextBox_Outputs.Name = "richTextBox_Outputs";
            this.richTextBox_Outputs.Size = new System.Drawing.Size(149, 60);
            this.richTextBox_Outputs.TabIndex = 2;
            this.richTextBox_Outputs.Text = "Current Adc: 4096\nVoltage Adc: 4096";
            // 
            // richTextBox_Voltage
            // 
            this.richTextBox_Voltage.Location = new System.Drawing.Point(16, 61);
            this.richTextBox_Voltage.Name = "richTextBox_Voltage";
            this.richTextBox_Voltage.Size = new System.Drawing.Size(76, 24);
            this.richTextBox_Voltage.TabIndex = 3;
            this.richTextBox_Voltage.Text = "3440";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(97, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Voltage";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(98, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Current";
            // 
            // checkBox_Simulator_State
            // 
            this.checkBox_Simulator_State.AutoSize = true;
            this.checkBox_Simulator_State.Location = new System.Drawing.Point(16, 12);
            this.checkBox_Simulator_State.Name = "checkBox_Simulator_State";
            this.checkBox_Simulator_State.Size = new System.Drawing.Size(127, 20);
            this.checkBox_Simulator_State.TabIndex = 7;
            this.checkBox_Simulator_State.Text = "Electric Enabled";
            this.checkBox_Simulator_State.UseVisualStyleBackColor = true;
            this.checkBox_Simulator_State.CheckedChanged += new System.EventHandler(this.checkBox_Simulator_State_CheckedChanged);
            // 
            // richTextBox_Rpm
            // 
            this.richTextBox_Rpm.Location = new System.Drawing.Point(139, 169);
            this.richTextBox_Rpm.Name = "richTextBox_Rpm";
            this.richTextBox_Rpm.Size = new System.Drawing.Size(71, 24);
            this.richTextBox_Rpm.TabIndex = 8;
            this.richTextBox_Rpm.Text = "250";
            this.richTextBox_Rpm.TextChanged += new System.EventHandler(this.richTextBox_Rpm_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Encod. Rpm";
            // 
            // checkBox_Rpm_Enabled
            // 
            this.checkBox_Rpm_Enabled.AutoSize = true;
            this.checkBox_Rpm_Enabled.Location = new System.Drawing.Point(16, 121);
            this.checkBox_Rpm_Enabled.Name = "checkBox_Rpm_Enabled";
            this.checkBox_Rpm_Enabled.Size = new System.Drawing.Size(116, 20);
            this.checkBox_Rpm_Enabled.TabIndex = 10;
            this.checkBox_Rpm_Enabled.Text = "Rpm_Enabled";
            this.checkBox_Rpm_Enabled.UseVisualStyleBackColor = true;
            this.checkBox_Rpm_Enabled.CheckedChanged += new System.EventHandler(this.checkBox_Rpm_Enabled_CheckedChanged);
            // 
            // richTextBox_rpm_max
            // 
            this.richTextBox_rpm_max.Location = new System.Drawing.Point(228, 169);
            this.richTextBox_rpm_max.Name = "richTextBox_rpm_max";
            this.richTextBox_rpm_max.Size = new System.Drawing.Size(71, 24);
            this.richTextBox_rpm_max.TabIndex = 11;
            this.richTextBox_rpm_max.Text = "250";
            // 
            // richTextBox_rpm_min
            // 
            this.richTextBox_rpm_min.Location = new System.Drawing.Point(62, 169);
            this.richTextBox_rpm_min.Name = "richTextBox_rpm_min";
            this.richTextBox_rpm_min.Size = new System.Drawing.Size(71, 24);
            this.richTextBox_rpm_min.TabIndex = 12;
            this.richTextBox_rpm_min.Text = "250";
            // 
            // Simulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(402, 213);
            this.Controls.Add(this.richTextBox_rpm_min);
            this.Controls.Add(this.richTextBox_rpm_max);
            this.Controls.Add(this.checkBox_Rpm_Enabled);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_Rpm);
            this.Controls.Add(this.checkBox_Simulator_State);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox_Voltage);
            this.Controls.Add(this.richTextBox_Outputs);
            this.Controls.Add(this.button_Update);
            this.Controls.Add(this.richTextBox_Current);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Simulator";
            this.Text = "Simulator";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.RichTextBox richTextBox_Current;
        public System.Windows.Forms.Button button_Update;
        public System.Windows.Forms.RichTextBox richTextBox_Outputs;
        public System.Windows.Forms.RichTextBox richTextBox_Voltage;
        public System.Windows.Forms.CheckBox checkBox_Simulator_State;
        public System.Windows.Forms.RichTextBox richTextBox_Rpm;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.CheckBox checkBox_Rpm_Enabled;
        public System.Windows.Forms.RichTextBox richTextBox_rpm_max;
        public System.Windows.Forms.RichTextBox richTextBox_rpm_min;
    }
}