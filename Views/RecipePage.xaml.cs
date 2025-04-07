namespace FoodExplorer.Views;
using FoodExplorer.Models;
using FoodExplorer.ViewModels;
public partial class RecipePage : ContentPage
{
    public RecipePage(Food food)
    {
        InitializeComponent();
        BindingContext = new FoodDetailViewModel(food);
    }
}
