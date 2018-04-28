using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonapetit
{
    class Product
    {
        private string name;
        private double price;
        private int weight;

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public double Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
        public int Weight { get; set; }

        public Product(string name, double price, int weight) {
            this.Name = name;
            this.Price = price;
            this.Weight = weight;
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Weight}";
        }
    }
}
