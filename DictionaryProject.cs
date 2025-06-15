using System;
using System.Collections.Generic;

// Create a dictionary where key is a string and value is a list of strings to store multiple values for each string 
Dictionary<string, List<string>> newDict = new Dictionary<string, List<string>>();

bool continueProgram = true;
// Loop to prompt user for input unless they quit
while (continueProgram)
{
    Console.WriteLine(); // Print a blank line for better readability
    Console.WriteLine("Choose an option:");
    Console.WriteLine("1. Populate the Dictionary");
    Console.WriteLine("2. Display Dictionary");
    Console.WriteLine("3. Remove a Key");
    Console.WriteLine("4. Add a New Key and Value");
    Console.WriteLine("5. Add a Value to an Existing Key");
    Console.WriteLine("6. Sort the Keys");
    Console.WriteLine("0. Exit");

    // Read Input
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
            AddValueToExistingKey(newDict);
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

// Defines the method to populate the dictionary 
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
    Console.WriteLine(); // Print a blank line for better readability

    if (dict.Count == 0)
    {
        Console.WriteLine("Dictionary is empty.");
        return;
    }

    foreach (var keyValuePair in dict) // Loops over each item in the dictionary
    {
        Console.WriteLine($"{keyValuePair.Key}: {string.Join(", ", keyValuePair.Value)}");
        // Gives the current key and the list of strings assigned to the key, then converts it to single string separated by commas
    }
}

// Defines the method to remove a key
static void RemoveKey(Dictionary<string, List<string>> dict)
{
    Console.WriteLine("Enter the key to remove:");
    string key = Console.ReadLine();

    if (dict.ContainsKey(key))
    {
        dict.Remove(key);
        Console.WriteLine($"Key '{key}' removed successfully.");
    }
    else
    {
        Console.WriteLine($"Key '{key}' not found in the dictionary.");
    }
}

// Defines the method to add a new key and value
static void AddNewKey(Dictionary<string, List<string>> dict)
{
    Console.WriteLine("Enter the new key:");
    string key = Console.ReadLine();
    
    if (dict.ContainsKey(key))
    {
        Console.WriteLine($"Key '{key}' already exists. Use option 5 to add a value to an existing key.");
        return;
    }
    
    Console.WriteLine("Enter the value for the new key:");
    string value = Console.ReadLine();
    
    dict[key] = new List<string> { value };
    Console.WriteLine($"Key '{key}' with value '{value}' added successfully.");
}

// Add value to existing key
static void AddValueToExistingKey(Dictionary<string, List<string>> dict)
{
    Console.WriteLine("Enter the existing key: ");
    string key = Console.ReadLine();

    // Check if the key exists in the dictionary
    if (!dict.TryGetValue(key, out List<string> values))
    {
        Console.WriteLine($"Key '{key}' not found.");
        return;
    }

    Console.WriteLine("Enter the additional value to add:");
    string value = Console.ReadLine();
    // Check if the value already exists in the list for that key
    if (values.Contains(value))
    {
        Console.WriteLine($"Value '{value}' already exists.");
    }
    else
    {
        values.Add(value);
        Console.WriteLine($"Added '{value}' to '{key}'");
    }
}

// Sort and display keys
static void SortAndDisplayKeys(Dictionary<string, List<string>> dict)
{
    var sortedKeys = dict.Keys.OrderBy(k => k).ToList();
    Console.WriteLine("Keys have been sorted.");
    foreach (var key in sortedKeys)
    {
        Console.WriteLine($"{key}: {string.Join(", ", dict[key])}");
    }
}
