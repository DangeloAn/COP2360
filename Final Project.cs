// bring in system namespace
using System;
using System.Collections.Generic;

// defined a class named contractor and made it public so it can accessed in other parts
public class Contractor
{
    private string contractorName; //holds the contractor name
    private int contractorNumber; //holds the ID number of contractor
    private DateTime startDate; // stores when the contractor started 

    public Contractor(string name, int number, DateTime start) //constructor that runs when you create a new contractor object
    {
        contractorName = name;
        contractorNumber = number;
        startDate = start;
    }

    public Contractor() // constructor that lets you create a object without adding details
    {
        contractorName = "Unknown";
        contractorNumber = 0;
        startDate = DateTime.Now;
    }

    public string GetName() // returns the contractor name 
    {
        return contractorName;
    }

    public void SetName(string name) // changes the contractor's name 
    {
        contractorName = name;
    }

    public int GetContractNumber() // same idea just for the contractor number
    {
        return contractorNumber;
    }

    public void SetContractNumber(int number)  
    {
        contractorNumber = number;
    }

    public DateTime GetStartDate() // same idea for the start date
    {
        return startDate;
    }

    public void SetStartDate(DateTime date) 
    {
        startDate = date;
    }
}

// Subcontractor class derived from Contractor
public class Subcontractor : Contractor
{
    private int shift; // 1 for day shift, 2 for night shift
    private double hourlyPayRate; // hourly pay rate for the subcontractor

    // Parameterized constructor
    public Subcontractor(string name, int number, DateTime start, int shift, double hourlyPayRate)
        : base(name, number, start)
    {
        this.shift = shift;
        this.hourlyPayRate = hourlyPayRate;
    }

    // Default constructor
    public Subcontractor() : base()
    {
        shift = 1; // Default to day shift
        hourlyPayRate = 0.0;
    }

    // Accessor methods
    public int GetShift()
    {
        return shift;
    }

    public double GetHourlyPayRate()
    {
        return hourlyPayRate;
    }

    // Mutator methods
    public void SetShift(int shift)
    {
        this.shift = shift;
    }

    public void SetHourlyPayRate(double rate)
    {
        hourlyPayRate = rate;
    }

    // Calculate pay with shift differential
    public float CalculateWeeklyPay(float hoursWorked)
    {
        double pay = hoursWorked * hourlyPayRate;

        // Apply 3% shift differential for night shifts
        if (shift == 2)
        {
            pay *= 1.03; // Increase pay by 3%
        }
        return (float)pay; // return the pay as a float
    }
}

// Program class to demonstrate the classes
class SubcontractorDemo
{
    static void Main()
    {
        // List to store multiple subcontractor objects
        List<Subcontractor> subcontractors = new List<Subcontractor>();
        string continueInput;

        do
        {
            // Prompt user for subcontractor details
            Console.WriteLine("\nEnter subcontractor details:");
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Contractor Number: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Shift (1 = day, 2 = night): ");
            int shift = int.Parse(Console.ReadLine());

            Console.Write("Hourly Pay Rate: ");
            double hourlyPayRate = double.Parse(Console.ReadLine());

            // Create a new Subcontractor object
            Subcontractor subcontractor = new Subcontractor(name, number, startDate, shift, hourlyPayRate);
            subcontractors.Add(subcontractor);

            // Display the created subcontractor details
            Console.WriteLine($"\nSubcontractor created:");
            Console.WriteLine($"Name: {subcontractor.GetName()}");
            Console.WriteLine($"Contractor Number: {subcontractor.GetContractNumber()}");
            Console.WriteLine($"Start Date: {subcontractor.GetStartDate():yyyy-MM-dd}");
            Console.WriteLine($"Shift: {subcontractor.GetShift()} (1 = day, 2 = night)");
            Console.WriteLine($"Hourly Pay Rate: ${subcontractor.GetHourlyPayRate():F2}");

            // Calculate and display pay
            Console.Write("\nEnter hours worked this week: ");
            float hoursWorked = float.Parse(Console.ReadLine());
            float weeklyPay = subcontractor.CalculateWeeklyPay(hoursWorked);
            Console.WriteLine($"Weekly Pay: ${weeklyPay:F2}");

            // Ask if user wants to add another subcontractor
            Console.Write("\nAdd another subcontractor? (yes/no): ");
            continueInput = Console.ReadLine().ToLower();

        } while (continueInput == "yes");

        // Display all created subcontractors
        Console.WriteLine("\nAll Subcontractors:");
        foreach (var sub in subcontractors)
        {
            Console.WriteLine($"Name: {sub.GetName()}, Number: {sub.GetContractNumber()}, Shift: {sub.GetShift()}");
        }
    }
}
