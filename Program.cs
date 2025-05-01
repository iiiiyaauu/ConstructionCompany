using System;
using AIS_StroitelnayaKompaniya;

class Program
{
    static void Main()
    {
        Database.Initialize();

        while (true)
        {
            Console.WriteLine("\n==== МЕНЮ ====");
            Console.WriteLine("1. Показать всех сотрудников");
            Console.WriteLine("2. Показать общий бюджет");
            Console.WriteLine("3. Изменить зарплату сотрудника");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Database.ListEmployees();
                    break;

                case "2":
                    double budget = BudgetManager.CalculateTotalBudget();
                    Console.WriteLine($"Общий бюджет на зарплаты: {budget} руб.");
                    break;

                case "3":
                    Console.Write("Введите ID сотрудника: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        Console.Write("Введите новую зарплату: ");
                        if (double.TryParse(Console.ReadLine(), out double newSalary))
                        {
                            BudgetManager.ChangeSalary(id, newSalary);
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: введите корректную зарплату.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите корректный ID.");
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }
    }
}
