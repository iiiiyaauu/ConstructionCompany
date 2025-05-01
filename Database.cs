using System;
using System.Collections.Generic;
using System.Linq;

namespace AIS_StroitelnayaKompaniya
{
    public static class Database
    {
        private static List<Employee> employees = new List<Employee>();
        private static int nextId = 1;

        public static void Initialize()
        {
            // Пример начальных данных
            employees.Add(new Employee { Id = nextId++, Name = "Иванов", Position = "Engineer", Salary = 50000 });
            employees.Add(new Employee { Id = nextId++, Name = "Петров", Position = "Manager", Salary = 60000 });
        }

        public static List<Employee> GetAllEmployees()
        {
            return employees;
        }

        public static Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public static void AddEmployee(Employee employee)
        {
            employee.Id = nextId++;
            employees.Add(employee);
        }

        public static void UpdateEmployee(Employee updatedEmployee)
        {
            var existing = GetEmployeeById(updatedEmployee.Id);
            if (existing != null)
            {
                existing.Name = updatedEmployee.Name;
                existing.Position = updatedEmployee.Position;
                existing.Salary = updatedEmployee.Salary;
            }
        }

        public static void DeleteEmployee(int id)
        {
            var employee = GetEmployeeById(id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        public static void ListEmployees()
        {
            Console.WriteLine("\nСписок сотрудников:");
            foreach (var emp in employees)
            {
                Console.WriteLine($"ID: {emp.Id}, Имя: {emp.Name}, Должность: {emp.Position}, Зарплата: {emp.Salary}");
            }
        }
    }
}
