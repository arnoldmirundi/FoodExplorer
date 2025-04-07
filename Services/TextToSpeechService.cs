namespace FoodExplorer.Services;

public class TextToSpeechService
{
    public async Task SpeakAsync(string text)
    {
        await TextToSpeech.Default.SpeakAsync(text);
    }
}
