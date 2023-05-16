using AutoMapper;
using GaCloudServer.Resources.Api.Mappers.Autorizzazioni;
using GaCloudServer.Resources.Api.Mappers.Aziende;
using GaCloudServer.Resources.Api.Mappers.Cdr;
using GaCloudServer.Resources.Api.Mappers.Comunicati;
using GaCloudServer.Resources.Api.Mappers.Consorzio;
using GaCloudServer.Resources.Api.Mappers.ContactCenter;
using GaCloudServer.Resources.Api.Mappers.Contratti;
using GaCloudServer.Resources.Api.Mappers.Crm;
using GaCloudServer.Resources.Api.Mappers.Csr;
using GaCloudServer.Resources.Api.Mappers.Dashboard;
using GaCloudServer.Resources.Api.Mappers.Global;
using GaCloudServer.Resources.Api.Mappers.Mezzi;
using GaCloudServer.Resources.Api.Mappers.Notification;
using GaCloudServer.Resources.Api.Mappers.Personale;
using GaCloudServer.Resources.Api.Mappers.PrenotazioneAuto;
using GaCloudServer.Resources.Api.Mappers.Presenze;
using GaCloudServer.Resources.Api.Mappers.Progetti;
using GaCloudServer.Resources.Api.Mappers.QueryBuilder;
using GaCloudServer.Resources.Api.Mappers.Reclami;
using GaCloudServer.Resources.Api.Mappers.Segnalazioni;
using GaCloudServer.Resources.Api.Mappers.Shortcuts;
using GaCloudServer.Resources.Api.Mappers.System;
using GaCloudServer.Resources.Api.Mappers.Tasks;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

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
            new ComunicatiMapperProfile(),
            new MezziMapperProfile(),
            new AziendeMapperProfile(),
            new PrenotazioneAutoMapperProfile(),
            new NotificationMapperProfile(),
            new GlobalMapperProfile(),
            new PersonaleMapperProfile(),
            new CsrMapperProfile(),
            new ReclamiMapperProfile(),
            new SegnalazioniMapperProfile(),
            new ContactCenterMapperProfile(),
            new PresenzeMapperProfile(),
            new ShortcutsMapperProfile(),
            new QueryBuilderMapperProfile(),
            new DashboardMapperProfile(),
            new ProgettiMapperProfile(),
            new TasksMapperProfile(),
            new SystemMapperProfile(),
            new ConsorzioMapperProfile(),
            new CrmMapperProfile()
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
