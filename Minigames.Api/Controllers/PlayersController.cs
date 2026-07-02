using Microsoft.AspNetCore.Mvc;
using Minigames.Application.DTOs;
using Minigames.Application.Interfaces;

namespace Minigames.Api.Controllers;

/// <summary>
/// API controller for managing players and their game statistics.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json")]
public class PlayersController : ControllerBase
{
    private readonly IPlayerService _playerService;

    /// <summary>
    /// Initializes a new instance of the PlayersController.
    /// </summary>
    public PlayersController(IPlayerService playerService)
    {
        _playerService = playerService;
    }

    /// <summary>
    /// Creates a new player.
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PlayerDto>> CreatePlayer([FromBody] CreatePlayerDto createPlayerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            var playerDto = await _playerService.CreatePlayerAsync(createPlayerDto);
            return CreatedAtAction(nameof(GetPlayerByName), new { playerName = playerDto.PlayerName }, playerDto);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    /// <summary>
    /// Retrieves a player by name.
    /// </summary>
    [HttpGet("{playerName}")]
    [ProducesResponseType(typeof(PlayerDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PlayerDto>> GetPlayerByName(string playerName)
    {
        try
        {
            var playerDto = await _playerService.GetPlayerByNameAsync(playerName);
            return Ok(playerDto);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Player '{playerName}' not found.");
        }
    }

    /// <summary>
    /// Retrieves the game summary for a player.
    /// </summary>
    [HttpGet("{playerName}/game-summary")]
    [ProducesResponseType(typeof(PlayerGameSummaryDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PlayerGameSummaryDto>> GetPlayerGameSummary(string playerName)
    {
        try
        {
            var gameSummary = await _playerService.GetPlayerGameSummaryAsync(playerName);

            if (gameSummary == null)
            {
                return NotFound($"Game summary for player '{playerName}' not found.");
            }

            return Ok(gameSummary);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Player '{playerName}' not found.");
        }
    }
}
