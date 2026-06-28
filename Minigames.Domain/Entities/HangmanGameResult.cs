namespace Minigames.Domain.Entities;

public class HangmanGameResult
{
    public int TimesPlayed { get; private set; }
    public int TimesWon { get; private set; }

    public void RecordGame(bool won)
    {
        TimesPlayed++;
        if (won)
        {
            TimesWon++;
        }
    }
}