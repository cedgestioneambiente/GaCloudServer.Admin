using System;

namespace GaCloudServer.Admin.Api.Dtos.Users
{
    public class UserProfileApiDto
    {
        public dynamic UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string OfficePhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

    }
}
