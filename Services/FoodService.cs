using FoodExplorer.Database;
using FoodExplorer.Models;

namespace FoodExplorer.Services;

public class FoodService
{
    private readonly FoodDatabase _database;

    public FoodService(FoodDatabase db) => _database = db;

    public Task<List<Food>> GetAll() => _database.GetItemsAsync();

    public Task<List<Food>> GetByContinent(string continent) =>
        _database.GetByContinentAsync(continent);
}
