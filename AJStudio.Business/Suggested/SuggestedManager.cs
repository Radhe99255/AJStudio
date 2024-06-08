using AJStudio.Core.Models;
using AJStudio.Data.Repository.Suggested;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Business.Suggested
{
    public class SuggestedManager : ISuggestedManager
    {
        private readonly ISuggestedRepository _suggestedRepository;

        /// <summary>
        /// Inject the Dependancy for the Repository to access the Repository
        /// </summary>
        /// <param name="suggestedRepository"></param>
        public SuggestedManager(ISuggestedRepository suggestedRepository)
        {
            _suggestedRepository = suggestedRepository;
        }

        /// <summary>
        /// Get the list of suggested from the repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<SuggestedModel>> Manager_GetAllSuggested()
        {
            return await _suggestedRepository.Repo_GetAllSuggested();
        }

        /// <summary>
        /// Get the suggested by suggested id from the repository
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <returns></returns>
        public async Task<SuggestedModel> Manager_GetSuggestedById(long suggestedId)
        {
            return await _suggestedRepository.Repo_GetSuggestedById(suggestedId);
        }

        /// <summary>
        /// Add the suggested into the repository with validation of suggested
        /// </summary>
        /// <param name="suggestedModel"></param>
        /// <returns></returns>
        public async Task<string> Manager_AddSuggested(SuggestedModel suggestedModel)
        {
            var checkSuggested = await _suggestedRepository.Repo_CheckSuggested(suggestedModel.Suggested);

            if (checkSuggested)
            {
                return "Exist";
            }

            return await _suggestedRepository.Repo_AddSuggested(suggestedModel);
        }

        /// <summary>
        /// Update Suggested into the Repository
        /// </summary>
        /// <param name="suggestedModel"></param>
        /// <returns></returns>
        public async Task<string> Manager_UpdateSuggested(SuggestedModel suggestedModel)
        {
            var checkSuggestedWithId = await _suggestedRepository.Repo_CheckSuggested(suggestedModel.Suggested_Id, suggestedModel.Suggested);

            if (checkSuggestedWithId)
            {
                return "Exist";
            }

            var updateSuggested = await _suggestedRepository.Repo_UpdateSuggested(suggestedModel);

            if (updateSuggested > 0)
            {
                return "Success";
            }

            return "Fail";
        }

        /// <summary>
        /// Delete Suggested from the repository
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <returns></returns>
        public async Task<string> Manager_DeleteSuggested(long suggestedId)
        {
            var deleteResult = await _suggestedRepository.Repo_DeleteSuggested(suggestedId);

            if (deleteResult > 0)
            {
                return "Success";
            }

            return "Fail";
        }
    }
}
