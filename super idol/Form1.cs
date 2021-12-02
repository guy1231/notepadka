using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace super_idol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;

        public static int CalculateFrameRate()
        {
            if (System.Environment.TickCount - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = System.Environment.TickCount;
            }
            frameRate++;
            return lastFrameRate;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            textBox2.Text = "\r\n[" + thetime + "]" + ": saved";
            Properties.Settings.Default.text = textBox1.Text;
            Properties.Settings.Default.font = textBox1.Font;
            Properties.Settings.Default.bgcolor = textBox1.BackColor;
            Properties.Settings.Default.txtcolor = textBox1.ForeColor;
            Properties.Settings.Default.log = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            textBox1.Text = Properties.Settings.Default.text;
            textBox1.Font = Properties.Settings.Default.font;
            textBox1.BackColor = Properties.Settings.Default.bgcolor;
            textBox1.ForeColor = Properties.Settings.Default.txtcolor;
            textBox2.Text = Properties.Settings.Default.log + "\r\n[" + thetime + "]" + ": loaded";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG";
            openFileDialog1.Title = "custom image";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
                textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": added font";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.BackColor = colorDialog1.Color;
                textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": added bgcolor";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
                textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": added txtcolor";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": added image";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            if (textBox1.Text.Contains("#include"))
            {
                label4.Text = "C++ (determined by library)";
            }
            else if (textBox1.Text.Contains("import"))
            {
                label4.Text = "Python (determined by library)";
            }
            else if (textBox1.Text.Contains("using"))
            {
                label4.Text = "C# (determined by library)";
            }
            else if (textBox1.Text.Contains("local"))
            {
                label4.Text = "Lua (determined by variable)";
            }
            else if (textBox1.Text.Contains("function"))
            {
                label4.Text = "Lua (determined by function)";
            }
            else if (!textBox1.Text.Contains("#include"))
            {
                label4.Text = "NaN";
            }
            else if (!textBox1.Text.Contains("import"))
            {
                label4.Text = "NaN";
            }
            else if (!textBox1.Text.Contains("using"))
            {
                label4.Text = "NaN";
            }
            else if (!textBox1.Text.Contains("local"))
            {
                label4.Text = "NaN";
            }
            else if (!textBox1.Text.Contains("function"))
            {
                label4.Text = "NaN";
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            var thetime = DateTime.UtcNow;
            textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": erased save";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            var thetime = DateTime.UtcNow;
            textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": reloaded save";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            Process proc = Process.GetCurrentProcess();
            textBox3.Text = proc.PrivateMemorySize64.ToString();
            textBox4.Text = CalculateFrameRate().ToString();
            textBox5.Text = thetime.ToString();
        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepadka, made by getfreethebadges in c#, thanks to stackoverflow");
        }

        private void сохранитьToolStripButton_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            textBox2.Text = textBox2.Text + "\r\n[" + thetime + "]" + ": saved";
            Properties.Settings.Default.text = textBox1.Text;
            Properties.Settings.Default.font = textBox1.Font;
            Properties.Settings.Default.bgcolor = textBox1.BackColor;
            Properties.Settings.Default.txtcolor = textBox1.ForeColor;
            Properties.Settings.Default.log = textBox2.Text;
            Properties.Settings.Default.Save();
        }

        private void открытьToolStripButton_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            textBox2.Text = Properties.Settings.Default.log + "\r\n[" + thetime + "]" + ": loaded";
            textBox1.Text = Properties.Settings.Default.text;
            textBox1.Font = Properties.Settings.Default.font;
            textBox1.BackColor = Properties.Settings.Default.bgcolor;
            textBox1.ForeColor = Properties.Settings.Default.txtcolor;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/getfreethebadges");
            linkLabel1.ForeColor = linkLabel1.VisitedLinkColor;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UC5xTdReuY-O1JCyD_Wm2ZxA");
            linkLabel1.ForeColor = linkLabel1.VisitedLinkColor;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            timer2.Stop();
            this.BackColor = Color.WhiteSmoke;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Random rnd1 = new Random();
            Random rnd2 = new Random();
            Random rnd3 = new Random();
            int int1 = rnd1.Next(1, 254);
            int int2 = rnd2.Next(1, 254);
            int int3 = rnd3.Next(1, 254);
            Color rainbowcolor = Color.FromArgb(255, int1, int2, int3);
            System.Threading.Thread.Sleep(10);
            this.BackColor = rainbowcolor;
            rnd1.Next(1, 254);
            rnd2.Next(1, 254);
            rnd3.Next(1, 254);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            openFileDialog2.Title = "open txt";
            openFileDialog2.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                StreamReader read = new StreamReader(File.OpenRead(openFileDialog2.FileName));
                textBox1.Text = read.ReadToEnd();
                read.Dispose();
                textBox2.Text = Properties.Settings.Default.log + "\r\n[" + thetime + "]" + ": loaded file";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            var thetime = DateTime.UtcNow;
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.Title = "save txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter write = new StreamWriter(File.Create(saveFileDialog1.FileName));
                write.Write(textBox1.Text);
                write.Dispose();
                textBox2.Text = Properties.Settings.Default.log + "\r\n[" + thetime + "]" + ": saved file";
            }
        }

    }
}
