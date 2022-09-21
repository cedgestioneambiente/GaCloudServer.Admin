using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Resources.Mezzi
{
    public class MezziTipoApiDto : GenericListApiDto
    {
    }

    public class MezziTipiApiDto : GenericPagedListApiDto<MezziTipoApiDto>
    {
    }

    public class MezziAlimentazioneApiDto : GenericListApiDto
    {
    }

    public class MezziAlimentazioniApiDto : GenericPagedListApiDto<MezziAlimentazioneApiDto>
    {
    }

    public class MezziCantiereApiDto : GenericListApiDto
    {
    }

    public class MezziCantieriApiDto : GenericPagedListApiDto<MezziCantiereApiDto>
    {
    }

    public class MezziClasseApiDto : GenericListApiDto
    {
    }

    public class MezziClassiApiDto : GenericPagedListApiDto<MezziClasseApiDto>
    {
    }

    public class MezziPatenteApiDto : GenericListApiDto
    {
    }

    public class MezziPatentiApiDto : GenericPagedListApiDto<MezziPatenteApiDto>
    {
    }

    public class MezziPeriodoScadenzaApiDto : GenericListApiDto
    {
    }

    public class MezziPeriodiScadenzeApiDto : GenericPagedListApiDto<MezziPeriodoScadenzaApiDto>
    {
    }

    public class MezziProprietarioApiDto : GenericListApiDto
    {
    }

    public class MezziProprietariApiDto : GenericPagedListApiDto<MezziProprietarioApiDto>
    {
    }

    public class MezziScadenzaTipoApiDto : GenericListApiDto
    {
    }

    public class MezziScadenzeTipiApiDto : GenericPagedListApiDto<MezziScadenzaTipoApiDto>
    {
    }

    public class MezziVeicoloApiDto : GenericApiDto
    {
        [Required(ErrorMessage = "Il campo Targa è obbligatorio.")]
        public string Targa { get; set; }
        public string? TargaPrecedente { get; set; }
        public string? Carro { get; set; }
        public string? Attrezzatura { get; set; }
        [Required(ErrorMessage = "Il campo Anno Immatricolazione è obbligatorio.")]
        public int AnnoImmatricolazione { get; set; }
        public string? AlboGestori { get; set; }
        public DateTime? ScadenzaContratto { get; set; }
        public string? Note { get; set; }
        public string? NumeroTelaio { get; set; }
        public int? PortataKg { get; set; }
        public int? MassaKg { get; set; }
        public bool Dismesso { get; set; }
        public DateTime? DismessoData { get; set; }
        public bool Ce { get; set; }
        public bool ManualeUsoManutenzione { get; set; }
        public bool CatalogoRicambi { get; set; }
        public long MezziTipoId { get; set; }
        public long MezziProprietarioId { get; set; }
        public long MezziCantiereId { get; set; }
        public long MezziClasseId { get; set; }
        public long MezziAlimentazioneId { get; set; }
        public long MezziPatenteId { get; set; }
        public long MezziPeriodoScadenzaId { get; set; }
        public bool Garanzia { get; set; }

        public MezziVeicoloApiDto()
        { 
            
        }

    }

    public class MezziVeicoliApiDto : GenericPagedListApiDto<MezziVeicoliApiDto>
    { }

    public class MezziScadenzaApiDto : GenericFileApiDto
    {
        public long MezziVeicoloId { get; set; }
        public long MezziScadenzaTipoId { get; set; }
        public DateTime DataScadenza { get; set; }
        public DateTime? DataUltimaScadenza { get; set; }
        public string? Note { get; set; }
    }

    public class MezziScadenzeApiDto : GenericPagedListApiDto<MezziScadenzaApiDto>
    { }

    public class MezziDocumentoApiDto : GenericFileApiDto
    {
        public string Descrizione { get; set; }
        public long MezziVeicoloId { get; set; }
    }

    public class MezziDocumentiApiDto : GenericPagedListApiDto<MezziDocumentoApiDto>
    { }
}
