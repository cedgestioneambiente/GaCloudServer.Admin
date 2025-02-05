using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Dtos.Common;
using GaCloudServer.BusinnessLogic.DTOs.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations.Schema;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi
{
    #region OLD
    #region PreventiviAnticipiTipologie
    public class PreventiviAnticipoTipologiaDto : GenericListDto
    {
    }

    public class PreventiviAnticipiTipologieDto : GenericPagedListDto<PreventiviAnticipoTipologiaDto>
    {
    }

    #endregion

    #region PreventiviAnticipiPagamenti
    public class PreventiviAnticipoPagamentoDto : GenericListDto
    {
    }

    public class PreventiviAnticipiPagamentiDto : GenericPagedListDto<PreventiviAnticipoPagamentoDto>
    {
    }

    #endregion

    #region PreventiviAnticipi
    public class PreventiviAnticipoDto : GenericDto
    {
        public string? RagioneSociale { get; set; }
        public string? Numero { get; set; }
        public DateTime? DataPreventivo { get; set; }
        public DateTime? DataPagamento { get; set; }
        public string? CfPiva { get; set; }
        public double? Incassato { get; set; }
        public double? ImportoTotale { get; set; }
        public double? Anticipo { get; set; }
        public string? NoteContabili { get; set; }
        public string? NoteOperative { get; set; }
        public string? Causale { get; set; }
        public bool Pagato { get; set; }
        public bool Fatturato { get; set; }
        public bool RegistratoContabilita { get; set; }
        public long PreventiviAnticipoTipologiaId { get; set; }
        public long? PreventiviAnticipoPagamentoId { get; set; }
    }

    public class PreventiviAnticipiDto : GenericPagedListDto<PreventiviAnticipoDto>
    {
    }

    #endregion

    #region PreventiviAnticipiAllegati
    public class PreventiviAnticipoAllegatoDto : GenericFileDto
    {
        public string? Descrizione { get; set; }
        public long PreventiviAnticipoId { get; set; }
    }

    public class PreventiviAnticipiAllegatiDto : GenericPagedListDto<PreventiviAnticipoAllegatoDto>
    {
    }

    #endregion
    #endregion

    #region PreventiviObject
    public class PreventiviObjectDto : GenericDto
    {
        public string ObjectNumber { get; set; }
        public DateTime DataInserimento { get; set; }
        public string CodComune { get; set; }
        public string ClienteComune { get; set; }
        public string CodCliente { get; set; }
        public string Cliente { get; set; }
        public string ClienteIndirizzo { get; set; }
        public string ClienteCfPiva { get; set; }
        public string ClienteCodSdi { get; set; }
        public string Intestatario { get; set; }
        public string IntestatarioComune { get; set; }
        public string IntestatarioIndirizzo { get; set; }
        public string? IntestatarioIndirizzoOperativo { get; set; }
        public string IntestatarioCfPiva { get; set; }
        public string? IntestatarioPiva { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        public long TypeId { get; set; }
        public string TypeDesc {  get; set; }
        public long StatusId { get; set; }
        public string AssigneeId { get; set; }
        public string AssigneeDesc { get; set; }
        public DateTime DataCompletamento { get; set; }
        public bool Completed { get; set; }
        public string NoteCrm { get; set; }
        public string NoteOperative { get; set; }

        public bool? FinancialLock { get; set; }
        public bool? FinancialForcedLock { get; set; }
        public string? FinancialLockDetail { get; set; }
        public DateTime? FinancialUnlockDate { get; set; }
        public string? FinancialUnlockUserId { get; set; }
        public string? FinancialUnlockUserName { get; set; }

        public DateTime? FinancialUnlockRequestDate { get; set; }
        public string? FinancialUnlockRequestUserId { get; set; }
        public string? FinancialUnlockRequestUserName { get; set; }

        public DateTime? DataScadenza { get; set; }
        public int Priority { get; set; }
        public string PriorityDesc { get; set; }

        public string IndirizzoSede { get; set; }
        public string IndirizzoFattura { get; set; }
        public bool CausalePag770s { get; set; }

        public string AssigneeMail { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }
        public bool? SendEmail { get; set; }
        public bool? SendNotify { get; set; }

        //Campo note per passaggio note assegnazione
        public string Note { get; set; }

        //Navigation Props
        public PreventiviObjectStatusDto Status { get; set; }
        public PreventiviObjectTypeDto Type { get; set; }


    }
    public class PreventiviObjectStatusDto : GenericListDto
    {
        public int? Order { get; set; }
    }
    public class PreventiviObjectTypeDto : GenericListDto
    {
    }
    public class PreventiviActionDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string UserId { get; set; }
        public DateTime Data { get; set; }
        public string Link { get; set; }
        public long ObjectId { get; set; }

    }
    public class PreventiviObjectAttachmentDto : GenericFileDto
    {
        public long ObjectId { get; set; }
        public string Descrizione { get; set; }
        public IFormFile? File { get; set; }
        public bool uploadFile { get; set; }
        public bool deleteFile { get; set; }
    }
    public class PreventiviObjectInspectionDto : GenericDto
    {
        public long ObjectId { get; set; }
        public DateTime? DateInspection { get; set; }
        public DateTime? DateExecution { get; set; }
        public string AssigneeId { get; set; }
        public long ModeId { get; set; }
        public long StatusId { get; set; }
        public string Note { get; set; }
        public string NoteInspection { get; set; }
        public bool Canceled { get; set; }

    }
    public class PreventiviObjectInspectionAttachmentDto : GenericFileDto
    {
        public long ObjectInspectionId { get; set; }
        public string Descrizione { get; set; }
        public IFormFile? File { get; set; }
        public bool uploadFile { get; set; }
        public bool deleteFile { get; set; }
    }
    public class PreventiviObjectInspectionImageDto : GenericFileDto
    {
        public long ObjectInspectionId { get; set; }
        public string Descrizione { get; set; }
        public IFormFile? File { get; set; }
        public bool uploadFile { get; set; }
        public bool deleteFile { get; set; }
    }
    public class PreventiviObjectInspectionModeDto : GenericListDto
    {
    }
    public class PreventiviObjectServiceTypeDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string? Notes { get; set; }
    }
    public class PreventiviObjectServiceTypeDetailDto : GenericDto
    {
        public long ServiceTypeId { get; set; }
        public string Descrizione { get; set; }
        public long GaugeId { get; set; }
        public string? Notes { get; set; }

        public CommonGaugeDto Gauge { get; set; }
    }
    public class PreventiviObjectServiceDto : GenericDto
    {
        public int Order { get; set; }
        public long ObjectId { get; set; }
        public long SectionId { get; set; }
        public string Descrizione { get; set; }
        public long ServiceTypeId { get; set; }
        public long ServiceTypeDetailId { get; set; }
        public long IvaCodeId { get; set; }
        public double Amount { get; set; }
        public bool ShowAmountOnPrint { get; set; }
        public double CostUnit { get; set; }
        public double CostTotal { get; set; }

        public string Notes { get; set; }
        public string NotesExtra { get; set; }
        public bool Analysis { get; set; }
        public string AnalysisDesc { get; set; }
        public bool Accepted { get; set; }

        public PreventiviObjectServiceTypeDto? ServiceType { get; set; }
        public PreventiviObjectServiceTypeDetailDto? ServiceTypeDetail { get; set; }
        public PreventiviObjectSectionDto? Section { get; set; }
        public CommonIvaCodeDto? IvaCode { get; set; }

    }
    public class PreventiviObjectSectionDto : GenericDto
    {
        public int Order { get; set; }
        public long ObjectId { get; set; }
        public string Descrizione { get; set; }
        public string? Note { get; set; }
        public long ProducerId { get; set; }
        public long DestinationId { get; set; }
        public bool DestinationOnPrint { get; set; }
        public bool TotalOnPrint { get; set; }
        public string Garbages { get; set; }
        public bool Accepted { get; set; }

        //Navigation Props
        public PreventiviProducerDto? Producer { get; set; }
        public PreventiviObjectDto? Object { get; set; }
        public PreventiviDestinationDto? Destination { get; set; }

    }

    public class PreventiviGarbageDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Code { get; set; }
        public string Note { get; set; }
        public bool Dangerous { get; set; }
        public bool Analysis { get; set; }
    }
    public class PreventiviServiceNoteTemplateDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Content { get; set; }
    }
    public class PreventiviConditionTemplateDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Content { get; set; }
    }
    public class PreventiviObjectPeriodDto : GenericDto
    {
        public string Descrizione { get; set; }
        public int DayValid { get; set; }
    }

    public class PreventiviPaymentTermDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Code { get; set; }
    }
    public class PreventiviObjectPayoutDto : GenericDto
    {
        public long ObjectId { get; set; }
        public long PaymentTermId { get; set; }
        public string Descrizione { get; set; }
        public DateTime DateValid { get; set; }
        public string Notes { get; set; }
        public long BankAccountId { get; set; }
        public long PeriodId { get; set; }
        public double Deposit {  get; set; }
        public string Note { get; set; }

        public PreventiviObjectPeriodDto Period { get; set; }
        public CommonBankAccountDto BankAccount { get; set; }
        public PreventiviPaymentTermDto PaymentTerm { get; set; }
    }
    public class PreventiviObjectConditionDto:GenericDto
    {
        public long ObjectId { get; set; }
        public int Order { get; set; }
        public string Descrizione { get; set; }

    }
    public class PreventiviProducerDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Ignore {  get; set; }
    }
    public class PreventiviDestinationDto : GenericDto
    {
        public string Descrizione { get; set; }
        public string Indirizzo { get; set; }
        public string CfPiva { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public bool Ignore { get; set; }
    }

    public class PreventiviObjectHistoryDto:GenericDto {
        public long ObjectId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime? DateEnd { get; set; }
        public string AssigneeId { get; set; }
        public string AssigneeDesc { get; set; }


        public long StatusId { get; set; }
        public string Note { get; set; }

        //Navigation Props
        public PreventiviObjectDto Object { get; set; }
        public PreventiviObjectStatusDto Status { get; set; }

    }
    #endregion

    #region Extras
    public class PreventiviObjectAssignementDto : GenericDto
    {
        public string CodComune { get; set; }
        public string ClienteComune { get; set; }
        public string CodCliente { get; set; }
        public string Cliente { get; set; }
        public string ClienteIndirizzo { get; set; }
        public string ClienteCfPiva { get; set; }
        public string ClienteCodSdi { get; set; }
        public string Intestatario { get; set; }
        public string IntestatarioComune { get; set; }
        public string IntestatarioIndirizzo { get; set; }
        public string? IntestatarioIndirizzoOperativo { get; set; }
        public string IntestatarioCfPiva { get; set; }
        public string? IntestatarioPiva { get; set; }
        public string Telefono { get; set; }
        public string Cellulare { get; set; }
        public string Email { get; set; }
        public string EmailPec { get; set; }
        public long TypeId { get; set; }
        public long? StatusId { get; set; }
        public string AssigneeId { get; set; }
        public string? AssigneeMail { get; set; }
        public string? NoteCrm { get; set; }
        public string? NoteOperative { get; set; }

        public long Inspection {  get; set; }
        public string? InspectionAssigneeId { get; set; }
        public string? InspectionAssigneeMail { get; set; }
        public string? InspectionNotes { get; set; }

        public bool? Attachments {  get; set; }
        public bool? SendNotify { get; set; }
        public bool? SendEmail { get; set; }
        public long? CrmTicketId { get; set; }
        public string CreatorId { get; set; }
        public string CreatorName { get; set; }


    }

    public class PreventiviObjectInspectionStatementDto
    { 
        public long Id { get; set; }
        public string ObjectNumber { get; set; }
        public string AssigneeMail { get; set; }
        public string AssigneeId { get; set; }
        public string InspectionAssigneeMail { get; set; }
        public string InspectionAssigneeId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorId { get; set; }
        public string Note {  get; set; }
        public string NoteInspection { get; set; }

        public bool? SendManager { get; set; }
        public bool? SendInspector { get; set;}

    }

    public class PreventiviSubjectFinancialDto
    {
        public long Id { get; set; }
        public string ObjectNumber { get; set; }
        public string AssigneeMail { get; set; }
        public string AssigneeId { get; set; }
        public string InspectionAssigneeMail { get; set; }
        public string InspectionAssigneeId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorId { get; set; }
        public string Note { get; set; }

    }
    #endregion
}