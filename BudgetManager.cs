using System.Linq;

namespace AIS_StroitelnayaKompaniya
{
    public static class BudgetManager
    {
        public static double CalculateTotalBudget()
        {
            return Database.GetAllEmployees().Sum(e => e.Salary);
        }

        public static bool ChangeSalary(string username, double newSalary)
        {
            return Database.UpdateSalary(username, newSalary);
        }
    }
}
