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
                    currentButton.ForeColor = Color.Black;
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
                    previousBtn.BackColor = Color.FromArgb(255, 185, 86);
                    previousBtn.ForeColor = Color.Black;
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
            panelTitle.BackColor = Color.FromArgb(255, 151, 2);
            panelLogo.BackColor = Color.FromArgb(254, 206, 0);
            panelmenu.BackColor = Color.FromArgb(255, 185, 86);
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

        private void iconButton6_Click_1(object sender, EventArgs e)
        {
            ActivateButton(sender);
            DialogResult dialogResult = MessageBox.Show("آیا میخواهید از برنامه خارج شوید", "خروج", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Forms.AboutUs(), sender);
        }
    }
}
