namespace SiggaFakeStore.Services;

using SiggaFakeStore.Models;

public class ApiClient
{
    private readonly HttpClient httpClient;

    public ApiClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public async Task<List<Product>?> SearchProductsAsync()
    {
        var response =
            await httpClient.GetFromJsonAsync<List<Product>>("https://fakestoreapi.com/products");

        if (response is null) return null;

        return response.ToList();
    }

    public async Task<Product?> SearchProductAsync(int id)
    {
        var response =
            await httpClient.GetFromJsonAsync<Product>("https://fakestoreapi.com/products/"+id);

        if (response is null) return null;
        
        return response;
    }
}
