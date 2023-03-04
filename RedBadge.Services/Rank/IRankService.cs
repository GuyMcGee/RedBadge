using RedBadge.Models.RankModels;

public interface IRankService
{
    public Task<bool> CreateRankAsync(RankCreate rankToCreate);

    public Task<List<RankListItem>> GetAllRanksAsync();

    public Task<RankDetails> GetRankByIdAsync(int rankId);

    public Task<bool> UpdateRankAsync(int rankId, RankEdit rankModel);

    public Task<bool> DeleteRankAsync(int rankId);
}
