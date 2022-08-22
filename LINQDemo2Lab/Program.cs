using System.Xml;

namespace LINQDemo2Lab
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> a = new List<int> { 1, 3, 4, 6 };
            for (int i = 0; i < a[1]; i++)
            {
                Console.WriteLine(a[i]);
            }

              List<Product> products = ProductsDB.GetProducts();

            
            
           

            //1. List all products whose price in between 50K to 80K
            Console.WriteLine("Products whose price in between 50K to 80K");
            var pp = from p in products
                     where p.Price >= 50000 && p.Price <= 80000
                     select p.Name;

            foreach (var p in pp)
            {
                Console.WriteLine("- " +p);
            }


            //2. Extract all products belongs to Laptops catagory
            Console.WriteLine(" ");
            Console.WriteLine("Products belongs to Laptops catagory");
            var  ll = from p in products
                      where p.Catagory.Name == "Laptops"
                      select p.Name;

            foreach (var p in ll)
            {
                Console.WriteLine("- " + p);
            }


            //3. Extract/Show Product Name and Catagory Name only
            Console.WriteLine(" ");
            Console.WriteLine("Show Product Name and Catagory Name only");

            var result3 = from p in products
                          //select p.Catagory.Name;
                            select new { Name = p.Name, Catagory = p.Catagory.Name };

            foreach (var p in result3)
            {
                Console.WriteLine($" {p.Name}  {p.Catagory}" );
            }

            //4. Show the costliest product name 
            Console.WriteLine(" ");
            Console.WriteLine("Show the costliest product name ");

           

            var result4 = (from p in products
                           where p.Price == products.Max(a => a.Price)
                           select p.Name);


            foreach (var p in result4)
            {
                Console.WriteLine($" {p}");
            }


            //5. Show the cheepest product name and its price

            Console.WriteLine(" ");
            Console.WriteLine("Show the cheapest product name ");



            var result5 = (from p in products
                           where p.Price == products.Min(a => a.Price)
                           select p.Name);


            foreach (var p in result5)
            {
                Console.WriteLine($" {p}");
            }

            //6. Show the 2nd and 3rd product details

            //Console.WriteLine(" ");
            //Console.WriteLine("Show the cheapest product name ");



            //var result6 = from p in products
            //              select new { Id = p.ProductID, Name = p.Name, Catagory = p.Catagory.Name, Price = p.Price };


            //foreach (var p in result6)
            //{
            //    Console.WriteLine($" {p}");
            //}

            //7. List all products in assending order of their price
            Console.WriteLine(" ");
            Console.WriteLine("List all products in assending order of their price ");



            var result7 = from p in products
                          orderby p.Price
                          select p;


            foreach (var p in result7)
            {
                Console.WriteLine($" {p.Name}");
            }


            //8. Count the no. of products belong to Tablets

            Console.WriteLine(" ");
            Console.WriteLine("Count the no. of products belong to Tablets");



            var result8 = (from p in products
                           where p.Catagory.Name == "Tablets"
                           select p).Count();

            Console.WriteLine(result8);



            //9. Show which catagory has costly product

            Console.WriteLine(" ");
            Console.WriteLine("Show which catagory has costly product");



            var result9 = from p in products
                          where p.Price ==  products.Max(a => a.Price)
                          select p.Catagory.Name;


            foreach (var p in result9)
            {
                Console.WriteLine($" {p}");
            }


            //10. Show which catagory has less products
            Console.WriteLine(" ");
            Console.WriteLine("Show which catagory has less products");



            var result10 = from p in products
                          group p by p.Catagory.Name into Cat
                           select new {Cname =Cat.Key, Cnt = Cat.Count()};

            var result11 = from p in result10
                           where p.Cnt == result10.Min(a => a.Cnt)
                           select p.Cname;

            foreach (var p in result11)
            {
                Console.WriteLine($" {p}");
            }

            //11. Save all products into XML document	

            XmlDocument xmld = new XmlDocument(); //pending

        }

    }
    class ProductsDB
    {
        public static List<Product> GetProducts()
        {
            Catagory cat1 = new Catagory { CatagoryID = 101, Name = "Laptops" };
            Catagory cat2 = new Catagory { CatagoryID = 201, Name = "Mobiles" };
            Catagory cat3 = new Catagory { CatagoryID = 301, Name = "Tablets" };

            Product p1 = new Product { ProductID = 1, Name = "Dell XPS 13", Catagory = cat1, Price = 90000 };
            Product p2 = new Product { ProductID = 2, Name = "HP 430", Catagory = cat1, Price = 50000 };
            Product p3 = new Product { ProductID = 3, Name = "IPhone 6", Catagory = cat2, Price = 80000 };
            Product p4 = new Product { ProductID = 4, Name = "Galaxy S6", Catagory = cat2, Price = 74000 };
            Product p5 = new Product { ProductID = 5, Name = "IPad Pro", Catagory = cat3, Price = 44000 };

            cat1.Products.Add(p1);
            cat1.Products.Add(p2);
            cat2.Products.Add(p3);
            cat2.Products.Add(p4);
            cat3.Products.Add(p5);

            List<Product> products = new List<Product>();
            products.Add(p1);
            products.Add(p2);
            products.Add(p3);
            products.Add(p4);
            products.Add(p5);

            return products;
        }
    }
    class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Catagory Catagory { get; set; }
    }
    class Catagory
    {
        public int CatagoryID { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
    }
}