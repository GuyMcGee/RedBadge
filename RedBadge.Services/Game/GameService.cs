using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Redbadge.Data.Context;
using Redbadge.Data.Entities;
using RedBadge.Models.GameModels;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> GameCreateAsync(GameCreate gameModel)
    {
        var gameEntity = new GameEntity()
        {
            Name = gameModel.Name,
        };

        await _context.Game.AddAsync(gameEntity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }

    public async Task<GameDetails> GetGameByIdAsync(int gameId)
    {
        var game = await _context.Game.FindAsync
            (gameId);
        if (game is null)
            return null;
        var gameDetail = new GameDetails
        {
            id = game.Id,
            name = game.Name,
        };

        return gameDetail;
    }

    public async Task<List<GameListItem>>GetGamesAsync()
    {
        return await _context.Game.Select(gameModel => new GameListItem
        {
            id = gameModel.Id,
            name = gameModel.Name,
        }).ToListAsync();   
    }

    public async Task<bool> UpdateGameAsync(int gameId, GameEdit gameModel)
    {
        var game = await _context.Game.FindAsync(gameId);
        if (game == null)
            return default;

        else
        {
            game.Name = gameModel.Name;

            await _context.SaveChangesAsync();
            return true;
        }

    }

    public async Task<bool> DeleteGameAsync(int gameId)
    {
        var gameEntity = await _context.Game.FindAsync(gameId);

        if (gameEntity == null)
            return false;

        else
        {
            _context.Game.Remove(gameEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}

