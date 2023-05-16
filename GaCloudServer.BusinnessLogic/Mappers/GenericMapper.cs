using AutoMapper;
using GaCloudServer.BusinessLogic.Mappers.Autorizzazioni;
using GaCloudServer.BusinessLogic.Mappers.Aziende;
using GaCloudServer.BusinessLogic.Mappers.Cdr;
using GaCloudServer.BusinessLogic.Mappers.Comunicati;
using GaCloudServer.BusinessLogic.Mappers.Contratti;
using GaCloudServer.BusinnessLogic.Mappers.Mezzi;
using GaCloudServer.BusinnessLogic.Mappers.Notification;
using GaCloudServer.BusinnessLogic.Mappers.PrenotazioneAuto;
using GaCloudServer.BusinnessLogic.Mappers.Global;
using GaCloudServer.BusinessLogic.Mappers.Personale;
using GaCloudServer.BusinessLogic.Mappers.Csr;
using GaCloudServer.BusinessLogic.Mappers.Reclami;
using GaCloudServer.BusinessLogic.Mappers.Segnalazioni;
using GaCloudServer.BusinessLogic.Mappers.EcSegnalazioni;
using GaCloudServer.BusinessLogic.Mappers.ContactCenter;
using GaCloudServer.BusinessLogic.Mappers.Presenze;
using GaCloudServer.BusinessLogic.Mappers.Shortcuts;
using GaCloudServer.BusinessLogic.Mappers.QueryBuilder;
using GaCloudServer.BusinessLogic.Mappers.Dashboard;
using GaCloudServer.BusinessLogic.Mappers.Progetti;
using GaCloudServer.BusinnessLogic.Mappers.Tasks;
using GaCloudServer.BusinessLogic.Mappers.System;
using GaCloudServer.BusinessLogic.Mappers.Consorzio;
using GaCloudServer.BusinessLogic.Mappers.Crm;

namespace GaCloudServer.BusinnessLogic.Mappers
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
            new EcSegnalazioniMapperProfile(),
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
