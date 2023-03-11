using RedBadge.Models.GameModels;

namespace RedBadge.Services.Game
{
public interface IGameService
{
    public Task<bool> CreateGameAsync(GameCreate gameModel);

    public Task<GameDetails> GetGameByIdAsync(int gameId);

    public Task<List<GameListItem>> GetAllGamesAsync();

    public Task<bool> UpdateGameAsync(int gameId, GameEdit gameModel);

    public Task<bool> DeleteGameAsync(int gameId);
}
}
