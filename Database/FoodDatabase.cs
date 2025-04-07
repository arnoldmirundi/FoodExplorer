using SQLite;
using FoodExplorer.Models;

namespace FoodExplorer.Database;

public class FoodDatabase
{
    private readonly SQLiteAsyncConnection _database;

    public FoodDatabase()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "FoodExplorer.db3");
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Food>().Wait();
    }

    public Task<List<Food>> GetItemsAsync() =>
        _database.Table<Food>().ToListAsync();

    public Task<List<Food>> GetByContinentAsync(string continent) =>
        _database.Table<Food>().Where(i => i.Continent == continent).ToListAsync();

    public Task<Food> GetItemAsync(int id) =>
        _database.Table<Food>().Where(i => i.Id == id).FirstOrDefaultAsync();

    public Task<int> SaveItemAsync(Food item) =>
        item.Id != 0 ? _database.UpdateAsync(item) : _database.InsertAsync(item);

    public Task<int> DeleteItemAsync(Food item) =>
        _database.DeleteAsync(item);

    public async Task SeedDataAsync()
    {
        if ((await GetItemsAsync()).Count > 0)
            return;

        var foods = new List<Food>
        {
            new() { Name = "Sushi", Description = "Japanese vinegared rice with raw fish.", Continent = "Asia", ImageUrl = "sushi.png" },
            new() { Name = "Pad Thai", Description = "Thai stir-fried noodles.", Continent = "Asia", ImageUrl = "padthai.png" },
            new() { Name = "Pizza", Description = "Italian flatbread with tomato and cheese.", Continent = "Europe", ImageUrl = "pizza.png" },
            new() { Name = "Croissant", Description = "French buttery, flaky pastry.", Continent = "Europe", ImageUrl = "croissant.png" },
            new() { Name = "Jollof Rice", Description = "West African rice dish.", Continent = "Africa", ImageUrl = "jollof.png" },
            new() { Name = "Bunny Chow", Description = "South African bread with curry.", Continent = "Africa", ImageUrl = "bunnychow.png" },
            new() { Name = "Burger", Description = "Beef patty in a bun.", Continent = "North America", ImageUrl = "burger.png" },
            new() { Name = "Poutine", Description = "Fries, cheese curds, gravy.", Continent = "North America", ImageUrl = "poutine.png" },
            new() { Name = "Feijoada", Description = "Brazilian black bean stew.", Continent = "South America", ImageUrl = "feijoada.png" },
            new() { Name = "Arepas", Description = "Cornmeal cakes.", Continent = "South America", ImageUrl = "arepas.png" },
            new() { Name = "Meat Pie", Description = "Savory pastry with meat.", Continent = "Australia", ImageUrl = "meatpie.png" },
            new() { Name = "Lamington", Description = "Sponge cake with chocolate.", Continent = "Australia", ImageUrl = "lamington.png" },
        };

        foreach (var food in foods)
        {
            await SaveItemAsync(food);
        }
    }
}
