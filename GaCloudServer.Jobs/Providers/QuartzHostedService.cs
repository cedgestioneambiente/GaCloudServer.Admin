using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GaCloudServer.Jobs.Dtos;
using Microsoft.Extensions.Hosting;
using Quartz;
using Quartz.Spi;

namespace GaCloudServer.Jobs.Providers
{
    public class QuartzHostedService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule> _jobSchedules;
        private IScheduler _scheduler;

        public QuartzHostedService(
            ISchedulerFactory schedulerFactory,
            IEnumerable<JobSchedule> jobSchedules,
            IJobFactory jobFactory)
        {
            _schedulerFactory = schedulerFactory;
            _jobSchedules = jobSchedules;
            _jobFactory = jobFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await _schedulerFactory.GetScheduler(cancellationToken);
            _scheduler.JobFactory = _jobFactory;

            foreach (var jobSchedule in _jobSchedules)
            {
                var job = CreateJob(jobSchedule);
                var trigger = CreateTrigger(jobSchedule);
                try
                {
                    await _scheduler.ScheduleJob(job, trigger, cancellationToken);
                }
                catch (Exception ex) { }
            }

            await _scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _scheduler.Shutdown(cancellationToken);
        }

        private static ITrigger CreateTrigger(JobSchedule schedule)
        {
            return TriggerBuilder
                .Create()
                .WithIdentity($"{schedule.JobName}.trigger")
                .WithCronSchedule(schedule.CronExpression)
                .WithDescription(schedule.CronExpression)
                .Build();
        }

        private static IJobDetail CreateJob(JobSchedule schedule)
        {
            var jobType = schedule.JobType;
            return JobBuilder
                .Create(jobType)
                .WithIdentity($"{schedule.JobName}.job",schedule.JobGroup)
                .WithDescription(jobType.Name)
                .Build();
        }
    }
}
