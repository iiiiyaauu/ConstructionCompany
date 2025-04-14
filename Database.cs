using System;
using Microsoft.Data.Sqlite;

public static class Database
{
    private const string ConnectionString = "Data Source=company.db";

    public static void Initialize()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        // Пример: создаём таблицу, если не существует
        string createTableQuery = @"
            CREATE TABLE IF NOT EXISTS Employees (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Position TEXT NOT NULL
            );
        ";

        using var command = new SqliteCommand(createTableQuery, connection);
        command.ExecuteNonQuery();

        Console.WriteLine("База данных и таблица Employees готовы!");
    }

    public static void AddEmployee(string name, string position)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        string insertQuery = "INSERT INTO Employees (Name, Position) VALUES (@name, @position);";

        using var command = new SqliteCommand(insertQuery, connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@position", position);

        command.ExecuteNonQuery();

        Console.WriteLine("Сотрудник добавлен.");
    }

    public static void ListEmployees()
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        string selectQuery = "SELECT Id, Name, Position FROM Employees;";

        using var command = new SqliteCommand(selectQuery, connection);
        using var reader = command.ExecuteReader();

        Console.WriteLine("\nСписок сотрудников:");
        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string name = reader.GetString(1);
            string position = reader.GetString(2);

            Console.WriteLine($"[{id}] {name} - {position}");
        }
    }

    public static void UpdateEmployee(int id, string newName, string newPosition)
    {
    using var connection = new SqliteConnection(ConnectionString);
    connection.Open();

    string updateQuery = "UPDATE Employees SET Name = @name, Position = @position WHERE Id = @id;";

    using var command = new SqliteCommand(updateQuery, connection);
    command.Parameters.AddWithValue("@name", newName);
    command.Parameters.AddWithValue("@position", newPosition);
    command.Parameters.AddWithValue("@id", id);

    int rowsAffected = command.ExecuteNonQuery();

    if (rowsAffected > 0)
        Console.WriteLine("Сотрудник обновлён.");
    else
        Console.WriteLine("Сотрудник с таким ID не найден.");
    }

    public static void DeleteEmployee(int id)
    {
        using var connection = new SqliteConnection(ConnectionString);
        connection.Open();

        string deleteQuery = "DELETE FROM Employees WHERE Id = @id;";

        using var command = new SqliteCommand(deleteQuery, connection);
        command.Parameters.AddWithValue("@id", id);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0)
            Console.WriteLine("Сотрудник удалён.");
        else
            Console.WriteLine("Сотрудник с таким ID не найден.");
    }

}

