using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Accounting.App
{
    public partial class Mainmenu : Form
    {
        public Mainmenu()
        {
            InitializeComponent();
            random = new Random();
            closechildform.Visible = false;
           
        }
        private void MainMenu_OnKeyBoardShortCut(object sender , KeyEventArgs e)
        {

        }

        // Move Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private Button currentButton;
        private Random random;
        private int tempIndex;
        private Form activeForm;
        private Color SelectThemeColor()
        {
            int index = random.Next(ThemeColor.ColorList.Count);
            while (tempIndex == index)
            {
                index = random.Next(ThemeColor.ColorList.Count);
            }
            tempIndex = index;
            string color = ThemeColor.ColorList[index];
            return ColorTranslator.FromHtml(color);

        }
        public void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = color;
                    currentButton.ForeColor = Color.White;
                    currentButton.Font = new System.Drawing.Font("Far.Diplomaat", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    panelLogo.BackColor = color;
                    panelTitle.BackColor = ThemeColor.changeColorBrightness(color, -0.3);
                    closechildform.Visible = true;
                    labelTitle.Text = currentButton.Text;

                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelmenu.Controls)
            {

                if (previousBtn.GetType() == typeof(FontAwesome.Sharp.IconButton))
                {
                    previousBtn.BackColor = Color.FromArgb(1, 36, 67);
                    previousBtn.ForeColor = Color.White;
                    previousBtn.Font = new System.Drawing.Font("Far.Diplomaat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            this.panelDesktop.Controls.Add(childForm);
            this.panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void Reset()
        {
            DisableButton();
            labelTitle.Text = "صفحه اصلی";
            panelTitle.BackColor = Color.FromArgb(1, 36, 67);
            panelLogo.BackColor = Color.FromArgb(124, 131, 253);
            panelmenu.BackColor = Color.FromArgb(1, 36, 67);
            closechildform.Visible = false;
        }
        private void menubtn1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AccountSide(), sender);
        }

        private void closechildform_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                Reset();
            }
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Transaction(), sender);
        }


        private void iconButton2_Click(object sender, EventArgs e)
        {
            Forms.Report report = new Forms.Report();
            report.TypeId = 1;
            OpenChildForm(report, sender);
            
        }
        private void iconButton3_Click(object sender, EventArgs e)
        {
            Forms.Report report = new Forms.Report();
            report.TypeId = 2;

            OpenChildForm(report, sender);
           
        }

    

     

        private void iconButton4_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelLogo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void iconButton5_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AboutUs(), sender);
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DialogResult dialogResult = MessageBox.Show("آیا میخواهید از برنامه خارج شوید", "خروج", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconButton7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.Chart(), sender);
        }



        private void Mainmenu_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control && e.KeyCode == Keys.A)
            {
                menubtn1.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.B)
            {
                iconButton1.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.S)
            {
                iconButton2.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.D)
            {
                iconButton3.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.E)
            {
                iconButton7.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.H)
            {
                iconButton5.PerformClick();
            }
            if (e.Control && e.KeyCode == Keys.C)
            {
                iconButton6.PerformClick();
            }
        }

    }
}
