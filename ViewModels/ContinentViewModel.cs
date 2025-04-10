using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using FoodExplorer.Models;
using FoodExplorer.Database;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage; // For Preferences

namespace FoodExplorer.ViewModels
{
    public class ContinentViewModel : INotifyPropertyChanged
    {
        private readonly FoodDatabase _db;
        private string _continentName;
        private string _searchText;
        private bool _isBusy;
        private bool _isAdmin;
        private ObservableCollection<Food> _filteredFoods = new();
        private Food _selectedFood;

        public ObservableCollection<Food> Foods { get; } = new();

        public ObservableCollection<Food> FilteredFoods
        {
            get => _filteredFoods;
            set
            {
                _filteredFoods = value;
                OnPropertyChanged();
            }
        }

        public string ContinentName
        {
            get => _continentName;
            set
            {
                _continentName = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                SearchFoods();
            }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }

        public Food SelectedFood
        {
            get => _selectedFood;
            set
            {
                _selectedFood = value;
                OnPropertyChanged();
            }
        }

        public ICommand LoadFoodsCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand FoodSelectedCommand { get; }
        public ICommand AddFoodCommand { get; }

        public ContinentViewModel(string continent)
        {
            _db = new FoodDatabase();
            ContinentName = continent;
            IsAdmin = Preferences.Get("IsAdmin", false); // Using Preferences instead of Application.Properties

            // Initialize commands
            LoadFoodsCommand = new Command(() => _ = LoadFoodsAsync(continent));
            SearchCommand = new Command(SearchFoods);
            FoodSelectedCommand = new Command<Food>(OnFoodSelected);
            AddFoodCommand = new Command(AddNewFood);

            _ = LoadInitialData(continent);
        }

        private async Task LoadInitialData(string continent)
        {
            await LoadFoodsAsync(continent);
            SearchFoods();
        }

        private async Task LoadFoodsAsync(string continent)
        {
            IsBusy = true;
            try
            {
                Foods.Clear();
                var items = await _db.GetByContinentAsync(continent);
                foreach (var item in items)
                {
                    Foods.Add(item);
                }
                FilteredFoods = new ObservableCollection<Food>(Foods);
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Error", $"Failed to load foods: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void SearchFoods()
        {
            if (Foods == null || Foods.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                FilteredFoods = new ObservableCollection<Food>(Foods);
            }
            else
            {
                FilteredFoods = new ObservableCollection<Food>(
                    Foods.Where(f =>
                        f.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                        f.Origin.Contains(SearchText, StringComparison.OrdinalIgnoreCase))
                );
            }
        }

        private async void OnFoodSelected(Food food)
        {
            if (food == null) return;

            SelectedFood = null; // Reset selection

            try
            {
                await Shell.Current.GoToAsync($"FoodDetailPage?foodId={food.Id}");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }

        private async void AddNewFood()
        {
            try
            {
                await Shell.Current.GoToAsync("NewFoodPage");
            }
            catch (Exception ex)
            {
                await Shell.Current.DisplayAlert("Navigation Error", ex.Message, "OK");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}