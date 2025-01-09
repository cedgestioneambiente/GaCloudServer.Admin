using AutoMapper;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Crm;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi.Views;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Crm;
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

            CreateMap<PreventiviObjectServiceTypeDto, PreventiviObjectServiceType>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectServiceTypeDto>, PageResponse<PreventiviObjectServiceType>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectServiceTypeDetailDto, PreventiviObjectServiceTypeDetail>(MemberList.Destination)
                .ForMember(dest => dest.Gauge, opt => opt.Ignore())
                .ReverseMap();
            CreateMap<PageResponse<PreventiviObjectServiceTypeDetailDto>, PageResponse<PreventiviObjectServiceTypeDetail>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectSectionDto, PreventiviObjectSection>(MemberList.Destination)
                .ForMember(dest => dest.Destination, opt => opt.Ignore())
                .ForMember(dest => dest.Producer, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PageResponse<PreventiviObjectSectionDto>, PageResponse<PreventiviObjectSection>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectServiceDto, PreventiviObjectService>(MemberList.Destination)
                .ForMember(dest => dest.ServiceType, opt => opt.Ignore())
                .ForMember(dest => dest.ServiceTypeDetail, opt => opt.Ignore())
                .ForMember(dest => dest.IvaCode, opt => opt.Ignore())
                .ForMember(dest => dest.Section, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<PageResponse<PreventiviObjectServiceDto>, PageResponse<PreventiviObjectService>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviGarbageDto, PreventiviGarbage>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviGarbageDto>, PageResponse<PreventiviGarbage>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviServiceNoteTemplateDto, PreventiviServiceNoteTemplate>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviServiceNoteTemplateDto>, PageResponse<PreventiviServiceNoteTemplate>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviConditionTemplateDto, PreventiviConditionTemplate>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviConditionTemplateDto>, PageResponse<PreventiviConditionTemplate>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectPeriodDto, PreventiviObjectPeriod>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectPeriodDto>, PageResponse<PreventiviObjectPeriod>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectPayoutDto, PreventiviObjectPayout>(MemberList.Destination)
                .ForMember(dest => dest.BankAccount,opt => opt.Ignore())
                .ForMember(dest => dest.Period, opt=> opt.Ignore())
                .ReverseMap();
            CreateMap<PageResponse<PreventiviObjectPayoutDto>, PageResponse<PreventiviObjectPayout>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectConditionDto, PreventiviObjectCondition>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviObjectConditionDto>, PageResponse<PreventiviObjectCondition>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviProducerDto, PreventiviProducer>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviProducerDto>, PageResponse<PreventiviProducer>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviDestinationDto, PreventiviDestination>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviDestinationDto>, PageResponse<PreventiviDestination>>(MemberList.Destination).ReverseMap();

            CreateMap<CrmEventComuneDto, CrmEventComune>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<CrmEventComuneDto>, PageResponse<CrmEventComune>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviObjectHistoryDto, PreventiviObjectHistory>(MemberList.Destination)
               .ForMember(dest => dest.Status, opt => opt.Ignore())
               .ForMember(dest => dest.Object, opt => opt.Ignore())
               .ReverseMap();
            CreateMap<PageResponse<PreventiviObjectHistoryDto>, PageResponse<PreventiviObjectHistory>>(MemberList.Destination).ReverseMap();

            CreateMap<PreventiviPaymentTermDto, PreventiviPaymentTerm>(MemberList.Destination).ReverseMap();
            CreateMap<PageResponse<PreventiviPaymentTermDto>, PageResponse<PreventiviPaymentTerm>>(MemberList.Destination).ReverseMap();

        }
    }
}

