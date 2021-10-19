
namespace Accounting.App
{
    partial class Mainmenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelmenu = new System.Windows.Forms.Panel();
            this.panelLogo = new Guna.UI2.WinForms.Guna2Panel();
            this.lableName = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.closechildform = new FontAwesome.Sharp.IconButton();
            this.iconButton6 = new FontAwesome.Sharp.IconButton();
            this.iconButton5 = new FontAwesome.Sharp.IconButton();
            this.menubtn1 = new FontAwesome.Sharp.IconButton();
            this.accunt = new FontAwesome.Sharp.IconPictureBox();
            this.panelmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accunt)).BeginInit();
            this.SuspendLayout();
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(2)))));
            this.panelmenu.Controls.Add(this.iconButton6);
            this.panelmenu.Controls.Add(this.iconButton5);
            this.panelmenu.Controls.Add(this.menubtn1);
            this.panelmenu.Controls.Add(this.panelLogo);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelmenu.Location = new System.Drawing.Point(982, 0);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(200, 653);
            this.panelmenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(0)))));
            this.panelLogo.Controls.Add(this.lableName);
            this.panelLogo.Controls.Add(this.accunt);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.ShadowDecoration.Parent = this.panelLogo;
            this.panelLogo.Size = new System.Drawing.Size(200, 80);
            this.panelLogo.TabIndex = 2;
            // 
            // lableName
            // 
            this.lableName.AutoSize = true;
            this.lableName.Font = new System.Drawing.Font("Far.Diplomaat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lableName.Location = new System.Drawing.Point(6, 28);
            this.lableName.Name = "lableName";
            this.lableName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lableName.Size = new System.Drawing.Size(142, 29);
            this.lableName.TabIndex = 0;
            this.lableName.Text = "کاربر گرامی خوش آمدید";
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(151)))), ((int)(((byte)(2)))));
            this.panelTitle.Controls.Add(this.closechildform);
            this.panelTitle.Controls.Add(this.labelTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(982, 80);
            this.panelTitle.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Far.Diplomaat", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.labelTitle.Location = new System.Drawing.Point(432, 19);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelTitle.Size = new System.Drawing.Size(123, 47);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "صفحه اصلی";
            // 
            // panelDesktop
            // 
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Font = new System.Drawing.Font("Far.Diplomaat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panelDesktop.Location = new System.Drawing.Point(0, 80);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(982, 573);
            this.panelDesktop.TabIndex = 3;
            // 
            // closechildform
            // 
            this.closechildform.Dock = System.Windows.Forms.DockStyle.Right;
            this.closechildform.FlatAppearance.BorderSize = 0;
            this.closechildform.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closechildform.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.closechildform.IconColor = System.Drawing.Color.Black;
            this.closechildform.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.closechildform.Location = new System.Drawing.Point(907, 0);
            this.closechildform.Name = "closechildform";
            this.closechildform.Size = new System.Drawing.Size(75, 80);
            this.closechildform.TabIndex = 0;
            this.closechildform.UseVisualStyleBackColor = true;
            this.closechildform.Click += new System.EventHandler(this.closechildform_Click);
            // 
            // iconButton6
            // 
            this.iconButton6.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton6.FlatAppearance.BorderSize = 0;
            this.iconButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton6.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.iconButton6.Font = new System.Drawing.Font("Far.Diplomaat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.iconButton6.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.iconButton6.IconColor = System.Drawing.Color.Black;
            this.iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton6.IconSize = 40;
            this.iconButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton6.Location = new System.Drawing.Point(0, 240);
            this.iconButton6.Name = "iconButton6";
            this.iconButton6.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.iconButton6.Size = new System.Drawing.Size(200, 80);
            this.iconButton6.TabIndex = 10;
            this.iconButton6.Text = "خروج";
            this.iconButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.iconButton6.UseVisualStyleBackColor = true;
            this.iconButton6.Click += new System.EventHandler(this.iconButton6_Click);
            // 
            // iconButton5
            // 
            this.iconButton5.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconButton5.FlatAppearance.BorderSize = 0;
            this.iconButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton5.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.iconButton5.Font = new System.Drawing.Font("Far.Diplomaat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.iconButton5.IconChar = FontAwesome.Sharp.IconChar.QuoteLeft;
            this.iconButton5.IconColor = System.Drawing.Color.Black;
            this.iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton5.IconSize = 40;
            this.iconButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton5.Location = new System.Drawing.Point(0, 160);
            this.iconButton5.Name = "iconButton5";
            this.iconButton5.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.iconButton5.Size = new System.Drawing.Size(200, 80);
            this.iconButton5.TabIndex = 9;
            this.iconButton5.Text = "درباره ما";
            this.iconButton5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.iconButton5.UseVisualStyleBackColor = true;
            // 
            // menubtn1
            // 
            this.menubtn1.Dock = System.Windows.Forms.DockStyle.Top;
            this.menubtn1.FlatAppearance.BorderSize = 0;
            this.menubtn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menubtn1.Flip = FontAwesome.Sharp.FlipOrientation.Horizontal;
            this.menubtn1.Font = new System.Drawing.Font("Far.Diplomaat", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.menubtn1.IconChar = FontAwesome.Sharp.IconChar.Server;
            this.menubtn1.IconColor = System.Drawing.Color.Black;
            this.menubtn1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menubtn1.IconSize = 40;
            this.menubtn1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menubtn1.Location = new System.Drawing.Point(0, 80);
            this.menubtn1.Name = "menubtn1";
            this.menubtn1.Padding = new System.Windows.Forms.Padding(0, 0, 12, 0);
            this.menubtn1.Size = new System.Drawing.Size(200, 80);
            this.menubtn1.TabIndex = 3;
            this.menubtn1.Text = "نمایش اطلاعات";
            this.menubtn1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.menubtn1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.menubtn1.UseVisualStyleBackColor = true;
            this.menubtn1.Click += new System.EventHandler(this.menubtn1_Click);
            // 
            // accunt
            // 
            this.accunt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(206)))), ((int)(((byte)(0)))));
            this.accunt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.accunt.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.accunt.IconColor = System.Drawing.SystemColors.ControlText;
            this.accunt.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.accunt.IconSize = 39;
            this.accunt.Location = new System.Drawing.Point(149, 17);
            this.accunt.Name = "accunt";
            this.accunt.Size = new System.Drawing.Size(39, 40);
            this.accunt.TabIndex = 0;
            this.accunt.TabStop = false;
            // 
            // Mainmenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 653);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelmenu);
            this.Font = new System.Drawing.Font("IRANSansWeb", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimumSize = new System.Drawing.Size(1200, 700);
            this.Name = "Mainmenu";
            this.Text = "Mainmenu";
            this.panelmenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accunt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelmenu;
        private Guna.UI2.WinForms.Guna2Panel panelLogo;
        private System.Windows.Forms.Label lableName;
        private FontAwesome.Sharp.IconPictureBox accunt;
        private System.Windows.Forms.Panel panelTitle;
        private FontAwesome.Sharp.IconButton closechildform;
        private System.Windows.Forms.Label labelTitle;
        private FontAwesome.Sharp.IconButton menubtn1;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton6;
        private System.Windows.Forms.Panel panelDesktop;
    }
}