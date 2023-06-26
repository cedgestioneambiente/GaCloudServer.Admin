namespace GaCloudServer.Resources.Api.Dtos.Custom
{
    public class ImageItemApiDto
    {
        public long id { get; set; }
        public string image { get; set; }
    }

    public class DateRangeDto { 
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
    }

    public class AuthRolesFilterApiDto
    { 
        public string roles { get; set; }
    }

   
}
