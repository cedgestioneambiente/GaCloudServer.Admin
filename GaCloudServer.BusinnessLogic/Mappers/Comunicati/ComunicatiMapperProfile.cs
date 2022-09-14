using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Comunicati;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Comunicati;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Comunicati
{
    internal class ComunicatiMapperProfile : Profile
    {
        public ComunicatiMapperProfile()
        {
            //GaComunicatiDocumenti Map
            CreateMap<ComunicatiDocumento, ComunicatiDocumentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ComunicatiDocumento>, ComunicatiDocumentiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
