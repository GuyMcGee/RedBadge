using Microsoft.EntityFrameworkCore;
using Redbadge.Data.Context;
using Redbadge.Data.Entities;
using RedBadge.Models.RankModels;

namespace RedBadge.Services.Rank
{
    public class RankService : IRankService
    {
        private readonly ApplicationDbContext _context;

        public RankService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateRankAsync(RankCreate rankToCreate)
        {
            var entity = new RankEntity
            {
                RankName = rankToCreate.RankName,
            };

            await _context.Rank.AddAsync(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<RankListItem>> GetAllRanksAsync()
        {
            return await _context.Rank.Select(rankObject => new RankListItem
            {
                Id = rankObject.Id,
                RankName = rankObject.RankName,
            }).ToListAsync();
        }

        public async Task<RankDetails> GetRankByIdAsync(int rankId)
        {
            var rankFromDb = await _context.Rank.FindAsync(rankId);
            if (rankFromDb is null)
                return null;
            else
            {
                var rankDetail = new RankDetails
                {
                    RankName = rankFromDb.RankName,
                };

                return rankDetail;
            }
        }
        public async Task<bool> UpdateRankAsync(int rankId, RankEdit rankModel)
        {
            var rank = await _context.Rank.FindAsync(rankId);
            if (rank == null)
                return default;

            else
            {
                rank.RankName = rankModel.RankName;

                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteRankAsync(int rankId)
        {
            var rankEntity = await _context.Rank.FindAsync(rankId);

            if (rankEntity == null)
                return false;

            else
            {
                _context.Rank.Remove(rankEntity);
                return await _context.SaveChangesAsync() == 1;
            }
        }
    }

}
