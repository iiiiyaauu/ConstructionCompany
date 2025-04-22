using System;
using AIS_StroitelnayaKompaniya;

class Program
{
    static void Main()
    {
        Database.Initialize();

        Console.WriteLine("Выберите роль:");
        Console.WriteLine("1. Директор");
        Console.WriteLine("2. Админ-панель сотрудников");
        Console.Write("Ваш выбор: ");
        string roleChoice = Console.ReadLine();

        if (roleChoice == "1")
        {
            DirectorMenu();
            return;
        }

        while (true)
        {
            Console.WriteLine("\n==== МЕНЮ ====");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Показать всех сотрудников");
            Console.WriteLine("3. Обновить сотрудника");
            Console.WriteLine("4. Удалить сотрудника");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddEmployeeMenu();
                    break;
                case "2":
                    Database.ListEmployees();
                    break;
                case "3":
                    UpdateEmployeeMenu();
                    break;
                case "4":
                    DeleteEmployeeMenu();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void DirectorMenu()
    {
        while (true)
        {
            Console.WriteLine("\n== Меню Директора ==");
            var director = new Director();
            director.ShowMenu();
            Console.Write("Выбор: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Database.ListEmployees();
                    break;
                case "2":
                    double total = BudgetManager.CalculateTotalBudget();
                    Console.WriteLine($"Общий бюджет на зарплаты: {total} руб.");
                    break;
                case "3":
                    Console.Write("ID сотрудника: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Новая зарплата: ");
                    double newSalary = double.Parse(Console.ReadLine());
                    BudgetManager.ChangeSalary(id, newSalary);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static void AddEmployeeMenu()
    {
        Console.Write("Тип сотрудника (Employee / Manager / Engineer): ");
        string type = Console.ReadLine();

        Console.Write("Имя: ");
        string name = Console.ReadLine();

        Console.Write("Зарплата: ");
        double salary = double.Parse(Console.ReadLine());

        if (type == "Manager")
        {
            Console.Write("Размер команды: ");
            int teamSize = int.Parse(Console.ReadLine());
            var manager = new Manager { Name = name, Position = "Manager", Salary = salary, TeamSize = teamSize };
            Database.AddEmployee(manager);
        }
        else if (type == "Engineer")
        {
            Console.Write("Специализация: ");
            string spec = Console.ReadLine();
            var engineer = new Engineer { Name = name, Position = "Engineer", Salary = salary, Specialization = spec };
            Database.AddEmployee(engineer);
        }
        else
        {
            var employee = new Employee { Name = name, Position = "Employee", Salary = salary };
            Database.AddEmployee(employee);
        }
    }

    static void UpdateEmployeeMenu()
    {
        Console.Write("ID сотрудника для обновления: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Новое имя: ");
        string name = Console.ReadLine();

        Console.Write("Новая зарплата: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Новая должность (Employee / Manager / Engineer): ");
        string position = Console.ReadLine();

        if (position == "Manager")
        {
            Console.Write("Новый размер команды: ");
            int teamSize = int.Parse(Console.ReadLine());
            var manager = new Manager { Id = id, Name = name, Position = position, Salary = salary, TeamSize = teamSize };
            Database.UpdateEmployee(manager);
        }
        else if (position == "Engineer")
        {
            Console.Write("Новая специализация: ");
            string spec = Console.ReadLine();
            var engineer = new Engineer { Id = id, Name = name, Position = position, Salary = salary, Specialization = spec };
            Database.UpdateEmployee(engineer);
        }
        else
        {
            var emp = new Employee { Id = id, Name = name, Position = position, Salary = salary };
            Database.UpdateEmployee(emp);
        }
    }

    static void DeleteEmployeeMenu()
    {
        Console.Write("ID сотрудника для удаления: ");
        int id = int.Parse(Console.ReadLine());
        Database.DeleteEmployee(id);
    }
}