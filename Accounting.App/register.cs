using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntity;
using BusinessLogic;
using FoxLearn.License;

namespace Accounting.App
{
    public partial class register : Form
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
        public register()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));

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


        bool chack = false;

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (guna2TextBox1.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^[\u0600-\u06FF ]+$");

                if (!mRegxExpression.IsMatch(guna2TextBox1.Text.Trim()))
                {
                    guna2TextBox1.Focus();
                    errorProvider2.SetError(guna2TextBox1, " لطفا نام خود را به فارسی تایپ کنید");
                    chack = false;

                }
                else if (mRegxExpression.IsMatch(guna2TextBox1.Text.Trim()))
                {
                    errorProvider2.Clear();
                    chack = true;
                }
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (guna2TextBox2.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(guna2TextBox2.Text.Trim()))
                {
                    guna2TextBox2.Focus();
                    errorProvider2.SetError(guna2TextBox2, "قالب آدرس ایمیل شما صحیح نیست");
                    chack = false;

                }
                else
                {
                    errorProvider2.Clear();
                    chack = true;
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (guna2TextBox3.Text.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"([0-9])$");

                if (!mRegxExpression.IsMatch(guna2TextBox3.Text.Trim()) || guna2TextBox3.Text.Length != 11)
                {

                    errorProvider2.SetError(guna2TextBox3, " قالب شماره تلفن شما اشتباه است");
                    chack = false;



                }
                else if (mRegxExpression.IsMatch(guna2TextBox3.Text.Trim()) || guna2TextBox3.Text.Length == 11)
                {
                    errorProvider2.Clear();
                    chack = true;
                }
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpressions;
            if (guna2TextBox5.Text.Trim() != string.Empty)
            {
                mRegxExpressions = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$");

                if (!mRegxExpressions.IsMatch(guna2TextBox5.Text.Trim()))
                {
                    errorProvider2.SetError(guna2TextBox5, "رمز شما باید از 8 رقم بیشتر باشد و از کارکتر های حروف بزرگ، شمارش، و کارکتر های مانند @ استفاده کنید");
                    chack = false;

                }
                else if (mRegxExpressions.IsMatch(guna2TextBox5.Text.Trim()))
                {
                    errorProvider2.Clear();
                    chack = true;
                }
            }
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            if (guna2TextBox6.Text != guna2TextBox5.Text)
            {
                errorProvider2.SetError(guna2TextBox6, "رمز یکسان نیست");
                chack = false;
            }
            else
            {
                errorProvider2.Clear();
                chack = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text.Trim() == string.Empty)
            {
                guna2TextBox1.Focus();
                chack = false;

            }
            else if (guna2TextBox2.Text.Trim() == string.Empty)
            {
                guna2TextBox2.Focus(); chack = false;

            }
            else if (guna2TextBox3.Text.Trim() == string.Empty)
            {
                guna2TextBox3.Focus(); chack = false;

            }
            else if (guna2TextBox4.Text.Trim() == string.Empty)
            {
                guna2TextBox4.Focus(); chack = false;

            }
            else if (guna2TextBox5.Text.Trim() == string.Empty)
            {
                guna2TextBox5.Focus(); chack = false;

            }
            else if (guna2TextBox6.Text.Trim() == string.Empty)
            {
                guna2TextBox6.Focus(); chack = false;

            }
            if (chack == true)
            {
                Users users = new Users();
                users.FullName = guna2TextBox1.Text;
                users.E_Post = guna2TextBox2.Text;
                users.Mobile = guna2TextBox3.Text;
                users.Address = guna2TextBox4.Text;
                users.Password = guna2TextBox5.Text;
                UserBl bl = new UserBl();
                MessageBox.Show(bl.Create(users));
                DialogResult = DialogResult.OK;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            KeyManager km = new KeyManager(guna2TextBox7.Text);
            string productKey = guna2TextBox8.Text;
            if (km.ValidKey(ref productKey))
            {
                KeyValuesClass kv = new KeyValuesClass();
                if (km.DisassembleKey(productKey, ref kv))
                {
                    LicenseInfo lic = new LicenseInfo();
                    lic.ProductKey = productKey;
                    lic.FullName = "Personal accounting";
                    if (kv.Type == LicenseType.TRIAL)
                    {
                        lic.Day = kv.Expiration.Day;
                        lic.Month = kv.Expiration.Month;
                        lic.Year = kv.Expiration.Year;
                    }

                    km.SaveSuretyFile(string.Format(@"{0}\Key.lic", Application.StartupPath), lic);
                    MessageBox.Show("فعال سازی برنامه با موفقیت انجام شد", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    guna2GradientPanel1.Enabled = true;
                }
            }
            else
                MessageBox.Show("کد لایسنس نامعتبر است", "پیغام", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void register_Load(object sender, EventArgs e)
        {
            guna2TextBox7.Text = ComputerInfo.GetComputerId();
        }

 

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void register_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void guna2ShadowPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Escape))
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void guna2TextBox7_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox8_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox5_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }

        private void guna2TextBox6_KeyDown(object sender, KeyEventArgs e)
        {
            nexttextbox(sender, e);
        }
    }
}
