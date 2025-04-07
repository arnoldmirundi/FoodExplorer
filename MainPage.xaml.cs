using FoodExplorer.Views;
using System.Diagnostics;

namespace FoodExplorer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnContinentClicked(object sender, EventArgs e)
        {
            try
            {
                if (sender is Button button && button.CommandParameter is string continent)
                {
                    Debug.WriteLine($"Navigating to {continent}"); 

                    var continentPage = new ContinentPage(continent);
                    await Navigation.PushAsync(continentPage);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Navigation failed: {ex.Message}");
                await DisplayAlert("Error", "Failed to navigate. Please try again.", "OK");
            }
        }
    }
}