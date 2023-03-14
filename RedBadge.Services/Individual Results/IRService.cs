using Redbadge.Data.Context;
using System.Net;
using Redbadge.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using RedBadge.Models;

namespace RedBadge.Services.IndividualResults
{
public class IRService : IIRService
{
    private readonly ApplicationDbContext _context;

    public IRService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateIRAsync (IndividualResult iRToCreate)
    {
        var entity = new IndividualResultEntity
        {
            GameId = iRToCreate.GameId,
            OccasionId = iRToCreate.OccasionId,
            PlayerId = iRToCreate.PlayerId,
            RankId = iRToCreate.RankId,
        };

        await _context.IndividualResult.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<IndividualResult>> GetAllIRAsync()
    {
        return await _context.IndividualResult
           .Include(i => i.Game)
           .Include(i => i.Occasion)
           .Include(i => i.Player)
           .Include(i => i.Rank)
           .Select(iRObject => new IndividualResult
           {
               Id = iRObject.Id,
               GameId = iRObject.Game.Id,
               OccasionId = iRObject.Occasion.Id,
               PlayerId = iRObject.Player.Id,
               RankId = iRObject.Rank.Id,
           }).ToListAsync();
    }

    public async Task<IndividualResult> GetIRByIdAsync(int iRId)
    {
        var iRFromDb = await _context.IndividualResult
            .Include(iREntity => iREntity.Game)
            .Include(iREntity => iREntity.Occasion)
            .Include(iREntity => iREntity.Player)
            .Include(iREntity => iREntity.Rank)
            .FirstOrDefaultAsync(iREntity => iREntity.Id == iRId);
            //return iRFromDb is null ? null : iRFromDb;


            return iRFromDb is null ? null : new IndividualResult
            {
                Id = iRFromDb.Id,
                GameId = iRFromDb.Game.Id,
                OccasionId = iRFromDb.Occasion.Id,
                PlayerId = iRFromDb.Player.Id,
                RankId = iRFromDb.Rank.Id,
                //Game = new Game
                //{
                //    Id = iRFromDb.Game.Id,
                //    Name = iRFromDb.Game.Name,
                //},
                //Occasion = new OccasionListItem
                //{
                //    Id = iRFromDb.Occasion.Id,
                //    Name = iRFromDb.Occasion.Name,
                //    DateTime = iRFromDb.Occasion.DateTime,
                //},
                //Player = new PlayerListItem
                //{
                //    Id = iRFromDb.Player.Id,
                //    Name = iRFromDb.Player.Name,
                //},
                //Rank = new RankListItem
                //{
                //    Id = iRFromDb.Rank.Id,
                //    RankName = iRFromDb.Rank.RankName,
                //}
            };
        }

        public async Task<bool> UpdateIRAsync(IndividualResult request)
    {
        var iRToBeUpdated = await _context.IndividualResult.FindAsync(request.Id);

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
        var iREntity = await _context.IndividualResult.FindAsync(iRId);

        if (iREntity == null)
            return false;

        _context.IndividualResult.Remove(iREntity);
        return await _context.SaveChangesAsync() == 1;
    }
}
}