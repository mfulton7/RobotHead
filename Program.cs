using System;
using System.IO.Ports;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Mitchell Fulton
//10/28/16
//credit goes to microsoft tutorial article on how to initialize serial communications for inspirations and for some of the basic communication setup
//https://msdn.microsoft.com/en-us/library/system.io.ports.serialport(v=vs.110).aspx

namespace Serial_Interface
{
    public class serial_comm
    {
        //defined communication
        static SerialPort link;
        //check for reply
        static bool listen;

        //array to hold all current potentiometer data
        public static int[] positions;


        static void Main()
        {
            //initialize the position array
            positions = new int[7];
            for(int i = 0; i<positions.Length; i++)
            {
                positions[i] = 0;
            }

            //initialize serial port
            link = new SerialPort();

            //set communication timeouts
            link.ReadTimeout = 1000;
            link.WriteTimeout = 500;
            

            //setup properties
            link.PortName = SetPortName(link.PortName);
            link.BaudRate = SetPortBaudRate(link.BaudRate);
            link.Parity = SetPortParity(link.Parity);
            link.DataBits = SetPortDataBits(link.DataBits);
            link.StopBits = SetPortStopBits(link.StopBits);
          

            //begin communication
            link.Open();
            listen = true;
           

            Console.WriteLine("Type QUIT at any time to exit...");

            string input;
            byte[] output;
            output = new byte[3];

           
           

            //create a thread dedicated to receiving info
            Thread reader = new Thread(Read);
            reader.Start();

            while (listen)
            {
                //get input
                input = Console.ReadLine();
                //if quit then stop checking for input and move to close program
                if (input == "QUIT")
                {
                    listen = false;
                }
                else if(input == "status")
                {
                    for(int i = 0; i<positions.Length; i++)
                    {
                        Console.Write("Motor " + i + " :\t" + positions[i] + "\n");
                    }
                }
                //else normally execute the program
                else
                {
                    //send a signal that has 3 parts
                    //byte for which motor
                    //byte for desired position
                    //byte for speed in which motor should move
                }

            }

            reader.Join();
            link.Close();
        }

   
        /// ///////////////////////////////////////////////      
        //function to listen for input
         public static void Read()
        {
            while (listen)
            {
                
                int waiting = 0;
                string result;
                
                try
                {                    
                    waiting = link.BytesToRead;
                  
                    byte[] tmp = new byte[waiting];
                    //if a bytes are waiting to be read
                    if (waiting > 0)
                    {
                        //get information update
                        link.Read(tmp, 0, waiting);
                        result = Encoding.UTF8.GetString(tmp);
                        //Console.WriteLine(result);
                        int place = result.Length - 1;
                        string[] codes = result.Split('0');
                        //if the recieved code meets the criteria for a valid code
                        //  if(result[place] == '0' && result.Length == 4)
                        //  {
                        //save the updates
                        for (int j = 0; j < codes.Length; j++)
                        {
                            if (codes[j].Length == 3)
                            {
                                int motornum = int.Parse(codes[j][0].ToString());
                                int motorpos = int.Parse(codes[j][1].ToString());
                                motorpos = motorpos * 10 + int.Parse(codes[j][2].ToString());
                                positions[motornum] = motorpos;
                            }
                        }
                            
                       // }
                        
                    }
                    //reset waiting
                    waiting = 0;
                    
                }
                catch (TimeoutException) { }
            }
        }

        ///////////////////////////////////////////////////////     
        //function to update motor position info to screen
        public static void Write(int num, int pos) {
            byte[] data = BitConverter.GetBytes(num);
            
            link.Write(data, 0, data.Length);

            data = BitConverter.GetBytes(pos);
            link.Write(data, 0, data.Length);


        }

        ///////////////////////////////////////////////////////
        //display port values and get user input
        public static string SetPortName(string defaultPortName)
        {
            string portName;

            Console.WriteLine("Available Ports:");
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter COM port value (Default: {0}): ", defaultPortName);
            portName = Console.ReadLine();

            if (portName == "" || !(portName.ToLower()).StartsWith("com"))
            {
                portName = defaultPortName;
            }
            return portName;
        }
        ///////////////////////////////////////////////////////
        //dsplay baudrate options and enter value
        public static int SetPortBaudRate(int defaultPortBaudRate)
        {
            string baudRate;

            Console.Write("Baud Rate(default:{0}): ", defaultPortBaudRate);
            baudRate = Console.ReadLine();

            if (baudRate == "")
            {
                baudRate = defaultPortBaudRate.ToString();
            }

            return int.Parse(baudRate);
        }
        ////////////////////////////////////////////////////////
        //display port parity values
        public static Parity SetPortParity(Parity defaultPortParity)
        {
            string parity;

            Console.WriteLine("Available Parity options:");
            foreach (string s in Enum.GetNames(typeof(Parity)))
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter Parity value (Default: {0}):", defaultPortParity.ToString(), true);
            parity = Console.ReadLine();

            if (parity == "")
            {
                parity = defaultPortParity.ToString();
            }

            return (Parity)Enum.Parse(typeof(Parity), parity, true);
        }
        ///////////////////////////////////////////////////////////
        public static int SetPortDataBits(int defaultPortDataBits)
        {
            string dataBits;

            Console.Write("Enter DataBits value (Default: {0}): ", defaultPortDataBits);
            dataBits = Console.ReadLine();

            if (dataBits == "")
            {
                dataBits = defaultPortDataBits.ToString();
            }

            return int.Parse(dataBits.ToUpperInvariant());
        }
        ///////////////////////////////////////////////////////////
        public static StopBits SetPortStopBits(StopBits defaultPortStopBits)
        {
            string stopBits;

            Console.WriteLine("Available StopBits options:");
            foreach (string s in Enum.GetNames(typeof(StopBits)))
            {
                Console.WriteLine("   {0}", s);
            }

            Console.Write("Enter StopBits value (None is not supported and \n" +
             "raises an ArgumentOutOfRangeException. \n (Default: {0}):", defaultPortStopBits.ToString());
            stopBits = Console.ReadLine();

            if (stopBits == "")
            {
                stopBits = defaultPortStopBits.ToString();
            }

            return (StopBits)Enum.Parse(typeof(StopBits), stopBits, true);
        }
        ///////////////////////////////////////////////////////////
  
    }
}
