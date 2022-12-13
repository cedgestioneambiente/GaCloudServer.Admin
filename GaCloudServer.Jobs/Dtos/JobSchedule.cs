namespace GaCloudServer.Jobs.Dtos
{
    public class JobSchedule
    {
        public JobSchedule(Type jobType, string jobName, string jobGroup, string cronExpression)
        {
            JobType = jobType;
            JobName = jobName;
            JobGroup = jobGroup;
            CronExpression = cronExpression;
        }

        public Type JobType { get; }
        public string JobName { get; }
        public string JobGroup { get; }
        public string CronExpression { get; }
    }

}
