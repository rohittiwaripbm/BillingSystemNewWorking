using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystemInWPF.ViewModels
{
    public class DemoProductCategoryList : BaseViewModel
    {
        public static List<DemoCategories> _categoryList { get; set; }
        public static ObservableCollection<DemoProducts> _products { get; set; }

       
        public void AddCategoriesProducts()
        {
            _categoryList = new List<DemoCategories>()
            {
            new DemoCategories() { Id = 1, Name = "Electronics" },
            new DemoCategories() { Id = 2, Name = "Clothing" },
            new DemoCategories() { Id = 3, Name = "Home & Kitchen" },
            new DemoCategories() { Id = 4, Name = "Toys & Games" },
            new DemoCategories() { Id = 5, Name = "Books" },
            new DemoCategories() { Id = 6, Name = "Sports & Outdoors" },
            new DemoCategories() { Id = 7, Name = "Beauty & Personal Care" },
            new DemoCategories() { Id = 8, Name = "Automotive" },
            new DemoCategories() { Id = 9, Name = "Health & Household" },
            new DemoCategories() { Id = 10, Name = "Office Products" }
            };

            // Products
            _products = new ObservableCollection<DemoProducts>
            {
                // Books
                new DemoProducts { ProductId = 1, ProductName = "The Catcher in the Rye", ProductPrice = 126, CategoryId = 5, ProductInStore = 20 },
                new DemoProducts { ProductId = 2, ProductName = "To Kill a Mockingbird", ProductPrice = 900, CategoryId = 5, ProductInStore = 15 },
                new DemoProducts { ProductId = 3, ProductName = "1984", ProductPrice = 150, CategoryId = 5, ProductInStore = 25 },
                new DemoProducts { ProductId = 4, ProductName = "The Great Gatsby", ProductPrice = 110, CategoryId = 5, ProductInStore = 18 },
                new DemoProducts { ProductId = 5, ProductName = "Pride and Prejudice", ProductPrice = 800, CategoryId = 5, ProductInStore = 12 },
                new DemoProducts { ProductId = 6, ProductName = "To the Lighthouse", ProductPrice = 140, CategoryId = 5, ProductInStore = 8 },
                new DemoProducts { ProductId = 7, ProductName = "The Odyssey", ProductPrice = 100, CategoryId = 5, ProductInStore = 22 },
                new DemoProducts { ProductId = 8, ProductName = "The Lord of the Rings", ProductPrice = 270, CategoryId = 5, ProductInStore = 30 },
                new DemoProducts { ProductId = 9, ProductName = "The Hobbit", ProductPrice = 900, CategoryId = 5, ProductInStore = 25 },
                new DemoProducts { ProductId = 10, ProductName = "The Hitchhiker's Guide to the Galaxy", ProductPrice = 600, CategoryId = 5, ProductInStore = 20 },

                // Electronics
                new DemoProducts { ProductId = 11, ProductName = "iPhone 12", ProductPrice = 899, CategoryId = 1, ProductInStore = 50 },
                new DemoProducts { ProductId = 12, ProductName = "Samsung Galaxy S21", ProductPrice = 799, CategoryId = 1, ProductInStore = 40 },
                new DemoProducts { ProductId = 13, ProductName = "MacBook Pro", ProductPrice = 1799, CategoryId = 1, ProductInStore = 25 },
                new DemoProducts { ProductId = 14, ProductName = "Dell XPS 13", ProductPrice = 1399, CategoryId = 1, ProductInStore = 30 },
                new DemoProducts{ ProductId = 15, ProductName = "Sony Playstation 5", ProductPrice = 499, CategoryId = 1, ProductInStore = 20},
                //Clothes
                new DemoProducts { ProductId = 16, ProductName = "T-shirt", ProductPrice = 1500, CategoryId = 2, ProductInStore = 20 },
                new DemoProducts { ProductId = 17, ProductName = "Jeans", ProductPrice = 2500, CategoryId = 2, ProductInStore = 15 },
                new DemoProducts { ProductId = 18, ProductName = "Dress", ProductPrice = 3500, CategoryId = 2, ProductInStore = 10 },
                new DemoProducts { ProductId = 19, ProductName = "Shoes", ProductPrice = 2000, CategoryId = 2, ProductInStore = 25 },
                new DemoProducts { ProductId = 20, ProductName = "Socks", ProductPrice = 35, CategoryId = 2, ProductInStore = 50 },
                new DemoProducts { ProductId = 21, ProductName = "Hoodie", ProductPrice = 3000, CategoryId = 2, ProductInStore = 10 },
                new DemoProducts { ProductId = 22, ProductName = "Shorts", ProductPrice = 1800, CategoryId = 2, ProductInStore = 30 },
                new DemoProducts { ProductId = 23, ProductName = "Jacket", ProductPrice = 5000, CategoryId = 2, ProductInStore = 5 },
                new DemoProducts { ProductId = 24, ProductName = "Blouse", ProductPrice = 2200, CategoryId = 2, ProductInStore = 12 },
                new DemoProducts { ProductId = 25, ProductName = "Saree", ProductPrice = 4000, CategoryId = 2, ProductInStore = 8 },
                //Home & Kitchen
                new DemoProducts { ProductId = 26, ProductName = "Electric Kettle", ProductPrice = 25.99m, CategoryId = 3, ProductInStore = 15 },
                new DemoProducts { ProductId = 27, ProductName = "Air Fryer", ProductPrice = 69.99m, CategoryId = 3, ProductInStore = 10 },
                new DemoProducts { ProductId = 28, ProductName = "Hand Blender", ProductPrice = 32.50m, CategoryId = 3, ProductInStore = 20 },
                new DemoProducts { ProductId = 29, ProductName = "Toaster", ProductPrice = 19.99m, CategoryId = 3, ProductInStore = 25 },
                new DemoProducts { ProductId = 30, ProductName = "Mixer Grinder", ProductPrice = 49.99m, CategoryId = 3, ProductInStore = 12 },
                new DemoProducts { ProductId = 31, ProductName = "Rice Cooker", ProductPrice = 39.99m, CategoryId = 3, ProductInStore = 18 },
                new DemoProducts { ProductId = 32, ProductName = "Microwave Oven", ProductPrice = 89.99m, CategoryId = 3, ProductInStore = 8 },
                new DemoProducts { ProductId = 33, ProductName = "Coffee Maker", ProductPrice = 45.99m, CategoryId = 3, ProductInStore = 13 },
                new DemoProducts { ProductId = 34, ProductName = "Vacuum Cleaner", ProductPrice = 79.99m, CategoryId = 3, ProductInStore = 7 },
                new DemoProducts { ProductId = 35, ProductName = "Food Processor", ProductPrice = 59.99m, CategoryId = 3, ProductInStore = 10 },
                //Toys & Games
                new DemoProducts { ProductId = 36, ProductName = "Lego Classic Creative Bricks Set", ProductPrice = 29.99m, CategoryId = 4, ProductInStore = 15 },
                new DemoProducts { ProductId = 37, ProductName = "Rubik's Cube", ProductPrice = 8.99m, CategoryId = 4, ProductInStore = 25 },
                new DemoProducts { ProductId = 38, ProductName = "Uno Card Game", ProductPrice = 4.99m, CategoryId = 4, ProductInStore = 30 },
                new DemoProducts { ProductId = 39, ProductName = "Monopoly Board Game", ProductPrice = 19.99m, CategoryId = 4, ProductInStore = 10 },
                new DemoProducts { ProductId = 40, ProductName = "Connect 4 Board Game", ProductPrice = 12.99m, CategoryId = 4, ProductInStore = 20 },
                new DemoProducts { ProductId = 41, ProductName = "Nerf N-Strike Elite Disruptor Blaster", ProductPrice = 14.99m, CategoryId = 4, ProductInStore = 8 },
                new DemoProducts { ProductId = 42, ProductName = "Crayola Inspiration Art Case", ProductPrice = 19.99m, CategoryId = 4, ProductInStore = 12 },
                new DemoProducts { ProductId = 43, ProductName = "Hot Wheels Basic Car 50-Pack", ProductPrice = 44.99m, CategoryId = 4, ProductInStore = 5 },
                new DemoProducts { ProductId = 44, ProductName = "Barbie Dreamhouse Dollhouse", ProductPrice = 179.99m, CategoryId = 4, ProductInStore = 2 },
                new DemoProducts { ProductId = 45, ProductName = "LEGO Star Wars: The Rise of Skywalker Millennium Falcon", ProductPrice = 159.99m, CategoryId = 4, ProductInStore = 4 },
                //Beauty & Personal Care
                new DemoProducts { ProductId = 46, ProductName = "L'Oreal Paris Voluminous Mascara", ProductPrice = 8.49m, CategoryId = 7, ProductInStore = 15 },
                new DemoProducts { ProductId = 47, ProductName = "Cetaphil Daily Facial Cleanser", ProductPrice = 8.79m, CategoryId = 7, ProductInStore = 20 },
                new DemoProducts { ProductId = 48, ProductName = "Maybelline SuperStay Matte Ink Liquid Lipstick", ProductPrice = 7.99m, CategoryId = 7, ProductInStore = 10 },
                new DemoProducts { ProductId = 49, ProductName = "Garnier Fructis Sleek & Shine Shampoo", ProductPrice = 4.49m, CategoryId = 7, ProductInStore = 25 },
                new DemoProducts { ProductId = 50, ProductName = "Neutrogena Hydro Boost Hydrating Gel Cream", ProductPrice = 16.99m, CategoryId = 7, ProductInStore = 5 },
                new DemoProducts { ProductId = 51, ProductName = "Dove Beauty Bar Soap", ProductPrice = 3.49m, CategoryId = 7, ProductInStore = 30 },
                new DemoProducts { ProductId = 52, ProductName = "Olay Regenerist Retinol 24 Night Moisturizer", ProductPrice = 28.99m, CategoryId = 7, ProductInStore = 8 },
                new DemoProducts { ProductId = 53, ProductName = "Aveeno Daily Moisturizing Lotion", ProductPrice = 8.99m, CategoryId = 7, ProductInStore = 12 },
                new DemoProducts { ProductId = 54, ProductName = "Revlon ColorStay Liquid Foundation", ProductPrice = 12.99m, CategoryId = 7, ProductInStore = 7 },
                new DemoProducts { ProductId = 55, ProductName = "Head and Shoulders Classic Clean Shampoo", ProductPrice = 6.99m, CategoryId = 7, ProductInStore = 18 },

            };

        }
    }
}
