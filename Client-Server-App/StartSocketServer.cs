using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_Server_App 
{
    public class StartSocketServer
    {
        private String GetHostEntryAddr = "localhost";
        private int serverPort = 11100;
        private Socket handler;
        private Socket sListener;

        private byte[] testMsg;
       
        private bool stopSocket = false;
        private String status = "";


        public StartSocketServer()
        {
            startSocket();
        }

        public void startSocket()
        {
            IPHostEntry ipHost = Dns.GetHostEntry(GetHostEntryAddr);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, serverPort);

            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                status = "Ожидание подключения";
                handler = sListener.Accept();

                while (!stopSocket)
                {
                    status = "Подключено";
                    testMsg = Encoding.UTF8.GetBytes("\nПодключено\n");
                    handler.Send(testMsg);
                }

                status = "Отключено";
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();

            }
            catch (SocketException)
            {

            }
            finally
            {

            }

        }
        public void stopServer()
        {
            stopSocket = false;
        }
        public String getStatusServer()
        {
            return status;
        }
    }
}