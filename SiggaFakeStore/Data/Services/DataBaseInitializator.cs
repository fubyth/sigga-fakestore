namespace SiggaFakeStore.Data.Services;

using Microsoft.Data.Sqlite;

public class DataBaseInitializator
{
    public static string connectionString = "Data Source=fakeStore.db";

    public static void InitializeDB()
    {

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
            command.ExecuteNonQuery();
        }
    }
}
