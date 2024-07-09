using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Common;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.Shared;

namespace GaCloudServer.BusinessLogic.Mappers.Common
{
    internal class CommonMapperProfile : Profile
    {
        public CommonMapperProfile()
        {

            CreateMap<CommonGaugeDto, Gauge>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CommonGaugeDto>, PageResponse<Gauge>>(MemberList.Destination).ReverseMap();

            CreateMap<CommonIvaCodeDto, IvaCode>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CommonIvaCodeDto>, PageResponse<IvaCode>>(MemberList.Destination).ReverseMap();

            CreateMap<CommonBankAccountDto, BankAccount>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CommonBankAccountDto>, PageResponse<BankAccount>>(MemberList.Destination).ReverseMap();
        }
    }
}

