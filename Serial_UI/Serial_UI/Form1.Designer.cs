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
            this.Input_Label = new System.Windows.Forms.Label();
            this.Output_Label = new System.Windows.Forms.Label();
            this.Input_Field = new System.Windows.Forms.Label();
            this.Output_Field = new System.Windows.Forms.Label();
            this.Command_Label = new System.Windows.Forms.Label();
            this.COM_Button = new System.Windows.Forms.Button();
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
            // Input_Label
            // 
            this.Input_Label.AutoSize = true;
            this.Input_Label.Location = new System.Drawing.Point(58, 104);
            this.Input_Label.Name = "Input_Label";
            this.Input_Label.Size = new System.Drawing.Size(66, 13);
            this.Input_Label.TabIndex = 3;
            this.Input_Label.Text = "Heard Input:";
            // 
            // Output_Label
            // 
            this.Output_Label.AutoSize = true;
            this.Output_Label.Location = new System.Drawing.Point(58, 167);
            this.Output_Label.Name = "Output_Label";
            this.Output_Label.Size = new System.Drawing.Size(95, 13);
            this.Output_Label.TabIndex = 4;
            this.Output_Label.Text = "Generated Output:";
            // 
            // Input_Field
            // 
            this.Input_Field.AutoSize = true;
            this.Input_Field.Location = new System.Drawing.Point(58, 126);
            this.Input_Field.Name = "Input_Field";
            this.Input_Field.Size = new System.Drawing.Size(35, 13);
            this.Input_Field.TabIndex = 5;
            this.Input_Field.Text = "label3";
            // 
            // Output_Field
            // 
            this.Output_Field.AutoSize = true;
            this.Output_Field.Location = new System.Drawing.Point(58, 191);
            this.Output_Field.Name = "Output_Field";
            this.Output_Field.Size = new System.Drawing.Size(35, 13);
            this.Output_Field.TabIndex = 6;
            this.Output_Field.Text = "label4";
            // 
            // Command_Label
            // 
            this.Command_Label.AutoSize = true;
            this.Command_Label.Location = new System.Drawing.Point(55, 322);
            this.Command_Label.Name = "Command_Label";
            this.Command_Label.Size = new System.Drawing.Size(156, 13);
            this.Command_Label.TabIndex = 7;
            this.Command_Label.Text = "Manual Control (num, spd, pos):";
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
            // Serial_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 439);
            this.Controls.Add(this.COM_Button);
            this.Controls.Add(this.Command_Label);
            this.Controls.Add(this.Output_Field);
            this.Controls.Add(this.Input_Field);
            this.Controls.Add(this.Output_Label);
            this.Controls.Add(this.Input_Label);
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
        private System.Windows.Forms.Label Input_Label;
        private System.Windows.Forms.Label Output_Label;
        private System.Windows.Forms.Label Input_Field;
        private System.Windows.Forms.Label Output_Field;
        private System.Windows.Forms.Label Command_Label;
        private System.Windows.Forms.Button COM_Button;
        public System.IO.Ports.SerialPort link;
    }
}

