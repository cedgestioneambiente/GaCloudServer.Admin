using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Reclami;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Reclami;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Reclami
{
    internal class ReclamiMapperProfile : Profile
    {
        public ReclamiMapperProfile()
        {
            //ReclamiMittenti
            CreateMap<ReclamiMittente, ReclamiMittenteDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiMittente>, ReclamiMittentiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiStati
            CreateMap<ReclamiStato, ReclamiStatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiStato>, ReclamiStatiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiTempiRisposte
            CreateMap<ReclamiTempoRisposta, ReclamiTempoRispostaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiTempoRisposta>, ReclamiTempiRisposteDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiTipiAzioni
            CreateMap<ReclamiTipoAzione, ReclamiTipoAzioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiTipoAzione>, ReclamiTipiAzioniDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiTipiOrigini
            CreateMap<ReclamiTipoOrigine, ReclamiTipoOrigineDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiTipoOrigine>, ReclamiTipiOriginiDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiAzioni
            CreateMap<ReclamiAzione, ReclamiAzioneDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiAzione>, ReclamiAzioniDto>(MemberList.Destination)
                .ReverseMap();

            //ReclamiDocumenti
            CreateMap<ReclamiDocumento, ReclamiDocumentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<ReclamiDocumento>, ReclamiDocumentiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}

