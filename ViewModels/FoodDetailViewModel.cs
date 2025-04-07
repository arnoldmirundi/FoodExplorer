using FoodExplorer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodExplorer.ViewModels
{
    public class FoodDetailViewModel
    {
        public FoodDetailViewModel(Food food)
        {
        }

        public Food SelectedFood { get; internal set; }

        internal async Task SpeakFoodInfo()
        {
            throw new NotImplementedException();
        }
    }
}
