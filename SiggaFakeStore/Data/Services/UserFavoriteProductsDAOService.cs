namespace SiggaFakeStore.Data.Services;

using SiggaFakeStore.Data.Models;
using Microsoft.Data.Sqlite;


public class UserFavoriteProductsDAOService
{
    public bool Save(UserFavoriteProductsDAO item)
    {
        bool result = false;

        if (CheckIfExist(item))
        {
            result = UpdateItem(item);
        }
        else
        { 
            result = InsertItem(item);
        }
        
        return result;
    }

    private bool UpdateItem(UserFavoriteProductsDAO item)
    {
        int result = -1;

        using (var connection = new SqliteConnection(DataBaseInitializator.connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();


                command.CommandText =
                @"
                    UPDATE user_favorite
                    SET favorite_list = $list
                    WHERE user_id = $id;
                ";
                command.Parameters.AddWithValue("$id", item.UserId);
                command.Parameters.AddWithValue("$list", item.FavoriteList);
                result = command.ExecuteNonQuery();

        }

        return result > 0;
    }

    private bool InsertItem(UserFavoriteProductsDAO item)
    {
        bool result = true;

        using (var connection = new SqliteConnection(DataBaseInitializator.connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();


                command.CommandText =
                @"
                    INSERT INTO user_favorite (user_id, favorite_list)
                    VALUES ($id, $list)
                ";
                command.Parameters.AddWithValue("$id", item.UserId);
                command.Parameters.AddWithValue("$list", item.FavoriteList);
                command.ExecuteNonQuery();

        }

        return result;
    }

    public UserFavoriteProductsDAO? ListUserFavorites(int userId)
    {
        UserFavoriteProductsDAO? result = null;

        using (var connection = new SqliteConnection(DataBaseInitializator.connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    SELECT *
                    FROM user_favorite
                    WHERE user_id = $id
                ";
            command.Parameters.AddWithValue("$id", userId);

            using (var reader = command.ExecuteReader())
            {
                var record = reader.Read();
                if (record)
                {
                    result = new UserFavoriteProductsDAO();
                    result.UserId = reader.GetInt32(0);
                    result.FavoriteList = reader.GetString(1);
                }
            }
        }

        return result;
    }

    public bool CheckIfExist(UserFavoriteProductsDAO item)
    {
        bool result = false;
        using (var connection = new SqliteConnection(DataBaseInitializator.connectionString))
        {
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"
                    SELECT *
                    FROM user_favorite
                    WHERE user_id = $id
                ";
            command.Parameters.AddWithValue("$id", item.UserId);

            using (var reader = command.ExecuteReader())
            {
                result = reader.HasRows;
            }
        }
        return result;
    }
}
