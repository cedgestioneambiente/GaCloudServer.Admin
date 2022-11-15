using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Mappers.Mezzi
{
    internal class MezziMapperProfile : Profile
    {
        public MezziMapperProfile()
        {
            CreateMap<MezziAlimentazione, MezziAlimentazioneDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziAlimentazione>, MezziAlimentazioniDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziClasse, MezziClasseDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziClasse>, MezziClassiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziPatente, MezziPatenteDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziPatente>, MezziPatentiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziPeriodoScadenza, MezziPeriodoScadenzaDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziPeriodoScadenza>, MezziPeriodiScadenzeDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziProprietario, MezziProprietarioDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziProprietario>, MezziProprietariDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziScadenzaTipo, MezziScadenzaTipoDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziScadenzaTipo>, MezziScadenzeTipiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziTipo, MezziTipoDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziTipo>, MezziTipiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziVeicolo, MezziVeicoloDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziVeicolo>, MezziVeicoliDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziScadenza, MezziScadenzaDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziScadenza>, MezziScadenzeDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<MezziDocumento, MezziDocumentoDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<PagedList<MezziDocumento>, MezziDocumentiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
