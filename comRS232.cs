using System;
using System.Diagnostics;
using System.IO.Ports;

namespace Sondeur_1007_Kongsberg
{

    public class comRS232
    {
        //Private attribute
        private string name;

        private SerialPort _serialPort;
        private MainWindow wd;

        //Public attribute
        public string messageInput = "";
        public string messageOutput = "";

        public comRS232(string nameInput, string COM, int bauds, MainWindow wds)
        {
            try
            {
                this.name = nameInput;
                //INIT
                _serialPort = new SerialPort(COM, bauds);
                this.wd = wds;                              //Declaration main window pour accès methode public

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                _serialPort.Open();
            }
            catch { }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            //string indata = sp.();  //ReadExisting()
            string mystring;
            sp.ReadTimeout = 300;       //timeout laissé a 100ms... a voir su on le modifie
            sp.NewLine = "\r";

            while (sp.BytesToRead > 0)
            {
                try
                {
                    byte stxCheck = (byte)sp.ReadByte();
                    if (stxCheck != 0)
                    {
                        mystring = sp.ReadLine();
                        wd.majDebugDisplay(mystring);
                        wd.sendToRedirect(mystring, this.name) ;
                        //Trace.WriteLine("le string " + mystring);
                    }
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("erreur lecture");
                    Trace.WriteLine(ex.Message);
                }

            }
        }

        ~comRS232()     //Destructeur de la classe... on s'assure de tout couper (Ancienne version avec les thread !)
        {
            //this._continue = false;
            //this.readThread.abord();
            this._serialPort.Close();
        }

        public void write(string msg)                               //a confirmer le fct !
        {
            try { 
                _serialPort.WriteLine(msg);
                wd.majDebugDisplay(msg);
            }
            catch
            {
                wd.errorDisplay(2);
            }
            
        }

        /*public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)     //Permet la réception/ lecture de données sur des events. peut etre plus intéressant avec un task async
        {
            this.messageInput = this._serialPort.ReadExisting();
            Trace.WriteLine(messageInput);
        }
        */
        public bool comIsOpen()
        {
            if (_serialPort.IsOpen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }           //True -> port is open; false -> port close

        public void closeCOM()
        {
            this._serialPort.Close();
        }

        public string getMessageInput()
        {
            return this.messageInput;
        }

        public void resetMessageInput()                                 //Reset des messages entrants !
        {
            this.messageInput = "$GNGGA,,,,,,,,,,,,,,,";
        }
    }

}