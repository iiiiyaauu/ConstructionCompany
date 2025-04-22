using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public class EmployeeService
{
    private string _connectionString = "Data Source=company.db";

    public void Create(Employee employee)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
            INSERT INTO Employees (Name, Position, Salary)
            VALUES ($name, $position, $salary);
        ";
        command.Parameters.AddWithValue("$name", employee.Name);
        command.Parameters.AddWithValue("$position", employee.Position);
        command.Parameters.AddWithValue("$salary", employee.Salary);

        command.ExecuteNonQuery();
    }

    public List<Employee> GetAll()
    {
        var employees = new List<Employee>();

        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT Id, Name, Position, Salary FROM Employees;";

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            employees.Add(new Employee
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Position = reader.GetString(2),
                Salary = reader.GetDouble(3)
            });
        }

        return employees;
    }

    public void Update(Employee employee)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText =
        @"
            UPDATE Employees
            SET Name = $name, Position = $position, Salary = $salary
            WHERE Id = $id;
        ";
        command.Parameters.AddWithValue("$id", employee.Id);
        command.Parameters.AddWithValue("$name", employee.Name);
        command.Parameters.AddWithValue("$position", employee.Position);
        command.Parameters.AddWithValue("$salary", employee.Salary);

        command.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM Employees WHERE Id = $id;";
        command.Parameters.AddWithValue("$id", id);

        command.ExecuteNonQuery();
    }
}
