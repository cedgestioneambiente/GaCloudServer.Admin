using GaCloudServer.Admin.EntityFramework.Shared.Entities.Resources.CreDeb;
using GaCloudServer.Admin.EntityFramework.Shared.Infrastructure.Interfaces;
using GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi;
using GaCloudServer.BusinnessLogic.Mappers;
using GaCloudServer.BusinnessLogic.Services.Interfaces;
using GaCloudServer.Shared;
using System.Globalization;

namespace GaCloudServer.BusinnessLogic.Services
{
    public class GaCreDebService : IGaCreDebService
    {
        protected readonly IQueryManager queryManager;

        protected readonly IGenericRepository<CreDebConto> gaCreDebContiRepo;
        protected readonly IGenericRepository<CreDebCanale> gaCreDebCanaliRepo;
        protected readonly IGenericRepository<CreDebIncassiInObject> gaCreDebIncassiInObjectsRepo;
        protected readonly IGenericRepository<CreDebIncassiInObjectDetail> gaCreDebIncassiInObjectDetailsRepo;

        protected readonly IUnitOfWork unitOfWork;

        public GaCreDebService(
            IQueryManager queryManager,
            IGenericRepository<CreDebConto> gaCreDebContiRepo,
            IGenericRepository<CreDebCanale> gaCreDebCanaliRepo,
            IGenericRepository<CreDebIncassiInObject> gaCreDebIncassiInObjectsRepo,
            IGenericRepository<CreDebIncassiInObjectDetail> gaCreDebIncassiInObjectDetailsRepo,
            IUnitOfWork unitOfWork)
        {
            this.queryManager = queryManager;

            this.gaCreDebContiRepo = gaCreDebContiRepo;
            this.gaCreDebCanaliRepo = gaCreDebCanaliRepo;
            this.gaCreDebIncassiInObjectsRepo = gaCreDebIncassiInObjectsRepo;
            this.gaCreDebIncassiInObjectDetailsRepo = gaCreDebIncassiInObjectDetailsRepo;

            this.unitOfWork = unitOfWork;
        }

        #region CreDebConti
        public async Task<PageResponse<CreDebContoDto>> GetCreDebContiAsync(PageRequest request)
        {
            var entities = await gaCreDebContiRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CreDebContoDto>>();
            return dtos;
        }

        public async Task<CreDebContoDto> GetCreDebContoByIdAsync(long id)
        {
            var entity = await gaCreDebContiRepo.GetAsync(id, new GetRequest() { });
            var dto = entity.ToModel<CreDebContoDto>();
            return dto;
        }

