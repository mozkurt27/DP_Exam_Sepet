using DP_Exam_Sepet.Managers;
using DP_Exam_Sepet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_Exam_Sepet.Views
{
    public partial class SaveUserForm : Form
    {
        MainForm mainForm;
        DataHolder dataHolder;
        public SaveUserForm(MainForm f)
        {
            mainForm = f;
            dataHolder = f.data;
            InitializeComponent();
        }

        private void SaveUserForm_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AppUser user = new AppUser();
            UserManager um = new UserManager(); 
            if(txtUserPass.Text.Length > 0 && txtName.Text.Length > 0 && txtSurname.Text.Length > 0)
            {
                bool check = um.CheckByUsername(txtUserName.Text, dataHolder.Users);
                if(!check)
                {
                    user.Id = dataHolder.Users.Last().Id + 1;
                    user.Name = txtName.Text;
                    user.Surname = txtSurname.Text;
                    user.Username = txtUserName.Text;
                    user.Password = txtUserPass.Text;
                    user.IsAdmin = false;
                    dataHolder.Users.Add(user);

                    MessageBox.Show("Kayıt olundu");
                    
                }
                else MessageBox.Show("Böyle bir kullanıcı adı mevcut !!!");
            }
            else MessageBox.Show("Boş Alan Bırakmayınız !!!");

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            if (txtUserName.Text.Length > 0) btnSave.Enabled = true;
            else btnSave.Enabled = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dataHolder.Writer(true);
            mainForm.Show();
            Dispose();
        }

        private void SaveUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataHolder.Writer(true);
            mainForm.Show();
            Dispose();
        }
    }
}
