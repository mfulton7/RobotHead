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
            this.SuspendLayout();
            // 
            // Command_Line
            // 
            this.Command_Line.Location = new System.Drawing.Point(87, 543);
            this.Command_Line.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Command_Line.Name = "Command_Line";
            this.Command_Line.Size = new System.Drawing.Size(426, 26);
            this.Command_Line.TabIndex = 0;
            // 
            // Command_Button
            // 
            this.Command_Button.Location = new System.Drawing.Point(87, 602);
            this.Command_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Command_Button.Name = "Command_Button";
            this.Command_Button.Size = new System.Drawing.Size(266, 35);
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
            this.Listen_Button.Location = new System.Drawing.Point(87, 86);
            this.Listen_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Listen_Button.Name = "Listen_Button";
            this.Listen_Button.Size = new System.Drawing.Size(230, 35);
            this.Listen_Button.TabIndex = 2;
            this.Listen_Button.Text = "Start Listening";
            this.Listen_Button.UseVisualStyleBackColor = true;
            this.Listen_Button.Click += new System.EventHandler(this.Listen_Button_Click);
            // 
            // Command_Label
            // 
            this.Command_Label.AutoSize = true;
            this.Command_Label.Location = new System.Drawing.Point(82, 495);
            this.Command_Label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Command_Label.Name = "Command_Label";
            this.Command_Label.Size = new System.Drawing.Size(289, 20);
            this.Command_Label.TabIndex = 7;
            this.Command_Label.Text = "Manual Control (num, spd, posX, posY):";
            // 
            // COM_Button
            // 
            this.COM_Button.Location = new System.Drawing.Point(818, 537);
            this.COM_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.COM_Button.Name = "COM_Button";
            this.COM_Button.Size = new System.Drawing.Size(172, 100);
            this.COM_Button.TabIndex = 8;
            this.COM_Button.Text = "Open  Link";
            this.COM_Button.UseVisualStyleBackColor = true;
            this.COM_Button.Click += new System.EventHandler(this.COM_Button_Click);
            // 
            // Blink_Button
            // 
            this.Blink_Button.Location = new System.Drawing.Point(818, 86);
            this.Blink_Button.Name = "Blink_Button";
            this.Blink_Button.Size = new System.Drawing.Size(172, 33);
            this.Blink_Button.TabIndex = 9;
            this.Blink_Button.Text = "Blink";
            this.Blink_Button.UseVisualStyleBackColor = true;
            this.Blink_Button.Click += new System.EventHandler(this.Blink_Button_Click);
            // 
            // Serial_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 675);
            this.Controls.Add(this.Blink_Button);
            this.Controls.Add(this.COM_Button);
            this.Controls.Add(this.Command_Label);
            this.Controls.Add(this.Listen_Button);
            this.Controls.Add(this.Command_Button);
            this.Controls.Add(this.Command_Line);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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
    }
}

