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
        public Login()
        {
            InitializeComponent();
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
        private void Form1_Load(object sender, EventArgs e)
        {
            difultvalue();

            if(login.Login("","") == 0)
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
           
            if(login.Login(guna2TextBox2.Text, guna2TextBox1.Text) == 1)
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
    }
}
