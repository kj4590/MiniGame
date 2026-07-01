using System.Data;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;
using System.Text.RegularExpressions;

namespace Minigames.Application.Services
{
    public class FormulaGameService : IFormulaGameService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly List<int> _numbersInFormula = [2,5,8,10,25,50];
        private const int Target = 532;

        public StartFormulaGameDto StartGame(string playerName)
        {
            return new StartFormulaGameDto
            (
                playerName,
                _numbersInFormula,
                Target
            );
        }

        public async Task<FormulaGameResultDto>SubmitAnswerAsync(SubmitFormulaAnswerDto _answer)
        {
            if (string.IsNullOrWhiteSpace(_answer.Expression))
                throw new ArgumentException("Expression cannot be empty.");
            if(!Regex.IsMatch(_answer.Expression, @"^[0-9+\-*/\s()]+$"))
                throw new ArgumentException("Expression contains invalid characters.(No alphabets, only mathematical operators : = - / * ()");

            var numbersUsed = Regex.Matches(_answer.Expression, @"\d+").Select(match => int.Parse(match.Value)).ToList();

            var availableNumbers = new List<int>(_numbersInFormula);

            foreach (int number in numbersUsed)
            {
                if (!availableNumbers.Contains(number))
                    throw new ArgumentException($"You cannot used numbers that are outside the provided list {_numbersInFormula}");

            }
        }
    }
}
