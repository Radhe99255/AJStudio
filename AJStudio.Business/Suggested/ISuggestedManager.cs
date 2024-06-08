using AJStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Business.Suggested
{
    public interface ISuggestedManager
    {
        Task<List<SuggestedModel>> Manager_GetAllSuggested();
        Task<SuggestedModel> Manager_GetSuggestedById(long suggestedId);
        Task<string> Manager_AddSuggested(SuggestedModel suggestedModel);
        Task<string> Manager_UpdateSuggested(SuggestedModel suggestedModel);
        Task<string> Manager_DeleteSuggested(long suggestedId);

    }
}
