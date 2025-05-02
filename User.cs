// === File: User.cs ===
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
            Console.WriteLine("2. Показать бюджет");
            Console.WriteLine("3. Выйти");
        }
    }

    public class Worker : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("\nМеню Сотрудника:");
            Console.WriteLine("1. Мои задачи");
            Console.WriteLine("2. Зарплата");
            Console.WriteLine("3. Выйти");
        }
    }

    public class Marketing : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("\nМеню Маркетолога:");
            Console.WriteLine("1. Зоны охвата");
            Console.WriteLine("2. Бюджет рекламы");
            Console.WriteLine("3. Выйти");
        }
    }
}
