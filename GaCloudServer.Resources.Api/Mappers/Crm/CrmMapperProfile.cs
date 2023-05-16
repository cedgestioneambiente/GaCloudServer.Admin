using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Csr;
using GaCloudServer.Resources.Api.Dtos.Crm;
using GaCloudServer.Resources.Api.Dtos.Csr;

namespace GaCloudServer.Resources.Api.Mappers.Crm
{
    public class CrmMapperProfile : Profile
    {
        public CrmMapperProfile()
        {
            //CrmEventState
            CreateMap<CrmEventStateDto, CrmEventStateApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CrmEventStatesDto, CrmEventStatesApiDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEventArea
            CreateMap<CrmEventAreaDto, CrmEventAreaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CrmEventAreasDto, CrmEventAreasApiDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEvent
            CreateMap<CrmEventDto, CrmEventApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CrmEventsDto, CrmEventsApiDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEvent
            CreateMap<CrmEventDeviceDto, CrmEventDeviceApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<CrmEventDevicesDto, CrmEventDevicesApiDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}
