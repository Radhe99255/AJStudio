using AJStudio.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AJStudio.Business.PlaneVariety
{
    public interface IPlaneVarietyManager
    {
        Task<List<PlaneVarietyModel>> Manager_GetAllPlaneVereitys();
        Task<PlaneVarietyModel> Manager_PlaneVereityById(long planeVereityId);
        Task<string> Manager_AddPlaneVereity(PlaneVarietyModel planeVarietyModel);
        Task<string> Manager_UpdatePlaneVereity(PlaneVarietyModel planeVarietyModel);
        Task<string> Manager_DeletePlaneVereity(long planeVereityId);
    }
}
