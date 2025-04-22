using System;

namespace AIS_StroitelnayaKompaniya
{
    public abstract class User
    {
        public string Username { get; set; }
        public abstract void ShowMenu();
    }

    public class Director : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("Меню Директора:");
            Console.WriteLine("1. Показать список сотрудников");
            Console.WriteLine("2. Показать бюджет");
            Console.WriteLine("3. Выйти");
        }
    }

    public class Worker : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("Меню Сотрудника:");
            Console.WriteLine("1. Мои задачи");
            Console.WriteLine("2. Зарплата");
            Console.WriteLine("3. Выйти");
        }
    }

    public class Marketing : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("Меню Маркетолога:");
            Console.WriteLine("1. Зоны охвата");
            Console.WriteLine("2. Бюджет рекламы");
            Console.WriteLine("3. Выйти");
        }
    }

    public class HR : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("Меню HR:");
            Console.WriteLine("1. Просмотр сотрудников");
            Console.WriteLine("2. Выйти");
        }
    }

    public class Manager : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("Меню Менеджера:");
            Console.WriteLine("1. Просмотр задач");
            Console.WriteLine("2. Выйти");
        }
    }

    public class SaleManager : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("Меню Агента по продажам:");
            Console.WriteLine("1. Просмотр клиентов");
            Console.WriteLine("2. Выйти");
        }
    }
}
