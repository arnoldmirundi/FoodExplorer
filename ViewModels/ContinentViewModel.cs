using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using FoodExplorer.Models;
using FoodExplorer.Database;

namespace FoodExplorer.ViewModels
{
    public class ContinentViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Food> Foods { get; set; } = new();

        private readonly FoodDatabase _db;

        public ContinentViewModel(string continent)
        {
            _db = new FoodDatabase();
            LoadFoodsAsync(continent);
        }

        private async void LoadFoodsAsync(string continent)
        {
            var items = await _db.GetByContinentAsync(continent);
            Foods.Clear();
            foreach (var item in items)
                Foods.Add(item);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
