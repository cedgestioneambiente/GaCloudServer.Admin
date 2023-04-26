using GaCloudServer.Admin.EntityFramework.Shared.DbContexts.Interfaces;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Admin.EntityFramework.Shared.Infrastructure
{
    public class QueryManager<TDbContext>: IQueryManager
        where TDbContext : DbContext, IResourcesDbContext
    {
        protected readonly DbContext _context;

        public QueryManager(TDbContext context)
        {
            _context = context;

        }

        public async Task<List<object>> ExecQueryWithParamsAsync(string query, params object[] parameters)
        {
            return null;


        }


        public async Task<List<object>> ExecQueryAsync(string query)
        {
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            { 
                command.CommandText = query;
                command.CommandType=System.Data.CommandType.Text;
                command.CommandTimeout = 0;

                _context.Database.SetCommandTimeout(480);
                _context.Database.OpenConnection();
                using (var result = await command.ExecuteReaderAsync())
                { 
                    var entities= new List<object>();

                    while (await result.ReadAsync())
                    {
                        
                        entities.Add(ToExpando(result));
                    }

                    return entities;
                }
            }
               
        }

        private static object ToExpando(IDataRecord record)
        {
            var expandoObject = new ExpandoObject() as IDictionary<string, object>;

            for (var i = 0; i < record.FieldCount; i++)
                expandoObject.Add(record.GetName(i), record[i]);

            return expandoObject;
        }

        public static List<T> DataReaderMapToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            T obj = default(T);
            while (dr.Read())
            {
                obj = Activator.CreateInstance<T>();
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (!object.Equals(dr[prop.Name], DBNull.Value))
                    {
                        prop.SetValue(obj, dr[prop.Name], null);
                    }
                }
                list.Add(obj);
            }
            return list;
        }

       


    }
}
