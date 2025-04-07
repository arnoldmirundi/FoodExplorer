using FoodExplorer.Models;

namespace FoodExplorer.Views
{
    public partial class FoodDetailPage : ContentPage
    {
        public FoodDetailPage(Food food)
        {
            InitializeComponent();
            BindingContext = food;
        }
    }
}
