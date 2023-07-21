using GaCloudServer.Resources.Api.Dtos.Base;

namespace GaCloudServer.Resources.Api.Dtos.Dispositivi
{
    #region DispositiviTipologie

    public class DispositiviTipologiaApiDto : GenericListApiDto
    {

    }

    public class DispositiviTipologieApiDto : GenericPagedListApiDto<DispositiviTipologiaApiDto>
    {

    }

    #endregion

    #region DispositiviModelli

    public class DispositiviModelloApiDto : GenericListApiDto
    {

    }

    public class DispositiviModelliApiDto : GenericPagedListApiDto<DispositiviModelloApiDto>
    {

    }

    #endregion

    #region DispositiviMarche

    public class DispositiviMarcaApiDto : GenericListApiDto
    {

    }

    public class DispositiviMarcheApiDto : GenericPagedListApiDto<DispositiviMarcaApiDto>
    {

    }

    #endregion

    #region DispositiviClassi

    public class DispositiviClasseApiDto : GenericListApiDto
    {

    }

    public class DispositiviClassiApiDto : GenericPagedListApiDto<DispositiviClasseApiDto>
    {

    }

    #endregion

    #region DispositiviCategorie

    public class DispositiviCategoriaApiDto : GenericListApiDto
    {

    }

    public class DispositiviCategorieApiDto : GenericPagedListApiDto<DispositiviCategoriaApiDto>
    {

    }

    #endregion

    #region DispositiviStocks

    public class DispositiviStockApiDto : GenericListApiDto
    {
        public long DispositiviItemId { get; set; }
        public string? Serial { get; set; }
        public string? AltriDati { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public DateTime? DataDismissione { get; set; }
        public long DispositiviCategoriaId { get; set; }
        public bool Disponibile { get; set; }
        public string? Descrizione { get; set; }
    }

    public class DispositiviStocksApiDto : GenericPagedListApiDto<DispositiviStockApiDto>
    {

    }

    #endregion

    #region DispositiviItems

    public class DispositiviItemApiDto : GenericListApiDto
    {
        public long DispositiviTipologiaId { get; set; }
        public long DispositiviMarcaId { get; set; }
        public long DispositiviModelloId { get; set; }
        public long DispositiviClasseId { get; set; }
        public string? Descrizione { get; set; }
    }

    public class DispositiviItemsApiDto : GenericPagedListApiDto<DispositiviItemApiDto>
    {

    }

    #endregion

    #region DispositiviOnDipendenti

    public class DispositiviOnDipendenteApiDto : GenericApiDto
    {
        public long DispositiviStockId { get; set; }
        public long PersonaleDipendenteId { get; set; }
        public DateTime DataConsegna { get; set; }
        public DateTime? DataRitiro { get; set; }
    }

    public class DispositiviOnDipendentiApiDto : GenericPagedListApiDto<DispositiviOnDipendenteApiDto>
    {

    }

    #endregion

    #region DispositiviOnModuli

    public class DispositiviOnModuloApiDto : GenericApiDto
    {
        public long DispositiviModuloId { get; set; }
        public long DispositiviOnDipendenteId { get; set; }

    }

    public class DispositiviOnModuliApiDto : GenericPagedListApiDto<DispositiviOnModuloApiDto>
    {

    }

    #endregion

    #region DispositiviModuli

    public class DispositiviModuloApiDto : GenericFileApiDto
    {
        public DateTime Data { get; set; }
        public string Numero { get; set; }
        public string? Note { get; set; }
        public long PersonaleDipendenteId { get; set; }
    }

    public class DispositiviModuliApiDto : GenericPagedListApiDto<DispositiviModuloApiDto>
    {

    }

    #endregion
}
