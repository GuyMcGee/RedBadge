using RedBadge.Models.OccasionModels;
public interface IOccasionService
    {
     public Task<bool> CreateOccasionAsync(OccasionCreate occasionToCreate);

    public Task<List<OccasionListItem>> GetAllOccasionsAsync();

    public Task<bool> GetOccasionByIdAsync(int occasionId);

    public Task<bool> UpdateOccasionAsync(int occasionId, OccasionEdit occasionModel);

    public Task<bool> DeleteOccasionAsync(int occasionId);
    }
