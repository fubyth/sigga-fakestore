namespace SiggaFakeStore.Data.Models;

using SiggaFakeStore.Models;

public class UserFavoriteProductsDAO
{
    public int UserId { get; set; }
    public string? FavoriteList { get; set; }

    public static UserFavoriteProductsDAO FromUserFavoriteProducts(UserFavoriteProducts orig)
    {
        UserFavoriteProductsDAO dest = new UserFavoriteProductsDAO();

        if (orig != null)
        {
            dest.UserId = orig.UserId;
            if (orig.FavoriteProducts != null)
            {
                dest.FavoriteList = String.Join(",", orig.FavoriteProducts);
            }
        }

        return dest;
    }

    public static UserFavoriteProducts ToUserFavoriteProducts(UserFavoriteProductsDAO orig)
    {
        UserFavoriteProducts dest = new UserFavoriteProducts();

        if (orig != null)
        {
            dest.UserId = orig.UserId;
            if (orig.FavoriteList != null)
            {
                if (orig.FavoriteList != null && orig.FavoriteList.Length > 0)
                {
                    dest.FavoriteProducts = orig.FavoriteList.Split(',').Select(x => int.Parse(x)).ToList();
                }
                else
                {
                    dest.FavoriteProducts = new List<int>();
                }
            }
        }

        return dest;
    }
}
