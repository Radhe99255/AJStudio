using AJStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Data.Repository.PlaneVariety
{
    public interface IPlaneVarietyRepository
    {
        Task<List<PlaneVarietyModel>> Repo_GetAllPlaneVereitys();
        Task<PlaneVarietyModel> Repo_PlaneVereityById(long planeVereityId);
        Task<string> Repo_AddPlaneVereity(PlaneVarietyModel planeVarietyModel);
        Task<long> Repo_UpdatePlaneVereity(PlaneVarietyModel planeVarietyModel);
        Task<int> Repo_DeletePlaneVereity(long planeVereityId);
        Task<bool> Repo_CheckPlaneVereity(string planeVereity);
        Task<bool> Repo_CheckPlaneVereity(long? planeVereityId, string planeVereity);
    }
}
