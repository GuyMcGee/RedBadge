using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Redbadge.Data.Context;
using Redbadge.Data.Entities;
using RedBadge.Models.OccasionModels;

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
}
