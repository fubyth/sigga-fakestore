namespace SiggaFakeStore.Models;

public class FavoriteProduct : Product
{
    public Boolean Favorite { get; set; }

    public static FavoriteProduct FromProduct(Product orig)
    {
        FavoriteProduct result = new FavoriteProduct();

        result.Id = orig.Id;
        result.Title = orig.Title;
        result.Description = orig.Description;
        result.Price = orig.Price;
        result.Image = orig.Image;
        result.Category = orig.Category;
        result.Favorite = false;
        
        return result;
    }
}