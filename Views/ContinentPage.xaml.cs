using FoodExplorer.ViewModels;

namespace FoodExplorer.Views;

public partial class ContinentPage : ContentPage
{
    public ContinentPage(string continent)
    {
        InitializeComponent();
        BindingContext = new ContinentViewModel(continent);
    }
}
