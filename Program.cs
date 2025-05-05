using System;
using AIS_StroitelnayaKompaniya;

class Program
{
    static void Main()
    {
        Database.Initialize();

        Console.Write("Введите имя пользователя: ");
        string username = Console.ReadLine();

        Console.Write("Введите роль (Director / Manager / Engineer / Worker): ");
        string role = Console.ReadLine();

        User currentUser = CreateUserByRole(username, role);

        if (currentUser == null)
        {
            Console.WriteLine("Неизвестная роль.");
            return;
        }

        while (true)
        {
            currentUser.ShowMenu();
            Console.Write("Выберите действие: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    if (currentUser is Director || currentUser is Manager)
                    {
                        double budget = BudgetManager.CalculateTotalBudget();
                        Console.WriteLine($"Общий бюджет на зарплаты: {budget} руб.");
                    }
                    else
                    {
                        Console.WriteLine($"Ваша зарплата: {Database.GetSalary(currentUser.Username)} руб.");
                    }
                    break;

                case "2":
                    if (currentUser is Director || currentUser is Manager)
                    {
                        Console.Write("Введите имя сотрудника: ");
                        string name = Console.ReadLine();

                        Console.Write("Введите новую зарплату: ");
                        if (double.TryParse(Console.ReadLine(), out double newSalary))
                        {
                            bool updated = BudgetManager.ChangeSalary(name, newSalary);
                            Console.WriteLine(updated ? "Зарплата обновлена." : "Сотрудник не найден.");
                        }
                        else
                        {
                            Console.WriteLine("Некорректная сумма.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("У вас нет прав на изменение зарплаты.");
                    }
                    break;

                case "3":
                    Console.WriteLine("Выход...");
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }

    static User CreateUserByRole(string username, string role)
    {
        return role.ToLower() switch
        {
            "director" => new Director { Username = username },
            "manager" => new Manager { Username = username },
            "engineer" => new Engineer { Username = username },
            "worker" => new Worker { Username = username },
            _ => null
        };
    }
}
