using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DP_Exam_Sepet.Models
{
    class DataHolder
    {
        public DataHolder()
        {
            
            ReadUsers();
            ReadCategories();
            ReadProducts();
            ReadSoldProduct();
        }

        public List<AppUser> Users { get; set; }
        public List<Category> Categories { get; set; }
        public List<Product> Products { get; set; }
        public List<SoldProduct> SoldProducts { get; set; }

        public AppUser CurrentUser { get; set; }

        private void FillUsers(List<AppUser> u)
        {
            Users = u;
    
        }
        private void FillCateories(List<Category> c)
        {
            Categories = c;

        }
        private void FillProducts(List<Product> p)
        {
            Products = p;

        }
        private void FillSoldProduct(List<SoldProduct> sp)
        {
            SoldProducts = sp;
        }
        public void WriteSoldproduct()
        {
            using (StreamWriter sw = new StreamWriter("SoldProduct.txt", false))
            {
                for (int i = 0; i < SoldProducts.Count; i++)
                {
                    sw.WriteLine(SoldProducts[i]);
                }
            }
        }
        private void ReadSoldProduct()
        {
            List<SoldProduct> soldproduct = new List<SoldProduct>();
            using (StreamReader sr = new StreamReader("SoldProduct.txt"))
            {

                string temp = "";
                //int r = 0;
                while (!sr.EndOfStream)
                {
                    SoldProduct sproduct = new SoldProduct();
                    temp = sr.ReadLine();
                    sproduct.SoldID = int.Parse(temp.Split(':')[0]);
                    sproduct.User = Users.Where(x => x.Username == temp.Split(':')[1]).ToList()[0];
                    sproduct.Category = new Category() { Name = temp.Split(':')[2] };
                    sproduct.Product = Products.Where(x => x.Name == temp.Split(':')[3]).ToList()[0];
                    sproduct.Adet = int.Parse(temp.Split(':')[5]);
                    sproduct.Toplam = decimal.Parse(temp.Split(':')[6]);
                    sproduct.PaymentType = temp.Split(':')[7];

                    
                    soldproduct.Add(sproduct);

                   // r++;
                }

            }
            FillSoldProduct(soldproduct);
        }
        private void ReadUsers()
        {
            List<AppUser> users = new List<AppUser>();
            using (StreamReader sr=new StreamReader("Users.txt"))
            {
                
                string temp = "";
                while (!sr.EndOfStream)
                {
                    AppUser appuser = new AppUser();
                    temp= sr.ReadLine();
                    appuser.Id = int.Parse(temp.Split(':')[0]);
                    appuser.Name = temp.Split(':')[1];
                    appuser.Surname = temp.Split(':')[2];
                    appuser.Username = temp.Split(':')[3];
                    appuser.Password = temp.Split(':')[4];
                    appuser.IsAdmin = bool.Parse(temp.Split(':')[5]);

                    users.Add(appuser);


                }
                
            }
            FillUsers(users);
        }
        private void WriteUsers()
        {
            using (StreamWriter sw = new StreamWriter("Users.txt", false))
            {
                for (int i = 0; i < Users.Count; i++)
                {
                    sw.WriteLine(Users[i]);
                }
            }
        }
        private void ReadCategories()
        {
            List<Category> categories = new List<Category>();
            using (StreamReader sr = new StreamReader("Categories.txt"))
            {
                while (!sr.EndOfStream)
                {
                    Category category = new Category();
                    
                    category.Name = sr.ReadLine();

                    categories.Add(category);
                }

            }
            FillCateories(categories);
        }
        private void WriteCategories()
        {
            using (StreamWriter sw = new StreamWriter("Categories.txt", false))
            {
                for (int i = 0; i < Categories.Count; i++)
                {
                    sw.WriteLine(Categories[i]);
                }
            }
        }
        private void ReadProducts()
        {
            List<Product> products = new List<Product>();
            using (StreamReader sr = new StreamReader("Products.txt"))
            {

                string temp = "";
                while (!sr.EndOfStream)
                {
                    Product product = new Product();
                    temp = sr.ReadLine();
                    product.Name = temp.Split(':')[0];
                    product.Price = int.Parse(temp.Split(':')[1]);
                    product.Category = new Category() { Name= temp.Split(':')[2] };
                    product.ImagesId = int.Parse(temp.Split(':')[3]);
                    products.Add(product);

                }

            }
            FillProducts(products);
        }
        private void WriteProducts()
        {
            using (StreamWriter sw = new StreamWriter("Products.txt", false))
            {
                for (int i = 0; i < Products.Count; i++)
                {
                    sw.WriteLine(Products[i].Name+":"+ Products[i].Price+":"+ Products[i].Category.Name+":"+Products[i].ImagesId);
                }
            }
        }
        public void Writer(bool isCheck)
        {

            if(isCheck) WriteUsers();
            else
            {
                WriteCategories();
                WriteProducts();
            }
            
        }




    }
}
