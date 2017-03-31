using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using rtaNetworking.Streaming;

using System.Net;
using System.Net.Sockets;

namespace StartServer
{
    public partial class Form1 : Form
    {
        public static int portConnect1; // for sending byte stream
        public Thread thread;

        private void socketThread()
        {
            portConnect1 = int.Parse(textBox1.Text);
            ImageStreamingServer _Server;
            _Server = new ImageStreamingServer();
            _Server.Start(8090); // videoserver 

            try
            {
                SendMessageFromSocket(portConnect1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.ReadLine();
            }
            //Client.start(portConnect1); // connect to socket


        }

        public void SendMessageFromSocket(int port)
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

            textBox1.Text = "Введите сообщение: ";

            Console.Write("Введите сообщение: ");
            string message = "new text";
            textBox1.Text.Insert(1,"Сокет соединяется с {0} ");
            
            Console.WriteLine("Сокет соединяется с {0} ", sender.RemoteEndPoint.ToString());
            byte[] msg = Encoding.UTF8.GetBytes(message);

            // Отправляем данные через сокет
            sender.Send(msg);

            // Получаем ответ от сервера
            int bytesRec = sender.Receive(bytes);


            Console.WriteLine("\nОтвет от сервера: {0}\n\n", Encoding.UTF8.GetString(bytes, 0, bytesRec));

            // Используем рекурсию для неоднократного вызова SendMessageFromSocket()
            if (message.IndexOf("<TheEnd>") == -1)
                SendMessageFromSocket(port);

            // Освобождаем сокет
            sender.Shutdown(SocketShutdown.Both);
            sender.Close();
        }


        /// <summary>
        /// Проверка правильности ввода порта в TextBox
        /// </summary>
        /// <param name="e">KeyPressEventArgs</param>
        private void checkPortBox(KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            thread = new Thread(socketThread); // Объявляем поток для запуска сервера
            //Default ports
            textBox1.Text = "11100";
            textBox2.Text = "11101";
            textBox3.Text = "11102";
            button2.Enabled = false;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Start Thread
            thread.Start();
           
            // Блокируем кнопки
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Stop Thread
            thread.Abort();
            thread.Join();

            // Блокируем кнопки
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        //Обработчики ввода
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkPortBox(e);

        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkPortBox(e);

        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkPortBox(e);

        }

        public void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
