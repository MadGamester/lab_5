using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Program
    {
        class Product
        {
            private String name;
            private String receiptDate;
            private double weight;
            private double price;
            private int count;

            private double totalWeight;
            private double totalPrice;

            public String Name { get { return name; } }
            public String ReceiptDate { get { return receiptDate; } }
            public double Weight { get { return weight; } }
            public double Price { get { return price; } }
            public int Count { get { return count; } }
            public double ToTalWeight { get { return totalWeight; } }
            public double ToTalPrice { get { return totalPrice; } }

            public Product()
            {
                this.name = "";
                this.receiptDate = "";
                this.weight = 0;
                this.price = 0;
                this.count = 0;
                this.totalPrice = 0;
                this.totalWeight = 0;
            }

            public Product(String name, String receiptDate, double weight, double price, int count)
            {
                this.name = name;
                this.receiptDate = receiptDate;
                this.weight = weight;
                this.price = price;
                this.count = count;
                this.totalPrice = count * price;
                this.totalWeight = count * weight;
            }

            public void showProductInfo()
            {
                Console.WriteLine("__________________________");
                Console.WriteLine("  <=| Product: " + name + " |=>");
                Console.WriteLine("   -Receipt date: " + receiptDate);
                Console.WriteLine("   -Weight: " + weight + " kg");
                Console.WriteLine("   -Price: " + price + " UAH");
                Console.WriteLine("   -Count: " + count);
                Console.WriteLine("__Total weight: " + totalWeight + " kg");
                Console.WriteLine("__Total price: " + totalPrice + " UAH");
                Console.WriteLine();
            }

        }

        class ProductNameComparer: IComparer<Product>
        {
            public int Compare(Product first, Product second)
            {
                if (String.Compare(first.Name, second.Name) > 0) return 1;

                return 0;
            }
        }

        class ProductPriceComparer: IComparer<Product>
        {
            public int Compare(Product first, Product second)
            {
                if (first.Price > second.Price) return 1;
                return 0;
            }
        }

        class Storage
        {
            private String name;
            private List<Product> products;
            
            public String Name { get { return name; } }

            public Storage(String name)
            {
                this.name = name;
                products = new List<Product>();
            }

            public void showStorage()
            {
                Console.WriteLine("________| Storage " + name + " |________");
                Console.WriteLine("Products count: " + products.Count);

                foreach (Product product in products)
                    product.showProductInfo();

                Console.WriteLine();
                Console.Write("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
            }

            public void sortProductsByName()
            {
                ProductNameComparer comparer = new ProductNameComparer();

                products.Sort(comparer);
            }

            public void sortProductsByPrice()
            {
                ProductPriceComparer comparer = new ProductPriceComparer();

                products.Sort(comparer);
            }

            public void addProduct(Product newProduct)
            {
                products.Add(newProduct);

                Console.WriteLine("*** Product " + newProduct.Name + " added! ***");
                Console.WriteLine();
                Console.Write("Press any key to continue!");
                Console.ReadKey();
                Console.Clear();
            }

            private void searchProdByName(String name)
            {
                Product result = products.Find(x => x.Name == name);

                Console.WriteLine();

                if (result == default(Product))
                    Console.WriteLine("Product with name " + name + " not found!");
                else
                    result.showProductInfo();
            }

            private void searchProdByReceiptDate(String receiptDate)
            {
                Product result = products.Find(x => x.ReceiptDate == receiptDate);

                Console.WriteLine();

                if (result == default(Product))
                    Console.WriteLine("Product with receipt date " + receiptDate + " not found!");
                else
                    result.showProductInfo();
            }

            private void searchProdByPrice(Double price)
            {
                Product result = products.Find(x => x.Price == price);

                Console.WriteLine();

                if (result == default(Product))
                    Console.WriteLine("Product with price " + price + "  UAH not found!");
                else
                    result.showProductInfo();
            }

            private void searchProdByWeight(Double weight)
            {
                Product result = products.Find(x => x.Weight == weight);

                Console.WriteLine();

                if (result == default(Product))
                    Console.WriteLine("Product with weight " + weight + " kg not found!");
                else
                    result.showProductInfo();
            }

            private void searchProdByCount(int count)
            {
                Product result = products.Find(x => x.Count == count);

                Console.WriteLine();

                if (result == default(Product))
                    Console.WriteLine("Product with count " + count + " not found!");
                else
                    result.showProductInfo();
            }

            public void searchProduct()
            {
                Console.Clear();
                Console.WriteLine("________| Storage " + name + " |________");
                Console.WriteLine("Products count: " + products.Count);
                Console.WriteLine();
                Console.WriteLine(">> Choose criterion for product searching <<");

                Console.WriteLine("1. By name");
                Console.WriteLine("2. By receipt date");
                Console.WriteLine("3. By price");
                Console.WriteLine("4. By weight");
                Console.WriteLine("5. By count");
                Console.WriteLine("0. Back");

                int mode;

                Console.Write("Searching mode: ");

                if (!Int32.TryParse(Console.ReadLine(), out mode)) mode = -1;

                Console.Clear();

                switch (mode)
                {
                    case 1: Console.Write("Enter name for searching: "); searchProdByName(Console.ReadLine()); break;
                    case 2: Console.Write("Enter receipt date for searching: "); searchProdByReceiptDate(Console.ReadLine()); break;
                    case 3: Console.Write("Enter price for searching: "); searchProdByPrice(Convert.ToDouble(Console.ReadLine())); break;
                    case 4: Console.Write("Enter weight for searching: "); searchProdByWeight(Convert.ToDouble(Console.ReadLine())); break;
                    case 5: Console.Write("Enter count for searching: "); searchProdByCount(Convert.ToInt32(Console.ReadLine())); break;
                    case 0: return;
                    default: Console.Clear(); Console.WriteLine("Invalid mode!"); break;
                }

                Console.WriteLine();
                Console.Write("Press any key to continue!");
                Console.ReadKey();
            }

            public int getProductsCount()
            {
                return products.Count;
            }
        }

        static Product readProdFromConsole()
        {
            String name;
            String receiptDate;
            double weight;
            double price;
            int count;

            Console.Write("Enter product name: ");
            name = Console.ReadLine();

            Console.Write("Enter product receipt data in format dd.mm.yy: ");
            receiptDate = Console.ReadLine();

            Console.Write("Enter product weight in kg: ");
            weight = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter product price in UAH: ");
            price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter product count: ");
            count = Convert.ToInt32(Console.ReadLine());

            Product newProduct = new Product(name, receiptDate, weight, price, count);

            Console.Clear();

            return newProduct;

        }

      


        static void Main(string[] args)
        {
            String storageName;



            Console.Write("Enter name for new storage: ");
            storageName = Console.ReadLine();

            Storage storage = new Storage(storageName);

            Console.Clear();

            Console.WriteLine("*** Storage " + storageName + " created! ***");
            Console.WriteLine();
            Console.Write("Press any key to continue!");
            Console.ReadKey();
            

            int mode = -1;

            while (mode != 0)
            {
                Console.Clear();
                Console.WriteLine("________| Storage " + storage.Name + " |________");
                Console.WriteLine("Products count: " + storage.getProductsCount());
                Console.WriteLine();

                Console.WriteLine(">> Choose mode <<");
                Console.WriteLine("1. Add product");
                Console.WriteLine("2. Show storage");
                Console.WriteLine("3. Search product");
                Console.WriteLine("4. Sort products by name");
                Console.WriteLine("5. Sort products by price");
                Console.WriteLine("0. Exit");

                Console.Write("Mode: ");



                if (!Int32.TryParse(Console.ReadLine(), out mode)) mode = -1;
               

                Console.Clear();

                switch (mode)
                {
                    case 1: storage.addProduct(readProdFromConsole()); break;
                    case 2: storage.showStorage(); break;
                    case 3: storage.searchProduct(); break;
                    case 4: storage.sortProductsByName(); break;
                    case 5: storage.sortProductsByPrice(); break;
                    case 0: Environment.Exit(0); break;
                    default:
                                Console.Clear();
                                Console.WriteLine("Invalid mode!");
                                Console.WriteLine();
                                Console.Write("Press any key to continue!");
                                Console.ReadKey();
                    break;
                }
            }


            Console.ReadKey();
        }
    }
}
