using System.Net.Http.Json;

using HangMan.Interfaces;
using HangMan.Model;

namespace HangMan.Servics;
public class WordService : IGetWord
{
    readonly HttpClient client;

    public WordService()
    {
        client = new HttpClient();
    }

    public async Task<string> DownloadRandomWordAsync()
    {
        var url = "https://random-words-api.vercel.app/word/";

        var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            var json = await response.Content.ReadFromJsonAsync<List<WordClass>>();

            return json.FirstOrDefault().word;
        }

        return null;
    }
}
