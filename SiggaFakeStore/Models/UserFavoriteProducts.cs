namespace SiggaFakeStore.Models;

public class UserFavoriteProducts
{
    public int UserId { get; set; }
    public List<int> FavoriteProducts { get; set; }

    public UserFavoriteProducts()
    { 
        FavoriteProducts = new List<int>();
    }

    public void AddFavoriteProduct(int id)
    {
        FavoriteProducts.Add(id);
    }

    public void RemoveFavoriteProduct(int id)
    {
        FavoriteProducts.Remove(id);
    }
}
