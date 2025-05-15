namespace SiggaFakeStore.Services;

using System;
using SiggaFakeStore.Models;

public class FavoriteProductService
{
    public async Task<List<FavoriteProduct>?> SearchProductsAsync(int userId)
    {
        ApiClient client = new ApiClient(new HttpClient());

        List<Product>? products = await client.SearchProductsAsync();

        List<FavoriteProduct>? result = null;

        if (products != null)
        {
            result = SetFavoriteItems(products, userId);
        }

        return result;
    }

    private List<FavoriteProduct> SetFavoriteItems(List<Product> products, int userId)
    {
        UserFavoriteProductsManagement userFavoriteProductsManagement = new UserFavoriteProductsManagement();

        UserFavoriteProducts userFavoriteProducts = userFavoriteProductsManagement.LoadFavorites(userId);

        List<FavoriteProduct> result = new List<FavoriteProduct>();
        foreach (Product product in products)
        {
            FavoriteProduct tmp = FavoriteProduct.FromProduct(product);

            int search = userFavoriteProducts.FavoriteProducts.FirstOrDefault(x => x == product.Id);
            if (search > 0)
            {
                tmp.Favorite = true;
            }

            result.Add(tmp);
        }

        return result;
    }

    public async Task<Product?> SearchProductAsync(int id, int userId)
    {
        ApiClient client = new ApiClient(new HttpClient());

        Product? product = await client.SearchProductAsync(id);

         FavoriteProduct? result = null;

        if (product != null)
        {
            result = SetFavoriteItem(product, userId);
        }

        return result;
    }

    private FavoriteProduct? SetFavoriteItem(Product product, int userId)
    {
        UserFavoriteProductsManagement userFavoriteProductsManagement = new UserFavoriteProductsManagement();

        UserFavoriteProducts userFavoriteProducts = userFavoriteProductsManagement.LoadFavorites(userId);

        FavoriteProduct result = FavoriteProduct.FromProduct(product);
        
        int search = userFavoriteProducts.FavoriteProducts.FirstOrDefault(x => x == product.Id);
        if (search > 0)
        {
            result.Favorite = true;
        }

        return result;
    }
}
