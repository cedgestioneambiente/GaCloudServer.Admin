using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity;
using Skoruba.Duende.IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Shared.Dtos.Extended
{
    public interface IExtendedUserDto : IUserDto
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string FullName { get; set; }
        string OfficePhoneNumber { get; set; }
        DateTime? DateOfBirth { get; set; }
    }

    public class ExtendedUserDto<TKey> : UserDto<TKey>, IExtendedUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get ; set; }
        public string OfficePhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
