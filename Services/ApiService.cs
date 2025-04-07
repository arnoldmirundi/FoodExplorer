using FoodExplorer.Models;
using System.Net.Http.Json;

namespace FoodExplorer.Services;

public class ApiService
{
    private readonly HttpClient _http = new();

    public async Task<List<Food>> GetRemoteFoods()
    {
        return await _http.GetFromJsonAsync<List<Food>>("https://mockapi.io/foods");
    }

    public async Task AddFood(Food food)
    {
        await _http.PostAsJsonAsync("https://mockapi.io/foods", food);
    }

    public async Task DeleteFood(int id)
    {
        await _http.DeleteAsync($"https://mockapi.io/foods/{id}");
    }
}
