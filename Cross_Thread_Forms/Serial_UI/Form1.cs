using System;
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
            string[] input = Command_Line.Text.Split(' ');
            byte[] in_bytes = new byte[3];
            byte[] tmp;
            tmp = Encoding.ASCII.GetBytes(input[0]);
            in_bytes[0] = tmp[0];
            tmp = Encoding.ASCII.GetBytes(input[1]);
            in_bytes[1] = tmp[1];
            tmp = Encoding.ASCII.GetBytes(input[2]);
            in_bytes[2] = tmp[2];

            link.Write(in_bytes, 0, in_bytes.Length);
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
    }
}
