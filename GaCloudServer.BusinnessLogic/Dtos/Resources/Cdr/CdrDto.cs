using GaCloudServer.BusinnessLogic.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Cdr
{
    #region CdrCentri

    public class CdrCentroDto:GenericDto
    {
        public string? Centro { get; set; }
        public string? Mail { get; set; }
        public string? UserMail { get; set; }
    }

    public class CdrCentriDto:GenericPagedListDto<CdrCentroDto>
    {
        
    }

    #endregion

    #region CdrComuni

    public class CdrComuneDto : GenericDto
    {
        public string? Comune { get; set; }
    }

    public class CdrComuniDto : GenericPagedListDto<CdrComuneDto>
    {

    }

    #endregion

    #region CdrCers

    public class CdrCerDto : GenericDto
    {
        public string? Cer { get; set; }
        public string? Descrizione { get; set; }
        public string? Imm { get; set; }
        public bool Pericoloso { get; set; }
        public bool Peso { get; set; }
        public bool Qta { get; set; }
    }

    public class CdrCersDto : GenericPagedListDto<CdrCerDto>
    {

    }

    #endregion

    #region CdrCersDettagli

    public class CdrCerDettaglioDto : GenericDto
    {
        public long CdrCerId { get; set; }
        public string? Descrizione { get; set; }
        public int PesoDefault { get; set; }
    }

    public class CdrCersDettagliDto : GenericPagedListDto<CdrCerDettaglioDto>
    {

    }

    #endregion

    #region CdrCersOnCentri

    public class CdrCerOnCentroDto : GenericDto
    {
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
    }

    public class CdrCersOnCentriDto : GenericPagedListDto<CdrCerOnCentroDto>
    {

    }

    #endregion

    #region CdrComuniOnCentri

    public class CdrComuneOnCentroDto : GenericDto
    {
        public long CdrCentroId { get; set; }
        public long CdrComuneId { get; set; }
    }

    public class CdrComuniOnCentriDto : GenericPagedListDto<CdrComuneOnCentroDto>
    {

    }

    #endregion

}