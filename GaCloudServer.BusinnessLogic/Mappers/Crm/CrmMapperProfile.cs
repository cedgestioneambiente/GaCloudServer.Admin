using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Crm
{
    internal class CrmMapperProfile : Profile
    {
        public CrmMapperProfile()
        {
            //CrmEventState
            CreateMap<CrmEventState, CrmEventStateDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmEventState>, CrmEventStatesDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEventArea
            CreateMap<CrmEventArea, CrmEventAreaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmEventArea>, CrmEventAreasDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEventComuni
            CreateMap<CrmEventComune, CrmEventComuneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmEventComune>, CrmEventComuniDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEvent
            CreateMap<CrmEvent, CrmEventDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmEvent>, CrmEventsDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEventDevice
            CreateMap<CrmEventDevice, CrmEventDeviceDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmEventDevice>, CrmEventDevicesDto>(MemberList.Destination)
                .ReverseMap();

            //CrmEvent
            CreateMap<CrmTicket, CrmTicketDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmTicket>, CrmTicketsDto>(MemberList.Destination)
                .ReverseMap();

            //CrmTicketAllegati
            CreateMap<CrmTicketAllegato, CrmTicketAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmTicketAllegato>, CrmTicketAllegatiDto>(MemberList.Destination)
                .ReverseMap();

            //CrmTicketTags
            CreateMap<CrmTicketTag, CrmTicketTagDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<CrmTicketTag>, CrmTicketTagsDto>(MemberList.Destination)
                .ReverseMap();


        }
    }
}
