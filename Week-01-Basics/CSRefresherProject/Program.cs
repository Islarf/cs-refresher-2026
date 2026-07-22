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

while (string.IsNullOrEmpty(userName)) {
    Console.WriteLine("Please enter your employee name?: ");
    userName = Console.ReadLine() ?? "";
}


Console.WriteLine($"Hello, {userName}!");


while (isRunning)   {

    //MainMenu
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("1: Search for a product");
    Console.WriteLine("2: Add a product to the tracker");
    Console.WriteLine("3: Search for multiple products");
    Console.WriteLine("4: Remove a product from the tracker");
    Console.WriteLine("5: Exit the program");

    String MenuChoice = Console.ReadLine() ?? "0";
    switch(MenuChoice)
    {
        case "1":
            Console.WriteLine("You have chosen to search for a product.");
            break;
        case "2":
            Console.WriteLine("You have chosen to add a product to the tracker.");
            break;
        case "3":
            Console.WriteLine("You have chosen to search for multiple products.");
            break;
        case "4":
            Console.WriteLine("You have chosen to remove a product from the tracker.");
            break;
        case "5":
            Console.WriteLine("You have chosen to exit the program.");
            isRunning = false;
            break;
        default:
            Console.WriteLine("Invalid choice. Please try again.");
            break;
    }


    /*
    //Acquiring product information from the user
    Console.WriteLine("\n\n\n\n");
    Console.WriteLine("What is the Item ID?: ");
    string itemID = Console.ReadLine() ?? "0";

    Console.WriteLine("What is the ItemDescription?: ");
    string itemDesc = Console.ReadLine() ?? "N/A";

    Console.WriteLine("What is the Unit Cost? (€): ");
    decimal.TryParse(Console.ReadLine(), out decimal unitCost);

    //no if used. the TryParse outputs a 0 if empty anyway.
    Console.WriteLine("What is the quantity purchased?: ");
    int.TryParse(Console.ReadLine(), out int quantityPurchased);

    //Confirming the details entered are correct
    Console.WriteLine("========================================");
    Console.WriteLine("\n\n\n**" + userName + " is adding the following product to the tracker: **");
    Console.WriteLine($"Item ID: {itemID}");
    Console.WriteLine($"Item Description: {itemDesc}");
    Console.WriteLine($"Unit Cost : {unitCost:C2}");
    Console.WriteLine($"Quantity Purchased: {quantityPurchased}");
    Console.WriteLine($"Total Cost: {(unitCost * quantityPurchased):C2}");
    Console.WriteLine("========================================");

    //Acquiring confirmation to push the product to the tracker, and showing an appropriate message
    Console.WriteLine("\n\n\n");
    Console.WriteLine("Do you want to publish this product to the tracker? (Y/N): ");
    if (Console.ReadLine()?.ToUpper() == "Y") {
        Console.WriteLine("Product published to the tracker!");
    }
    else    {
        Console.WriteLine("Product not published to the tracker.");
    }
    

    //Loop clause; asking the user if they want to try again or enter another product
    if (Console.ReadLine()?.ToUpper() == "N")    {
        isRunning = false;
    }
    */
}

Console.WriteLine("\nThank you for using Expense Tracker. Goodbye!");
