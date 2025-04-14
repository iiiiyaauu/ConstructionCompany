class Program
{
    static void Main()
    {
        Database.Initialize();

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
                    Console.Write("Имя: ");
                    string name = Console.ReadLine();
                    Console.Write("Должность: ");
                    string position = Console.ReadLine();
                    Database.AddEmployee(name, position);
                    break;

                case "2":
                    Database.ListEmployees();
                    break;

                case "3":
                    Console.Write("ID сотрудника: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Новое имя: ");
                    string newName = Console.ReadLine();
                    Console.Write("Новая должность: ");
                    string newPosition = Console.ReadLine();
                    Database.UpdateEmployee(updateId, newName, newPosition);
                    break;

                case "4":
                    Console.Write("ID сотрудника: ");
                    int deleteId = int.Parse(Console.ReadLine());
                    Database.DeleteEmployee(deleteId);
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
