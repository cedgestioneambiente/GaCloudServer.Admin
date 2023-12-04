using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Previsio;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Previsio;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Previsio
{
    internal class PrevisioMapperProfile : Profile
    {
        public PrevisioMapperProfile()
        {
            //PrevisioOdsLetture
            CreateMap<PrevisioOdsLettura, PrevisioOdsLetturaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PrevisioOdsLettura>, PrevisioOdsLettureDto>(MemberList.Destination)
                .ReverseMap();

            //PrevisioAnomalieLetture
            CreateMap<PrevisioAnomaliaLettura, PrevisioAnomaliaLetturaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PrevisioAnomaliaLettura>, PrevisioAnomalieLettureDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}


