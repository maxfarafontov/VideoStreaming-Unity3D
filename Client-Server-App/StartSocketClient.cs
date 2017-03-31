using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client_Server_App
{
    public class StartSocketClient
    {
        private String message;

        public String getMessage(){return message;}

        public StartSocketClient(int port)
        {
            start(11000);
        }

        public void start(int port)
        {
            try
            {
                SendMessageFromSocket(port);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
        }

        private void SendMessageFromSocket(int port)
        {
            // Буфер для входящих данных
            byte[] bytes = new byte[1024];

            // Соединяемся с удаленным устройством

            // Устанавливаем удаленную точку для сокета
            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);

            Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // Соединяем сокет с удаленной точкой
            sender.Connect(ipEndPoint);


            //Console.Write("Введите сообщение: ");
            //string message = Console.ReadLine();

            //Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            //byte[] msg = Encoding.UTF8.GetBytes(message);

            // Отправляем данные через сокет
            //sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);
            string filename = "Cam1Shot_" + 1 + ".png";
            System.IO.File.WriteAllBytes(filename, bytes);

            Console.WriteLine("\nОтвет от сервера - чет получили");
            //message = "Ответ от сервера: " + Encoding.UTF8.GetString(bytes, 0, bytesRec);
            message = "Ответ от сервера: - чет получили хз";

            SendMessageFromSocket(port);
            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
            //if (message.IndexOf("<TheEnd>") == -1)
            //    SendMessageFromSocket(port);

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }
    }
}
