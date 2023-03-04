using Microsoft.EntityFrameworkCore;
using Redbadge.Data.Context;
using Redbadge.Data.Entities;
using RedBadge.Models.OccasionModels;
using RedBadge.Models.PlayerModels;

public class PlayerService : IPlayerService
{
    private readonly ApplicationDbContext _context;

    public PlayerService(ApplicationDbContext context)
    {
        _context = context;
    }   

    public async Task<bool> CreatePlayerAsync (PlayerCreate playerToCreate)
    {
        var entity = new PlayerEntity
        {
            Name = playerToCreate.Name,
        };

        await _context.Player.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<PlayerListItem>> GetAllPlayersAsync()
    {
        return await _context.Player.Select(playerObject => new PlayerListItem
        {
            Id = playerObject.Id,
            Name = playerObject.Name,
        }).ToListAsync();
    }

    public async Task<PlayerDetails> GetPlayerByIdAsync(int playerId)
    {
        var playerFromDb = await _context.Player.FindAsync(playerId);
        if (playerFromDb is null)
            return null;
        else
        {
            var playerDetail = new PlayerDetails
            {
                Name = playerFromDb.Name,
            };

            return playerDetail;
        }
    }
    public async Task<bool> UpdatePlayerAsync(int playerId, PlayerEdit playerModel)
    {
        var player = await _context.Player.FindAsync(playerId);
        if (player == null)
            return default;

        else
        {
            player.Name = playerModel.Name;

            await _context.SaveChangesAsync();
            return true;
        }
    }

    public async Task<bool> DeletePlayerAsync(int playerId)
    {
        var playerEntity = await _context.Player.FindAsync(playerId);

        if (playerEntity == null)
            return false;

        else
        {
            _context.Player.Remove(playerEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}