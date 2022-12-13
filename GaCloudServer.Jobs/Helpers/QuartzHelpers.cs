using System.Collections.Specialized;

namespace GaCloudServer.Jobs.Helpers
{
    public static class QuartzHelpers
    {

        public static NameValueCollection GetQuartzDevConfig()
        { 
            return new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "AuthServer.SSO Scheduler",
                // json serialization is the one supported under .NET Core (binary isn't)
                ["quartz.serializer.type"] = "json",
                ["org.quartz.scheduler.makeSchedulerThreadDaemon"] = "true",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool,Quartz",
                ["quartz.threadPool.threadCount"] = "10",
                ["quartz.jobStore.misfireThreshold"] = "60000",
                ["quartz.jobStore.lockHandler.type"] = "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz",

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
        }

        public static NameValueCollection GetQuartzProdConfig()
        {
            return new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "AuthServer.SSO Scheduler",
                // json serialization is the one supported under .NET Core (binary isn't)
                ["quartz.serializer.type"] = "json",
                ["org.quartz.scheduler.makeSchedulerThreadDaemon"] = "true",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool,Quartz",
                ["quartz.threadPool.threadCount"] = "10",
                ["quartz.jobStore.misfireThreshold"] = "60000",
                ["quartz.jobStore.lockHandler.type"] = "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz",

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
        }
    }
}
