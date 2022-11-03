using AutoMapper;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Personale;
using GaCloudServer.Resources.Api.Dtos.Resources.Personale;

namespace GaCloudServer.Resources.Api.Mappers.Personale
{
    public class PersonaleMapperProfile : Profile
    {
        public PersonaleMapperProfile()
        {
            //PersonaleQualifiche
            CreateMap<PersonaleQualificaDto, PersonaleQualificaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleQualificheDto, PersonaleQualificheApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAssunzioni
            CreateMap<PersonaleScadenzaTipoDto, PersonaleScadenzaTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleAssunzioniDto, PersonaleAssunzioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleDipendenti
            CreateMap<PersonaleDipendenteDto, PersonaleDipendenteApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleDipendentiDto, PersonaleDipendentiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleDipendentiScadenze
            CreateMap<PersonaleDipendenteScadenzaDto, PersonaleDipendenteScadenzaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleDipendentiScadenzeDto, PersonaleDipendentiScadenzeApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleScadenzeTipi
            CreateMap<PersonaleScadenzaTipoDto, PersonaleScadenzaTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleScadenzeTipiDto, PersonaleScadenzeTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleScadenzeDettagli
            CreateMap<PersonaleScadenzaDettaglioDto, PersonaleScadenzaDettaglioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleScadenzeDettagliDto, PersonaleScadenzeDettagliApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSanzioniMotivi
            CreateMap<PersonaleSanzioneMotivoDto, PersonaleSanzioneMotivoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleSanzioniMotiviDto, PersonaleSanzioniMotiviApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSanzioniDescrizioni
            CreateMap<PersonaleSanzioneDescrizioneDto, PersonaleSanzioneDescrizioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleSanzioniDescrizioniDto, PersonaleSanzioniDescrizioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSanzioni
            CreateMap<PersonaleSanzioneDto, PersonaleSanzioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleSanzioniDto, PersonaleSanzioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAbilitazioniTipi
            CreateMap<PersonaleAbilitazioneTipoDto, PersonaleAbilitazioneTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleAbilitazioniTipiDto, PersonaleAbilitazioniTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleAbilitazioni
            CreateMap<PersonaleAbilitazioneDto, PersonaleAbilitazioneApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleAbilitazioniDto, PersonaleAbilitazioniApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleRetributiviTipi
            CreateMap<PersonaleRetributivoTipoDto, PersonaleRetributivoTipoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleRetributiviTipiDto, PersonaleRetributiviTipiApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleRetributivi
            CreateMap<PersonaleRetributivoDto, PersonaleRetributivoApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleRetributiviDto, PersonaleRetributiviApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSchedeConsegne
            CreateMap<PersonaleSchedaConsegnaDto, PersonaleSchedaConsegnaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleSchedeConsegneDto, PersonaleSchedeConsegneApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleSchedeConsegnaDettagli
            CreateMap<PersonaleSchedaConsegnaDettaglioDto, PersonaleSchedaConsegnaDettaglioApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleSchedeConsegneDettagliDto, PersonaleSchedeConsegneDettagliApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoliModelli
            CreateMap<PersonaleArticoloModelloDto, PersonaleArticoloModelloApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleArticoliModelliDto, PersonaleArticoliModelliApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoliTipologie
            CreateMap<PersonaleArticoloTipologiaDto, PersonaleArticoloTipologiaApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleArticoliTipologieDto, PersonaleArticoliTipologieApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoliDpis
            CreateMap<PersonaleArticoloDpiDto, PersonaleArticoloDpiApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleArticoliDpisDto, PersonaleArticoliDpisApiDto>(MemberList.Destination)
                .ReverseMap();

            //PersonaleArticoli
            CreateMap<PersonaleArticoloDto, PersonaleArticoloApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PersonaleArticoliDto, PersonaleArticoliApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
