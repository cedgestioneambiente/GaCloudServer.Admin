using GaCloudServer.Admin.EntityFramework.Shared.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Extensions
{
    public static class EntityExtension
    {
        private static readonly Type _byteArrayType = typeof(byte[]);
        public static bool CorsMatch(this Uri cors, Uri uri)
        {
            cors = cors ?? throw new ArgumentNullException(nameof(cors));
            uri = uri ?? throw new ArgumentNullException(nameof(uri));

            return uri.Scheme.ToUpperInvariant() == cors.Scheme.ToUpperInvariant() &&
                uri.Host.ToUpperInvariant() == cors.Host.ToUpperInvariant() &&
            uri.Port == cors.Port;
        }

        public static void Copy<TEntity>(this TEntity from, TEntity to) where TEntity : GenericEntity
        {
            var properties = typeof(TEntity).GetProperties()
                .Where(p => !p.PropertyType.ImplementsGenericInterface(typeof(ICollection<>)) || p.PropertyType == _byteArrayType);
            foreach (var property in properties.Where(props => props.Name != "CreatedAt" && props.Name != "CreatedBy"))
            {
                property.SetValue(to, property.GetValue(from));
            }
        }

        public static void CopyAuditValues<TEntity>(this TEntity from, TEntity to) where TEntity : GenericAuditableEntity
        {
            var properties = typeof(TEntity).GetProperties()
                .Where(p => !p.PropertyType.ImplementsGenericInterface(typeof(ICollection<>)) || p.PropertyType == _byteArrayType);
            foreach (var property in properties.Where(prop => nameof(prop) == "CreateAt" || nameof(prop) == "CreatedBy"))
            {
                property.SetValue(to, property.GetValue(from));
            }
        }

    }
}
