using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mezzi.Views
{
    public class ViewGaMezziDocumenti:GenericEntity
    {
        public long MezziVeicoloId { get; set; }
        public string Targa { get; set; }
        public string Descrizione { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }

    }
}
