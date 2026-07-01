using static Minigames.Application.DTOs.HangmanGameResultDto;

namespace Minigames.Application.Interfaces
{
    public interface IHangmanGameService
    {
        StartHangmanGameDto StartGame(string playerName);

        Task<HangmanAnswerResultDto> SubmitGuessAsync(SubmitHangmanGuessDto guess);
    }
}
