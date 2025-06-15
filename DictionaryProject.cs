using System;
using System.Collections.Generic;

// Create a dictionary where key is a string and value is a list of strings to store multiple values for each string 
Dictionary<string, List<string>> newDict = new Dictionary<string, List<string>>();

bool continueProgram = true;
// Loop to prompt user for input unless they quit
while (continueProgram)
{
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Populate the Dictionary");
    Console.WriteLine("2. Display Dictionary");
    Console.WriteLine("3. Remove a Key");
    Console.WriteLine("4. Add a New Key and Value");
    Console.WriteLine("5. Add a Value to an Existing Key");
    Console.WriteLine("6. Sort the Keys");
    Console.WriteLine("0. Exit");

    //Reads input
    string choice = Console.ReadLine();

    // a switch statement that will handle that input
    switch (choice)
    {
        // Based on input these will call a method of users choice
        case "1":
            PopulateDictionary(newDict);
            break;
        case "2":
            DisplayDictionary(newDict);
            break;
        case "3":
            RemoveKey(newDict);
            break;
        case "4":
            AddNewKey(newDict);
            break;
        case "5":
            AddValuetoExistingKey(newDict);
            break;
        case "6":
            SortAndDisplayKeys(newDict);
            break;
        case "0":
            continueProgram = false;
            break;
        default:
            Console.WriteLine("Invalid Choice");
            break;


    }

}

// Defines the method populate dictionary 
static void PopulateDictionary(Dictionary<string, List<string>> dict)
{
    dict["Orange"] = new List<string> { "Fruit" }; //adding new entrys to dict
    dict["Spinach"] = new List<string> { "Vegetable" };
    dict["Dog"] = new List<string> { "Animal" };
    Console.WriteLine("Dictionary populated"); //Confirmation message for user
}

//Same thing just defines the method display dict
static void DisplayDictionary(Dictionary<string, List<string>> dict)
{
    foreach (var keyValuepair in dict) //loops over each item in the dictionary
    {
        Console.WriteLine($"{keyValuepair.Key}: {string.Join(", ", keyValuepair.Value)}");
        // gives the current key and the list of strings assigned to the key, then converts it to single string separted by commas
    }

}
