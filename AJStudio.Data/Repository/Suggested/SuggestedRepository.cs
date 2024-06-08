using AJStudio.Core.Models;
using AJStudio.Data.Context;
using AJStudio.Data.DBTables;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AJStudio.Data.Repository.Suggested
{
    public class SuggestedRepository : ISuggestedRepository
    {
        private readonly AJStudioContext _aJStudioContext;
        private readonly IMapper _mapper;

        /// <summary>
        /// Inject the Dependancy for the DbContext to access the database
        /// </summary>
        /// <param name="aJStudioContext"></param>
        /// <param name="mapper"></param>
        public SuggestedRepository(AJStudioContext aJStudioContext, IMapper mapper)
        {
            _aJStudioContext = aJStudioContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of all Suggested from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<SuggestedModel>> Repo_GetAllSuggested()
        {
            var suggested = await _aJStudioContext.SuggestedTable.ToListAsync();
            return _mapper.Map<List<SuggestedModel>>(suggested);
        }

        /// <summary>
        /// Get the suggested by suggested Id from the database
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <returns></returns>
        public async Task<SuggestedModel> Repo_GetSuggestedById(long suggestedId)
        {
            var suggested = await _aJStudioContext.SuggestedTable.FirstOrDefaultAsync(x => x.Suggested_Id == suggestedId);
            return _mapper.Map<SuggestedModel>(suggested);
        }

        /// <summary>
        /// Add Suggested into the database
        /// </summary>
        /// <param name="suggestedModel"></param>
        /// <returns></returns>
        public async Task<string> Repo_AddSuggested(SuggestedModel suggestedModel)
        {
            SuggestedDBTable suggestedDBTable = new SuggestedDBTable()
            {
                Suggested = suggestedModel.Suggested
            };

            await _aJStudioContext.SuggestedTable.AddAsync(suggestedDBTable);
            await _aJStudioContext.SaveChangesAsync();

            return suggestedDBTable.Suggested_Id.ToString();
        }

        /// <summary>
        /// Update the suggested into the database
        /// </summary>
        /// <param name="suggestedModel"></param>
        /// <returns></returns>
        public async Task<long> Repo_UpdateSuggested(SuggestedModel suggestedModel)
        {
            var existingSuggested = await _aJStudioContext.SuggestedTable.Where(x => x.Suggested_Id == suggestedModel.Suggested_Id).SingleOrDefaultAsync();

            if (existingSuggested == null)
            {
                return 0;
            }

            _aJStudioContext.Entry(existingSuggested).CurrentValues.SetValues(suggestedModel);
            await _aJStudioContext.SaveChangesAsync();

            return suggestedModel.Suggested_Id;
        }

        /// <summary>
        /// Delete suggested from the database
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <returns></returns>
        public async Task<int> Repo_DeleteSuggested(long suggestedId)
        {
            var suggested = await _aJStudioContext.SuggestedTable.FindAsync(suggestedId);

            if (suggested == null)
            {
                return 0;
            }

            _aJStudioContext.SuggestedTable.Remove(suggested);
            return await _aJStudioContext.SaveChangesAsync();
        }

        /// <summary>
        /// check the Suggested into the database while Add the Suggested
        /// </summary>
        /// <param name="suggested"></param>
        /// <returns></returns>
        public async Task<bool> Repo_CheckSuggested(string suggested)
        {
            if (suggested != null)
            {
                var isSuggestedAddExist = await _aJStudioContext.SuggestedTable.Where(x => x.Suggested == suggested).FirstOrDefaultAsync();

                if (isSuggestedAddExist != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        /// <summary>
        /// Check suggested into the database while update the database
        /// Overrieded method of Add
        /// </summary>
        /// <param name="suggestedId"></param>
        /// <param name="suggested"></param>
        /// <returns></returns>
        public async Task<bool> Repo_CheckSuggested(long? suggestedId, string suggested)
        {
            if (suggestedId != null && suggested != null)
            {
                var isSuggestedUpdateExist = await _aJStudioContext.SuggestedTable.Where(x => x.Suggested_Id != suggestedId && x.Suggested == suggested).FirstOrDefaultAsync();

                if (isSuggestedUpdateExist != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
    }
}
