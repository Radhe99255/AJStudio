using AJStudio.Core.Models;
using AJStudio.Data.Context;
using AJStudio.Data.DBTables;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AJStudio.Data.Repository.PlaneVariety
{
    public class PlaneVarietyRepository : IPlaneVarietyRepository
    {
        private readonly AJStudioContext _aJStudioContext;
        private readonly IMapper _mapper;

        public PlaneVarietyRepository(AJStudioContext aJStudioContext, IMapper mapper)
        {
            _aJStudioContext = aJStudioContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of all Plane Vereity from the database
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlaneVarietyModel>> Repo_GetAllPlaneVereitys()
        {
            var planeVereitys = await _aJStudioContext.PlaneVarietyTable.ToListAsync();
            return _mapper.Map<List<PlaneVarietyModel>>(planeVereitys);
        }

        /// <summary>
        /// Get the Plane Vereity by PlaneVereity Id from the database
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <returns></returns>
        public async Task<PlaneVarietyModel> Repo_PlaneVereityById(long planeVereityId)
        {
            var planeVereity = await _aJStudioContext.PlaneVarietyTable.FirstOrDefaultAsync(x => x.PlaneVariety_Id == planeVereityId);
            return _mapper.Map<PlaneVarietyModel>(planeVereity);
        }

        /// <summary>
        /// Add Plane Vereity into the database
        /// </summary>
        /// <param name="planeVarietyModel"></param>
        /// <returns></returns>
        public async Task<string> Repo_AddPlaneVereity(PlaneVarietyModel planeVarietyModel)
        {
            PlaneVarietyDBTable planeVarietyDBTable = new PlaneVarietyDBTable()
            {
                PlaneVariety = planeVarietyModel.PlaneVariety
            };

            await _aJStudioContext.PlaneVarietyTable.AddAsync(planeVarietyDBTable);
            await _aJStudioContext.SaveChangesAsync();

            return planeVarietyDBTable.PlaneVariety_Id.ToString();
        }

        /// <summary>
        /// Update the Plane Vereity into the database
        /// </summary>
        /// <param name="planeVarietyModel"></param>
        /// <returns></returns>
        public async Task<long> Repo_UpdatePlaneVereity(PlaneVarietyModel planeVarietyModel)
        {
            var existingPlaneVereity = await _aJStudioContext.PlaneVarietyTable.Where(x => x.PlaneVariety_Id == planeVarietyModel.PlaneVariety_Id).SingleOrDefaultAsync();

            if (existingPlaneVereity == null)
            {
                return 0;
            }

            _aJStudioContext.Entry(existingPlaneVereity).CurrentValues.SetValues(planeVarietyModel);
            await _aJStudioContext.SaveChangesAsync();
            return planeVarietyModel.PlaneVariety_Id;
        }

        /// <summary>
        /// Delete plane vereity from the database
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <returns></returns>
        public async Task<int> Repo_DeletePlaneVereity(long planeVereityId)
        {
            var planeVereity = await _aJStudioContext.PlaneVarietyTable.FindAsync(planeVereityId);

            if (planeVereity == null)
            {
                return 0;
            }

            _aJStudioContext.PlaneVarietyTable.Remove(planeVereity);
            return await _aJStudioContext.SaveChangesAsync();
        }

        /// <summary>
        /// check the Plane Vereity into the database while Add the Customer
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <param name="planeVereity"></param>
        /// <returns></returns>
        public async Task<bool> Repo_CheckPlaneVereity(string planeVereity)
        {
            if (planeVereity != null)
            {
                var isPlaneVereityAddExist = await _aJStudioContext.PlaneVarietyTable.Where(x => x.PlaneVariety == planeVereity).FirstOrDefaultAsync();

                if (isPlaneVereityAddExist != null)
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
        /// check the Plane Vereity into the database while Update the Customer
        /// Overried method of Add.
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <param name="planeVereity"></param>
        /// <returns></returns>
        public async Task<bool> Repo_CheckPlaneVereity(long? planeVereityId, string planeVereity)
        {
            if(planeVereityId != null && planeVereity != null)
            {
                var isPlaneVereityUpdateExist = await _aJStudioContext.PlaneVarietyTable.Where(x => x.PlaneVariety_Id != planeVereityId && x.PlaneVariety == planeVereity).FirstOrDefaultAsync();

                if (isPlaneVereityUpdateExist != null)
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
