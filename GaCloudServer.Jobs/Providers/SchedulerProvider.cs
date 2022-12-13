using CrystalQuartz.Core.Contracts;
using CrystalQuartz.Core.SchedulerProviders;
using Quartz;
using Quartz.Impl;
using System.Collections.Specialized;

namespace GaCloudServer.Jobs.Providers
{
    public static class SchedulerProvider
    {

        public static IScheduler CreateScheduler(SingletonJobFactory jobFactory)
        {
            var properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "AuthServer.SSO Scheduler",
                // json serialization is the one supported under .NET Core (binary isn't)
                ["quartz.serializer.type"] = "json",
                ["org.quartz.scheduler.makeSchedulerThreadDaemon"]="true",
                ["quartz.threadPool.type"]= "Quartz.Simpl.SimpleThreadPool,Quartz" ,
                ["quartz.threadPool.threadCount"]= "10" ,
                ["quartz.jobStore.misfireThreshold"]= "60000" ,
                ["quartz.jobStore.lockHandler.type"]= "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz" ,

                // the following setup of job store is just for example and it didn't change from v2
                // according to your usage scenario though, you definitely need 
                // the ADO.NET job store and not the RAMJobStore.
                ["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz",
                ["quartz.jobStore.useProperties"] = "true",
                ["quartz.jobStore.dataSource"] = "default",
                ["quartz.jobStore.tablePrefix"] = "QRTZ_",
                ["quartz.jobStore.driverDelegateType"] = "Quartz.Impl.AdoJobStore.SqlServerDelegate, Quartz",
                ["quartz.dataSource.default.provider"] = "SqlServer", // SqlServer-41 is the new provider for .NET Core
                ["quartz.dataSource.default.connectionString"] = @"Server=.\sqlexpress;Database=GaCloud;Trusted_Connection=True;MultipleActiveResultSets=true"
            };

            var schedulerFactory = new StdSchedulerFactory(properties);// (properties);
            var scheduler = schedulerFactory.GetScheduler().Result;

            //var job = JobBuilder.Create<TestJob>()
            //    .WithIdentity("scheduler_status_job", "default")
            //    .Build();

            //var trigger = TriggerBuilder.Create()
            //    .WithIdentity("scheduler_status_trigger", "default")
            //    .ForJob(job)
            //    .StartNow()
            //    .WithSimpleSchedule(x => x
            //        .WithIntervalInSeconds(1)
            //        .RepeatForever())
            //    .Build();

            //var testJob = JobBuilder.Create<Test2Job>()
            //    .StoreDurably(true)
            //    .RequestRecovery(true)
            //    .WithIdentity("Test2")
            //    .Build();

            //var testTrigger = TriggerBuilder.Create()
            //    .WithIdentity("scheduler_test_trigger", "default")
            //    .ForJob(testJob)
            //    .StartNow()
            //    .WithSimpleSchedule(x => x
            //        .WithIntervalInSeconds(1)
            //        .RepeatForever())
            //    .Build();

            ////scheduler.ScheduleJob(job, trigger);
            //scheduler.ScheduleJob(testJob, testTrigger);
            //scheduler.JobFactory = jobFactory;

            //scheduler.Start();

            return scheduler;
        }

        
    }
}
