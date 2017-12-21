using DP_Exam_Sepet.Managers;
using DP_Exam_Sepet.Models;
using DP_Exam_Sepet.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_Exam_Sepet
{
    public partial class MainForm : Form
    {
        internal DataHolder data;
        public MainForm()
        {
            data = new DataHolder();
            InitializeComponent();
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager();

            bool isCorrect = userManager.CheckCredentials(txtUsername.Text, txtUserpass.Text, data.Users);

            if (isCorrect)
            {
                AppUser currentUser = userManager.FindByUsername(txtUsername.Text, data);

                if (currentUser != null)
                {
                    data.CurrentUser = currentUser;

                    if (currentUser.IsAdmin)
                    {
                        AdminForm adminForm = new AdminForm(this);
                        adminForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        AppUserForm appUserForm = new AppUserForm(this);
                        appUserForm.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                MessageBox.Show("Giriş başarısız", ":(", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private void btnJoinUs_Click(object sender, EventArgs e)
        {
            SaveUserForm suf = new SaveUserForm(this);
            suf.Show();
            Hide();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
