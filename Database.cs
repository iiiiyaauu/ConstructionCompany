using System.Collections.Generic;
using System.Linq;

namespace AIS_StroitelnayaKompaniya
{
    public static class Database
    {
        private static List<Employee> employees = new List<Employee>();

        public static void Initialize()
        {
            employees.Add(new Employee { Id = 1, Name = "Иванов", Position = "Engineer", Salary = 50000 });
            employees.Add(new Employee { Id = 2, Name = "Петров", Position = "Manager", Salary = 60000 });
        }

        public static List<Employee> GetAllEmployees() => employees;

        public static Employee GetEmployeeById(int id) =>
            employees.FirstOrDefault(e => e.Id == id);

        public static void UpdateEmployee(Employee emp)
        {
            var existing = GetEmployeeById(emp.Id);
            if (existing != null)
            {
                existing.Name = emp.Name;
                existing.Position = emp.Position;
                existing.Salary = emp.Salary;
            }
        }
    }
}
