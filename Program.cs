using A1;
using static A1.Product;

namespace A1
{
    public class ProductOutOfStockException : Exception
    {
        public ProductOutOfStockException(string Message) : base(Message)
        {

        }
    }
    public class Product
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public class Ordermanage
        {
            public bool PlaceOrder(Product product)
            {

                if (product.Stock <= 0)
                {
                    throw new ProductOutOfStockException("Product out of stock");

                }

                return true;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ordermanage order = new Ordermanage();
            Console.WriteLine("Enter the Product Name :");

            string Productname = Console.ReadLine();
            Console.WriteLine("Enter the Number of stock");

            int ProStock = int.Parse(Console.ReadLine());

            Product product = new Product { Name = Productname, Stock = ProStock };

            try
            {
                if (order.PlaceOrder(product))
                {
                    Console.WriteLine("Order Placed successfully");
                }

            }
            catch (ProductOutOfStockException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occure" + ex.Message);
            }
        }

    }
}



