class Employee
{
    private string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Employee: {name}, Salary: {CalcSalary()}");        
    }
            
    protected virtual double CalcSalary()
    {
        return 0;
    }
}

class FullTimeEmployee : Employee
{
    private double monthlySalary;

    public FullTimeEmployee(string name, double monthlySalary) : base(name)
    {
        this.monthlySalary = monthlySalary;
    }

    protected override double CalcSalary()
    {
        return monthlySalary;
    }
}

class PartTimeEmployee : Employee
{
    private double hourlyRate;
    private int hoursWorked;

    public PartTimeEmployee(string name, double hourlyRate, int hoursWorked) : base(name)
    {
        this.hourlyRate = hourlyRate;
        this.hoursWorked = hoursWorked;
    }

    protected override double CalcSalary()
    {
        return hourlyRate * hoursWorked;
    }
}   

class Program
{
    static void Main(string[] args)
    {
        Employee fullTimeEmp = new FullTimeEmployee("John Doe", 3000);
        Employee partTimeEmp = new PartTimeEmployee("Jane Smith", 15, 120);

        fullTimeEmp.ShowInfo();
        partTimeEmp.ShowInfo();
    }
}