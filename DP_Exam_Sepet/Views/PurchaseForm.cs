using DP_Exam_Sepet.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_Exam_Sepet.Views
{
    public partial class PurchaseForm : Form
    {
        Product product;
        AppUserForm saveuserForm;
        int txtCursor =0;
        DataHolder dataHolder;
        public PurchaseForm(AppUserForm suf,Product p)
        {
            saveuserForm = suf;
            product = p;
            dataHolder = suf.dataHolder;
            InitializeComponent();
        }

        private void PurchaseForm_Load(object sender, EventArgs e)
        {
            
            lblProductname.Text = product.Name;
            lblProductprice.Text = product.Price.ToString();
            lblProductCategory.Text = product.Category.ToString();
            pbProduct.Image = Image.FromFile("Images\\"+product.ImagesId+".png");
            txtAcountNumber.MaxLength = 19;
            txtSN.MaxLength = 3;
            txtUsername.Text = dataHolder.CurrentUser.Name;
            txtUsersurname.Text = dataHolder.CurrentUser.Surname;
            txtUsername.ReadOnly = true;
            txtUsersurname.ReadOnly = true;
        }

        private void PurchaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            saveuserForm.Show();
            Dispose();
        }

        private void rbKK_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbKK.Checked)
            {
                gbInfos.Text = "EFT Hesap Bilgileri";
                lblCardnumber.Text = "Hesap Numarası:";
                lblSN.Visible = false;
                txtSN.Visible = false;
                return;
            }
            gbInfos.Text = "Kredi Kartı Bilgileri";
            lblCardnumber.Text = "Kard Numarası:";
            lblSN.Visible = true;
            txtSN.Visible = true;

        }

        

        private void btnPayEnd_Click(object sender, EventArgs e)
        {
            if (rbKK.Checked)
            {
                if (txtUsername.Text.Length > 0 && txtUsersurname.Text.Length > 0 && txtUserAdress.Text.Length > 0 && txtProductAdet.Text.Length > 0 && txtAcountNumber.Text.Length == 19 && txtSN.Text.Length > 0)
                {
                    KKBuying();
                }
                else MessageBox.Show("Eksik bilgi girdiniz!");
            }else
            {
                if (txtUsername.Text.Length > 0 && txtUsersurname.Text.Length > 0 && txtUserAdress.Text.Length > 0 && txtProductAdet.Text.Length > 0 && txtAcountNumber.Text.Length == 19)
                {
                    EFTBuying();
                }
                else MessageBox.Show("Eksik bilgi gidiniz!");
            }
        }

        private void txtAcountNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
            {
                txtCursor++;
                if (txtCursor == 5)
                {
                    if (txtAcountNumber.Text.Length<19)
                    {
                        txtAcountNumber.Text += "-";
                        txtAcountNumber.Focus();
                        txtAcountNumber.SelectionStart = txtAcountNumber.Text.Length;
                    }

                    txtCursor = 1;
                }
                
                e.Handled = false;
            }

            else if ((int)e.KeyChar == 8)
            {
                e.Handled = false;//eğer basılan tuş backspace ise yazdır.
                if (txtAcountNumber.Text.Length == 0) txtCursor = 0;
            }
            else
            {
                e.Handled = true;//bunların dışındaysa hiçbirisini yazdırma
            }
            
        }

        private void KKBuying()
        {
            lblResult.Visible = true;
            lblResult.Text = "Bankayla iletişime geçiliyor...";
            Refresh();
            Thread.Sleep(1000);
            lblResult.Text = "Kart bilgileri kontrol ediliyor...";
            Refresh();
            Thread.Sleep(1000);
            lblResult.Text = "Ödeme işlemi tamamlanıyor...";
            Refresh();
            Thread.Sleep(1000);

            DialogResult dr = new DialogResult();
            dr = MessageBox.Show(product.Name + " x " + txtProductAdet.Text+" = "+(product.Price*int.Parse(txtProductAdet.Text)+"\nAlışverişi tamamlamak istiyor musunuz??"), "Uyarı !!!", MessageBoxButtons.YesNo);

            if(dr == DialogResult.Yes)
            {
                lblResult.Text = "Satın alma başarılı bir şekilde yapıldı.";
                Refresh();
                SoldProduct sp = new SoldProduct();
                sp.SoldID = dataHolder.SoldProducts.Count == 0 ? 1 : (dataHolder.SoldProducts[dataHolder.SoldProducts.Count - 1].SoldID + 1);
                sp.Adet = int.Parse(txtProductAdet.Text);
                sp.Category = product.Category;
                sp.Product = product;
                sp.Toplam = product.Price * int.Parse(txtProductAdet.Text);
                sp.User = dataHolder.CurrentUser;
                sp.PaymentType = rbKK.Checked ? "KK" : "EFT";
                dataHolder.SoldProducts.Add(sp);
                saveuserForm.SoldsLoad();
                Thread.Sleep(1000);

                saveuserForm.Show();
                Dispose(); 
            }
            else
            {
                lblResult.Text = "Satın alma iptal edildi...";
                Refresh();
                Thread.Sleep(1000);
                lblResult.Text = "";
                Refresh();

            }
        }
        private void EFTBuying()
        {
            lblResult.Visible = true;
            lblResult.Text = "Bankayla iletişime geçiliyor...";
            Refresh();
            Thread.Sleep(1000);
            lblResult.Text = "Hesap bilgileri kontrol ediliyor...";
            Refresh();
            Thread.Sleep(1000);
            lblResult.Text = "Hesap bakiyesi kontrol ediliyor...";
            Refresh();
            Thread.Sleep(1000);
            lblResult.Text = "Ödeme işlemi tamamlanıyor...";
            Refresh();
            Thread.Sleep(1000);

            DialogResult dr = new DialogResult();
            dr = MessageBox.Show(product.Name + " x " + txtProductAdet.Text + " = " + (product.Price * int.Parse(txtProductAdet.Text) + "\nAlışverişi tamamlamak istiyor musunuz??"), "Uyarı !!!", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                lblResult.Text = "Satın alma başarılı bir şekilde yapıldı.";
                Refresh();
                SoldProduct sp = new SoldProduct();
                sp.SoldID = dataHolder.SoldProducts[dataHolder.SoldProducts.Count - 1].SoldID + 1;
                sp.Adet = int.Parse(txtProductAdet.Text);
                sp.Category = product.Category;
                sp.Product = product;
                sp.Toplam = product.Price * int.Parse(txtProductAdet.Text);
                sp.User = dataHolder.CurrentUser;
                sp.PaymentType = rbKK.Checked ? "KK" : "EFT";
                dataHolder.SoldProducts.Add(sp);
                saveuserForm.SoldsLoad();
                Thread.Sleep(1000);

                saveuserForm.Show();
                Dispose();
            }
            else
            {
                lblResult.Text = "Satın alma iptal edildi...";
                Refresh();
                Thread.Sleep(1000);

            }
        }

        private void txtProductAdet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                e.Handled = false;
            else if ((int)e.KeyChar == 8)
                e.Handled = false;
            else e.Handled = true;
           
        }

        private void txtSN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57)
                e.Handled = false;
            else if ((int)e.KeyChar == 8)
                e.Handled = false;
            else e.Handled = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            dataHolder.WriteSoldproduct();
            saveuserForm.SoldsLoad();
            saveuserForm.Show();
            Dispose();
        }
    }
}
