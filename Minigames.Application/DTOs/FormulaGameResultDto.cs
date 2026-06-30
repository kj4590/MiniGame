using Minigames.Domain.Entities;

namespace Minigames.Application.DTOs;

public class FormulaGameResultDto
{
    public int TimesPlayed { get; set; } = 0;
    public int? BestDifference { get; set; } = 0;

    public static implicit operator FormulaGameResultDto?(FormulaGameResult? v)
    {
        if (v == null)  return null;
        return new FormulaGameResultDto { TimesPlayed = v.TimesPlayed, BestDifference = v.BestDifference };
    }
}