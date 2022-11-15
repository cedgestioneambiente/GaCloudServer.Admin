using GaCloudServer.BusinnessLogic.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Mezzi
{
    public class MezziTipoDto : GenericListDto
    {
    }

    public class MezziTipiDto : GenericPagedListDto<MezziTipoDto>
    {
    }

    public class MezziAlimentazioneDto : GenericListDto
    {
    }

    public class MezziAlimentazioniDto : GenericPagedListDto<MezziAlimentazioneDto>
    {
    }

    public class MezziClasseDto : GenericListDto
    {
    }

    public class MezziClassiDto : GenericPagedListDto<MezziClasseDto>
    {
    }

    public class MezziPatenteDto : GenericListDto
    {
    }

    public class MezziPatentiDto : GenericPagedListDto<MezziPatenteDto>
    {
    }

    public class MezziPeriodoScadenzaDto : GenericListDto
    {
    }

    public class MezziPeriodiScadenzeDto : GenericPagedListDto<MezziPeriodoScadenzaDto>
    {
    }

    public class MezziProprietarioDto : GenericListDto
    {
    }

    public class MezziProprietariDto : GenericPagedListDto<MezziProprietarioDto>
    {
    }

    public class MezziScadenzaTipoDto : GenericListDto
    {
    }

    public class MezziScadenzeTipiDto : GenericPagedListDto<MezziScadenzaTipoDto>
    {
    }

    public class MezziVeicoloDto : GenericDto
    {
        [Required(ErrorMessage ="Il campo Targa è obbligatorio.")]
        public string Targa { get; set; }
        public string? TargaPrecedente { get; set; }
        public string? Carro { get; set; }
        public string? Attrezzatura { get; set; }
        [Required(ErrorMessage ="Il campo Anno Immatricolazione è obbligatorio.")]
        public int AnnoImmatricolazione { get; set; }
        public string? AlboGestori { get; set; }
        public DateTime? ScadenzaContratto { get; set; }
        public string? Note { get; set; }
        public string? NumeroTelaio { get; set; }
        public int PortataKg { get; set; }
        public int MassaKg { get; set; }
        public bool Dismesso { get; set; }
        public DateTime? DismessoData { get; set; }
        public bool Ce { get; set; }
        public bool ManualeUsoManutenzione { get; set; }
        public bool CatalogoRicambi { get; set; }
        public long MezziTipoId { get; set; }
        public long MezziProprietarioId { get; set; }
        public long GlobalSedeId { get; set; }
        public long MezziClasseId { get; set; }
        public long MezziAlimentazioneId { get; set; }
        public long MezziPatenteId { get; set; }
        public long MezziPeriodoScadenzaId { get; set; }
        public bool Garanzia { get; set; }

    }

    public class MezziVeicoliDto : GenericPagedListDto<MezziVeicoliDto>
    { }

    public class MezziScadenzaDto : GenericFileDto
    {
        public long MezziVeicoloId { get; set; }
        public long MezziScadenzaTipoId { get; set; }
        public DateTime DataScadenza { get; set; }
        public DateTime? DataUltimaScadenza { get; set; }
        public string Note { get; set; }
    }

    public class MezziScadenzeDto : GenericPagedListDto<MezziScadenzaDto>
    { }

    public class MezziDocumentoDto : GenericFileDto
    {
        public string Descrizione { get; set; }
        public long MezziVeicoloId { get; set; }
    }

    public class MezziDocumentiDto : GenericPagedListDto<MezziDocumentoDto>
    { }
}
