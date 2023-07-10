using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sondeur_1007_Kongsberg
{
    public class ServeurTCPIP
    {
        private MainWindow wd;
        TcpListener server;
        public bool listenerOn = false;
        Thread listen;
        public bool newMessage = false;

        public string message = "";

        //Constructeur, prend un param le port que l'on souhaite utiliser
        //Lance le thread d'écoute pour les clients
        public ServeurTCPIP(int port, MainWindow wds)
        {
            this.wd = wds;
            this.server = new TcpListener(IPAddress.Any, port);
            this.server.Start();
            this.listenerOn = true;
            this.listen = new Thread(new ThreadStart(StartListener));
            this.listen.Start();
        }

        // methode d'écoute, en attente des clients
        public void StartListener()
        {
            while (this.listenerOn)
            {
                //lecture msg entrant
                try
                {
                    Trace.WriteLine("Waiting for a connection...");
                    TcpClient client = server.AcceptTcpClient();
                    Trace.WriteLine("Connected ");
                    Thread t = new Thread(new ParameterizedThreadStart(HandleDevice));
                    t.Start(client);
                }
                catch (SocketException e)
                {
                    Console.WriteLine("SocketException: {0}", e);
                    server.Stop();
                }
            }
            
        }

        //Methode de com avec le client - du moment qu'une requete arrive en entrée, on maintien la com en envoyant
        //Chaque seconde les datas souhaités (dans notre cas, X,Y et Z)
        public void HandleDevice(Object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = client.GetStream();

            while (client.Connected && (this.listenerOn == true))        //Tant que le client est connecté, on balance les données
            {
                if (newMessage == true)
                {
                    byte[] byteToSend = System.Text.Encoding.ASCII.GetBytes(this.message);
                    try
                    {
                        ns.Write(byteToSend, 0, byteToSend.Length);
                        
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine("Exception : serveurTCPIP - Dans le while hypack");
                        Trace.WriteLine(ex);
                    }
                    newMessage = false;
                }
                Thread.Sleep(200);         //Petit délai pour ne pas spam les clients
            }
            client.GetStream().Close();
            client.Dispose();               //permet de libérer les ressource utilisés par le TCPClient
            client.Close();
        }

        public void closeServer()
        {
            this.listenerOn = false;
            server.Stop();
        }
    }
}
