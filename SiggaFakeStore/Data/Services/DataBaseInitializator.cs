namespace SiggaFakeStore.Data.Services;

using Microsoft.Data.Sqlite;

public class DataBaseInitializator
{
    public static string connectionString = "Data Source=fakeStore.db";

    public static void InitializeDB()
    {

        Console.WriteLine("BaseDirectory: " + AppContext.BaseDirectory);

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    CREATE TABLE IF NOT EXISTS user_favorite (
                        user_id INTEGER NOT NULL PRIMARY KEY,
                        favorite_list TEXT NOT NULL
                    );
                ";

            // INSERT INTO user
            // VALUES (1, 'Brice'),
            //        (2, 'Alexander'),
            //        (3, 'Nate');

            command.ExecuteNonQuery();
        }
    }
}
