using AJStudio.Core.Models;

namespace AJStudio.Data.Repository.Suggested
{
    public interface ISuggestedRepository
    {
        Task<List<SuggestedModel>> Repo_GetAllSuggested();
        Task<SuggestedModel> Repo_GetSuggestedById(long suggestedId);
        Task<string> Repo_AddSuggested(SuggestedModel suggestedModel);
        Task<long> Repo_UpdateSuggested(SuggestedModel suggestedModel);
        Task<int> Repo_DeleteSuggested(long suggestedId);
        Task<bool> Repo_CheckSuggested(string suggested);
        Task<bool> Repo_CheckSuggested(long? suggestedId, string suggested);
    }
}
