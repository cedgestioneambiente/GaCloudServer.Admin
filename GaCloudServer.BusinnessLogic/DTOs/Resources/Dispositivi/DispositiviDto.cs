using GaCloudServer.BusinnessLogic.DTOs.Base;


namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Dispositivi
{
    #region DispositiviTipologie

    public class DispositiviTipologiaDto : GenericListDto
    {

    }

    public class DispositiviTipologieDto : GenericPagedListDto<DispositiviTipologiaDto>
    {

    }

    #endregion

    #region DispositiviModelli

    public class DispositiviModelloDto : GenericListDto
    {

    }

    public class DispositiviModelliDto : GenericPagedListDto<DispositiviModelloDto>
    {

    }

    #endregion

    #region DispositiviMarche

    public class DispositiviMarcaDto : GenericListDto
    {

    }

    public class DispositiviMarcheDto : GenericPagedListDto<DispositiviMarcaDto>
    {

    }

    #endregion

    #region DispositiviClassi

    public class DispositiviClasseDto : GenericListDto
    {

    }

    public class DispositiviClassiDto : GenericPagedListDto<DispositiviClasseDto>
    {

    }

    #endregion

    #region DispositiviCategorie

    public class DispositiviCategoriaDto : GenericListDto
    {

    }

    public class DispositiviCategorieDto : GenericPagedListDto<DispositiviCategoriaDto>
    {

    }

    #endregion

    #region DispositiviStocks

    public class DispositiviStockDto : GenericListDto
    {
        public long DispositiviItemId { get; set; }
        public string? Serial { get; set; }
        public string? AltriDati { get; set; }
        public DateTime DataRegistrazione { get; set; }
        public DateTime? DataDismissione { get; set; }
        public long DispositiviCategoriaId { get; set; }
        public bool Disponibile { get; set; }
    }

    public class DispositiviStocksDto : GenericPagedListDto<DispositiviStockDto>
    {

    }

    #endregion

    #region DispositiviItems

    public class DispositiviItemDto : GenericListDto
    {
        public long DispositiviTipologiaId { get; set; }
        public long DispositiviMarcaId { get; set; }
        public long DispositiviModelloId { get; set; }
        public long DispositiviClasseId { get; set; }
        public string? Descrizione   { get; set; }
    }

    public class DispositiviItemsDto : GenericPagedListDto<DispositiviItemDto>
    {

    }

    #endregion

    #region DispositiviOnDipendenti

    public class DispositiviOnDipendenteDto : GenericDto
    {
        public long DispositiviStockId { get; set; }
        public long PersonaleDipendenteId { get; set; }
        public DateTime DataConsegna { get; set; }
        public DateTime? DataRitiro { get; set; }
        public string? Note { get; set; }


    }

    public class DispositiviOnDipendentiDto : GenericPagedListDto<DispositiviOnDipendenteDto>
    {
        public List<DispositiviOnDipendenteDto> Data { get; set; }
    }

    #endregion

    #region DispositiviOnModuli

    public class DispositiviOnModuloDto : GenericDto
    {
        public long DispositiviModuloId { get; set; }
        public long DispositiviOnDipendenteId { get; set; }

    }

    public class DispositiviOnModuliDto : GenericPagedListDto<DispositiviOnModuloDto>
    {

    }

    #endregion

    #region DispositiviModuli

    public class DispositiviModuloDto : GenericFileDto
    {
        public DateTime Data { get; set; }
        public string? Numero { get; set; }
        public string? Note { get; set; }
        public long PersonaleDipendenteId { get; set; }
    }

    public class DispositiviModuliDto : GenericPagedListDto<DispositiviModuloDto>
    {

    }

    #endregion
}
