using Minigames.Application.DTOs;

namespace Minigames.Application.Interfaces;

public interface IHangmanGameService
{
    StartHangmanGameDto StartGame(string playerName);
    Task<HangmanAnswerResultDto> SubmitGuessAsync(SubmitGuessDto guess);
}
