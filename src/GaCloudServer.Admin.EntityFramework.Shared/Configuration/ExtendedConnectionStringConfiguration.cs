namespace GaCloudServer.Admin.EntityFramework.Shared.Configuration
{
    public class ExtendedConnectionStringConfiguration
    {
        public string ResourcesDbConnection { get; set; }

        public void SetConnections(string commonConnectionString)
        {
            ResourcesDbConnection = commonConnectionString;
        }
    }

}
