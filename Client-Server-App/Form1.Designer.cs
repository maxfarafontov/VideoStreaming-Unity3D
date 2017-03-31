namespace Client_Server_App
{
    public partial class Form1
    {
        

        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.portBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.portBox2 = new System.Windows.Forms.TextBox();
            this.portBox1 = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.logBox = new System.Windows.Forms.TextBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox0 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.portBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.portBox6 = new System.Windows.Forms.TextBox();
            this.portBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.portBox8 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.portBox9 = new System.Windows.Forms.TextBox();
            this.portBox10 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.portBox7 = new System.Windows.Forms.TextBox();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Camera 3";
            // 
            // portBox3
            // 
            this.portBox3.Location = new System.Drawing.Point(316, 82);
            this.portBox3.MaxLength = 5;
            this.portBox3.Name = "portBox3";
            this.portBox3.Size = new System.Drawing.Size(59, 20);
            this.portBox3.TabIndex = 13;
            this.portBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox3_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(258, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Camera 2";
            // 
            // portBox2
            // 
            this.portBox2.Location = new System.Drawing.Point(316, 56);
            this.portBox2.MaxLength = 5;
            this.portBox2.Name = "portBox2";
            this.portBox2.Size = new System.Drawing.Size(59, 20);
            this.portBox2.TabIndex = 11;
            this.portBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            // 
            // portBox1
            // 
            this.portBox1.Location = new System.Drawing.Point(316, 30);
            this.portBox1.MaxLength = 5;
            this.portBox1.Name = "portBox1";
            this.portBox1.Size = new System.Drawing.Size(59, 20);
            this.portBox1.TabIndex = 9;
            this.portBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(166, 30);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 18;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // logBox
            // 
            this.logBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.logBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.logBox.ForeColor = System.Drawing.SystemColors.Desktop;
            this.logBox.Location = new System.Drawing.Point(439, 27);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.logBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logBox.ShortcutsEnabled = false;
            this.logBox.Size = new System.Drawing.Size(267, 322);
            this.logBox.TabIndex = 21;
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(166, 58);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 24;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.toolStripProgressBar1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 381);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(706, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 25;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Status";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(706, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem3.Text = "1111";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(619, 355);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = "Stream";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox0
            // 
            this.textBox0.Location = new System.Drawing.Point(15, 30);
            this.textBox0.Name = "textBox0";
            this.textBox0.Size = new System.Drawing.Size(134, 20);
            this.textBox0.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Camera 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(258, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 36;
            this.label4.Text = "Camera 4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(258, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 35;
            this.label5.Text = "Camera 5";
            // 
            // portBox5
            // 
            this.portBox5.Location = new System.Drawing.Point(316, 134);
            this.portBox5.MaxLength = 5;
            this.portBox5.Name = "portBox5";
            this.portBox5.Size = new System.Drawing.Size(59, 20);
            this.portBox5.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(258, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 33;
            this.label6.Text = "Camera 6";
            // 
            // portBox6
            // 
            this.portBox6.Location = new System.Drawing.Point(316, 160);
            this.portBox6.MaxLength = 5;
            this.portBox6.Name = "portBox6";
            this.portBox6.Size = new System.Drawing.Size(59, 20);
            this.portBox6.TabIndex = 32;
            // 
            // portBox4
            // 
            this.portBox4.Location = new System.Drawing.Point(316, 108);
            this.portBox4.MaxLength = 5;
            this.portBox4.Name = "portBox4";
            this.portBox4.Size = new System.Drawing.Size(59, 20);
            this.portBox4.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(258, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Camera 7";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Camera 8";
            // 
            // portBox8
            // 
            this.portBox8.Location = new System.Drawing.Point(316, 212);
            this.portBox8.MaxLength = 5;
            this.portBox8.Name = "portBox8";
            this.portBox8.Size = new System.Drawing.Size(59, 20);
            this.portBox8.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(258, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 41;
            this.label9.Text = "Camera 9";
            // 
            // portBox9
            // 
            this.portBox9.Location = new System.Drawing.Point(316, 238);
            this.portBox9.MaxLength = 5;
            this.portBox9.Name = "portBox9";
            this.portBox9.Size = new System.Drawing.Size(59, 20);
            this.portBox9.TabIndex = 40;
            // 
            // portBox10
            // 
            this.portBox10.Location = new System.Drawing.Point(316, 264);
            this.portBox10.MaxLength = 5;
            this.portBox10.Name = "portBox10";
            this.portBox10.Size = new System.Drawing.Size(59, 20);
            this.portBox10.TabIndex = 39;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(258, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 38;
            this.label10.Text = "Camera 10";
            // 
            // portBox7
            // 
            this.portBox7.Location = new System.Drawing.Point(316, 186);
            this.portBox7.MaxLength = 5;
            this.portBox7.Name = "portBox7";
            this.portBox7.Size = new System.Drawing.Size(59, 20);
            this.portBox7.TabIndex = 37;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar1.Click += new System.EventHandler(this.toolStripProgressBar1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 137);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.ShortcutsEnabled = false;
            this.textBox1.Size = new System.Drawing.Size(120, 39);
            this.textBox1.TabIndex = 45;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "awdaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa\r\nawdddddddddddddddddddddddddddddddd" +
    "\r\ndwawdawdaw\r\nawdawdawd\r\nawd\r\nawda\r\nwd\r\nawd\r\naw\r\ndaw\r\nd";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 403);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.portBox8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.portBox9);
            this.Controls.Add(this.portBox10);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.portBox7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.portBox5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.portBox6);
            this.Controls.Add(this.portBox4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox0);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.portBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.portBox2);
            this.Controls.Add(this.portBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Video Socket Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox portBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox portBox2;
        private System.Windows.Forms.TextBox portBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox logBox;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox0;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox portBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox portBox6;
        private System.Windows.Forms.TextBox portBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox portBox8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox portBox9;
        private System.Windows.Forms.TextBox portBox10;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox portBox7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.TextBox textBox1;
    }
}

