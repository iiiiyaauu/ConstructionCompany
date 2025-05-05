using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AIS_StroitelnayaKompaniya
{
    public static class Database
    {
        private static List<Employee> employees = new List<Employee>();
        private const string FilePath = "users.txt";

        public static void Initialize()
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
                return;
            }

            var lines = File.ReadAllLines(FilePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    employees.Add(new Employee
                    {
                        Username = parts[0],
                        Role = parts[1],
                        Salary = double.Parse(parts[2])
                    });
                }
            }
        }

        public static double GetSalary(string username)
        {
            var emp = employees.FirstOrDefault(e => e.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            return emp?.Salary ?? 0;
        }

        public static List<Employee> GetAllEmployees() => employees;

        public static void SaveAll()
        {
            var lines = employees.Select(e => $"{e.Username},{e.Role},{e.Salary}");
            File.WriteAllLines(FilePath, lines);
        }

        public static bool UpdateSalary(string username, double newSalary)
        {
            var emp = employees.FirstOrDefault(e => e.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
            if (emp != null)
            {
                emp.Salary = newSalary;
                SaveAll();
                return true;
            }
            return false;
        }
    }
}
