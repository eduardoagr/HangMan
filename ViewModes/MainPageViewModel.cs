using CommunityToolkit.Mvvm.ComponentModel;

using HangMan.Interfaces;

namespace HangMan.ViewModes;
public partial class MainPageViewModel : ObservableObject
{
    readonly IGetWord getWord;

    string answer = string.Empty;
    readonly List<char> charList = new();

    [ObservableProperty]
    private string _spotlight;


    public MainPageViewModel(IGetWord getWord)
    {
        this.getWord = getWord;
        InitializeAsync();
    }

    private async Task<string> GetWord()
    {
        answer = await getWord.DownloadRandomWordAsync();
        return answer;
    }

    private void CalculateWord(string ans, List<char> guessed)
    {
        var temp = ans.Select(x => guessed.IndexOf(x) >= 0 ? x : '_').ToArray();
        Spotlight = string.Join(' ', temp);
    }

    public void InitializeAsync()
    {
        Task.Run(async () =>
        {
            answer = await GetWord();
            CalculateWord(answer, charList);
        });

    }

}
