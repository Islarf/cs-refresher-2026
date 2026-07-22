// Week 1 Project :: Inventory and Expense Tracker

//so the print later can output the euro symbol
Console.OutputEncoding = System.Text.Encoding.UTF8;


//Variables
string userName = string.Empty;
bool isRunning = true;

//Introduction
Console.WriteLine("==================================");
Console.WriteLine("== Inventory and Expense Tracker ==");
Console.WriteLine("==================================");
Console.WriteLine("\n\n\n\n");
NameEntry();
Console.WriteLine($"Hello, {userName}!");
while (isRunning)
{
    RunMenu();
}
Console.WriteLine("\nThank you for using Expense Tracker. Goodbye!");



void NameEntry()
{
    while (string.IsNullOrEmpty(userName))
    {
        Console.Write("Please enter your employee name?: ");
        userName = Console.ReadLine() ?? "";
    }
}


void RunMenu()
{

    //MainMenu
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1: Search for a product");
    Console.WriteLine("2: Add a product to the tracker");
    Console.WriteLine("3: Remove a product from the tracker");
    Console.WriteLine("4: Exit the program");

    String MenuChoice = Console.ReadLine() ?? "0";
    while (MenuChoice != "-1") {
        switch (MenuChoice)
        {
            case "1":
                Console.WriteLine("You have chosen to search for a product.");
                MenuChoice = "-1";
                break;
            case "2":
                Console.WriteLine("You have chosen to add a product to the tracker.");
                ProductManager newProduct = new ProductManager();
                newProduct.AddProduct_Console();
                Console.WriteLine("Would you like to add another product? (Y/N)");
                if (Console.ReadLine()?.ToUpper() != "Y")
                {
                    MenuChoice = "-1";
                }

                break;
            case "3":
                Console.WriteLine("You have chosen to remove a product from the tracker.");
                MenuChoice = "-1";
                break;
            case "4":
                Console.WriteLine("You have chosen to exit the program.");
                MenuChoice = "-1";
                isRunning = false;
                break;
            default:
                Console.WriteLine("Invalid choice. Please try again.");
                break;
        }
    }

}

public class Product
{
    public string ItemID { get; set; } = "";
    public string ItemDesc { get; set; } = "";
    public decimal UnitCost { get; set; }
    public int Quantity { get; set; }
    public decimal TotalCost => UnitCost * Quantity;
}

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
        _products.Add(newProduct);
        Console.WriteLine($"You created the product: {newProduct.ItemID} : {newProduct.ItemDesc}, Quantity: {newProduct.Quantity}, Total Cost: {newProduct.TotalCost}");
        Console.WriteLine("Confirm that you would like to add this Product to the tracker? (Y/N)");
        if (Console.ReadLine()?.ToUpper() == "Y")
        {
            Console.WriteLine("Product added to the tracker.");
        }
        else
        {
            _products.Remove(newProduct);
            Console.WriteLine("Product not added to the tracker.");
        }
    }

}