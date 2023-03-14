using RedBadge.Models;
using RedBadge.Models.IndividualResultsModels;

 public interface IIRService
{
    public Task<bool> CreateIRAsync(IndividualResult iRToCreate);

    public Task<List<IndividualResult>> GetAllIRAsync();

    public Task<IndividualResult> GetIRByIdAsync(int iRId);

    public Task<bool> UpdateIRAsync(IndividualResult request);

    public Task<bool> DeleteIRAsync(int iRId);
}

