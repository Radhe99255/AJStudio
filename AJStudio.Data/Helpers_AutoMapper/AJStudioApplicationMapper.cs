using AJStudio.Core.Models;
using AJStudio.Data.DBTables;
using AutoMapper;

namespace AJStudio.Data.Helpers_AutoMapper
{
    public class AJStudioApplicationMapper : Profile
    {
        public AJStudioApplicationMapper()
        {
            CreateMap<ContactUsDBTable,ContactUsModel>().ReverseMap();
            CreateMap<PlaneVarietyDBTable,PlaneVarietyModel>().ReverseMap();
            CreateMap<SuggestedDBTable,SuggestedModel>().ReverseMap();
        }
    }
}
