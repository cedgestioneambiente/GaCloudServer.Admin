using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Custom;

namespace GaCloudServer.Resources.Api.Helpers
{
    public static class GenericHelper
    {
        public static bool CanConvertToInt(string input)
        {
            int number;
            return int.TryParse(input, out number);
        }

        public static bool CanConvertToDate(string input)
        {
            return DateTime.TryParse(input, out _);
        }

        public static bool CanConvertToDouble(string input)
        {
            return double.TryParse(input, out _);
        }

        public static bool IsNotNullOrEmpty(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static string ConvertNullToString(string input)
        {
            return input ?? "";
        }
    }
}
