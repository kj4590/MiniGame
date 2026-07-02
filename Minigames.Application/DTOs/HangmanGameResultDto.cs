using Minigames.Domain.Entities;

namespace Minigames.Application.DTOs;

public class HangmanGameResultDto
{
    public int TimesPlayed { get; set; } = 0;
    public int TimesWon { get; set; } = 0;

    public static implicit operator HangmanGameResultDto?(HangmanGameResult? v)
    {
        if (v == null)
            return null;
        return new HangmanGameResultDto
        {
            TimesPlayed = v.TimesPlayed,
            TimesWon = v.TimesWon
        };
    }
}