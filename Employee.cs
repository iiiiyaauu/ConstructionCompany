public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Position { get; set; }
    public double Salary { get; set; }

    // Виртуальный метод для переопределения в наследниках
    public virtual string GetInfo()
    {
        return $"{Id} | {Name} | {Position} | {Salary}";
    }
}

public class Manager : Employee
{
    public int TeamSize { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Team Size: {TeamSize}";
    }
}

public class Engineer : Employee
{
    public string Specialization { get; set; }

    public override string GetInfo()
    {
        return base.GetInfo() + $" | Specialization: {Specialization}";
    }
}
