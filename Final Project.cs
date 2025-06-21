// bring in system namespace
using stystem;

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

    public int GetContractNumber() // same idea returns the number
    {
        return contractorNumber;
    }

    public void SetContractNumber(int number) // changes the number 
    {
        contractorNumber = number;
    }

    public DateTime GetStartDate() // returns the start date
    {
        return startDate;
    }

    public void SetStartDate(DateTime date) // changes the start date 
    {
        startDate = date;
    }

}