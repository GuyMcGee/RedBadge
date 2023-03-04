using RedBadge.Models.PlayerModels;

public interface IPlayerService
{
    public Task<bool> CreatePlayerAsync(PlayerCreate playerToCreate);

    public Task<List<PlayerListItem>> GetAllPlayersAsync();

    public Task<PlayerDetails> GetPlayerByIdAsync(int playerId);

    public Task<bool> UpdatePlayerAsync(int playerId, PlayerEdit playerModel);

    public Task<bool> DeletePlayerAsync(int playerId);
}
