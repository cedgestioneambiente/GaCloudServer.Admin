using GaCloudServer.BusinnessLogic.DTOs.Base;

namespace GaCloudServer.BusinnessLogic.Dtos.Resources.Comunicati
{
    public class ComunicatiDocumentoDto : GenericFileDto
    {
        public DateTime DataDocumento { get; set; }
        public string Numero { get; set; }
        public string Titolo { get; set; }

        public ComunicatiDocumentoDto()
        {
            this.Numero = string.Empty;
            this.Titolo = string.Empty;
        }
    }

    public class ComunicatiDocumentiDto : GenericPagedListDto<ComunicatiDocumentoDto>
    { 
    }
}
