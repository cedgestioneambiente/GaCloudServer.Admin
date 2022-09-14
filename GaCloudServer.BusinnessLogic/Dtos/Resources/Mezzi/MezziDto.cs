
using GaCloudServer.BusinnessLogic.DTOs.Base;

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

    public class MezziCantiereDto : GenericListDto
    {
    }

    public class MezziCantieriDto : GenericPagedListDto<MezziCantiereDto>
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

    public class MezziVeicoliDto : GenericPagedListDto<MezziVeicoliDto>
    { }

    public class MezziScadenzaDto : GenericFileDto
    {
        public long MezzoVeicoloId { get; }
        public long MezzoScadenzaTipoId { get; }
        public DateTimeOffset DataScadenza { get; }
        public DateTime? DataUltimaScadenza { get; }
        public string Note { get; }
    }

    public class MezziScadenzeDto : GenericPagedListDto<MezziScadenzaDto>
    { }

    public class MezziDocumentoDto : GenericFileDto
    {
        public string Descrizione { get; }
        public long MezzoVeicoloId { get; }
    }

    public class MezziDocumentiDto : GenericPagedListDto<MezziDocumentoDto>
    { }
}
