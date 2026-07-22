// Week 1 Project :: Inventory and Expense Tracker

Console.OutputEncoding = System.Text.Encoding.UTF8;

Menu app = new Menu();
app.Start();

//AppUI
public class Menu
{
    private ProductManager _productManager = new ProductManager();
    private string _userName = string.Empty;
    private bool _isRunning = true;

    public void Start()
    {
        //Introduction
        Console.WriteLine("==================================");
        Console.WriteLine("== Inventory and Expense Tracker ==");
        Console.WriteLine("==================================");
        Console.WriteLine("\n\n\n\n");
        GetUserName();
        Console.WriteLine($"Hello, {_userName}!");
        while (_isRunning)
        {
            DisplayAndHandleMenu();
        }
        Console.WriteLine($"*** Thank you for using Expense Tracker. Goodbye! {_userName} ***");
    }
    private void GetUserName()
    {
        while (string.IsNullOrEmpty(_userName))
        {
            Console.Write("Please enter your employee name: ");
            _userName = Console.ReadLine() ?? "";
        }
    }

    //Display the menu and handle user input
    private void DisplayAndHandleMenu()
    {
        Console.WriteLine("\nWhat would you like to do?");
        Console.WriteLine("1: Search for a product");
        Console.WriteLine("2: Add a product to the tracker");
        Console.WriteLine("3: Remove a product from the tracker");
        Console.WriteLine("4: Exit the program");
        string choice = Console.ReadLine() ?? "0";
        switch (choice)
        {
            case "1":
                Console.WriteLine("You have chosen to search for a product.");
                break;
            case "2":
                bool isAdding = true;
                while(isAdding)
                {
                    _productManager.AddProduct_Console();
                    Console.WriteLine("\nWould you like to add another product? (Y/N)");
                    if(Console.ReadLine()?.Trim().ToUpper() != "Y")
                    {
                        isAdding = false;
                    }
                }
                break;
            case "3":
                Console.WriteLine("You have chosen to remove a product from the tracker.");
                break;
            case "4":
                Console.WriteLine("You have chosen to exit the program.");
                _isRunning = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }
}

//Product class to hold product information
public class Product
{
    public string ItemID { get; set; } = "";
    public string ItemDesc { get; set; } = "";
    public decimal UnitCost { get; set; }
    public int Quantity { get; set; }
    public decimal TotalCost => UnitCost * Quantity;
}

//Product Manager class to manage the list of products
public class ProductManager
{
    private List<Product> _products = new List<Product>();

    public void AddProduct_Console()
    {
        Console.WriteLine("\n-- Add a Product --");
        Console.Write("Enter the Item ID: ");
        string id = Console.ReadLine() ?? "-1";
        //here we can clarify if the item ID already exists
        Console.Write("Enter Description ");
        string desc = Console.ReadLine() ?? "N/A";
        Console.Write("Enter Unit Cost: ");
        decimal.TryParse(Console.ReadLine(), out decimal o_cost);
        Console.Write("Enter Quantity: ");
        int.TryParse(Console.ReadLine(), out int o_quantity);

        Product newProduct = new Product
        {
            ItemID = id,
            ItemDesc = desc,
            UnitCost = o_cost,
            Quantity = o_quantity
        };
        Console.WriteLine($"You created the product: {newProduct.ItemID} : {newProduct.ItemDesc}, Quantity: {newProduct.Quantity}, Total Cost: {newProduct.TotalCost}");
        Console.WriteLine("Confirm that you would like to add this Product to the tracker? (Y/N)");
        if (Console.ReadLine()?.ToUpper() == "Y")
        {
            _products.Add(newProduct);
            Console.WriteLine("Product added to the tracker.");
        }
        else
        {
            Console.WriteLine("Product entry discarded.");
        }
    }

}