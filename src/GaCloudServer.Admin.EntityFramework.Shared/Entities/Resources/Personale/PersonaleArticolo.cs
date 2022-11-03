using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Personale
{
    public class PersonaleArticolo : GenericEntity
    {
        public long PersonaleArticoloTipologiaId { get; set; }
        public long PersonaleArticoloModelloId { get; set; }
        public long PersonaleArticoloDpiId { get; set; }

        public PersonaleArticoloTipologia PersonaleArticoloTipologia { get; set; }
        public PersonaleArticoloModello PersonaleArticoloModello { get; set; }
        public PersonaleArticoloDpi PersonaleArticoloDpi { get; set; }
    }
}
