using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.BackOffice;
using GaCloudServer.Resources.Api.Dtos.Resources.BackOffice;

namespace GaCloudServer.Resources.Api.Mappers.BackOffice
{
    public class BackOfficeMapperProfile : Profile
    {
        public BackOfficeMapperProfile()
        {
            //AziendeListe
            CreateMap<BackOfficeDocReceiptDto, BackOfficeDocReceiptApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<BackOfficeDocRecipesDto, BackOfficeDocRecipesApiDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}
