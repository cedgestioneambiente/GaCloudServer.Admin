using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Ost.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Ost;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class OstService : IOstService
    {
        protected readonly IGenericRepository<ViewOstTickets> viewOstTicketsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public OstService(

            IGenericRepository<ViewOstTickets> viewOstTicketsRepo,

            IUnitOfWork unitOfWork)
        {
            this.viewOstTicketsRepo = viewOstTicketsRepo;

            this.unitOfWork = unitOfWork;
        }

        #region Tickets

        #region Views
        public async Task<List<int>> GetViewOstTicketsAnniAsync()
        {
            try
            {
                var entities = await viewOstTicketsRepo.GetAllAsync();
                var anni = from x in entities.Data
                           select x.dateCreated.Year;
                anni = anni.Distinct();
                return anni.ToList();
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        public async Task<PagedList<ViewOstTickets>> GetViewOstTicketsByAnnoAsync(int anno)
        {
            try
            {
                return await viewOstTicketsRepo.GetWithFilterAsync(x=>x.dateCreated.Year==anno);
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<PagedList<ViewOstTickets>> GetViewOstOpenTicketsByAnnoAsync(int anno)
        {
            try
            {
                return await viewOstTicketsRepo.GetWithFilterAsync(x => x.dateCreated.Year == anno && x.name=="Open",1,0, "dateCreated","OrderByDescending");
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<OstTicketSummaryDto> GetOstTicketSummaryAsync(int anno)
        {
            try
            {
                var entities = await viewOstTicketsRepo.GetWithFilterAsync(x => x.dateCreated.Year == anno, 1, 0, "ticket_id");

                var summary = new OstTicketSummaryDto();
                summary.year = anno;
                summary.totalClosed = entities.Data.Where(x => x.dateClosed != null).Count();
                summary.total = entities.Data.Count();
                summary.totalOverdue = entities.Data.Where(x => x.dateClosed == null && x.dateCreated < DateTime.Now.AddHours(-36)).Count();
                summary.totalNewFromYesterday = entities.Data.Where(x => x.dateCreated > DateTime.Now.AddDays(-1)).Count();
                summary.totalOpen = entities.Data.Where(x => x.dateClosed == null).Count();
                summary.totalWorked = entities.Data.Where(x => x.dateClosed == null && x.isanswered == true).Count();
                summary.totalClosedFromYesterday = entities.Data.Where(x => x.dateClosed != null && x.dateClosed > DateTime.Now.AddDays(-1)).Count();
                summary.totalNewToday = entities.Data.Where(x => x.dateCreated.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy")).Count();

                return summary;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<OstTicketDistribution> GetOstTicketDistributionAsync(int anno)
        {
            try
            {
                var entities = await viewOstTicketsRepo.GetWithFilterAsync(x => x.dateCreated.Year == anno, 1, 0, "ticket_id");

                var distr = new OstTicketDistribution();
                distr.labels = (from x in entities.Data
                                select x.topic).Distinct().ToList();

                distr.series = new List<int>();

                foreach (var item in distr.labels)
                {
                    var count = entities.Data.Where(x => x.topic == item).Count();
                    distr.series.Add(count);
                }

                distr.totalOpen = entities.Data.Count();
                distr.totalClosed = entities.Data.Where(x => x.dateClosed != null).Count();

                return distr;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<OstTicketDistribution> GetOstTicketSectDistributionAsync(int anno)
        {
            try
            {
                var entities = await viewOstTicketsRepo.GetWithFilterAsync(x => x.dateCreated.Year == anno, 1, 0, "ticket_id");

                var distr = new OstTicketDistribution();
                distr.labels = (from x in entities.Data
                                select x.settore).Distinct().ToList();

                distr.series = new List<int>();

                foreach (var item in distr.labels)
                {
                    var count = entities.Data.Where(x => x.settore == item).Count();
                    distr.series.Add(count);
                }

                distr.totalOpen = entities.Data.Count();
                distr.totalClosed = entities.Data.Where(x => x.dateClosed != null).Count();

                return distr;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<OstTicketStatistics> GetOstTicketStatisticsAsync(int anno)
        {
            try
            {
                var entities = await viewOstTicketsRepo.GetWithFilterAsync(x => x.dateCreated.Year == anno, 1, 0, "ticket_id");

                var stat = new OstTicketStatistics();
                stat.labels = new List<string>() { "Lun", "Mar", "Mer", "Gio", "Ven", "Sab", "Dom" };
                var minDate = entities.Data.Select(x => x.dateCreated).Min();
                var maxDate = entities.Data.Select(x => x.dateCreated).Max();
                var dayBetween = GetNumberOfDates(minDate, maxDate);//  (maxDate - minDate).TotalDays;
                stat.ticketSlaOpen = 18;
                stat.ticketSlaClosed = 36;
                stat.ticketMidDay = entities.Data.Count() / dayBetween;
                var listResTime = (from x in entities.Data.Where(x => x.dateClosed != null)
                                   select (x.dateClosed.GetValueOrDefault() - x.dateCreated).TotalMinutes).ToList();

                stat.ticketMidTime = (listResTime.Sum() / entities.Data.Where(x => x.dateClosed != null).Count()) / 60;

                var listResDay = (from x in entities.Data.Where(x => x.dateClosed != null)
                                  group new
                                  {
                                      x.ticket_id,
                                      x.dateClosed
                                  } by x.dateClosed.GetValueOrDefault().ToString("dd/MM/yyyy") into closedGroup
                                  select closedGroup);

                stat.ticketMidClosedDay = entities.Data.Where(x => x.dateClosed != null).Count() / listResDay.Count();

                var listOverdue = entities.Data.Where(x => x.dateClosed == null && x.dateCreated < DateTime.Now.AddHours(-36));

                List<double> overdue = new List<double>();
                foreach (var item in listOverdue)
                {
                    var time = (DateTime.Now - item.dateCreated.AddHours(36)).TotalMinutes;
                    overdue.Add(time);
                }

                stat.tickedMidOverdue = (overdue.Sum() / listOverdue.Count()) / 60;


                //Current Week
                DayOfWeek currentDay = DateTime.Now.DayOfWeek;
                int daysTillCurrentDay = currentDay - DayOfWeek.Monday;
                DateTime currentWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay);
                DateTime lastWeekStartDate = DateTime.Now.AddDays(-daysTillCurrentDay - 7);

                int index = 0;
                do
                {
                    stat.twOpen.Add(entities.Data.Where(x => x.dateCreated.ToString("dd/MM/yyyy") == currentWeekStartDate.AddDays(index).ToString("dd/MM/yyyy")).Count());
                    stat.twClosed.Add(entities.Data.Where(x => x.dateClosed != null && x.dateClosed.GetValueOrDefault().ToString("dd/MM/yyyy") == currentWeekStartDate.AddDays(index).ToString("dd/MM/yyyy")).Count());
                    stat.lwOpen.Add(entities.Data.Where(x => x.dateCreated.ToString("dd/MM/yyyy") == lastWeekStartDate.AddDays(index).ToString("dd/MM/yyyy")).Count());
                    stat.lwClosed.Add(entities.Data.Where(x => x.dateClosed != null && x.dateClosed.GetValueOrDefault().ToString("dd/MM/yyyy") == lastWeekStartDate.AddDays(index).ToString("dd/MM/yyyy")).Count());
                    index++;
                } while (index < 7);


                return stat;
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        #endregion

        #endregion

        #region Common
        private async Task<long> SaveChanges()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        private void DetachEntity<T>(T entity)
        {
            unitOfWork.DetachEntity(entity);
        }
        #endregion

        #region Helpers
        public static int GetNumberOfDates(DateTime from, DateTime to)
        {
            if (to < from)
                throw new ArgumentException("To cannot be smaller than from.", nameof(to));

            if (to.Date == from.Date)
                return 0;

            int n = 0;
            DateTime nextDate = from;
            while (nextDate <= to.Date)
            {
                if (nextDate.DayOfWeek != DayOfWeek.Saturday && nextDate.DayOfWeek != DayOfWeek.Sunday)
                    n++;
                nextDate = nextDate.AddDays(1);
            }

            return n;
        }
        #endregion
    }
}
