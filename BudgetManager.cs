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
            var emp = Database.GetEmployeeById(id);
            if (emp != null)
            {
                emp.Salary = newSalary;
                Database.UpdateEmployee(emp);
                Console.WriteLine("Зарплата обновлена.");
            }
            else
            {
                Console.WriteLine("Сотрудник не найден.");
            }
        }
    }
}
