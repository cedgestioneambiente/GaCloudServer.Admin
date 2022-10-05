namespace GaCloudServer.BusinnessLogic.Extensions
{
    public static class FilterExtensions
    {
        public static string toWildcardString(this string input)
        {
            return "%"+input + "%";
        }
    }
}
