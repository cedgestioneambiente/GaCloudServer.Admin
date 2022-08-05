using AutoMapper;
using GaCloudServer.BusinessLogic.Mappers.Autorizzazioni;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Mappers
{
    public static class GenericMapper
    {
        internal static IMapper Mapper { get; }

        internal static List<Profile> profiles = new List<Profile>()
        {
            new AutorizzazioniMapperProfile()
        };

        static GenericMapper() {

            Mapper = new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(profile);
                }
            }).CreateMapper();
        }

        //Generic Extensions
        public static TDto ToDto<TDto, TEntity>(this TEntity item)
            where TDto : class
            where TEntity : class
        {
            return Mapper.Map<TDto>(item);
        }

        public static TEntity ToEntity<TEntity, TDto>(this TDto item)
            where TEntity : class
            where TDto : class
        {
            return Mapper.Map<TEntity>(item);
        }


    }
}
