namespace Serial_UI
{
    partial class Serial_Interface
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
            this.Command_Line = new System.Windows.Forms.TextBox();
            this.Command_Button = new System.Windows.Forms.Button();
            this.link = new System.IO.Ports.SerialPort(this.components);
            this.Listen_Button = new System.Windows.Forms.Button();
            this.Command_Label = new System.Windows.Forms.Label();
            this.COM_Button = new System.Windows.Forms.Button();
            this.Blink_Button = new System.Windows.Forms.Button();
            this.Input_Field = new System.Windows.Forms.Label();
            this.Output_Field = new System.Windows.Forms.Label();
            this.Label_In = new System.Windows.Forms.Label();
            this.Label_Out = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Command_Line
            // 
            this.Command_Line.Location = new System.Drawing.Point(58, 353);
            this.Command_Line.Name = "Command_Line";
            this.Command_Line.Size = new System.Drawing.Size(285, 20);
            this.Command_Line.TabIndex = 0;
            // 
            // Command_Button
            // 
            this.Command_Button.Location = new System.Drawing.Point(58, 391);
            this.Command_Button.Name = "Command_Button";
            this.Command_Button.Size = new System.Drawing.Size(177, 23);
            this.Command_Button.TabIndex = 1;
            this.Command_Button.Text = "Send Command";
            this.Command_Button.UseVisualStyleBackColor = true;
            this.Command_Button.Click += new System.EventHandler(this.Command_Button_Click);
            // 
            // link
            // 
            this.link.PortName = "COM3";
            // 
            // Listen_Button
            // 
            this.Listen_Button.Location = new System.Drawing.Point(58, 56);
            this.Listen_Button.Name = "Listen_Button";
            this.Listen_Button.Size = new System.Drawing.Size(153, 23);
            this.Listen_Button.TabIndex = 2;
            this.Listen_Button.Text = "Start Listening";
            this.Listen_Button.UseVisualStyleBackColor = true;
            this.Listen_Button.Click += new System.EventHandler(this.Listen_Button_Click);
            // 
            // Command_Label
            // 
            this.Command_Label.AutoSize = true;
            this.Command_Label.Location = new System.Drawing.Point(55, 322);
            this.Command_Label.Name = "Command_Label";
            this.Command_Label.Size = new System.Drawing.Size(193, 13);
            this.Command_Label.TabIndex = 7;
            this.Command_Label.Text = "Manual Control (num, spd, posX, posY):";
            // 
            // COM_Button
            // 
            this.COM_Button.Location = new System.Drawing.Point(545, 349);
            this.COM_Button.Name = "COM_Button";
            this.COM_Button.Size = new System.Drawing.Size(115, 65);
            this.COM_Button.TabIndex = 8;
            this.COM_Button.Text = "Open  Link";
            this.COM_Button.UseVisualStyleBackColor = true;
            this.COM_Button.Click += new System.EventHandler(this.COM_Button_Click);
            // 
            // Blink_Button
            // 
            this.Blink_Button.Location = new System.Drawing.Point(545, 56);
            this.Blink_Button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Blink_Button.Name = "Blink_Button";
            this.Blink_Button.Size = new System.Drawing.Size(115, 21);
            this.Blink_Button.TabIndex = 9;
            this.Blink_Button.Text = "Blink";
            this.Blink_Button.UseVisualStyleBackColor = true;
            this.Blink_Button.Click += new System.EventHandler(this.Blink_Button_Click);
            // 
            // Input_Field
            // 
            this.Input_Field.AutoSize = true;
            this.Input_Field.Location = new System.Drawing.Point(55, 127);
            this.Input_Field.Name = "Input_Field";
            this.Input_Field.Size = new System.Drawing.Size(35, 13);
            this.Input_Field.TabIndex = 10;
            this.Input_Field.Text = "label1";
            // 
            // Output_Field
            // 
            this.Output_Field.AutoSize = true;
            this.Output_Field.Location = new System.Drawing.Point(55, 200);
            this.Output_Field.Name = "Output_Field";
            this.Output_Field.Size = new System.Drawing.Size(35, 13);
            this.Output_Field.TabIndex = 11;
            this.Output_Field.Text = "label1";
            // 
            // Label_In
            // 
            this.Label_In.AutoSize = true;
            this.Label_In.Location = new System.Drawing.Point(55, 114);
            this.Label_In.Name = "Label_In";
            this.Label_In.Size = new System.Drawing.Size(88, 13);
            this.Label_In.TabIndex = 12;
            this.Label_In.Text = "CleverBot Heard:";
            // 
            // Label_Out
            // 
            this.Label_Out.AutoSize = true;
            this.Label_Out.Location = new System.Drawing.Point(55, 187);
            this.Label_Out.Name = "Label_Out";
            this.Label_Out.Size = new System.Drawing.Size(80, 13);
            this.Label_Out.TabIndex = 13;
            this.Label_Out.Text = "CleverBot Said:";
            // 
            // Serial_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 439);
            this.Controls.Add(this.Label_Out);
            this.Controls.Add(this.Label_In);
            this.Controls.Add(this.Output_Field);
            this.Controls.Add(this.Input_Field);
            this.Controls.Add(this.Blink_Button);
            this.Controls.Add(this.COM_Button);
            this.Controls.Add(this.Command_Label);
            this.Controls.Add(this.Listen_Button);
            this.Controls.Add(this.Command_Button);
            this.Controls.Add(this.Command_Line);
            this.Name = "Serial_Interface";
            this.Text = "Robot Head Program";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Command_Line;
        private System.Windows.Forms.Button Command_Button;
        private System.Windows.Forms.Button Listen_Button;
        private System.Windows.Forms.Label Command_Label;
        private System.Windows.Forms.Button COM_Button;
        public System.IO.Ports.SerialPort link;
        private System.Windows.Forms.Button Blink_Button;
        private System.Windows.Forms.Label Input_Field;
        private System.Windows.Forms.Label Output_Field;
        private System.Windows.Forms.Label Label_In;
        private System.Windows.Forms.Label Label_Out;
    }
}

