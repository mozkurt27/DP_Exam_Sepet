﻿namespace DP_Exam_Sepet
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtUserpass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnJoinUs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "User Pass:";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(81, 23);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(129, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtUserpass
            // 
            this.txtUserpass.Location = new System.Drawing.Point(81, 58);
            this.txtUserpass.Name = "txtUserpass";
            this.txtUserpass.PasswordChar = '*';
            this.txtUserpass.Size = new System.Drawing.Size(129, 20);
            this.txtUserpass.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(135, 94);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Giriş";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnJoinUs
            // 
            this.btnJoinUs.Location = new System.Drawing.Point(0, 135);
            this.btnJoinUs.Name = "btnJoinUs";
            this.btnJoinUs.Size = new System.Drawing.Size(85, 23);
            this.btnJoinUs.TabIndex = 5;
            this.btnJoinUs.Text = "Kaydol";
            this.btnJoinUs.UseVisualStyleBackColor = true;
            this.btnJoinUs.Click += new System.EventHandler(this.btnJoinUs_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 159);
            this.Controls.Add(this.btnJoinUs);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserpass);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtUserpass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnJoinUs;
    }
}

