using CommunityToolkit.Mvvm.ComponentModel;

using HangMan.Servics;

namespace HangMan.ViewModes;
public partial class MainPageViewModel : ObservableObject
{
    readonly WordService wordService;

    string answer = string.Empty;
    readonly List<char> charList = new();

    [ObservableProperty]
    private string sporlight;

    public MainPageViewModel(WordService wordService)
    {
        this.wordService = wordService;
        GetWord();
        CalculateWord(answer, charList);
    }

    private async void GetWord()
    {
        answer = await wordService.GetRandomWord();
    }

    private void CalculateWord(string ans, List<char> guessed)
    {
        var temp = ans.Select(x => guessed.IndexOf(x) >= 0 ? x : '_').ToArray();
        sporlight = string.Join(' ', temp);
    }


}
