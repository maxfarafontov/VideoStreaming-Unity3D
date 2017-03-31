using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_Server_App
{
    public partial class FormShowImage : Form
    {
        public FormShowImage()
        {
            InitializeComponent();
        }

        public FormShowImage(Form1 f)
        {
            InitializeComponent();
        }

        private void FormShowImage_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate(@"http://localhost:"+8080);
        }
    }
}
