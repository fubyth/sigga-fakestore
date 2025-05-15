namespace SiggaFakeStore.Services;

using SiggaFakeStore.Models;
using SiggaFakeStore.Data.Models;
using SiggaFakeStore.Data.Services;

public class UserFavoriteProductsManagement
{
    private static UserFavoriteProducts user1Favorites = new UserFavoriteProducts();
    private static UserFavoriteProducts user2Favorites = new UserFavoriteProducts();

    UserFavoriteProductsDAOService userFavoriteProductsDAOService = new UserFavoriteProductsDAOService();

    public void AddFavorite(int id, int user)
    {
        UserFavoriteProducts userFavorites = LoadFavorites(user);
        userFavorites.AddFavoriteProduct(id);
        userFavoriteProductsDAOService.Save(UserFavoriteProductsDAO.FromUserFavoriteProducts(userFavorites));
    }

    public UserFavoriteProducts LoadFavorites(int user)
    {
        UserFavoriteProductsDAO? userFavoriteProductsDAO = userFavoriteProductsDAOService.ListUserFavorites(user);
        UserFavoriteProducts userFavorites;

        if (userFavoriteProductsDAO != null)
        {
            userFavorites = UserFavoriteProductsDAO.ToUserFavoriteProducts(userFavoriteProductsDAO);
        }
        else
        {
            userFavorites = new UserFavoriteProducts();
            userFavorites.UserId = user;
        }

        return userFavorites;
    }

    public void RemoveFavorite(int id, int user)
    {
        UserFavoriteProducts userFavorites = LoadFavorites(user);

        userFavorites.RemoveFavoriteProduct(id);

        userFavoriteProductsDAOService.Save(UserFavoriteProductsDAO.FromUserFavoriteProducts(userFavorites));
    }
}
