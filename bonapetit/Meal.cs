using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonapetit
{
    class Meal
    {
        private string name;
        private string type;
        private List<Product> products = new List<Product>();
        private int ordered = 0;
        private double price = 0.0;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public List<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
        public int Ordered
        {
            get { return this.ordered; }
            set { this.ordered = value; }
        }
        public double Price
        {
            get { return this.price; }            
        }

        public Meal() { }
        public Meal(string name, string type)
        {
            this.Name = name;
            this.Type = type;
            this.Products = new List<Product>();
        }
        public Meal(string name, string type, List<Product> products)
        {
            this.Name = name;
            this.Type = type;
            this.Products = products;
            double price = 0.0;
            foreach (var item in products)
            {
                price += item.Price;
            }
            price = price + price;

        }
        public void AddProduct(Product product) {
            this.Products.Add(product);
            this.price += product.Price;
            //double price = 0.0;
            //foreach (var item in products)
            //{
            //    price += item.Price;
            //}
            //price = price + price;
        }
        public override string ToString()
        {
            return $"{this.Name } - {this.Type}";
        }
    }
}
