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


void NameEntry()
{
    while (string.IsNullOrEmpty(userName))
    {
        Console.WriteLine("Please enter your employee name?: ");
        userName = Console.ReadLine() ?? "";
    }
}


void RunMenu() {

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

}

Console.WriteLine("\nThank you for using Expense Tracker. Goodbye!");
