namespace Minigames.Domain.Entities;

public class  FormulaGameResult
{
    public int TimesPlayed { get; private set; }

    public int? BestDifference { get; private set; }

    public void RecordGame(int difference)
    {
        TimesPlayed++;
        if (BestDifference == null || difference < BestDifference)
        {
            BestDifference = difference;
        }
    }
}