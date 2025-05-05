using System;

namespace AIS_StroitelnayaKompaniya
{
    public class Engineer : User
    {
        public override void ShowMenu()
        {
            Console.WriteLine("\nМеню Инженера:");
            Console.WriteLine("1. Инженерные задачи");
            Console.WriteLine("2. Зарплата");
            Console.WriteLine("0. Выйти");
        }
    }
}