public class IOccasionService
    {
     Task<bool> CreateOccasionAsync(OccasionCreate occasionToCreate);

    Task<bool> GetOccasionByIdAsync(int occasionId);
    }
