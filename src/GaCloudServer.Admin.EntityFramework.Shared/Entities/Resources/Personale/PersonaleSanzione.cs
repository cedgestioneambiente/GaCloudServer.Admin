using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleSanzione : GenericFileAuditableEntity
    {
        public long PersonaleDipendenteId { get; set; }
        public DateTime Data { get; set; }
        public long PersonaleSanzioneMotivoId { get; set; }
        public long PersonaleSanzioneDescrizioneId { get; set; }
        public string DettaglioSanzione { get; set; }

        public PersonaleDipendente PersonaleDipendente { get; set; }
        public PersonaleSanzioneMotivo PersonaleSanzioneMotivo { get; set; }
        public PersonaleSanzioneDescrizione PersonaleSanzioneDescrizione { get; set; }
    }
}
