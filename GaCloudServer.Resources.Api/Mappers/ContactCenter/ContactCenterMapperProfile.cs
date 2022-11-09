using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.ContactCenter;
using GaCloudServer.Resources.Api.Dtos.Resources.ContactCenter;


namespace GaCloudServer.Resources.Api.Mappers.ContactCenter
{
    public class ContactCenterMapperProfile : Profile
    {
        public ContactCenterMapperProfile()
        {
            //ContactCenterComuni
            CreateMap<ContactCenterComuneDto, ContactCenterComuneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterComuniDto, ContactCenterComuniApiDto > (MemberList.Destination)
                .ReverseMap();

            //ContactCenterProvenienze
            CreateMap<ContactCenterProvenienzaDto, ContactCenterProvenienzaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterProvenienzeDto, ContactCenterProvenienzeApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterStatiRichieste
            CreateMap<ContactCenterStatoRichiestaDto, ContactCenterStatoRichiestaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterStatiRichiesteDto, ContactCenterStatiRichiesteApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTipiRichieste
            CreateMap<ContactCenterTipoRichiestaDto, ContactCenterTipoRichiestaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterTipiRichiesteDto, ContactCenterTipiRichiesteApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterMails
            CreateMap<ContactCenterMailDto, ContactCenterMailApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterMailsDto, ContactCenterMailsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterAllegati
            CreateMap<ContactCenterAllegatoDto, ContactCenterAllegatoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterAllegatiDto, ContactCenterAllegatiApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterMailsOnTickets
            CreateMap<ContactCenterMailOnTicketDto, ContactCenterMailOnTicketApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterMailsOnTicketsDto, ContactCenterMailsOnTicketsApiDto>(MemberList.Destination)
                .ReverseMap();

            //ContactCenterTickets
            CreateMap<ContactCenterTicketDto, ContactCenterTicketApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ContactCenterTicketsDto, ContactCenterTicketsApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}


