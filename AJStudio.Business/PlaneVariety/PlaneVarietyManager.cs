using AJStudio.Core.Models;
using AJStudio.Data.Repository.PlaneVariety;

namespace AJStudio.Business.PlaneVariety
{
    public class PlaneVarietyManager : IPlaneVarietyManager
    {
        private readonly IPlaneVarietyRepository _planeVarietyRepository;

        /// <summary>
        /// Inject the Dependancy for the Repository to access the Repository
        /// </summary>
        /// <param name="contactUsRepository"></param>
        public PlaneVarietyManager(IPlaneVarietyRepository planeVarietyRepository)
        {
            _planeVarietyRepository = planeVarietyRepository;
        }

        /// <summary>
        /// Get the list of plane Vereitys from the repository
        /// </summary>
        /// <returns></returns>
        public async Task<List<PlaneVarietyModel>> Manager_GetAllPlaneVereitys()
        {
            return await _planeVarietyRepository.Repo_GetAllPlaneVereitys();
        }

        /// <summary>
        /// Get the plane vereity by plane vereity id from the repository
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <returns></returns>
        public async Task<PlaneVarietyModel> Manager_PlaneVereityById(long planeVereityId)
        {
            return await _planeVarietyRepository.Repo_PlaneVereityById(planeVereityId);
        }

        /// <summary>
        /// Add the plane vereity into the repository with validation of vereity name
        /// </summary>
        /// <param name="planeVarietyModel"></param>
        /// <returns></returns>
        public async Task<string> Manager_AddPlaneVereity(PlaneVarietyModel planeVarietyModel)
        {
            var checkPlaneVereity = await _planeVarietyRepository.Repo_CheckPlaneVereity(planeVarietyModel.PlaneVariety);

            if (checkPlaneVereity)
            {
                return "Exist";
            }

            return await _planeVarietyRepository.Repo_AddPlaneVereity(planeVarietyModel);
        }

        /// <summary>
        /// Update Plane Vereity into the Repository
        /// </summary>
        /// <param name="planeVarietyModel"></param>
        /// <returns></returns>
        public async Task<string> Manager_UpdatePlaneVereity(PlaneVarietyModel planeVarietyModel)
        {
            var checkPlaneVereityWithId = await _planeVarietyRepository.Repo_CheckPlaneVereity(planeVarietyModel.PlaneVariety_Id, planeVarietyModel.PlaneVariety);

            if (checkPlaneVereityWithId)
            {
                return "Exist";
            }

            var updateplaneVereity = await _planeVarietyRepository.Repo_UpdatePlaneVereity(planeVarietyModel);

            if (updateplaneVereity > 0)
            {
                return "Success";
            }

            return "Fail";
        }

        /// <summary>
        /// Delete Plane Vereity from the repository
        /// </summary>
        /// <param name="planeVereityId"></param>
        /// <returns></returns>
        public async Task<string> Manager_DeletePlaneVereity(long planeVereityId)
        {
            var deleteResult = await _planeVarietyRepository.Repo_DeletePlaneVereity(planeVereityId);

            if (deleteResult > 0)
            {
                return "Success";
            }

            return "Fail";
        }
    }
}
