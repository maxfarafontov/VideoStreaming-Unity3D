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
using System.Net;
using System.Net.Sockets;



namespace Client_Server_App
{
    public partial class Form1 : Form
    {

        // --------------Variables----------------//
        String message = "";
        bool stopServer = false;
        bool send = false;
        string logMessage = "";
        private BackgroundWorker backgroundWorker;
        //private Thread socketThread;
        StartSocketServer socketServer = new StartSocketServer();

        delegate void updateInfo();

        //----Таймер для обновления окошек лога--//
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        int timerCounter = 0;
        //----------------------------------------//

        // --------------End----------------------//

        private void updateLabels()
        {
            
        }

        

        public Form1()
        {
            InitializeComponent();

        }

        void timer_Tick(object sender, EventArgs e)
        {
            //В текстбокс выводим значение timerCounter увеличенное на 1
            this.logBox.Text = (++timerCounter).ToString();
        }

        private void socketTask()
        {
            socketServer.startServer(int.Parse(portBox1.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //thread = new Thread(socketTask); // Объявляем поток для запуска сервера

            //Default ports
            portBox1.Text = "11100";
            portBox2.Text = "11101";
            portBox3.Text = "11102";
            //textBox0.Text = "127.0.0.1";
            textBox0.Text = "localhost";
            btnDisconnect.Enabled = false;
            //this.Invoke(new updateInfo(updateLabels), new object[] { });
        }

        //Start Client Button
        private void button1_Click(object sender, EventArgs e)
        {
            Thread socketServer = new Thread(socketTask);
            socketServer.Start();

            timer.Interval = 1000; //интервал между срабатываниями 1000 миллисекунд
            timer.Tick += new EventHandler(timer_Tick); //подписываемся на события Tick
            timer.Start();


            
        }
        //Stop Button
        private void button2_Click(object sender, EventArgs e)
        {

            //Stop Thread
            socketServer.stopServer();
            //thread.Abort();
            //thread.Join(500);


        }

        //this.Invoke(new updateInfo(updateLabels), new object[] { });
        private void button3_Click(object sender, EventArgs e)
        {
            FormShowImage newForm = new FormShowImage(this);
            newForm.Show();
        }

        private void socketClientThread()
        {
            SendMessageFromSocket(11100);
        }

        // Client Start
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread socketClient = new Thread(socketClientThread);
            socketClient.Start();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            stopServer = true;
        }


        private void SendMessageFromSocket(int port)
        {

            
            BeginInvoke(new MethodInvoker(delegate
            {
                toolStripProgressBar1.Value = 20;
                btnConnect.Enabled = false;
            }));

            Socket sender;
            string localHost = "localhost";

            // буфер для данных
            //byte[] imageBuffer = new byte[1024 * 1024];
            
            int bytesRec = 0;
            
            // берем значение из textBox с адресом машины
            BeginInvoke(new MethodInvoker(delegate
            {
                toolStripProgressBar1.Value = 50;
                //localHost = textBox0.Text;
            }));

            try
            {
                IPHostEntry ipHost = Dns.GetHostEntry(localHost);
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
                sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(ipEndPoint);

                BeginInvoke(new MethodInvoker(delegate
                {
                    if (sender.Connected)
                    {
                        btnConnect.Enabled = false;
                        btnDisconnect.Enabled = true;
                        statusLabel.Text = "Подключен к серверу";
                        toolStripProgressBar1.Value = 100;
                    }
                    else
                    {
                        toolStripProgressBar1.Value = 0;
                        btnConnect.Enabled = true;
                    }
                }));

                while (true)
                {
                    if (!stopServer)
                    {
                        //int bytesRec = sender.Receive(imageBuffer);
                        //string filename = "Cam1Shot_" + 1 + ".png";
                        //System.IO.File.WriteAllBytes(filename, bytes);
                        byte[] textBuffer = new byte[1024];
                        bytesRec = sender.Receive(textBuffer);
                        
                        //BeginInvoke(new MethodInvoker(delegate
                        //{
                        //logBox.Text += "Получено: " + Encoding.UTF8.GetString(textBuffer, 0, bytesRec) + Environment.NewLine;
                        //}));
                        logMessage += "Получено: " + Encoding.UTF8.GetString(textBuffer, 0, bytesRec) + Environment.NewLine;

                        // Используем рекурсию для неоднократного вызова SendMessageFromSocket()

                        //sender.Shutdown(SocketShutdown.Both);
                        //sender.Close();
                    }
                    else
                    {
                        sender.Shutdown(SocketShutdown.Both);
                        sender.Close();
                        
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            statusLabel.Text = "Не подключен ";
                            toolStripProgressBar1.Value = 0;
                            btnConnect.Enabled = true;
                            btnDisconnect.Enabled = false;
                            stopServer = false;
                        }));
                        break;
                    }

                }
                
            }
            catch (SocketException)
            {
                BeginInvoke(new MethodInvoker(delegate{
                    statusLabel.Text = "Ошибка подключения!";
                }));
            }
            finally
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    btnConnect.Enabled = true;
                }));
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        int i = 0;
        // Таймер для обновления лога
        private void timer1_Tick(object sender, EventArgs e)
        {
            //logBox.Text += "Добавляем значение\n + Environment.NewLine";
            //statusLabel.Text = "Готов уже " + i++ + " секунд";
            logBox.Text = logMessage;
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

        private void toolStripProgressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
