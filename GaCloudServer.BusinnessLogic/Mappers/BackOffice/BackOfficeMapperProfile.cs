using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.BackOffice;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Aziende
{
    internal class BackOfficeMapperProfile : Profile
    {
        public BackOfficeMapperProfile()
        {
            //AziendeListe
            CreateMap<BackOfficeDocReceipt, BackOfficeDocReceiptDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<BackOfficeDocReceipt>, BackOfficeDocRecipesDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

