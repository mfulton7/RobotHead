﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serial_UI;

namespace Serial_UI
{
    public partial class Serial_Interface : Form
    {

        delegate void SetTextCallback(string text);
        private SpeechHandler speech;
        

        public Serial_Interface()
        {
            InitializeComponent();

            BackgroundWorker bw = new BackgroundWorker();
            bw.DoWork += new DoWorkEventHandler(create_Speech_Session);
            bw.RunWorkerAsync();
        }

        private void COM_Button_Click(object sender, EventArgs e)
        {
            //if comms haven't been set up
            if (!link.IsOpen)
            {
                //set communication timeouts
                link.ReadTimeout = 1000;
                link.WriteTimeout = 500;

                link.Open();
                COM_Button.Text = "Close Link";

                //create a thread dedicated to receiving info
                Thread reader = new Thread(() => Program.Read(link));
                reader.Start();

                
            }
            else
            {
                COM_Button.Text = "Open Link";
                link.Close();
            }

        }

        //sends the context of the command line over arduino
        private void Command_Button_Click(object sender, EventArgs e)
        {
            if (link.IsOpen)
            {
                string[] input = Command_Line.Text.Split(' ');
                byte[] bytes = Array.ConvertAll(input, byte.Parse);
                Command_Line.Text = "";




                link.Write(bytes, 0, bytes.Length);
            }
            else
            {
                MessageBox.Show("Error Com Port not open...", "Error", MessageBoxButtons.OK);
            }
        }

        //starts listening to pass input to clever bot
        private void Listen_Button_Click(object sender, EventArgs e)
        {
            //start clever bot thread
            //if no current listening thread
            if (!Program.l_thread)
            {
                Listen_Button.Text = "Stop Listening";
                speech.Begin_Listening();
                Program.l_thread = true;
            }
            else
            {
                Listen_Button.Text = "Start Listening";
                speech.Stop_Listening();
                Program.l_thread = false;
            }
        }

        private void create_Speech_Session(object sender, DoWorkEventArgs e)
        {
            speech = new SpeechHandler(this);
        }
        public void set_Input_Text(string message)
        {
            if (this.Input_Field.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(set_Input_Text);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                this.Input_Field.Text = message;
            }
        }

        public void set_Output_Text(string message)
        {
            if (this.Output_Field.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(set_Output_Text);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                this.Output_Field.Text = message;
            }
        }
        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           
            Application.Exit();
        }

        private void Blink_Button_Click(object sender, EventArgs e)
        {
            if (link.IsOpen)
            {
                byte[] b = new byte[4];
                b[0] = 2;
                b[1] = 0;
                b[2] = 0;
                b[3] = 0;
                link.Write(b, 0, b.Length);
            }
            else
            {
                MessageBox.Show("Error Com Port not open...", "Error", MessageBoxButtons.OK);
            }

        }
    }
}

