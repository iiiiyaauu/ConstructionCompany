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
            Console.WriteLine("\nМеню Директора:");
            Console.WriteLine("1. Показать список сотрудников");
            Console.WriteLine("2. Показать общий бюджет");
            Console.WriteLine("3. Изменить зарплату сотрудника");
            Console.WriteLine("0. Выйти");
        }
    }

    public class Worker : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("\nМеню Рабочего:");
            Console.WriteLine("1. Мои задачи");
            Console.WriteLine("2. Зарплата");
            Console.WriteLine("0. Выйти");
        }
    }
}