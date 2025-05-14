using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Constants
{
    public static class GraphConsts
    {
        public const string clientId = "24ec9dff-f26a-41e3-8308-97f78a8750f8";
        public const string clientSecret = "lRWAxoPw2OEwj.dbTh7k~9o~mf2XIB5~_N";
        public const string redirectUri = "msal24ec9dff-f26a-41e3-8308-97f78a8750f8://auth";
        public const string tenantId = "cad030df-cadc-4c78-8e23-9c7372718e36";
        public const string authority = "https://login.microsoftonline.com/cad030df-cadc-4c78-8e23-9c7372718e36/v2.0";
        public static readonly List<string> _scopes = new List<string> { "https://graph.microsoft.com/.default" } ;
        public static List<string> scopes { get { return _scopes; } }
    }
}
