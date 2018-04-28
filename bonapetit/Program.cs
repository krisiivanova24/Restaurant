using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bonapetit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> messages = new List<string>();

            List<Product> products = new List<Product>();
            List<Meal> meals = new List<Meal>();
            string[] inputs = Console.ReadLine().Split().ToArray();
            do
            {
                string command = inputs[0];
                switch (command)
                {
                    case "AddProduct":
                        {
                            string name = inputs[1];
                            double price = double.Parse(inputs[2]);
                            int weight = int.Parse(inputs[3]);
                            Product inputProduct = new Product(name, price, weight);
                            products.Add(inputProduct);
                            break;
                        }
                    case "AddMultiProducts":
                        {
                            byte num = byte.Parse(inputs[1]);
                            for (int i = 0; i < num; i++)
                            {
                                string[] newInput = Console.ReadLine().Split().ToArray();
                                string name = newInput[0];
                                double price = double.Parse(newInput[1]);
                                int weight = int.Parse(newInput[2]);
                                Product inputProduct = new Product(name, price, weight); //moje i navednyj
                                products.Add(inputProduct);


                            }
                            break;
                        }
                    case "PrintProduct":
                        {
                            string name = inputs[1];
                            //Console.WriteLine($"{products.Where(v=>v.Name ==name)} - {products.}");
                            foreach (var item in products)
                            {
                                if (String.Equals(name, item.Name))
                                {
                                    messages.Add(item.ToString());
                                }
                            }
                            break;
                        }
                    case "AddMeal":
                        {
                            Meal meal = new Meal(inputs[1], inputs[2]);
                            meals.Add(meal);
                            break;
                        }
                    case "AddMealProducts":
                        {
                            byte num = byte.Parse(inputs[3]);
                            string name = inputs[1];
                            string type = inputs[2];
                            foreach (var item in meals)
                            {
                                if (String.Equals(item.Name, name) && String.Equals(item.Type, type))
                                {
                                    for (int i = 0; i < num; i++)
                                    {
                                        string[] newInput = Console.ReadLine().Split().ToArray();
                                        Product inputProduct = new Product(newInput[0], double.Parse(newInput[1]), int.Parse(newInput[2]));
                                        Meal meal3 = new Meal(name, type);
                                        meal3.AddProduct(inputProduct);
                                        //item.Products.Add(inputProduct);
                                    }
                                }
                                else
                                {
                                    Meal newMeal = new Meal(name,type);
                                    List<Product> newPr = new List<Product>();
                                    for (int i = 0; i < num; i++)
                                    {
                                        //newPr.Add(inputs[i+4]);
                                    }
                                   
                                }
                            }
                            break;
                        }
                    case "PrintMeal":
                        {
                            string name = inputs[1];
                            foreach (var item in meals)
                            {
                                if (String.Equals(name, item.Name))
                                {
                                    messages.Add(item.ToString());
                                }
                            }
                            break;
                        }
                    case "AddProductToMeal":
                        {
                            string namePr = inputs[1];
                            string nameMea = inputs[2];
                            foreach (var item in products)
                            {
                                if (String.Equals(item.Name, namePr))
                                {
                                    foreach (var pair in meals)
                                    {
                                        if (String.Equals(pair.Name, nameMea))
                                        {
                                            pair.AddProduct(item);
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    case "ContainsProduct":
                        {
                            string namePr = inputs[1];
                            string nameMea = inputs[2];

                            Meal findMeal = meals.Find(b => b.Name == nameMea);
                            //foreach (var pair in meals)
                            //{
                            //    if (String.Equals(nameMea, pair.Name))
                            //    {
                            //Console.WriteLine(findMeal.ToString ());
                            //Console.WriteLine(findMeal.Products.Count +" //////////////////////////////////////");
                            //if (findMeal.Products.Count != 0)
                            //{ 
                            if (findMeal != null)
                            {

                            
                                foreach (var item in findMeal.Products)
                                {
                                    if (String.Equals(item.Name, namePr))
                                    {
                                        messages.Add($"{namePr} is contained in {nameMea}.");
                                        break;
                                    }
                                    else
                                    {
                                        messages.Add($"{namePr} is NOT contained in {nameMea}.");
                                        break;
                                    }
                                }
                           
                            }

                            //}
                            //}
                            break;
                        }
                    case "GetMealPrice":
                        {
                            string name = inputs[1];
                            foreach (var pair in meals)
                            {
                                if (String.Equals(name, pair.Name))
                                {

                                    messages.Add($"The price of {name} is: {(pair.Price + pair.Price * 0.3):f2}");
                                }
                            }
                            break;
                        }
                    case "PrintMealRecipe":
                        {
                            string name = inputs[1];
                            foreach (var pair in meals)
                            {
                                if (String.Equals(name, pair.Name))
                                {
                                    messages.Add(new string('-', 25));
                                    messages.Add($"{name} RECIPE");
                                    messages.Add(new string('-', 25));
                                    foreach (var item in pair.Products)
                                    {
                                        messages.Add($"{item.Name} - {item.Weight}");
                                    }
                                    messages.Add(new string('-', 25));
                                }
                            }
                            break;
                        }
                    case "OrderMeal":
                        {
                            string name = inputs[1];
                            foreach (var pair in meals)
                            {
                                if (String.Equals(name, pair.Name))
                                {
                                    pair.Ordered++;
                                }

                            }
                            break;
                        }
                    case "GetSpecialty":
                        {
                            string meal = "";
                            int count = 0; ;
                            foreach (var pair in meals)
                            {
                                if (count < pair.Ordered)
                                {
                                    count = pair.Ordered;
                                    meal = pair.Name;
                                }
                            }
                            messages.Add($"The current specialty is: {meal}");
                            break;
                        }
                    case "RecommendByPrice":
                        {
                            double price = double.Parse(inputs[1]);
                            List<Meal> meals2 = new List<Meal>();
                            Meal which = new Meal();
                            foreach (var pair in meals)
                            {
                                if (pair.Price <= price)
                                {
                                    meals.Add(pair);
                                }
                            }
                            which = meals2.OrderByDescending(w => w.Price).First();
                            messages.Add($"The recommended meal for {price} is {which.Name}. It costs {which.Price}");
                            break;
                        }

                    case "RecommendedByPriceAndType":
                        {
                            double price = double.Parse(inputs[1]);
                            string tip = inputs[2];
                            List<Meal> meals2 = new List<Meal>();
                            Meal which = new Meal();
                            foreach (var pair in meals)
                            {
                                if (String.Equals(pair.Type, tip))
                                {
                                    if (pair.Price <= price)
                                    {
                                        meals.Add(pair);
                                    }
                                }

                            }
                            which = meals2.OrderByDescending(w => w.Price).First();
                            //Console.WriteLine($"The recommended meal for {price} is {which.Name}. It costs {which.Price}");
                            messages.Add($"The recommended meal for {price} of type {tip} is {which.Name}. It costs {which.Price}");
                            break;
                        }
                    case "Cheapest":
                        {
                            double cheapPr = 999999999;
                            string which = "";

                            foreach (var pair in meals)
                            {
                                foreach (var item in pair.Products)
                                {
                                    //Console.WriteLine(item.Price + "-------------------------------------------------------------------");
                                    //Console.WriteLine(cheapPr + "+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
                                    if (item.Price < cheapPr)
                                    {


                                        cheapPr = item.Price;
                                        which = item.Name;
                                    }
                                }
                            }
                            messages.Add($"The cheapest product is {which}.");
                            break;
                        }
                }
                inputs = Console.ReadLine().Split().ToArray();
            } while (!inputs.Contains("End"));

            for (int i = 0; i < messages.Count; i++)
            {
                Console.WriteLine(messages[i]);
            }
        }
    }
}
