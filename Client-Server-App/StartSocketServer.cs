using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client_Server_App 
{
    public class StartSocketServer
    {
        private String logMessage = "";
       
        private bool checkEnd = true;

        public void startServer(int port)
        {
            string ipServer = "localhost";

            // Устанавливаем для сокета локальную конечную точку
            IPHostEntry ipHost = Dns.GetHostEntry(ipServer);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            
            // Создаем сокет Tcp/Ip
            Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Назначаем сокет локальной конечной точке и слушаем входящие сокеты
            sListener.Bind(ipEndPoint);
            sListener.Listen(10);

            // Начинаем слушать соединения
            while (checkEnd)
            {
                Console.WriteLine("Ожидаем соединение через порт ", port," : ", ipEndPoint);
                logMessage += "Ожидаем соединение через порт " + port + " : " + ipEndPoint;
               
                // Программа приостанавливается, ожидая входящее соединение
                Socket handler = sListener.Accept();
                string data = null;

                // Мы дождались клиента, пытающегося с нами соединиться

                byte[] bytes = new byte[1024];
                int bytesRec = handler.Receive(bytes);

                data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

                // Показываем данные на консоли
                Console.Write("Полученный текст: " + data + "\n\n");
                logMessage += "Полученный текст: " + data + "\n\n";

                // Отправляем ответ клиенту
                string reply = "Спасибо за запрос в " + data.Length.ToString() + " символов";
                byte[] msg = Encoding.UTF8.GetBytes(reply);
                handler.Send(msg);

                if ((data.IndexOf("<TheEnd>") > -1) && checkEnd)
                {
                    Console.WriteLine("Сервер завершил соединение с клиентом.");
                    break;
                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            
        }

        public void stopServer()
        {
            checkEnd = false;
        }
        public String recieveLogMessage()
        {
            return logMessage;
        }

    }
}