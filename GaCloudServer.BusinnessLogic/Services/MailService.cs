using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Mail;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class MailService:IMailService
    {

        protected readonly IGenericRepository<MailJob> mailJobsRepository;

        protected readonly IUnitOfWork unitOfWork;

        public MailService(

            IGenericRepository<MailJob> _gaMailJobsRepository,

            IUnitOfWork _unitOfWork

            )
        {
            mailJobsRepository = _gaMailJobsRepository;

            unitOfWork = _unitOfWork;
        }

        #region MailJob
        public async Task<PagedList<MailJob>> GetMailJobsAsync(bool all)
        {
            if (all)
            {
                var entities = await mailJobsRepository.GetAllAsync(1, 0);

                return entities;
            }
            else
            {
                var entities = await mailJobsRepository.GetWithFilterAsync(x => x.IsSended == false && x.IsError == false);

                return entities;
            }

        }

        public async Task<MailJob> GetMailJobByIdAsync(long id)
        {
            var entity = await mailJobsRepository.GetByIdAsync(id);

            return entity;
            
        }

        public async Task<long> AddMailJobAsync(MailJob entity)
        {
            await mailJobsRepository.AddAsync(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<long> UpdateMailJobAsync(MailJob entity)
        {

            var original = mailJobsRepository.GetByIdAsNoTraking(x => x.Id == entity.Id);
            mailJobsRepository.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteMailJobAsync(long id)
        {
            var entity = await mailJobsRepository.GetByIdAsync(id);
            mailJobsRepository.Remove(entity);
            await SaveChanges();

            return true;
            
        }

        public async Task<bool> SetErrorOnMailJobAsync(long id)
        {
            var entity = await mailJobsRepository.GetByIdAsync(id);
            entity.IsError = true;
            mailJobsRepository.Update(entity);
            await SaveChanges();

            return true;
           
        }

        public async Task<bool> SetSendedOnMailJobAsync(long id)
        {
            var entity = await mailJobsRepository.GetByIdAsync(id);
            entity.IsSended = true;
            entity.DateSend = DateTime.Now;
            mailJobsRepository.Update(entity);
            await SaveChanges();

            return true;
           
        }

        #endregion

        #region Shared
        private async Task<long> SaveChanges()
        {
            return await unitOfWork.SaveChangesAsync();
        }

        private void DetachEntity<T>(T entity)
        {
            unitOfWork.DetachEntity(entity);
        }

        #endregion
    }
}
