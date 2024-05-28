using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    public static class GenericHelper
    {
        public static T GetPropertyValue<T>(object obj, string propertyName)
        {
            // Usa la riflessione per ottenere il valore della proprietà
            PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);
            if (propertyInfo != null)
            {
                return (T)propertyInfo.GetValue(obj);
            }
            return default;
        }
    }
}
