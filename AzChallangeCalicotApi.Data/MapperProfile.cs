using AutoMapper;
using ENTITIES = AzChallangeCalicotApi.Data.Entities;
using MODELS = AzChallangeCalicotApi.Type.Models;

namespace AzChallangeCalicotApi.Data
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ENTITIES.Produit, MODELS.Produit>();
            CreateMap<MODELS.Produit, ENTITIES.Produit>()
                .ForMember(opt => opt.Images, opt => opt.Ignore());

            CreateMap<ENTITIES.Image, MODELS.Image>();
            CreateMap<MODELS.Image, ENTITIES.Image>();
        }
    }
}
