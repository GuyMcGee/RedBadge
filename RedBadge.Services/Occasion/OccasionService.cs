using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Redbadge.Data.Context;
using Redbadge.Data.Entities;
using RedBadge.Models.GameModels;
using RedBadge.Models.OccasionModels;

namespace RedBadge.Services.Occasion
{
public class OccasionService : IOccasionService
{
    private readonly ApplicationDbContext _context;

    public OccasionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateOccasionAsync (OccasionCreate occasionToCreate)
    {
        var entity = new OccasionEntity
        {
            Name = occasionToCreate.Name, //entity propety is on the left of the = and model properties are on the right
            DateTime = occasionToCreate.DateTime
        };

        await _context.Occasion.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<OccasionListItem>> GetAllOccasionsAsync()
    {
        //is it more accurate to think of this "occasionObject" variable as a model or an object, since it is an instance of the OccasionListItem class?
        return await _context.Occasion.Select(occasionObject => new OccasionListItem
        {
            Id = occasionObject.Id,
            Name = occasionObject.Name,
            DateTime = occasionObject.DateTime
        }).ToListAsync();
    }

    public async Task<OccasionDetails> GetOccasionByIdAsync(int occasionId)
    {
        var occasionFromDb = await _context.Occasion.FindAsync(occasionId);
        if (occasionFromDb is null)
            return null;
        else
        {
            var occasionDetail = new OccasionDetails
            {
                Id = occasionId,
                Name = occasionFromDb.Name,
                DateTime = occasionFromDb.DateTime
            };

            return occasionDetail;
        }
    }

    public async Task<bool> UpdateOccasionAsync(int occasionId, OccasionEdit occasionModel)
    {
        var occasion = await _context.Occasion.FindAsync(occasionId);
        if (occasion == null)
            return default;

        else
        {
            occasion.Name = occasionModel.Name;
            occasion.DateTime = occasionModel.DateTime;

            await _context.SaveChangesAsync();
            return true;
        }

    }

    public async Task<bool> DeleteOccasionAsync(int occasionId)
    {
        var occasionEntity = await _context.Occasion.FindAsync(occasionId);

        if (occasionEntity == null)
            return false;

        else
        {
            _context.Occasion.Remove(occasionEntity);
            return await _context.SaveChangesAsync() == 1;
        }
    }
}
}

