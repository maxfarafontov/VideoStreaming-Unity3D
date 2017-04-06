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
        //String message = "";
        bool stopClient = false;
        string logMessage = "";
        private BackgroundWorker backgroundWorker;
        

        delegate void updateInfo();

        
        // Socket
        private String GetHostEntryAddr = "localhost";
        private int serverPort = 11100;
        private Socket handler;
        private Socket sListener;

        private byte[] testMsg;

        private bool stopSocket = false;
        private String status = "";
        // --------------End----------------------//

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //thread = new Thread(socketTask); // Объявляем поток для запуска сервера

            //Default variables
            portBox1.Text = "11100";
            portBox2.Text = "11101";
            portBox3.Text = "11102";
            portBox4.Text = "11103";
            portBox5.Text = "11104";
            portBox6.Text = "11105";
            portBox7.Text = "11106";
            portBox8.Text = "11107";
            portBox9.Text = "11108";
            portBox10.Text = "11109";
            textBox0.Text = "localhost";
            btnDisconnect.Enabled = false;

            Thread socketServer = new Thread(startServerThread);
            socketServer.Start();
            //this.Invoke(new updateInfo(updateLabels), new object[] { });
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

        /// <summary>
        /// Server for testing
        /// </summary>
        private void startServerThread()
        {
            BeginInvoke(new MethodInvoker(delegate {
                btn_start_server.Enabled = false;
                btn_stop_server.Enabled = true;
                toolStripProgressBar2.Value = 50;
                statusServerLabel.Text = "Сервер запущен! Ожидание подключения...";
            }));

            IPHostEntry ipHost = Dns.GetHostEntry(GetHostEntryAddr);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, serverPort);

            sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sListener.Bind(ipEndPoint);
                sListener.Listen(10);
                status = "Ожидание подключения";

                while (!stopSocket)
                {
                    handler = sListener.Accept();
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        btnConnect.Enabled = false;

                        statusServerLabel.Text = "Подключен клиент";
                        logMessage += ("Подключен клиент! " + Environment.NewLine);
                        toolStripProgressBar2.Value = 100;
                    }));
                    status = "Подключено";
                    testMsg = Encoding.UTF8.GetBytes("\nПодключено\n");

                    while (!stopSocket)
                    {
                        handler.Send(testMsg);
                    }

                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                }

                status = "Отключено";
                
            }
            catch (SocketException e)
            {
                
                BeginInvoke(new MethodInvoker(delegate 
                {
                    logMessage += e.ToString();
                    btn_start_server.Enabled = true;
                    btn_stop_server.Enabled = false;
                    statusServerLabel.Text = "Отключено";
                    toolStripProgressBar2.Value = 0;
                }));
            }
            finally
            {
                BeginInvoke(new MethodInvoker(delegate {
                    btn_start_server.Enabled = true;
                    btn_stop_server.Enabled = false;
                    statusServerLabel.Text = "Отключено";
                    toolStripProgressBar2.Value = 0;
                }));
            }
        }

        // Client Start
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Thread socketClient = new Thread(socketClientThread);
            socketClient.Start();
        }
        // Client Stop
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            stopClient = true;
            //socketServer.stopServer();
        }

        private void btn_start_server_Click(object sender, EventArgs e)
        {
            Thread socketServer = new Thread(startServerThread);
            socketServer.Start();
            
        }

        private void btn_stop_server_Click(object sender, EventArgs e)
        {
            stopSocket = true;
        }

        /// <summary>
        /// Socket Client
        /// </summary>
        /// <param name="port">Номер порта подключения</param>
        private void SendMessageFromSocket(int port)
        {
            BeginInvoke(new MethodInvoker(delegate {
                    toolStripProgressBar1.Value = 20;
                    btnConnect.Enabled = false;
                }));

            Socket sender;
            string localHost = "localhost";

            // буфер для данных
            //byte[] imageBuffer = new byte[1024 * 1024];
            
            int bytesRec = 0;

            BeginInvoke(new MethodInvoker(delegate{
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
                        logMessage += ("Connected! " + Environment.NewLine);
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
                    if (!stopClient)
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
                        //logMessage += ("Получено: " + Encoding.UTF8.GetString(textBuffer, 0, bytesRec) + Environment.NewLine);

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
                            stopClient = false;
                        }));
                        break;
                    }

                }
                
            }
            catch (SocketException)
            {
                BeginInvoke(new MethodInvoker(delegate{
                    statusLabel.Text = "Ошибка подключения!";
                    toolStripProgressBar1.Value = 0;
                }));
                logMessage += "Ошибка подключения";
            }
            finally
            {
                BeginInvoke(new MethodInvoker(delegate{
                    btnConnect.Enabled = true;
                }));

            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        // Таймер для обновления лога
        private void timer1_Tick(object sender, EventArgs e)
        {
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

        
    }
}
