using RedBadge.Models.GameModels;
public interface IGameService
{
    public Task<bool> GameCreateAsync(GameCreate gameModel);

    public Task<GameDetails> GetGameByIdAsync(int gameId);

    public Task<List<GameListItem>> GetGamesAsync();

    public Task<bool> UpdateGameAsync(int gameId, GameEdit gameModel);

    public Task<bool> DeleteGameAsync(int gameId);
}
