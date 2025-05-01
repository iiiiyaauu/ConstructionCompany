using System;
using System.Linq;

namespace AIS_StroitelnayaKompaniya
{
    public static class BudgetManager
    {
        public static double CalculateTotalBudget()
        {
            var employees = Database.GetAllEmployees();
            return employees.Sum(e => e.Salary);
        }

        public static void ChangeSalary(int id, double newSalary)
        {
            var employee = Database.GetEmployeeById(id);
            if (employee != null)
            {
                employee.Salary = newSalary;
                Console.WriteLine($"Зарплата сотрудника {employee.Name} изменена на {newSalary}.");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }
    }
}
