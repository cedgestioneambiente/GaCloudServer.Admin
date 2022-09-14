using GaCloudServer.Resources.Api.Dtos.Base;

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
        public string Targa { get; }
        public string TargaPrecedente { get; }
        public string Carro { get; }
        public string Attrezzatura { get; }
        public int AnnoImmatricolazione { get; }
        public string AlboGestori { get; }
        public DateTime? ScadenzaContratto { get; }
        public string Note { get; }
        public string NumeroTelaio { get; }
        public int PortataKg { get; }
        public int MassaKg { get; }
        public bool Dismesso { get; }
        public DateTime? DismessoData { get; }
        public bool Ce { get; }
        public bool ManualeUsoManutenzione { get; }
        public bool CatalogoRicambi { get; }
        public long MezzoTipoId { get; }
        public long MezzoProprietarioId { get; }
        public long MezzoCantiereId { get; }
        public long MezzoClasseId { get; }
        public long MezzoAlimentazioneId { get; }
        public long MezzoPatenteId { get; }
        public long MezzoPeriodoScadenzaId { get; }
        public bool Garanzia { get; }

    }

    public class MezziVeicoliApiDto : GenericPagedListApiDto<MezziVeicoliApiDto>
    { }

    public class MezziScadenzaApiDto : GenericFileApiDto
    {
        public long MezzoVeicoloId { get; }
        public long MezzoScadenzaTipoId { get; }
        public DateTimeOffset DataScadenza { get; }
        public DateTime? DataUltimaScadenza { get; }
        public string Note { get; }
    }

    public class MezziScadenzeApiDto : GenericPagedListApiDto<MezziScadenzaApiDto>
    { }

    public class MezziDocumentoApiDto : GenericFileApiDto
    {
        public string Descrizione { get; }
        public long MezzoVeicoloId { get; }
    }

    public class MezziDocumentiApiDto : GenericPagedListApiDto<MezziDocumentoApiDto>
    { }
}
