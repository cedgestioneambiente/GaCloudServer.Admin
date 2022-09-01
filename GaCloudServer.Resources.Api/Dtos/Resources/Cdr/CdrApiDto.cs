using GaCloudServer.Resources.Api.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaCloudServer.Resources.Api.ApiApiDtos.Cdr
{
    #region CdrCentri

    public class CdrCentroApiDto : GenericApiDto
    {
        public string? Centro { get; set; }
        public string? Mail { get; set; }
        public string? UserMail { get; set; }
    }

    public class CdrCentriApiDto : GenericPagedListApiDto<CdrCentroApiDto>
    {

    }

    #endregion

    #region CdrComuni

    public class CdrComuneApiDto : GenericApiDto
    {
        public string? Comune { get; set; }
    }

    public class CdrComuniApiDto : GenericPagedListApiDto<CdrComuneApiDto>
    {

    }

    #endregion

    #region CdrCers

    public class CdrCerApiDto : GenericApiDto
    {
        public string? Cer { get; set; }
        public string? Descrizione { get; set; }
        public string? Imm { get; set; }
        public bool Pericoloso { get; set; }
        public bool Peso { get; set; }
        public bool Qta { get; set; }
    }

    public class CdrCersApiDto : GenericPagedListApiDto<CdrCerApiDto>
    {

    }

    #endregion

    #region CdrCersDettagli

    public class CdrCerDettaglioApiDto : GenericApiDto
    {
        public long CdrCerId { get; set; }
        public string? Descrizione { get; set; }
        public int PesoDefault { get; set; }
    }

    public class CdrCersDettagliApiDto : GenericPagedListApiDto<CdrCerDettaglioApiDto>
    {

    }

    #endregion

    #region CdrCersOnCentri

    public class CdrCerOnCentroApiDto : GenericApiDto
    {
        public long CdrCentroId { get; set; }
        public long CdrCerId { get; set; }
    }

    public class CdrCersOnCentriApiDto : GenericPagedListApiDto<CdrCerOnCentroApiDto>
    {

    }

    #endregion

    #region CdrComuniOnCentri

    public class CdrComuneOnCentroApiDto : GenericApiDto
    {
        public long CdrCentroId { get; set; }
        public long CdrComuneId { get; set; }
    }

    public class CdrComuniOnCentriApiDto : GenericPagedListApiDto<CdrComuneOnCentroApiDto>
    {

    }

    #endregion

}