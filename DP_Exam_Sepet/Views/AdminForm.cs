using DP_Exam_Sepet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_Exam_Sepet.Views
{
    public partial class AdminForm : Form
    {
        MainForm mainform;
        DataHolder dataHolder;
        string filename;
        public AdminForm(MainForm f)
        {
            mainform = f;
            dataHolder = f.data;
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            CategoriesLoad();
            AllSoldProducts();
            cbCategories.SelectedIndex = 0;
            ProductsLoad();
            ImageLoad();
        }
        private void AllSoldProducts()
        {
            lbSoldProducts.Items.Clear();
            foreach (SoldProduct sp in dataHolder.SoldProducts)
            {
                lbSoldProducts.Items.Add(sp);
            }

        }
        private void CategoriesLoad()
        {
            foreach (Category cat in dataHolder.Categories)
            {
                cbCategories.Items.Add(cat);
            }
        }
        private void ProductsLoad()
        {
            foreach (Product pro in dataHolder.Products)
            {
                cbProducts.Items.Add(pro);
            }
            if (cbProducts.Items.Count > 0) cbProducts.SelectedIndex = 0;
        }

        private void ImageLoad()
        {
            Product pro = (Product)cbProducts.SelectedItem;
            
            pbProduct.Image = Image.FromFile("Images\\"+pro.ImagesId+".png");
        }
        private void btnCategoryAdd_Click(object sender, EventArgs e)
        {
            Category cat = new Category() { Name = txtCategoryName.Text };
            if(txtCategoryName.Text.Length > 0)
            {
                dataHolder.Categories.Add(cat);
                cbCategories.Items.Clear();
                CategoriesLoad();
                MessageBox.Show("Kategori Eklendi !");
                return;
            }
            MessageBox.Show("Ürün adını boş geçmeyin !");

        }

        private void txtCategoryName_TextChanged(object sender, EventArgs e)
        {
            if (txtCategoryName.Text.Length > 0)
            {
                btnCategoryAdd.Enabled = true;
                return;
            }

            btnCategoryAdd.Enabled = false;
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            Product pro = new Product() { Name = txtProductName.Text, Price = int.Parse(txtProductPrice.Text), Category = (Category)cbCategories.SelectedItem ,ImagesId = dataHolder.Products[dataHolder.Products.Count-1].ImagesId+1};
            if(txtProductName.Text.Length > 0)
            {
                dataHolder.Products.Add(pro);
                cbProducts.Items.Clear();
                File.Copy(filename, "Images\\" + (pro.ImagesId) + ".png");
                ProductsLoad();
                MessageBox.Show("Ürün Eklendi");
                return;
            }

            MessageBox.Show("Ürün adı girmeyi unuttunuz !");

        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            if (txtProductName.Text.Length > 0)
            {
                btnProductAdd.Enabled = true;
                return;
            }
            btnProductAdd.Enabled = false;

        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataHolder.Writer(false);
            mainform.Show();
            Dispose();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            dr = MessageBox.Show("Gerçekten çıkmak istiyor musunuz ?", "UYARI !!!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                dataHolder.Writer(false);
                mainform.Show();
                Dispose();
            }
            
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ImageLoad();
        }

       

        private void btnAddpicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Title = "Resim Seç...";
            open.ShowDialog();
            filename = open.FileName;

            if (!string.IsNullOrEmpty(open.FileName))
            {
                txtPicturename.Text = open.SafeFileName;

            }


        }

        private void txtProductPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                e.Handled = false;
            else if ((int)e.KeyChar == 8)
                e.Handled = false;
            else e.Handled = true;
        }
    }
}
