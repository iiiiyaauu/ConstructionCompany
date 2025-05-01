using System;
using System.Collections.Generic;
using System.Linq;

namespace AIS_StroitelnayaKompaniya
{
    public static class EmployeeService
    {
        private static List<Employee> employees = new List<Employee>();
        private static int nextId = 1;

        public static void AddEmployee(Employee employee)
        {
            employee.Id = nextId++;
            employees.Add(employee);
        }

        public static void UpdateEmployee(Employee updatedEmployee)
        {
            var existing = employees.FirstOrDefault(e => e.Id == updatedEmployee.Id);
            if (existing != null)
            {
                existing.Name = updatedEmployee.Name;
                existing.Position = updatedEmployee.Position;
                existing.Salary = updatedEmployee.Salary;

                if (existing is Manager manager && updatedEmployee is Manager updatedManager)
                {
                    manager.TeamSize = updatedManager.TeamSize;
                }
                else if (existing is Engineer engineer && updatedEmployee is Engineer updatedEngineer)
                {
                    engineer.Specialization = updatedEngineer.Specialization;
                }
            }
        }

        public static void DeleteEmployee(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
        }

        public static void ListEmployees()
        {
            foreach (var employee in employees)
            {
                Console.WriteLine($"ID: {employee.Id} | Имя: {employee.Name} | Должность: {employee.Position} | Зарплата: {employee.Salary}");

                if (employee is Manager manager)
                {
                    Console.WriteLine($"  Размер команды: {manager.TeamSize}");
                }
                else if (employee is Engineer engineer)
                {
                    Console.WriteLine($"  Специализация: {engineer.Specialization}");
                }
            }
        }

        public static double CalculateTotalBudget()
        {
            return employees.Sum(e => e.Salary);
        }

        public static Employee GetEmployeeById(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
