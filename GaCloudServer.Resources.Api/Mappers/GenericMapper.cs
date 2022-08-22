using AutoMapper;
using GaCloudServer.Resources.Api.Mappers.Autorizzazioni;
using GaCloudServer.Resources.Api.Mappers.Contratti;
using GaCloudServer.Resources.Api.Mappers.Cdr;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.Resources.Api.Mappers
{
    public static class GenericMapper
    {
        internal static IMapper Mapper { get; }

        internal static List<Profile> profiles = new List<Profile>()
        {
            new AutorizzazioniMapperProfile(),
            new ContrattiMapperProfile(),
            new CdrMapperProfile(),
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
        public static TDto ToDto<TDto, TApiDto>(this TApiDto item)
            where TDto : class
            where TApiDto : class
        {
            return Mapper.Map<TDto>(item);
        }

        public static TDto ToPagedDto<TDto, TApiDto>(this PagedList<TApiDto> item)
            where TDto : class
            where TApiDto : class
        {
            return Mapper.Map<TDto>(item);
        }

        public static TApiDto ToApiDto<TApiDto, TDto>(this TDto item)
            where TApiDto : class
            where TDto : class
        {
            return Mapper.Map<TApiDto>(item);
        }

        public static TApiDto ToPagedApiDto<TApiDto, TDto>(this PagedList<TDto> item)
            where TApiDto : class
            where TDto : class
        {
            return Mapper.Map<TApiDto>(item);
        }


    }
}
