using System;

namespace AIS_StroitelnayaKompaniya
{
    public class Manager : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("\nМеню Менеджера:");
            Console.WriteLine("1. Отчет по команде");
            Console.WriteLine("2. Бюджет отдела");
            Console.WriteLine("0. Выйти");
        }
    }
}