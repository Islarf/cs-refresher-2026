// Week 1 Project :: Expense and Currency Tracker

//so the print later can output the euro symbol
Console.OutputEncoding = System.Text.Encoding.UTF8;


//Variables
string userName = string.Empty;
bool isRunning = true;

//Introduction
Console.WriteLine("==================================");
Console.WriteLine("== Expense and Currency Tracker ==");
Console.WriteLine("==================================");
Console.WriteLine("\n\n\n\n");

while (string.IsNullOrEmpty(userName)) {
    Console.WriteLine("Please enter your employee name?: ");
    userName = Console.ReadLine() ?? "";
}


Console.WriteLine($"Hello, {userName}!");


while (isRunning)   {
    //Acquiring product information from the user
    Console.WriteLine("\n\n\n\n");
    Console.WriteLine("What is the Item ID?: ");
    string itemID = Console.ReadLine() ?? "0";

    Console.WriteLine("What is the ItemDescription?: ");
    string itemDesc = Console.ReadLine() ?? "N/A";

    //If method to check if the user input is a valid decimal, and if not, set the unit cost to 0.00. this is entirely unnecessary, but doing it anyway.
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
    Console.WriteLine("Do you want to try again or enter another product? (Y/N): ");
    if (Console.ReadLine()?.ToUpper() == "N")    {
        isRunning = false;
    }

}

Console.WriteLine("\nThank you for using Expense Tracker. Goodbye!");
