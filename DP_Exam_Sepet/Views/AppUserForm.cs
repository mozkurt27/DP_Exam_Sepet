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
    public partial class AppUserForm : Form
    {
        MainForm mainform;
        internal DataHolder dataHolder;
        public AppUserForm(MainForm f)
        {
            mainform = f;
            dataHolder = f.data;
            InitializeComponent();
        }

        private void AppUserForm_Load(object sender, EventArgs e)
        {
            CategoriesLoad();
            SoldsLoad();
            cbCategories.SelectedIndex = 0;

        }
        public void SoldsLoad()
        {
            lbSoldProducts.Items.Clear();
            foreach (SoldProduct sp in dataHolder.SoldProducts) 
            {
                if(sp.User.Username == dataHolder.CurrentUser.Username)
                lbSoldProducts.Items.Add(sp);
            }
        }
        private void CategoriesLoad()
        {
            cbCategories.Items.Clear();
            foreach (Category cat in dataHolder.Categories)
            {
                cbCategories.Items.Add(cat);
            }
        }
        private void ProductsLoad()
        {
            lbProducts.Items.Clear();
            foreach (Product pro in dataHolder.Products)
            {
                if (pro.Category.Name == cbCategories.SelectedItem.ToString())
                {
                    lbProducts.Items.Add(pro);
                }
                
            }
            
        }

        private void cbCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductsLoad();
        }

        private void AppUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataHolder.WriteSoldproduct();
            mainform.Show();
            Dispose();
        }

        private void lbProducts_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(lbProducts.SelectedItem != null)
            {

                PurchaseForm pf = new PurchaseForm( this, (Product)lbProducts.SelectedItem);
                pf.Show();
                Hide();
            }
            else MessageBox.Show("boş seçim");

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Gerçekten çıkmak istiyor musunuz ?","UYARI !!!",MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                dataHolder.WriteSoldproduct();
                mainform.Show();
                Dispose();
            }
            
            
        }

        private void lbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
