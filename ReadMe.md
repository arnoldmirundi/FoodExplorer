 FoodExplorer  .NET MAUI App


A crossplatform mobile application built with .NET MAUI that showcases famous foods from around the world, with detailed information about each dish, recipes, and the ability to save favorites.

 Features

 Continental Food Exploration: Browse dishes by continent (Asia, Europe, Africa, etc.)
 Detailed Dish Information: 
   Taste type (spicy, sweet, savory)
   Ingredients list
   Origin and cultural significance
   Preparation methods
 Recipe Guide: Stepbystep cooking instructions
 Favorites System: Save your favorite dishes
 Accessibility Features:
   Adjustable font sizes
   Dark/Light mode
   Texttospeech functionality
 Hardware Integration:
   Shake device for random recipe
   Locationbased recommendations
   Haptic feedback

 Technologies Used

 .NET MAUI 8.0
 CommunityToolkit.MVVM
 XAML for UI
 SQLite for local storage
 RESTful API integration

 Requirements

 .NET 8 SDK
 Visual Studio 2022 (with MAUI workload) or Visual Studio Code
 Android/iOS/Windows development environment

 Installation

1. Clone the repository:
   bash
   git clone https://github.com/yourusername/foodaroundtheworld.git
   cd foodaroundtheworld
   

2. Restore dependencies:
   bash
   dotnet restore
   

3. Build the project:
   bash
   dotnet build
   

4. Run on your preferred platform:
   bash
   dotnet build t:Run f net8.0android
    or
   dotnet build t:Run f net8.0ios
    or
   dotnet build t:Run f net8.0windows
   

 Project Structure


FoodExplorer/
├── Models/           Data models
├── Services/         Business logic and data services
├── ViewModels/       ViewModels for MVVM pattern
├── Views/            UI Pages and components
├── Resources/        Styles, fonts, images
└── wwwroot/          API mock data (optional)


 Development Setup

1. Install required workloads:
   bash
   dotnet workload install maui
   

2. Configure your development environment for your target platform (Android, iOS, or Windows)

3. For API development, set up the mock server:
   bash
   cd apimock
   npm install
   npm start
   

 Screenshots

| Home Screen | Dish Details | Recipe View |
||||
| ![Home](screenshots/home.png) | ![Details](screenshots/details.png) | ![Recipe](screenshots/recipe.png) |

 Contributing

Contributions are welcome! Please follow these steps:

1. Fork the repository
2. Create a new branch (git checkout b feature/yourfeature)
3. Commit your changes (git commit am 'Add some feature')
4. Push to the branch (git push origin feature/yourfeature)
5. Create a new Pull Request

License

This project is licensed under the MIT License  see the [LICENSE](LICENSE) file for details.

Acknowledgments

 .NET MAUI team for the excellent crossplatform framework
 Community Toolkit contributors
 All the food cultures that inspired this app



