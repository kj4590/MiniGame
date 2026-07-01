using Microsoft.AspNetCore.Mvc;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Api.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        [Produces("application/json")]
        public class LeaderboardController : ControllerBase
        {
            private readonly ILeaderboardService _leaderboardService;

                public LeaderboardController(ILeaderboardService leaderboardservice)
            {
                _leaderboardService = leaderboardservice;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<LeaderboardDto>>> GetLeaderboard()
            {
                var leaderboard = await _leaderboardService.GetLeaderboardAsync();
                return Ok(leaderboard);
            }

            [HttpGet("hangman")]

            public async Task<ActionResult<IEnumerable<LeaderboardDto>>> GetHangmanLeaderboard()
            {
                var leaderboard = await _leaderboardService.GetHangmanLeaderboardAsync();
                return Ok(leaderboard);
            }

            [HttpGet("formula")]

            public async Task<ActionResult<IEnumerable<LeaderboardDto>>> GetFormulaLeaderboard()
            {
                var leaderboard = await _leaderboardService.GetFormulaLeaderboardAsync();
                return Ok(leaderboard);
            }
        }
}
