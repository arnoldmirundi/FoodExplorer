using SQLite;
using System.ComponentModel;

namespace FoodExplorer.Models
{
    [Table("Foods")]  // Explicit table name
    public class Food : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [NotNull, MaxLength(100)]
        public string Name { get; set; }

        [NotNull, MaxLength(50)]
        public string Origin { get; set; }

        [NotNull, MaxLength(50)]
        public string Continent { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                OnPropertyChanged(nameof(ImageUrl));
            }
        }

        [MaxLength(50)]
        public string CountryFlag { get; set; }  // e.g. "japan.png"

        [Ignore]  // Not stored in database
        public string DisplayOrigin => $"{Origin} • {Continent}";

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}