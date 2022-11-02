using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Personale
{
    internal class PersonaleMapperProfile : Profile
    {
        public PersonaleMapperProfile()
        {
            //PersonaleQualifiche
            CreateMap<PersonaleQualifica, PersonaleQualificaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleQualifica>, PersonaleQualificheDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAssunzioni
            CreateMap<PersonaleAssunzione, PersonaleAssunzioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleAssunzione>, PersonaleAssunzioniDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleDipendenti
            CreateMap<PersonaleDipendente, PersonaleDipendenteDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleDipendente>, PersonaleDipendentiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleDipendentiScadenze
            CreateMap<PersonaleDipendenteScadenza, PersonaleDipendenteScadenzaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleDipendenteScadenza>, PersonaleDipendentiScadenzeDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleScadenzeTipi
            CreateMap<PersonaleScadenzaTipo, PersonaleScadenzaTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleScadenzaTipo>, PersonaleScadenzeTipiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleScadenzeDettagli
            CreateMap<PersonaleScadenzaDettaglio, PersonaleScadenzaDettaglioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleScadenzaDettaglio>, PersonaleScadenzeDettagliDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
