using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.Shared;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinessLogic.Mappers.Preventivi
{
    internal class PreventiviMapperProfile : Profile
    {
        public PreventiviMapperProfile()
        {
            #region OLD
            //PreventiviAnticipiTipologie
            CreateMap<PreventiviAnticipoTipologia, PreventiviAnticipoTipologiaDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipoTipologia>, PreventiviAnticipiTipologieDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipiPagamenti
            CreateMap<PreventiviAnticipoPagamento, PreventiviAnticipoPagamentoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipoPagamento>, PreventiviAnticipiPagamentiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipi
            CreateMap<PreventiviAnticipo, PreventiviAnticipoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipo>, PreventiviAnticipiDto>(MemberList.Destination)
                .ReverseMap();

            //PreventiviAnticipiAllegati
            CreateMap<PreventiviAnticipoAllegato, PreventiviAnticipoAllegatoDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<PreventiviAnticipoAllegato>, PreventiviAnticipiAllegatiDto>(MemberList.Destination)
                .ReverseMap();

            #endregion

            //Preventivi

            CreateMap<PreventiviObjectDto, PreventiviObject>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectDto>, PageResponse<PreventiviObject>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectAttachmentDto, PreventiviObjectAttachment>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectAttachmentDto>, PageResponse<PreventiviObjectAttachment>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectStatusDto, PreventiviObjectStatus>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectStatusDto>, PageResponse<PreventiviObjectStatus>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectTypeDto, PreventiviObjectType>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectTypeDto>, PageResponse<PreventiviObjectType>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviActionDto, PreventiviAction>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviActionDto>, PageResponse<PreventiviAction>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectInspectionModeDto, PreventiviObjectInspectionMode>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectInspectionModeDto>, PageResponse<PreventiviObjectInspectionMode>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectInspectionDto, PreventiviObjectInspection>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectInspectionDto>, PageResponse<PreventiviObjectInspection>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectInspectionAttachmentDto, PreventiviObjectInspectionAttachment>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectInspectionAttachmentDto>, PageResponse<PreventiviObjectInspectionAttachment>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectInspectionImageDto, PreventiviObjectInspectionImage>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectInspectionImageDto>, PageResponse<PreventiviObjectInspectionImage>>(MemberList.Destination).ReverseMap();

        }
    }
}

