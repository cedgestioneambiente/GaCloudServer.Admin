using GaCloudServer.BusinnessLogic.Dtos.Custom;
using GaCloudServer.Resources.Api.Dtos.Custom;
using System.Reflection;

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

        public static string[] ConvertPropertyToColumn(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "L'oggetto di input non può essere nullo.");
            }

            Type objectType = obj.GetType();
            PropertyInfo[] properties = objectType.GetProperties();

            string[] propertyNames = new string[properties.Length];
            for (int i = 0; i < properties.Length; i++)
            {
                propertyNames[i] = properties[i].Name;
            }

            return propertyNames;
        }
    }
}
