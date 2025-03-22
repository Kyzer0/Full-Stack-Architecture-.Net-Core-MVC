using Microsoft.Data.SqlClient;

namespace GitHubPractice
{
    internal class Program
    {
        string connectionString = "Server=MAJINBOO\\SQLEXPRESS01;Database=ProductDB;Trusted_Connection=True;";
        public List<Model> _products = new List<Model>()
            {
                new Model{ ProductKey = 1, ProductName = "Sardine", ProductPrice =  28.50m}
            };
        static void Main(string[] args)
        {
            //create db

            Program program = new Program();
            while (true)
            {
                Console.WriteLine("Enter a Task: ");
                Console.WriteLine("C - Create\n" +
                    "R - Read\n" +
                    "U - Update\n" +
                    "D - Delete\n" +
                    "E - Exit");
                Console.Write("Answer: ");
                char userInput = Convert.ToChar(Console.ReadLine());

                if (userInput == 'E' || userInput == 'e') break;
                switch (userInput)
                {
                    case 'C':
                    case 'c':
                        program.Create();
                        break;
                    case 'R':
                    case 'r':
                        program.Read();
                        break;
                    case 'U':
                    case 'u':
                        program.Update();
                        break;
                    case 'D':
                    case 'd':
                        program.Delete();
                        break;
                    default:
                        Console.WriteLine("Invalid Answer!");
                        break;
                }
            }
        }

        public void Create()
        {
            if (_products == null) throw new ArgumentNullException("Cannot be null");

            Console.Write("Enter ProductName: ");
            string productName = Console.ReadLine();

            Console.Write("Enter ProductPrice: ");
            decimal productPrice = Convert.ToDecimal(Console.ReadLine());

            var newProducts = new Model()
            {
                ProductName = productName,
                ProductPrice = productPrice
            };
            _products.Add(newProducts);

            //adding Database
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Products (ProductName, ProductPrice) VALUES (@ProductName, @ProductPrice)";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProductName", productName);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Read()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Products";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.WriteLine("\nProduct Information:\n");
                    while (reader.Read())
                    {
                        Console.WriteLine($"Product ID: {reader["ProductKey"]}, " +
                                          $"Name: {reader["ProductName"]}, " +
                                          $"Price: {reader["ProductPrice"]}");
                    }
                }
            }
        }


        public void Update()
{
    Console.WriteLine("Enter Product ID you want to update: ");
    int productId = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Enter new Product Name: ");
    string productName = Console.ReadLine();

    Console.WriteLine("Enter new Product Price: ");
    decimal productPrice = Convert.ToDecimal(Console.ReadLine());

    using (SqlConnection conn = new SqlConnection(connectionString))
    {
        conn.Open();
        string query = "UPDATE Products SET ProductName = @ProductName, ProductPrice = @ProductPrice WHERE ProductKey = @ProductKey";
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@ProductKey", productId);
            cmd.Parameters.AddWithValue("@ProductName", productName);
            cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
                Console.WriteLine("Product updated successfully!");
            else
                Console.WriteLine("Product not found.");
        }
    }
}


        public void Delete()
        {
            if (_products.Count <= 0) throw new ArgumentOutOfRangeException("Cannot be less than or equal to zero");
            Console.WriteLine("Enter Item you Want to Delete: ");
            int userInput = Convert.ToInt32(Console.ReadLine());

            var checkId = _products.Find(x => x.ProductKey == userInput);
            if (checkId != null)
            {
                _products.Remove(checkId);
            }
        }
    }
    public class Model
    {
        public int ProductKey { get; set; }
        public required string ProductName { get; set; }
        public required decimal ProductPrice { get; set; }
    }
}
