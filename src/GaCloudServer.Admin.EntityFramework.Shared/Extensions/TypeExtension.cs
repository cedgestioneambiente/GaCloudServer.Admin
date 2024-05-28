using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Extensions
{
    public static class TypeExtension
    {
        public static bool ImplementsGenericInterface(this Type type, Type interfaceType)
        {
            if (!type.IsGenericType(interfaceType))
            {
                return type.GetTypeInfo().ImplementedInterfaces.Any((Type info) => info.IsGenericType(interfaceType));
            }

            return true;
        }

        public static bool IsGenericType(this Type type, Type genericType)
        {
            if (type.IsGenericType)
            {
                return type.GetGenericTypeDefinition() == genericType;
            }

            return false;
        }


    }
}
