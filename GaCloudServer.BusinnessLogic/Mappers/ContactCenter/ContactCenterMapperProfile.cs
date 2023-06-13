using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.ContactCenter;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.ContactCenter
{
    internal class ContactCenterMapperProfile : Profile
    {
        public ContactCenterMapperProfile()
        {
            //ContactCenterComuni
            CreateMap<ContactCenterComune, ContactCenterComuneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterComune>, ContactCenterComuniDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterProvenienze
            CreateMap<ContactCenterProvenienza, ContactCenterProvenienzaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterProvenienza>, ContactCenterProvenienzeDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterStatiRichieste
            CreateMap<ContactCenterStatoRichiesta, ContactCenterStatoRichiestaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterStatoRichiesta>, ContactCenterStatiRichiesteDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTipiRichieste
            CreateMap<ContactCenterTipoRichiesta, ContactCenterTipoRichiestaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterTipoRichiesta>, ContactCenterTipiRichiesteDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterMails
            CreateMap<ContactCenterMail, ContactCenterMailDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterMail>, ContactCenterMailsDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterAllegati
            CreateMap<ContactCenterAllegato, ContactCenterAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterAllegato>, ContactCenterAllegatiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterMailsOnTickets
            CreateMap<ContactCenterMailOnTicket, ContactCenterMailOnTicketDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterMailOnTicket>, ContactCenterMailsOnTicketsDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTickets
            CreateMap<ContactCenterTicket, ContactCenterTicketDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterTicket>, ContactCenterTicketsDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTickets
            CreateMap<ContactCenterPrintTemplate, ContactCenterPrintTemplateDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ContactCenterPrintTemplate>, ContactCenterPrintTemplatesDto>(MemberList.Destination)
                .ReverseMap();

        }
    }
}

