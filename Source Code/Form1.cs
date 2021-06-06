using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace HolyAutoClicker
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        private const int LEFTUP = 0x0004;
        private const int LEFTDOWN = 0x0002;
        private const int RIGHTDOWN = 0x0008;
        private const int RIGHTUP = 0x0010;





        public int intervals = 100;
        public bool Click = false;
        public int parsedValue;

        public Form1()
        {
            InitializeComponent();
            guna2HtmlLabel8.Text = intervals.ToString() + "ms";
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            guna2HtmlLabel2.Text = "HolyAutoClicker - Not Active";
            guna2HtmlLabel8.Text = intervals.ToString() + "ms";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread AC = new Thread(AutoClick);
            backgroundWorker1.RunWorkerAsync();
            AC.Start();
        }

        int first = LEFTUP; 
        int second = LEFTDOWN;

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = guna2ComboBox1.Items[guna2ComboBox1.SelectedIndex].ToString();
            //Left MB
            //Right MB
            // Middle MB
            if (selectedItem == "Left MB")
            {
                first = LEFTUP;
                second = LEFTDOWN;
            }
            else if (selectedItem == "Right MB")
            {
                first = RIGHTUP;
                second = RIGHTDOWN;
            }
            else
            {
                first = LEFTUP;
                second = LEFTDOWN;
            }

        }

        private void AutoClick()
        {
            while (true)
            {
                if (Click == true)
                {
                    mouse_event(dwFlags: first, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(1);
                    mouse_event(dwFlags: second, dx: 0, dy: 0, cButtons: 0, dwExtraInfo: 0);
                    Thread.Sleep(intervals);
                }
                Thread.Sleep(2);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                
                if (guna2ToggleSwitch1.Checked == true )
                {
                    guna2HtmlLabel2.Text = "HolyAutoClicker - Active";
                    guna2HtmlLabel5.Visible = true;
                    guna2HtmlLabel4.Visible = true;
                    if (GetAsyncKeyState(Keys.Down) < 0)
                    {
                        Click = false;
                    }
                    else if (GetAsyncKeyState(Keys.Up) < 0)
                    {
                        Click = true;
                    }
                    Thread.Sleep(1);
                }
                else if (guna2ToggleSwitch1.Checked == false )
                {
                    guna2HtmlLabel5.Visible = false;
                    guna2HtmlLabel4.Visible = false;
                }        
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(guna2TextBox1.Text, out parsedValue))
            {
                MessageBox.Show("Hey! You need a number!\n\nUnless you want the default delay!");
                return;
            }
            else
            {
                intervals = int.Parse(guna2TextBox1.Text);
                guna2HtmlLabel8.Text = intervals.ToString() + "ms";
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {


        }
        private void guna2HtmlLabel4_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2HtmlLabel8_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void guna2HtmlLabel12_Click(object sender, EventArgs e)
        {
            
        }
    }
}
