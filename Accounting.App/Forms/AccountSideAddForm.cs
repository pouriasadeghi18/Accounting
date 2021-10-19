﻿using System;
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
using System.IO;

namespace Accounting.App.Forms
{
    public partial class AccountSideAddForm : Form
    {
        public AccountSideAddForm()
        {
            InitializeComponent();
        }

        bool chack = false;
        CostomerBL bl = new CostomerBL();

        private void rjTextBox1__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (rjTextBox1.Texts.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^[\u0600-\u06FF]+$");

                if (!mRegxExpression.IsMatch(rjTextBox1.Texts.Trim()))
                {
                    rjTextBox1.Focus();
                    errorProvider1.SetError(rjTextBox1, " لطفا نام خود را به فارسی تایپ کنید");
                    chack = false;

                }
                else if (mRegxExpression.IsMatch(rjTextBox1.Texts.Trim()))
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            }
        }

        private void rjTextBox2__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (rjTextBox2.Texts.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(rjTextBox2.Texts.Trim()))
                {
                    rjTextBox2.Focus();
                    errorProvider1.SetError(rjTextBox2, "قالب آدرس ایمیل شما صحیح نیست");
                    chack = false;

                }
                else
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            }
        }

        private void rjTextBox3__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpression;
            if (rjTextBox3.Texts.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"([0-9])$");

                if (!mRegxExpression.IsMatch(rjTextBox3.Texts.Trim()) || rjTextBox3.Texts.Length != 11)
                {

                    errorProvider1.SetError(rjTextBox3, " قالب شماره تلفن شما اشتباه است");
                    chack = false;



                }
                else if (mRegxExpression.IsMatch(rjTextBox3.Texts.Trim()) || rjTextBox3.Texts.Length == 11)
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            }
        }

        private void rjTextBox5__TextChanged(object sender, EventArgs e)
        {
            Regex mRegxExpressions;
            if (rjTextBox5.Texts.Trim() != string.Empty)
            {
                mRegxExpressions = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,50}$");

                if (!mRegxExpressions.IsMatch(rjTextBox5.Texts.Trim()))
                {
                    errorProvider1.SetError(rjTextBox5, "رمز شما باید از 8 رقم بیشتر باشد و از کارکتر های حروف بزرگ، شمارش، و کارکتر های مانند @ استفاده کنید");
                    chack = false;

                }
                else if (mRegxExpressions.IsMatch(rjTextBox5.Texts.Trim()))
                {
                    errorProvider1.Clear();
                    chack = true;
                }
            }
        }

        private void rjTextBox6__TextChanged(object sender, EventArgs e)
        {
            if (rjTextBox6.Texts != rjTextBox5.Texts)
            {
                errorProvider1.SetError(rjTextBox6, "رمز یکسان نیست");
                chack = false;
            }
            else
            {
                errorProvider1.Clear();
                chack = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                guna2PictureBox1.ImageLocation = openFile.FileName;
            }
        }

        private void rjButton2_Click(object sender, EventArgs e)
        {
            if(rjTextBox1.Texts.Trim() == string.Empty)
            {
                rjTextBox1.Focus();
                chack = false;
            }
            else if (rjTextBox2.Texts.Trim() == string.Empty)
            {
                rjTextBox2.Focus();
                chack = false;
            }
            else if (rjTextBox3.Texts.Trim() == string.Empty)
            {
                rjTextBox3.Focus();
                chack = false;
            }
            else if (rjTextBox5.Texts.Trim() == string.Empty)
            {
                rjTextBox5.Focus();
                chack = false;
            }
            else if (rjTextBox6.Texts.Trim() == string.Empty)
            {
                rjTextBox6.Focus();
                chack = false;
            }
            if(chack == true)
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(guna2PictureBox1.ImageLocation);
                string path = Application.StartupPath + "/Images/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                guna2PictureBox1.Image.Save(path + imageName);


                Costomer costomer = new Costomer();
                costomer.FullName = rjTextBox1.Texts;
                costomer.E_Post = rjTextBox2.Texts;
                costomer.Mobile = rjTextBox3.Texts;
                costomer.Password = rjTextBox5.Texts;
                costomer.Address = rjTextBox4.Texts;
                costomer.PicAddress = imageName;
                MessageBox.Show(bl.Creat(costomer));
                DialogResult = DialogResult.OK;

            }
            else
            {
                MessageBox.Show("لطفا اطلاعات  را دقیق وارد کنید");
            }

        }
    }
}
