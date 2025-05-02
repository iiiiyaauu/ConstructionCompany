using AIS_StroitelnayaKompaniya;

class Program
{
    static void Main()
    {
        Database.Initialize();

        Console.WriteLine("Введите имя пользователя: ");
        string username = Console.ReadLine();

        Console.WriteLine("Введите роль (Director / Worker / Marketing): ");
        string role = Console.ReadLine();

        User currentUser = role switch
        {
            "Director" => new Director { Username = username },
            "Worker" => new Worker { Username = username },
            "Marketing" => new Marketing { Username = username },
            _ => null
        };

        if (currentUser == null)
        {
            Console.WriteLine("Неверная роль.");
            return;
        }

        while (true)
        {
            currentUser.ShowMenu();
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            if (role == "Director")
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Общий бюджет: {BudgetManager.CalculateTotalBudget()}");
                        break;
                    case "2":
                        Console.Write("Введите ID сотрудника: ");
                        int id = int.Parse(Console.ReadLine());
                        Console.Write("Введите новую зарплату: ");
                        double salary = double.Parse(Console.ReadLine());
                        BudgetManager.ChangeSalary(id, salary);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
            else if (role == "Worker")
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Ваша зарплата: (не реализовано — зависит от логики авторизации)");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
            else if (role == "Marketing")
            {
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Бюджет на рекламу: (заглушка)");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный ввод.");
                        break;
                }
            }
        }
    }
}
