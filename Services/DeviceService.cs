namespace FoodExplorer.Services;

public class DeviceService
{
    public void Vibrate() => Vibration.Default.Vibrate();

    public async Task<string> GetLocationAsync()
    {
        var location = await Geolocation.Default.GetLastKnownLocationAsync();
        return location != null ? $"Lat: {location.Latitude}, Lon: {location.Longitude}" : "Unknown";
    }

    public void ShakeDetected()
    {
        // For actual shake detection, use a plugin or platform-specific code
        Vibration.Default.Vibrate(TimeSpan.FromMilliseconds(500));
    }
}