        public async Task<long> CreateCreDebContoAsync(CreDebContoDto dto)
        {
            var entity = dto.ToEntity<CreDebConto>();
            var response = await gaCreDebContiRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCreDebContoAsync(long id, CreDebContoDto dto)
        {
            var entity = dto.ToEntity<CreDebConto>();
            var response = await gaCreDebContiRepo.UpdateAsync(entity);
            return response.Id;
        }

        public async Task<bool> DeleteCreDebContoAsync(long id)
        {
            await gaCreDebContiRepo.DeleteAsync(id);
            return true;
        }
        #endregion

        #region CreDebCanali
        public async Task<PageResponse<CreDebCanaleDto>> GetCreDebCanaliAsync(PageRequest request)
        {
            var entities = await gaCreDebCanaliRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CreDebCanaleDto>>();
            return dtos;
        }

        public async Task<CreDebCanaleDto> GetCreDebCanaleByIdAsync(long id)
        {
            var entity = await gaCreDebCanaliRepo.GetAsync(id, new GetRequest() { });
            var dto = entity.ToModel<CreDebCanaleDto>();
            return dto;
        }

        public async Task<long> CreateCreDebCanaleAsync(CreDebCanaleDto dto)
        {
            var entity = dto.ToEntity<CreDebCanale>();
            var response = await gaCreDebCanaliRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCreDebCanaleAsync(long id, CreDebCanaleDto dto)
        {
            var entity = dto.ToEntity<CreDebCanale>();
            var response = await gaCreDebCanaliRepo.UpdateAsync(entity);
            return response.Id;
        }

        public async Task<bool> DeleteCreDebCanaleAsync(long id)
        {
            await gaCreDebCanaliRepo.DeleteAsync(id);
            return true;
        }
        #endregion

        #region CreDebIncassiInObjects
        public async Task<PageResponse<CreDebIncassiInObjectDto>> GetCreDebIncassiInObjectsAsync(PageRequest request)
        {
            var entities = await gaCreDebIncassiInObjectsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CreDebIncassiInObjectDto>>();
            return dtos;
        }

        public async Task<CreDebIncassiInObjectDto> GetCreDebIncassiInObjectByIdAsync(long id)
        {
            var entity = await gaCreDebIncassiInObjectsRepo.GetAsync(id, new GetRequest() { });
            var dto = entity.ToModel<CreDebIncassiInObjectDto>();
            return dto;
        }

        public async Task<long> CreateCreDebIncassiInObjectAsync(CreDebIncassiInObjectDto dto)
        {
            var entity = dto.ToEntity<CreDebIncassiInObject>();
            var response = await gaCreDebIncassiInObjectsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCreDebIncassiInObjectAsync(long id, CreDebIncassiInObjectDto dto)
        {
            var entity = dto.ToEntity<CreDebIncassiInObject>();
            var response = await gaCreDebIncassiInObjectsRepo.UpdateAsync(entity);
            return response.Id;
        }

        public async Task<bool> DeleteCreDebIncassiInObjectAsync(long id)
        {
            await gaCreDebIncassiInObjectsRepo.DeleteAsync(id);
            return true;
        }

        #region Functions
        public async Task<bool> UpdateCreDebIncassiInObjectContabAsync(long id)
        {
            var entity = await gaCreDebIncassiInObjectsRepo.GetAsync(id, new GetRequest());
            entity.Contab = entity.Contab == null ? false : !entity.Contab;
            var response = await gaCreDebIncassiInObjectsRepo.UpdateAsync(entity);
            return true;

        }
        #endregion
        #endregion

        #region CreDebIncassiInObjectDetails
        public async Task<PageResponse<CreDebIncassiInObjectDetailDto>> GetCreDebIncassiInObjectDetailsAsync(PageRequest request)
        {
            var entities = await gaCreDebIncassiInObjectDetailsRepo.GetAsync(request);
            var dtos = entities.ToModel<PageResponse<CreDebIncassiInObjectDetailDto>>();
            return dtos;
        }

        public async Task<CreDebIncassiInObjectDetailDto> GetCreDebIncassiInObjectDetailByIdAsync(long id)
        {
            var entity = await gaCreDebIncassiInObjectDetailsRepo.GetAsync(id, new GetRequest() { });
            var dto = entity.ToModel<CreDebIncassiInObjectDetailDto>();
            return dto;
        }

        public async Task<long> CreateCreDebIncassiInObjectDetailAsync(CreDebIncassiInObjectDetailDto dto)
        {
            var entity = dto.ToEntity<CreDebIncassiInObjectDetail>();
            var response = await gaCreDebIncassiInObjectDetailsRepo.CreateAsync(entity);
            return entity.Id;
        }

        public async Task<long> UpdateCreDebIncassiInObjectDetailAsync(long id, CreDebIncassiInObjectDetailDto dto)
        {
            var entity = dto.ToEntity<CreDebIncassiInObjectDetail>();
            var response = await gaCreDebIncassiInObjectDetailsRepo.UpdateAsync(entity);
            return response.Id;
        }

        public async Task<bool> DeleteCreDebIncassiInObjectDetailAsync(long id)
        {
            await gaCreDebIncassiInObjectDetailsRepo.DeleteAsync(id);
            return true;
        }

        public async Task<bool> DeleteCreDebIncassiInObjectDetailByObjectIdAsync(long id)
        {
            var entityToDelete= await gaCreDebIncassiInObjectDetailsRepo.GetAsync( new PageRequest() {Filter=$"IdTask eq {id}" });
            if (entityToDelete == null)
                return false;
            foreach (var item in entityToDelete.Items)
                await gaCreDebIncassiInObjectDetailsRepo.DeleteAsync(item.Id);
            return true;
        }
        #endregion

        #region Export
        public async Task<string> GenerateCreDebRecordTextFileAsync(long id, List<CreDebIncassiExportResponseApiDto> defaultRecord, List<CreDebIncassiExportResponseApiDto> ritenuteRecord, bool newProcedure = false)
        {
            int i = 1;
            List<CreDebRecordDto> records = new List<CreDebRecordDto>();
            foreach (var item in defaultRecord)
            {
                CreDebRecordDto record = new CreDebRecordDto();
                CreDebIncassiInTestataDto testata = new CreDebIncassiInTestataDto()
                {
                    CODICE_SOCIETA = "01", // Valore fisso
                    CODICE_DIVISIONE = "1",
                    NUMERO_REGISTRAZIONE = i,
                    TIPO_MOVIMENTO = "M",
                    CODICE_CAUSALE_MODELL = "PNOTA",
                    SEGNO_TOTALE_OPERAZIONE = "+",
                    SIMULATA = "N",
                    FLAG_SCADENZA_UNICA = "N",
                    PROTOCOLLO_IVA = "0000000000",

                    // Imposta i valori letti dal database
                    DATA_REGISTRAZIONE = newProcedure?item.DataValuta: item.DataRegistrazione,
                    DATA_DOCUMENTO = item.DataDocumento,
                    DESCRIZIONE_MOVIMENTO = item.DescrizioneMovimento,
                    CONTO_CLIENTE_FORNITORE = item.ContoClienteFornitore,
                    TOTALE_OPERAZIONE = "0", //reader.GetString(4)
                    ESTREMI_DOCUMENTO = item.NumFat,
                    RAGIONESOCIALE =item.RagSoc,
                };

                record.testata = testata;
                CreDebIncassiInCogeDto cogeA = new CreDebIncassiInCogeDto()
                {
                    CODICE_SOCETA = "01",
                    CODICE_DIVISIONE = "1",
                    NUMERO_REGISTRAZIONE = i,
                    PROGRESSIVO_RIGA = 1,
                    SEGNO = "A",
                    DATA_REGISTRAZIONE =newProcedure?item.DataValuta: item.DataRegistrazione,
                    DATA_VALUTA =item.DataValuta,
                    DESCRIZIONE_RIGA = item.DescrizioneMovimento + " - " + item.Nota,
                    CONTO = item.ContoClienteFornitore,
                    IMPORTO = item.TotaleOperazione.Replace(",",""),
                    NOTA = item.Nota,
                };

                CreDebIncassiInCogeDto cogeD = new CreDebIncassiInCogeDto()
                {
                    CODICE_SOCETA = "01",
                    CODICE_DIVISIONE = "1",
                    NUMERO_REGISTRAZIONE = i,
                    PROGRESSIVO_RIGA = 1,
                    SEGNO = "D",
                    DATA_REGISTRAZIONE = newProcedure? item.DataValuta: item.DataRegistrazione,
                    DATA_VALUTA = item.DataValuta,
                    DESCRIZIONE_RIGA = item.DescrizioneMovimento + " - " + item.Nota,
                    CONTO = item.ContoPagamento,
                    IMPORTO = item.TotaleOperazione.Replace(",", ""),
                    NOTA = item.Nota,
                };

                record.cogeRows.Add(cogeD);
                record.cogeRows.Add(cogeA);

                records.Add(record);

                CreDebIncassiInObjectDetailDto creDebIncassiInObjectDetailDto = new CreDebIncassiInObjectDetailDto()
                {
                    Id = 0,
                    IdTask = id,
                    CodCli = item.CodCli,
                    NumFat = item.NumFat,
                    DtFat = item.DataDocumento,
                    DtAvPag = item.DataValuta,
                    DtReg = newProcedure ? item.DataValuta : item.DataRegistrazione,
                    ContoC = item.ContoC,
                    Canale = item.Canale,
                    Incrim = double.Parse(item.TotaleOperazione,CultureInfo.InvariantCulture),
                    Segno = "A",
                    Descrizione= item.DescrizioneMovimento,
                    Conto = item.ContoClienteFornitore,
                    UniqueKey=item.UniqueKey
                };

                await CreateCreDebIncassiInObjectDetailAsync(creDebIncassiInObjectDetailDto);
                i++;

            }

            foreach (var item in ritenuteRecord)
            {
                CreDebRecordDto record = new CreDebRecordDto();
                CreDebIncassiInTestataDto testata = new CreDebIncassiInTestataDto()
                {
                    CODICE_SOCIETA = "01", // Valore fisso
                    CODICE_DIVISIONE = "1",
                    NUMERO_REGISTRAZIONE = i,
                    TIPO_MOVIMENTO = "M",
                    CODICE_CAUSALE_MODELL = "PNOTA",
                    SEGNO_TOTALE_OPERAZIONE = "+",
                    SIMULATA = "N",
                    FLAG_SCADENZA_UNICA = "N",
                    PROTOCOLLO_IVA = "0000000000",

                    // Imposta i valori letti dal database
                    DATA_REGISTRAZIONE = newProcedure ? item.DataValuta : item.DataRegistrazione,
                    DATA_DOCUMENTO = item.DataDocumento,
                    DESCRIZIONE_MOVIMENTO = item.DescrizioneMovimento,
                    CONTO_CLIENTE_FORNITORE = item.ContoClienteFornitore,
                    TOTALE_OPERAZIONE = "0", //reader.GetString(4)
                    ESTREMI_DOCUMENTO = item.NumFat,
                    RAGIONESOCIALE = item.RagSoc,
                };

                record.testata = testata;
                CreDebIncassiInCogeDto cogeA = new CreDebIncassiInCogeDto()
                {
                    CODICE_SOCETA = "01",
                    CODICE_DIVISIONE = "1",
                    NUMERO_REGISTRAZIONE = i,
                    PROGRESSIVO_RIGA = 1,
                    SEGNO = "A",
                    DATA_REGISTRAZIONE = newProcedure ? item.DataValuta : item.DataRegistrazione,
                    DATA_VALUTA = item.DataValuta,
                    DESCRIZIONE_RIGA = item.DescrizioneMovimento + " - " + item.Nota,
                    CONTO = item.ContoPagamento,
                    IMPORTO = item.TotaleOperazione.Replace(",", ""),
                    NOTA = item.Nota,
                };

                CreDebIncassiInCogeDto cogeD = new CreDebIncassiInCogeDto()
                {
                    CODICE_SOCETA = "01",
                    CODICE_DIVISIONE = "1",
                    NUMERO_REGISTRAZIONE = i,
                    PROGRESSIVO_RIGA = 1,
                    SEGNO = "D",
                    DATA_REGISTRAZIONE = newProcedure ? item.DataValuta : item.DataRegistrazione,
                    DATA_VALUTA = item.DataValuta,
                    DESCRIZIONE_RIGA = item.DescrizioneMovimento + " - " + item.Nota,
                    CONTO = item.ContoClienteFornitore,
                    IMPORTO = item.TotaleOperazione.Replace(",", ""),
                    NOTA = item.Nota,
                };

                record.cogeRows.Add(cogeD);
                record.cogeRows.Add(cogeA);

                records.Add(record);

                CreDebIncassiInObjectDetailDto creDebIncassiInObjectDetailDto = new CreDebIncassiInObjectDetailDto()
                {
                    Id = 0,
                    IdTask = id,
                    CodCli = item.CodCli,
                    NumFat = item.NumFat,
                    DtFat = item.DataDocumento,
                    DtAvPag = item.DataValuta,
                    DtReg = newProcedure ? item.DataValuta : item.DataRegistrazione,
                    ContoC = item.ContoC,
                    Canale = item.Canale,
                    Incrim = double.Parse(item.TotaleOperazione, CultureInfo.InvariantCulture),
                    Segno = "A",
                    Descrizione = item.DescrizioneMovimento,
                    Conto = item.ContoClienteFornitore,
                    UniqueKey = item.UniqueKey
                };

                await CreateCreDebIncassiInObjectDetailAsync(creDebIncassiInObjectDetailDto);
                i++;

            }
            // Genera il record posizionale
            string incassiRecord = "";

            foreach (var row in records)
            {
                incassiRecord += row.testata.GetCompleteRecord();
                incassiRecord += "\r";
                foreach (var cogeRow in row.cogeRows)
                {
                    incassiRecord += cogeRow.GetCompleteRecord();
                    incassiRecord += "\r";
                }
            }
            return incassiRecord;
        }
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
    }
}