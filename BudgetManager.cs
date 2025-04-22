using System;
using System.Linq;

public static class BudgetManager
{
    public static double CalculateTotalBudget()
    {
        return Database.Employees.Sum(e => e.Salary);
    }

    public static void ChangeSalary(int employeeId, double newSalary)
    {
        var employee = Database.GetEmployeeById(employeeId);
        if (employee != null)
        {
            employee.Salary = newSalary;
            Console.WriteLine($"Зарплата сотрудника с ID {employeeId} изменена на {newSalary}");
        }
        else
        {
            Console.WriteLine("Сотрудник не найден.");
        }
    }
}
