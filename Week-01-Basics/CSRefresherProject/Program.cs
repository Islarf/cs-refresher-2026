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
        Console.WriteLine("\n***What would you like to do?***\n");
        Console.WriteLine("1: Search for a product");
        Console.WriteLine("2: Add a product to the tracker");
        Console.WriteLine("3: Remove a product from the tracker");
        Console.WriteLine("4: Exit the program");
        Console.Write("Enter your choice (1-4): ");
        string choice = Console.ReadLine() ?? "0";
        switch (choice)
        {
            case "1":
                Console.WriteLine("You have chosen to search for a product.");
                _productManager.SearchProducts_Console();
                break;
            case "2":
                bool isAdding = true;
                while(isAdding)
                {
                    _productManager.AddProduct_Console();
                    if(!ConsoleHelper.GetUserConfirmation("Would you like to add another product?"))
                    {
                        isAdding = false;
                    }
                }
                break;
            case "3":
                bool isRemoving = true;
                while(isRemoving)
                {
                    _productManager.RemoveProduct_Console();
                    if(!ConsoleHelper.GetUserConfirmation("Would you like to remove another product?"))
                    {
                        isRemoving = false;
                    }
                }
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

//Other useful console helpers i need
public static class ConsoleHelper
{
    public static bool GetUserConfirmation(string prompt)
    {
        while (true)
        {
            Console.Write($"{prompt} (Y/N) : ");
            string input = Console.ReadLine()?.Trim().ToUpper() ?? "";
            if (input == "Y")
            {
                return true;
            }
            if (input == "N")
            {
                return false;
            }
            Console.WriteLine("Invalid input. Please enter 'Y' for Yes or 'N' for No.\n");
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
        //Item ID, and duplication handling
        Console.Write("Enter the Item ID : ");
        int itemID;
        while (!int.TryParse(Console.ReadLine(), out itemID) || !DoesItemExist(itemID.ToString(), _products))
        {
            Console.Write("Invalid ID, or Item ID already exists. Enter a unique numeric Item ID : ");
        }

        //Description, Unit Cost, and Quantity
        Console.Write("Enter Description : ");
        string desc = Console.ReadLine() ?? "N/A";
        Console.Write("Enter Unit Cost : ");
        decimal cost;
        while (!decimal.TryParse(Console.ReadLine(), out cost) || cost <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid unit cost (greater than 0).");
        }
        Console.Write("Enter Quantity : ");
        int quantity;
        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid quantity (0 or greater).");
        }

        Product newProduct = new Product
        {
            ItemID = "" + itemID,
            ItemDesc = desc,
            UnitCost = cost,
            Quantity = quantity
        };
        Console.WriteLine($"You created the product: {newProduct.ItemID} : {newProduct.ItemDesc}, Quantity: {newProduct.Quantity}, Total Cost: {newProduct.TotalCost}");
        if (ConsoleHelper.GetUserConfirmation("Confirm that you would like to add this Product to the tracker?"))
        {
            _products.Add(newProduct);
            Console.WriteLine("Product added to the tracker.");
        }
        else
        {
            Console.WriteLine("Product entry discarded.");
        }
    }

    public bool SearchProducts_Console()
    {
        Console.WriteLine("\n-- Search Products --");
        if (_products.Count == 0)
        {
            Console.WriteLine("No products in the tracker.");
            return false;
        }
        Console.Write("Enter the item ID or the Descrption search term (or press Enter to view all) : ");
        string query = (Console.ReadLine() ?? "").Trim().ToLower();
        List<Product> results = _products
            .Where(p => p.ItemID.ToLower().Contains(query) || p.ItemDesc.ToLower().Contains(query))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine($"No products found matching '{query}'.");
        }
        else
        {
            Console.WriteLine($"\nFound {results.Count} matching product(s): ");
            DisplayProducts(results);
        }
        return true;
    }

    public void DisplayProducts(List<Product> products)
    {
        Console.WriteLine("----------------------------------------------");
        foreach (Product p in products)
        {
            DisplayProduct(p);
        }
        Console.WriteLine("----------------------------------------------");

    }

    public void DisplayProduct(Product p)
    {
        Console.WriteLine($"ID: {p.ItemID} ||, Description: {p.ItemDesc} ||, Unit Cost: {p.UnitCost} ||, Quantity: {p.Quantity} ||, Total Cost: {p.TotalCost}");
    }

    public bool DoesItemExist(string itemId, List<Product> productList)
    {
        //if both inputs are empty, exit the method and return false
        if (string.IsNullOrEmpty(itemId) || productList == null) return false;

        return productList.Any(p => p.ItemID.Equals(itemId, StringComparison.OrdinalIgnoreCase));
    }



    public void RemoveProduct_Console()
    {

        Console.WriteLine("\n-- Remove a Product --");
        //1: check if the product list is empty
        if (_products.Count == 0)
        {
            Console.WriteLine("No products in the tracker.");
            return;
        }

        //2:Search for products by ID / Desc
        List<Product> results = new List<Product>();
        while (results.Count == 0)
        {
            Console.Write("Enter the Item ID or Product Description of the product to remove (Press ENTER to cancel): ");
            string searchTerm = Console.ReadLine()?.Trim() ?? "";
            //2.a: check if the user wants to cancel the removal
            if (string.IsNullOrEmpty(searchTerm))
            {
                Console.WriteLine("Product removal cancelled.\n\n***Returning to the main menu.***");
                return;
            }
            //4: Search for the product(s) in the list

            results = _products
                .Where(p => p.ItemID.ToLower().Equals(searchTerm) || p.ItemDesc.ToLower().Contains(searchTerm))
                .ToList();
            if (results.Count == 0)
            {
                Console.WriteLine($"\n***No matching products found for '{searchTerm}'. Please try again.***\n\n");
            }
        }
        //1: Handle multiple (description) matches by narrowing to one specific item ID
        Product productToRemove = new Product();

        if (results.Count() > 1)
        {
            Console.WriteLine($"*** {results.Count} products were found matching your search. ***");
            DisplayProducts(results);

            string targetId = "";
            while (true)
            {
                Console.Write("Multiple items found. Enter the exact Item ID of the item to remove (Press ENTER to cancel): ");
                targetId = (Console.ReadLine()?.Trim() ?? "").Trim();
                if (string.IsNullOrEmpty(targetId))
                {
                    Console.WriteLine("Product removal cancelled.");
                    return;
                }

                //Check if the entered ID exists in the results
                if (DoesItemExist(targetId, results))
                {
                    break;
                }
                productToRemove = results.First(p => p.ItemID.Equals(targetId, StringComparison.OrdinalIgnoreCase));
            }
        }
        else
        {
            productToRemove = results[0];
        }

        Console.WriteLine($"You have selected to remove the product: ");
        DisplayProduct(productToRemove);

        if (ConsoleHelper.GetUserConfirmation("Are you sure you want to remove this product from the tracker?"))
        {
            _products.Remove(productToRemove);
            Console.WriteLine($"Product {productToRemove.ItemID} : {productToRemove.ItemDesc} removed from the tracker.");
        }
        else
        {
            Console.WriteLine("Product removal cancelled.");
        }
    }
}





