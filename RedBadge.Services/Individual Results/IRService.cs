using Redbadge.Data.Context;
using System.Net;
using RedBadge.Models.IndividualResultsModels;
using Redbadge.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using RedBadge.Models.GameModels;
using RedBadge.Models.OccasionModels;
using RedBadge.Models.PlayerModels;
using RedBadge.Models.RankModels;
using System.Runtime.CompilerServices;

namespace RedBadge.Services.IndividualResults
{
public class IRService : IIRService
{
    private readonly ApplicationDbContext _context;

    public IRService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateIRAsync (IRCreate iRToCreate)
    {
        var entity = new IndividualResultsEntity
        {
            GameId = iRToCreate.GameId,
            OccasionId = iRToCreate.OccasionId,
            PlayerId = iRToCreate.PlayerId,
            RankId = iRToCreate.RankId,
        };

        await _context.IndividualResults.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<IRListItem>> GetAllIRAsync()
    {
        return await _context.IndividualResults
            .Include(i => i.Game)
            .Include(i => i.Occasion)
            .Include(i => i.Player)
            .Include(i => i.Rank)
            .Select(iRObject => new IRListItem
            {
            Id = iRObject.Id,
            GameId = iRObject.Game.Id,
            OccasionId = iRObject.Occasion.Id,
            PlayerId = iRObject.Player.Id,
            RankId = iRObject.Rank.Id,
        }).ToListAsync();
    }

    public async Task<IRDetails> GetIRByIdAsync(int iRId)
    {
        var iRFromDb = await _context.IndividualResults
            .Include(iREntity => iREntity.Game)
            .Include(iREntity => iREntity.Occasion)
            .Include(iREntity => iREntity.Player)
            .Include(iREntity => iREntity.Rank)
            .FirstOrDefaultAsync(iREntity => iREntity.Id == iRId);

        return iRFromDb is null ? null : new IRDetails
        {
            Id = iRFromDb.Id,
            Game = new GameListItem
            {
                Id = iRFromDb.Game.Id,
                Name = iRFromDb.Game.Name,
            },
            Occasion = new OccasionListItem
            {
                Id = iRFromDb.Occasion.Id,
                Name = iRFromDb.Occasion.Name,
                DateTime = iRFromDb.Occasion.DateTime,
            },
            Player = new PlayerListItem
            {
                Id = iRFromDb.Player.Id,
                Name = iRFromDb.Player.Name,
            },
            Rank = new RankListItem
            {
                Id = iRFromDb.Rank.Id,
                RankName = iRFromDb.Rank.RankName,
            }
        };
    }

    public async Task<bool> UpdateIRAsync(IREdit request)
    {
        var iRToBeUpdated = await _context.IndividualResults.FindAsync(request.Id);

        if (iRToBeUpdated == null)
            return false;

        iRToBeUpdated.GameId = request.GameId;
        iRToBeUpdated.OccasionId = request.OccasionId;
        iRToBeUpdated.PlayerId = request.PlayerId;
        iRToBeUpdated.RankId = request.RankId;
        //should this be Names instead of IDs?

        var numberOfChanges = await _context.SaveChangesAsync();
        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteIRAsync(int iRId)
    {
        var iREntity = await _context.IndividualResults.FindAsync(iRId);

        if (iREntity == null)
            return false;

        _context.IndividualResults.Remove(iREntity);
        return await _context.SaveChangesAsync() == 1;
    }
}
}