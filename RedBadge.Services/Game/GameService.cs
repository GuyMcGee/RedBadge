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

    public async Task<bool> CreateGameAsync(GameCreate gameModel)
    {
        var gameEntity = new GameEntity()
        {
            Name = gameModel.Name,
        };

        await _context.Game.AddAsync(gameEntity);
        var numberOfChanges = await _context.SaveChangesAsync();

        return numberOfChanges == 1;
    }
    public async Task<List<GameListItem>>GetAllGamesAsync()
    {
        return await _context.Game.Select(gameModel => new GameListItem
        {
            Id = gameModel.Id,
            Name = gameModel.Name,
        }).ToListAsync();   
    }

    public async Task<GameDetails> GetGameByIdAsync(int gameId)
    {
        var game = await _context.Game.FindAsync
            (gameId);
        if (game is null)
            return null; //is this freaking out because it is impossible for this variable to be null?
        var gameDetail = new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
        };

        return gameDetail;
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

