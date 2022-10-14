using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti;
using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.Contratti.Views;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.Dtos.Resources.Contratti;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using Skoruba.Duende.IdentityServer.Admin.EntityFramework.Extensions.Common;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using GaCloudServer.BusinnessLogic.Extensions;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaContrattiService : IGaContrattiService
    {
        protected readonly IGenericRepository<ContrattiPermesso> gaContrattiPermessiRepo;
        protected readonly IGenericRepository<ContrattiServizio> gaContrattiServiziRepo;
        protected readonly IGenericRepository<ContrattiTipologia> gaContrattiTipologieRepo;
        protected readonly IGenericRepository<ContrattiUtenteOnPermesso> gaContrattiUtentiOnPermessiRepo;
        protected readonly IGenericRepository<ContrattiModalita> gaContrattiModalitasRepo;
        protected readonly IGenericRepository<ContrattiFornitore> gaContrattiFornitoriRepo;
        protected readonly IGenericRepository<ContrattiDocumento> gaContrattiDocumentiRepo;

        protected readonly IGenericRepository<ViewGaContrattiUtenti> viewGaContrattiUtentiRepo;
        protected readonly IGenericRepository<ViewGaContrattiUtentiOnPermessi> viewGaContrattiUtentiOnPermessiRepo;
        protected readonly IGenericRepository<ViewGaContrattiDocumenti> viewGaContrattiDocumentiRepo;
        protected readonly IGenericRepository<ViewGaContrattiDocumentiList> viewGaContrattiDocumentiListRepo;
        protected readonly IGenericRepository<ViewGaContrattiNumeratori> viewGaContrattiNumeratoriRepo;

        //protected readonly IProcedureManager<SpGaContrattiNumeratore> spGaContrattiNumeratoreRepo;
        //protected readonly IProcedureManager<SpGaContrattiPermesso> spGaContrattiPermessoRepo;
        //protected readonly IProcedureManager<SpGaContrattiPermessoMode> spGaContrattiPermessoModeRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaContrattiService(
            IGenericRepository<ContrattiPermesso> gaContrattiPermessiRepo,
            IGenericRepository<ContrattiServizio> gaContrattiServiziRepo,
            IGenericRepository<ContrattiTipologia> gaContrattiTipologieRepo,
            IGenericRepository<ContrattiUtenteOnPermesso> gaContrattiUtentiOnPermessiRepo,
            IGenericRepository<ContrattiModalita> gaContrattiModalitasRepo,
            IGenericRepository<ContrattiFornitore> gaContrattiFornitoriRepo,
            IGenericRepository<ContrattiDocumento> gaContrattiDocumentiRepo,

            IGenericRepository<ViewGaContrattiUtenti> viewGaContrattiUtentiRepo,
            IGenericRepository<ViewGaContrattiUtentiOnPermessi> viewGaContrattiUtentiOnPermessiRepo,
            IGenericRepository<ViewGaContrattiDocumenti> viewGaContrattiDocumentiRepo,
            IGenericRepository<ViewGaContrattiDocumentiList> viewGaContrattiDocumentiListRepo,
            IGenericRepository<ViewGaContrattiNumeratori> viewGaContrattiNumeratoriRepo,

            //IProcedureManager<SpGaContrattiNumeratore> spGaContrattiNumeratoreRepo,
            //IProcedureManager<SpGaContrattiPermesso> spGaContrattiPermessoRepo,
            //IProcedureManager<SpGaContrattiPermessoMode> spGaContrattiPermessoModeRepo,


            IUnitOfWork unitOfWork)
        {
            this.gaContrattiPermessiRepo = gaContrattiPermessiRepo;
            this.gaContrattiServiziRepo = gaContrattiServiziRepo;
            this.gaContrattiTipologieRepo = gaContrattiTipologieRepo;
            this.gaContrattiUtentiOnPermessiRepo = gaContrattiUtentiOnPermessiRepo;
            this.gaContrattiModalitasRepo = gaContrattiModalitasRepo;
            this.gaContrattiFornitoriRepo = gaContrattiFornitoriRepo;
            this.gaContrattiDocumentiRepo = gaContrattiDocumentiRepo;

            this.viewGaContrattiUtentiRepo = viewGaContrattiUtentiRepo;
            this.viewGaContrattiUtentiOnPermessiRepo = viewGaContrattiUtentiOnPermessiRepo;
            this.viewGaContrattiDocumentiRepo = viewGaContrattiDocumentiRepo;
            this.viewGaContrattiDocumentiListRepo = viewGaContrattiDocumentiListRepo;
            this.viewGaContrattiNumeratoriRepo = viewGaContrattiNumeratoriRepo;

            //this.spGaContrattiNumeratoreRepo = spGaContrattiNumeratoreRepo;
            //this.spGaContrattiPermessoRepo = spGaContrattiPermessoRepo;
            //this.spGaContrattiPermessoModeRepo = spGaContrattiPermessoModeRepo;

            this.unitOfWork = unitOfWork;
        }

        #region Contratti Permessi
        public async Task<ContrattiPermessiDto> GetGaContrattiPermessiAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiPermessiRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiPermessiDto, PagedList<ContrattiPermesso>>();
            return dtos;
        }

        public async Task<ContrattiPermessoDto> GetGaContrattiPermessoByIdAsync(long id)
        {
            var entity = await gaContrattiPermessiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiPermessoDto, ContrattiPermesso>();
            return dto;
        }

        public async Task<long> AddGaContrattiPermessoAsync(ContrattiPermessoDto dto)
        {
            var entity = dto.ToEntity<ContrattiPermesso, ContrattiPermessoDto>();
            await gaContrattiPermessiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiPermessoAsync(ContrattiPermessoDto dto)
        {
            var entity = dto.ToEntity<ContrattiPermesso, ContrattiPermessoDto>();
            gaContrattiPermessiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiPermessoAsync(long id)
        {
            var entity = await gaContrattiPermessiRepo.GetByIdAsync(id);
            gaContrattiPermessiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiPermessoAsync(long id, string descrizione)
        {
            var entity = await gaContrattiPermessiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiPermessoAsync(long id)
        {
            var entity = await gaContrattiPermessiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiPermessiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiPermessiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti Servizi
        public async Task<ContrattiServiziDto> GetGaContrattiServiziAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiServiziRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiServiziDto, PagedList<ContrattiServizio>>();
            return dtos;
        }

        public async Task<ContrattiServizioDto> GetGaContrattiServizioByIdAsync(long id)
        {
            var entity = await gaContrattiServiziRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiServizioDto, ContrattiServizio>();
            return dto;
        }

        public async Task<long> AddGaContrattiServizioAsync(ContrattiServizioDto dto)
        {
            var entity = dto.ToEntity<ContrattiServizio, ContrattiServizioDto>();
            await gaContrattiServiziRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiServizioAsync(ContrattiServizioDto dto)
        {
            var entity = dto.ToEntity<ContrattiServizio, ContrattiServizioDto>();
            gaContrattiServiziRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiServizioAsync(long id)
        {
            var entity = await gaContrattiServiziRepo.GetByIdAsync(id);
            gaContrattiServiziRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiServizioAsync(long id, string descrizione)
        {
            var entity = await gaContrattiServiziRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiServizioAsync(long id)
        {
            var entity = await gaContrattiServiziRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiServiziRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiServiziRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti Tipologie
        public async Task<ContrattiTipologieDto> GetGaContrattiTipologieAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiTipologieRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiTipologieDto, PagedList<ContrattiTipologia>>();
            return dtos;
        }

        public async Task<ContrattiTipologiaDto> GetGaContrattiTipologiaByIdAsync(long id)
        {
            var entity = await gaContrattiTipologieRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiTipologiaDto, ContrattiTipologia>();
            return dto;
        }

        public async Task<long> AddGaContrattiTipologiaAsync(ContrattiTipologiaDto dto)
        {
            var entity = dto.ToEntity<ContrattiTipologia, ContrattiTipologiaDto>();
            await gaContrattiTipologieRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiTipologiaAsync(ContrattiTipologiaDto dto)
        {
            var entity = dto.ToEntity<ContrattiTipologia, ContrattiTipologiaDto>();
            gaContrattiTipologieRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiTipologiaAsync(long id)
        {
            var entity = await gaContrattiTipologieRepo.GetByIdAsync(id);
            gaContrattiTipologieRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiTipologiaAsync(long id, string descrizione)
        {
            var entity = await gaContrattiTipologieRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiTipologiaAsync(long id)
        {
            var entity = await gaContrattiTipologieRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiTipologieRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti UtentiOnPermessi

        #region Functions
        public async Task<bool> UpdateGaContrattiUtenteOnPermessoAsync(string utenteId, long permessoId)
        {
            try
            {
                var checkExist = await gaContrattiUtentiOnPermessiRepo.CheckIfExist(x => x.UtenteId == utenteId && x.ContrattiPermessoId == permessoId);
                if (checkExist)
                {
                    var entity = await gaContrattiUtentiOnPermessiRepo.GetSingleWithFilter(x => x.UtenteId == utenteId && x.ContrattiPermessoId == permessoId);
                    gaContrattiUtentiOnPermessiRepo.Remove(entity);
                    await SaveChanges();
                    return true;
                }
                else
                {
                    var entity = new ContrattiUtenteOnPermesso();
                    entity.UtenteId = utenteId;
                    entity.ContrattiPermessoId = permessoId;
                    gaContrattiUtentiOnPermessiRepo.Add(entity);
                    await SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaContrattiUtentiOnPermessi>> GetViewGaContrattiUtentiOnPermessiAsync(string utenteId)
        {
            {
                var entities = await viewGaContrattiUtentiOnPermessiRepo.GetWithFilterAsync(x => x.UtenteId == utenteId, 1, 0, "utenteId");

                return entities;
            }
        }
        #endregion

        #endregion

        #region Contratti Utenti

        #region Views
        public async Task<PagedList<ViewGaContrattiUtenti>> GetViewGaContrattiUtentiAsync(int page = 1, int pageSize = 0)
        {
            {
                var entities = await viewGaContrattiUtentiRepo.GetAllAsync(page, pageSize);
                return entities;
            }
        }
        #endregion

        #endregion

        #region Contratti Modalitas
        public async Task<ContrattiModalitasDto> GetGaContrattiModalitasAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiModalitasRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiModalitasDto, PagedList<ContrattiModalita>>();
            return dtos;
        }

        public async Task<ContrattiModalitaDto> GetGaContrattiModalitaByIdAsync(long id)
        {
            var entity = await gaContrattiModalitasRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiModalitaDto, ContrattiModalita>();
            return dto;
        }

        public async Task<long> AddGaContrattiModalitaAsync(ContrattiModalitaDto dto)
        {
            var entity = dto.ToEntity<ContrattiModalita, ContrattiModalitaDto>();
            await gaContrattiModalitasRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiModalitaAsync(ContrattiModalitaDto dto)
        {
            var entity = dto.ToEntity<ContrattiModalita, ContrattiModalitaDto>();
            gaContrattiModalitasRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiModalitaAsync(long id)
        {
            var entity = await gaContrattiModalitasRepo.GetByIdAsync(id);
            gaContrattiModalitasRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiModalitaAsync(long id, string descrizione)
        {
            var entity = await gaContrattiModalitasRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiModalitaAsync(long id)
        {
            var entity = await gaContrattiModalitasRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiModalitasRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiModalitasRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti Fornitori
        public async Task<ContrattiFornitoriDto> GetGaContrattiFornitoriAsync(int page = 1, int pageSize = 0)
        {
            var entities = await gaContrattiFornitoriRepo.GetAllAsync(page, pageSize);
            var dtos = entities.ToDto<ContrattiFornitoriDto, PagedList<ContrattiFornitore>>();
            return dtos;
        }

        public async Task<ContrattiFornitoreDto> GetGaContrattiFornitoreByIdAsync(long id)
        {
            var entity = await gaContrattiFornitoriRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiFornitoreDto, ContrattiFornitore>();
            return dto;
        }

        public async Task<long> AddGaContrattiFornitoreAsync(ContrattiFornitoreDto dto)
        {
            var entity = dto.ToEntity<ContrattiFornitore, ContrattiFornitoreDto>();
            await gaContrattiFornitoriRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiFornitoreAsync(ContrattiFornitoreDto dto)
        {
            var entity = dto.ToEntity<ContrattiFornitore, ContrattiFornitoreDto>();
            gaContrattiFornitoriRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiFornitoreAsync(long id)
        {
            var entity = await gaContrattiFornitoriRepo.GetByIdAsync(id);
            gaContrattiFornitoriRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiFornitoreAsync(long id, string partitaIva)
        {
            var entity = await gaContrattiFornitoriRepo.GetWithFilterAsync(x => x.PartitaIva == partitaIva && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiFornitoreAsync(long id)
        {
            var entity = await gaContrattiFornitoriRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiFornitoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiFornitoriRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #endregion

        #region Contratti Documenti
        public async Task<ContrattiDocumentiDto> GetGaContrattiDocumentiByIdAsync(long fornitoreId)
        {
            var entities = await gaContrattiDocumentiRepo.GetWithFilterAsync(x => x.ContrattiFornitoreId == fornitoreId, 1, 0);
            var dtos = entities.ToDto<ContrattiDocumentiDto, PagedList<ContrattiDocumento>>();
            return dtos;
        }

        public async Task<ContrattiDocumentoDto> GetGaContrattiDocumentoByIdAsync(long id)
        {
            var entity = await gaContrattiDocumentiRepo.GetByIdAsync(id);
            var dto = entity.ToDto<ContrattiDocumentoDto, ContrattiDocumento>();
            return dto;
        }

        public async Task<long> AddGaContrattiDocumentoAsync(ContrattiDocumentoDto dto)
        {
            var entity = dto.ToEntity<ContrattiDocumento, ContrattiDocumentoDto>();
            await gaContrattiDocumentiRepo.AddAsync(entity);
            await SaveChanges();
            return entity.Id;
        }

        public async Task<long> UpdateGaContrattiDocumentoAsync(ContrattiDocumentoDto dto)
        {
            var entity = dto.ToEntity<ContrattiDocumento, ContrattiDocumentoDto>();
            gaContrattiDocumentiRepo.Update(entity);
            await SaveChanges();

            return entity.Id;

        }

        public async Task<bool> DeleteGaContrattiDocumentoAsync(long id)
        {
            var entity = await gaContrattiDocumentiRepo.GetByIdAsync(id);
            gaContrattiDocumentiRepo.Remove(entity);
            await SaveChanges();

            return true;
        }

        #region Functions
        public async Task<bool> ValidateGaContrattiDocumentoAsync(long id, string descrizione)
        {
            var entity = await gaContrattiDocumentiRepo.GetWithFilterAsync(x => x.Descrizione == descrizione && x.Id != id);

            if (entity.Data.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<bool> ChangeStatusGaContrattiDocumentoAsync(long id)
        {
            var entity = await gaContrattiDocumentiRepo.GetByIdAsync(id);
            if (entity.Disabled)
            {
                entity.Disabled = false;
                gaContrattiDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }
            else
            {
                entity.Disabled = true;
                gaContrattiDocumentiRepo.Update(entity);
                await SaveChanges();
                return true;
            }

        }
        #endregion

        #region Views
        public async Task<PagedList<ViewGaContrattiDocumenti>> GetViewGaContrattiDocumentiByIdAsync(ContrattiDocumentiRequestDto dto)
        {
            try
            {
            PagedList<ViewGaContrattiDocumenti> entities = new PagedList<ViewGaContrattiDocumenti>();
            entities = await viewGaContrattiDocumentiRepo.GetWithFilterAsync(x => x.ContrattiFornitoreId == dto.fornitoreId && x.Archiviato == dto.archiviato, 1, 0);
            if (dto.userRoles.Contains("Administrator") || dto.userRoles.Contains("GaContrattiAdmin"))
            {
                return entities;
            }
            else
            {
                PagedList<ViewGaContrattiDocumenti> entitiesPermitted = new PagedList<ViewGaContrattiDocumenti>();

                var permessi = await viewGaContrattiUtentiOnPermessiRepo.GetWithFilterAsync(x => x.UtenteId == dto.userId && x.Abilitato == true);
                List<string> permessiList = new List<string>();
                foreach (var p in permessi.Data) { permessiList.Add(p.Permesso); }

                var contratti = await gaContrattiDocumentiRepo.GetWithFilterAsync(x => x.ContrattiFornitoreId == dto.fornitoreId);
                foreach (var itm in contratti.Data)
                {
                    List<string> permessiContratto = new List<string>();
                    if (itm.Direzione) permessiContratto.Add("DIREZIONE");
                    if (itm.Contabilita) permessiContratto.Add("CONTABILITA");
                    if (itm.Personale) permessiContratto.Add("PERSONALE");
                    if (itm.Informatica) permessiContratto.Add("INFORMATICA");
                    if (itm.Tecnico) permessiContratto.Add("TECNICO");
                    if (itm.QualitaSicurezza) permessiContratto.Add("QUALITASICUREZZA");
                    if (itm.Commerciale) permessiContratto.Add("COMMERCIALE");
                    if (itm.AffariGenerali) permessiContratto.Add("AFFARIGENERALI");
                    if (itm.Comunicazione) permessiContratto.Add("COMUNICAZIONE");

                    var check = permessiContratto.Intersect(permessiList, StringComparer.OrdinalIgnoreCase).Any();
                    if (check)
                    {
                        entitiesPermitted.Data.Add(entities.Data.Where(x => x.Id == itm.Id).FirstOrDefault());
                    }
                }
                    await SaveChanges();
                    return entitiesPermitted;
                }
            }
            catch (Exception ex)
            {
                await SaveChanges();
                throw;
            }
        }

        public async Task<PagedList<ViewGaContrattiDocumentiList>> GetViewGaContrattiDocumentiListByModeAsync(ContrattiDocumentiListRequestDto dto)
        {
            //Mode
            //1: Attivi
            //2: Passivi
            //3: Archivio
            //4: Totale


            {
                PagedList<ViewGaContrattiDocumentiList> entities = new PagedList<ViewGaContrattiDocumentiList>();
                PagedList<ContrattiDocumento> contratti = new PagedList<ContrattiDocumento>();


                switch (dto.mode)
                {
                    case 1:
                        entities = await viewGaContrattiDocumentiListRepo.GetWithFilterAsync(x => (x.TipologiaId == 1 || x.TipologiaId == 4) && x.Archiviato == false, 1, 0);
                        contratti = await gaContrattiDocumentiRepo.GetWithFilterAsync(x => (x.ContrattiTipologiaId == 1 || x.ContrattiTipologiaId == 4) && x.Archiviato == false, 1, 0);
                        break;
                    case 2:
                        entities = await viewGaContrattiDocumentiListRepo.GetWithFilterAsync(x => (x.TipologiaId == 2 || x.TipologiaId == 3) && x.Archiviato == false, 1, 0);
                        contratti = await gaContrattiDocumentiRepo.GetWithFilterAsync(x => (x.ContrattiTipologiaId == 2 || x.ContrattiTipologiaId == 3) && x.Archiviato == false, 1, 0);
                        break;
                    case 3:
                        entities = await viewGaContrattiDocumentiListRepo.GetWithFilterAsync(x => x.Archiviato == true, 1, 0);
                        contratti = await gaContrattiDocumentiRepo.GetWithFilterAsync(x => x.Archiviato == true, 1, 0);
                        break;
                    case 4:
                        entities = await viewGaContrattiDocumentiListRepo.GetAllAsync();
                        contratti = await gaContrattiDocumentiRepo.GetAllAsync();
                        break;
                }

                if (dto.userRoles.Contains("Administrator") || dto.userRoles.Contains("GaContrattiAdmin"))
                {
                    return entities;
                }
                else
                {
                    PagedList<ViewGaContrattiDocumentiList> entitiesPermitted = new PagedList<ViewGaContrattiDocumentiList>();

                    var permessi = await viewGaContrattiUtentiOnPermessiRepo.GetWithFilterAsync(x => x.UtenteId == dto.userId && x.Abilitato == true);
                    List<string> permessiList = new List<string>();
                    foreach (var p in permessi.Data) { permessiList.Add(p.Permesso); }

                    foreach (var itm in contratti.Data)
                    {
                        List<string> permessiContratto = new List<string>();
                        if (itm.Direzione) permessiContratto.Add("DIREZIONE");
                        if (itm.Contabilita) permessiContratto.Add("CONTABILITA");
                        if (itm.Personale) permessiContratto.Add("PERSONALE");
                        if (itm.Informatica) permessiContratto.Add("INFORMATICA");
                        if (itm.Tecnico) permessiContratto.Add("TECNICO");
                        if (itm.QualitaSicurezza) permessiContratto.Add("QUALITASICUREZZA");
                        if (itm.Commerciale) permessiContratto.Add("COMMERCIALE");
                        if (itm.AffariGenerali) permessiContratto.Add("AFFARIGENERALI");
                        if (itm.Comunicazione) permessiContratto.Add("COMUNICAZIONE");

                        var check = permessiContratto.Intersect(permessiList, StringComparer.OrdinalIgnoreCase).Any();
                        if (check)
                        {
                            entitiesPermitted.Data.Add(entities.Data.Where(x => x.Id == itm.Id).FirstOrDefault());
                        }
                    }
                    return entitiesPermitted;
                }
            }

        }

        public async Task<PagedList<ViewGaContrattiNumeratori>> GetViewGaContrattiNumeratoriAsync()
        {
                var entities = await viewGaContrattiNumeratoriRepo.GetAllAsync(1, 0);
                await SaveChanges();

                return entities;
        }
        #endregion

        #region Sp
        //public async Task<PagedList<SpGaContrattiNumeratore>> GetSpGaContrattiNumeratoreAsync()
        //{
        //    var entities = await spGaContrattiNumeratoreRepo.ExecStoreProcedureAsync("SP_GetGaContrattiNumeratori");

        //    var response = new PagedList<SpGaContrattiNumeratore>();
        //    response.Data.AddRange(entities.ToList());
        //    response.TotalCount = entities.Count();
        //    response.PageSize = 0;

        //    return response;
        //}

        //public async Task<PagedList<SpGaContrattiPermesso>> GetSpGaContrattiPermessoAsync(ContrattiDocumentiRequestDto dto)
        //{

        //    {
        //        var userId = new SqlParameter("@userId", dto.userId);
        //        var userRoles = SqlDbTypeExtensions.StringCollectionToParameter(dto.userRoles, "@userRoles");
        //        var fornitoreId = new SqlParameter("@fornitoreId", dto.fornitoreId);
        //        var archiviato = new SqlParameter("@archiviato", dto.archiviato);

        //        var entities = await spGaContrattiPermessoRepo.ExecStoreProcedureWithParamsAsync("SP_GetGaContrattiPermessi @userId,@userRoles,@fornitoreId,@archiviato", parameters: new[] { userId, userRoles, fornitoreId, archiviato });

        //        var response = new PagedList<SpGaContrattiPermesso>();
        //        response.Data.AddRange(entities.ToList());
        //        response.TotalCount = entities.Count();
        //        response.PageSize = 0;

        //        return response;
        //    }

        //}

        //public async Task<PagedList<SpGaContrattiPermessoMode>> GetSpGaContrattiPermessoModeAsync(ContrattiDocumentiListRequestDto dto)
        //{

        //    {
        //        var userId = new SqlParameter("@userId", dto.userId);
        //        var userRoles = SqlDbTypeExtensions.StringCollectionToParameter(dto.userRoles, "@userRoles");
        //        var mode = new SqlParameter("@mode", dto.mode);

        //        var entities = await spGaContrattiPermessoModeRepo.ExecStoreProcedureWithParamsAsync("SP_GetGaContrattiPermessiMode @userId,@userRoles,@mode", parameters: new[] { userId, userRoles, mode });

        //        var response = new PagedList<SpGaContrattiPermessoMode>();
        //        response.Data.AddRange(entities.ToList());
        //        response.TotalCount = entities.Count();
        //        response.PageSize = 0;

        //        return response;

                    

        //    }
        //}
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

    }
    #endregion
}