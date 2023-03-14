using RedBadge.Models.IndividualResultsModels;

 public interface IIRService
{
    public Task<bool> CreateIRAsync(IRCreate iRToCreate);

    public Task<List<IRListItem>> GetAllIRAsync();

    public Task<IRDetails> GetIRByIdAsync(int iRId);

    public Task<bool> UpdateIRAsync(IREdit request);

    public Task<bool> DeleteIRAsync(int iRId);
}

