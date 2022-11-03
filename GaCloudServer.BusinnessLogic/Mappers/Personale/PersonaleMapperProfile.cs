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

            //PersonaleSanzioniMotivi
            CreateMap<PersonaleSanzioneMotivo, PersonaleSanzioneMotivoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleSanzioneMotivo>, PersonaleSanzioniMotiviDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSanzioniDescrizioni
            CreateMap<PersonaleSanzioneDescrizione, PersonaleSanzioneDescrizioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleSanzioneDescrizione>, PersonaleSanzioniDescrizioniDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSanzioni
            CreateMap<PersonaleSanzione, PersonaleSanzioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleSanzione>, PersonaleSanzioniDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAbilitazioniTipi
            CreateMap<PersonaleAbilitazioneTipo, PersonaleAbilitazioneTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleAbilitazioneTipo>, PersonaleAbilitazioniTipiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAbilitazioni
            CreateMap<PersonaleAbilitazione, PersonaleAbilitazioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleAbilitazione>, PersonaleAbilitazioniDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleRetributiviTipi
            CreateMap<PersonaleRetributivoTipo, PersonaleRetributivoTipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleRetributivoTipo>, PersonaleRetributiviTipiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleRetributivi
            CreateMap<PersonaleRetributivo, PersonaleRetributivoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleRetributivo>, PersonaleRetributiviDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSchedeConsegne
            CreateMap<PersonaleSchedaConsegna, PersonaleSchedaConsegnaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleSchedaConsegna>, PersonaleSchedeConsegneDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSchedeConsegnaDettagli
            CreateMap<PersonaleSchedaConsegnaDettaglio, PersonaleSchedaConsegnaDettaglioDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleSchedaConsegnaDettaglio>, PersonaleSchedeConsegneDettagliDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoliModelli
            CreateMap<PersonaleArticoloModello, PersonaleArticoloModelloDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleArticoloModello>, PersonaleArticoliModelliDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoliTipologie
            CreateMap<PersonaleArticoloTipologia, PersonaleArticoloTipologiaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleArticoloTipologia>, PersonaleArticoliTipologieDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoliDpis
            CreateMap<PersonaleArticoloDpi, PersonaleArticoloDpiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleArticoloDpi>, PersonaleArticoliDpisDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoli
            CreateMap<PersonaleArticolo, PersonaleArticoloDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PersonaleArticolo>, PersonaleArticoliDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
