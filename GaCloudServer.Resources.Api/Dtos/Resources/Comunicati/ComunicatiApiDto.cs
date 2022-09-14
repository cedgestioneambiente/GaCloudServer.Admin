using GaCloudServer.Resources.Api.Dtos.Base;
using System.ComponentModel.DataAnnotations;

namespace GaCloudServer.Resources.Api.Dtos.Comunicati
{
    #region ComunicatiDocumenti
    public class ComunicatiDocumentoApiDto:GenericFileApiDto
    {
        public DateTime DataDocumento { get; set; }
        [Required(ErrorMessage ="Il campo Numero è obbligatorio.")]
        public string Numero { get; set; }
        [Required(ErrorMessage ="Il campo Titolo è obbligatorio.")]
        public string Titolo { get; set; }

    }

    public class ComunicatiDocumentiApiDto : GenericPagedListApiDto<ComunicatiDocumentoApiDto>
    {
    }

    #endregion

}
