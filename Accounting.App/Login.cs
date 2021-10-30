using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;

namespace Accounting.App
{
    public partial class Login : Form
    {
        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect,     // x-coordinate of upper-left corner
               int nTopRect,      // y-coordinate of upper-left corner
               int nRightRect,    // x-coordinate of lower-right corner
               int nBottomRect,   // y-coordinate of lower-right corner
               int nWidthEllipse, // width of ellipse
               int nHeightEllipse // height of ellipse
           );
        public Login()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

        }
        LoginBl login = new LoginBl();
        public void difultvalue()
        {
            accountingtypebl bl = new accountingtypebl();
            AccountingType one = new AccountingType() { id = 1, TypeTitle = "هزینه" };
            AccountingType two = new AccountingType() { id = 2, TypeTitle = "درآمد" };
            bl.Create(one);
            bl.Create(two);
        }
        public void nexttextbox(object btnSender, KeyEventArgs e)
        {
            if (btnSender != null)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        // Move Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void Form1_Load(object sender, EventArgs e)
        {
            difultvalue();

            if (login.Login("", "") == 0)
            {
                guna2Button1.Visible = true;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            register register = new register();
            register.ShowDialog();
            if (login.Login("", "") != 0)
            {
                guna2Button1.Visible = false;
            }

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (login.Login(guna2TextBox2.Text, guna2TextBox1.Text) == 1)
            {

                Mainmenu m = new Mainmenu();
                m.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("نام کاربری و یا کلمه عبور اشتباه است");
            }

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://zil.ink/porya");
        }


        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا برای خروج از برنامه مطمئن هستید؟", "خروج", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }
           
        }

        private void Login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
            
        }
        
       

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }
    }
}
