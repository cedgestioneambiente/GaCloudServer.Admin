using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Cdr;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Cdr
{
    public class CdrMapperProfile : Profile
    {
        public CdrMapperProfile()
        {
            //GaCdrCentri Map
            CreateMap<CdrCentro, CdrCentroDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CdrCentro>, CdrCentriDto>(MemberList.Destination)
                .ReverseMap();

            
        }
    }
}