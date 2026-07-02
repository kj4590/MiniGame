using Minigames.Application.DTOs;

namespace Minigames.Application.Interfaces;

public interface IFormulaGameService
{
    StartFormulaGameDto StartGame(string playerName);
    Task<FormulaAnswerResultDto> SubmitFormulaAnswerAsync(SubmitFormulaAnswerDto answer);
}
