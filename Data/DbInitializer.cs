using Ccog3nt_product_Management_4._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ccog3nt_product_Management_4._0.Data
{
    public class DbInitializer
    {
        public static void Initialize(Cog3ntDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                new Product{ID = 37, ProductId=37, Sku= 20000370 , OrderProductId = 37, ProductName ="Pork Bangers 500 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=4},
                new Product{ID = 38, ProductId=38, Sku= 20000400 , OrderProductId = 38, ProductName ="BF Bangers", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/11/04"),UnitsPerCase=2},
                new Product{ID = 39, ProductId=39, Sku= 20000943 , OrderProductId = 39, ProductName ="Chuckles Peanut 150g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=30},
                new Product{ID = 40, ProductId=40, Sku= 20000950 , OrderProductId = 40, ProductName ="Chuckles Peanut 150g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=30},
                new Product{ID = 41, ProductId=41, Sku= 20000967 , OrderProductId = 41, ProductName ="Chuckles Peanut 150g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=48},
                new Product{ID = 42, ProductId=42, Sku= 20000974 , OrderProductId = 42, ProductName ="Chuckles Peanut 150g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=30},
                new Product{ID = 43, ProductId=43, Sku= 20001018 , OrderProductId = 43, ProductName ="Pecan Cashew 100 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 44, ProductId=44, Sku= 200001025 , OrderProductId = 44, ProductName ="Soft Eating Gum 125g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=40},
                new Product{ID = 45, ProductId=45, Sku= 200001056, OrderProductId = 45, ProductName ="Cran Mac Ngt 100 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 46, ProductId=46, Sku= 200001056, OrderProductId = 46, ProductName ="Liq Allsorts 125 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=40},
                new Product{ID = 47, ProductId=47, Sku= 20001209, OrderProductId = 47, ProductName ="Ccnut Mmallows 150 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=40},
                new Product{ID = 48, ProductId=48, Sku= 20002480, OrderProductId = 48, ProductName ="WW Beans Tom Sauce", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 49, ProductId=49, Sku= 20002718, OrderProductId = 49, ProductName ="Tomato Soup 400 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 50, ProductId=50, Sku= 20003036, OrderProductId = 50, ProductName ="Straw Jam Jar 340 g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 51, ProductId=51, Sku= 20003050, OrderProductId = 51, ProductName ="Apricot Jam Jar 340", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 52, ProductId=52, Sku= 20003067, OrderProductId = 52, ProductName ="Sev Orange Marmalade", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 54, ProductId=54, Sku= 20003319, OrderProductId = 54, ProductName ="English Breakfast Te", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=6 },
                new Product{ID = 55, ProductId=55, Sku= 20003067, OrderProductId = 55, ProductName ="Ext Strong Black Tea", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=6},
                new Product{ID = 56, ProductId=56, Sku= 20003357, OrderProductId = 56, ProductName ="Breakfst Ground 250g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=8 },
                new Product{ID = 57, ProductId=57, Sku= 20003388, OrderProductId = 57, ProductName ="Sunflower Oil 750ml", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},

                new Product{ID = 58, ProductId=58, Sku= 20003050, OrderProductId = 58, ProductName ="2 ply Toil Ppr 4", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 59, ProductId=59, Sku= 20003067, OrderProductId = 59, ProductName ="W.Lab Lime DWL", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
                new Product{ID = 60, ProductId=60, Sku= 20003319, OrderProductId = 60, ProductName ="English Cucumber", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=25 },
                new Product{ID = 61, ProductId=61, Sku= 20003067, OrderProductId = 61, ProductName ="Mini Cucumbers", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=20},
                new Product{ID = 62, ProductId=62, Sku= 20003357, OrderProductId = 62, ProductName ="Iceberg Lettuce Head", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=8 },
                new Product{ID = 63, ProductId=63, Sku= 20003388, OrderProductId = 63, ProductName ="Celery Whole 400g", ModifiedDate= DateTime.Parse("2021/05/07"),ImportDate= DateTime.Parse("2020/06/13"),UnitsPerCase=12},
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);

            }
            context.SaveChanges();
        }
    }
}
