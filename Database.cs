using System;
using System.Collections.Generic;
using System.Linq;

public static class Database
{
    public static List<Employee> Employees = new List<Employee>();
    private static int _nextId = 1;

    public static void Initialize()
    {
        // Инициализация с парой примеров
        Employees.Add(new Employee { Id = _nextId++, Name = "Иванов", Position = "Employee", Salary = 50000 });
        Employees.Add(new Employee { Id = _nextId++, Name = "Петров", Position = "Manager", Salary = 80000 });
    }

    public static void AddEmployee(Employee employee)
    {
        employee.Id = _nextId++;
        Employees.Add(employee);
        Console.WriteLine("Сотрудник добавлен.");
    }

    public static void ListEmployees()
    {
        Console.WriteLine("\n=== Список сотрудников ===");
        foreach (var emp in Employees)
        {
            Console.WriteLine($"{emp.Id}: {emp.Name}, {emp.Position}, Зарплата: {emp.Salary}");
        }
    }

    public static void UpdateEmployee(Employee updated)
    {
        var existing = Employees.FirstOrDefault(e => e.Id == updated.Id);
        if (existing != null)
        {
            existing.Name = updated.Name;
            existing.Position = updated.Position;
            existing.Salary = updated.Salary;
            Console.WriteLine("Сотрудник обновлён.");
        }
        else
        {
            Console.WriteLine("Сотрудник не найден.");
        }
    }

    public static void DeleteEmployee(int id)
    {
        var emp = Employees.FirstOrDefault(e => e.Id == id);
        if (emp != null)
        {
            Employees.Remove(emp);
            Console.WriteLine("Сотрудник удалён.");
        }
        else
        {
            Console.WriteLine("Сотрудник не найден.");
        }
    }

    public static Employee GetEmployeeById(int id)
    {
        return Employees.FirstOrDefault(e => e.Id == id);
    }
}
