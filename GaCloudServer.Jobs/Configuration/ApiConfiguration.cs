namespace AuthServer.SSO.Schedule.Configuration
{
    public class ApiConfiguration
    {
        public string ApiName { get; set; }

        public string ApiVersion { get; set; }

        public string IdentityServerBaseUrl { get; set; }

        public string ApiBaseUrl { get; set; }

        public string OidcSwaggerUIClientId { get; set; }

        public bool RequireHttpsMetadata { get; set; }

        public string OidcApiName { get; set; }

        public string AdministrationRole { get; set; }
        public string UserRole { get; set; }
        public string UserEcRole { get; set; }
        public string UserFoRole { get; set; }

        public bool CorsAllowAnyOrigin { get; set; }

        public string[] CorsAllowOrigins { get; set; }
    }
}





