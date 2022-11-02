using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;
using Skoruba.AuditLogging.EntityFramework.Helpers.Common;

namespace GaCloudServer.Resources.Api.Mappers.ContactCenter
{
    public class ContactCenterMapperProfile : Profile
    {
        public ContactCenterMapperProfile()
        {
            //ContactCenterComuni
            CreateMap<ContactCenterComuneDto, ContactCenterComuneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterComuniDto>, ContactCenterComuniApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterProvenienze
            CreateMap<ContactCenterProvenienzaDto, ContactCenterProvenienzaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterProvenienzeDto>, ContactCenterProvenienzeApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterStatiRichieste
            CreateMap<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiestaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterStatiRichiesteDto>, ContactCenterStatiRichiesteApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTipiRichieste
            CreateMap<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiestaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterTipiRichiesteDto>, ContactCenterTipiRichiesteApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterMails
            CreateMap<ContactCenterMailDto, ContactCenterMailApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterMailsDto>, ContactCenterMailsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterAllegati
            CreateMap<ContactCenterAllegatoDto, ContactCenterAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterAllegatiDto>, ContactCenterAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterMailsOnTickets
            CreateMap<ContactCenterMailOnTicketDto, ContactCenterMailOnTicketApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterMailsOnTicketsDto>, ContactCenterMailsOnTicketsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTickets
            CreateMap<ContactCenterTicketDto, ContactCenterTicketApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterTicketsDto>, ContactCenterTicketsApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}


