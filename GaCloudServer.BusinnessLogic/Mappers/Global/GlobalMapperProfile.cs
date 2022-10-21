using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Global;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Global;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.Global
{
    internal class GlobalMapperProfile : Profile
    {
        public GlobalMapperProfile()
        {
            //GlobalSedi
            CreateMap<GlobalSede, GlobalSedeDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<GlobalSede>, GlobalSediDto>(MemberList.Destination)
                .ReverseMap();

            //GlobalCentriCosti
            CreateMap<GlobalCentroCosto, GlobalCentroCostoDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<GlobalCentroCosto>, GlobalCentriCostiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
