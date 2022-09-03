namespace HangMan.Interfaces;
public interface IGetWord
{
    Task<string> DownloadRandomWordAsync();
}
