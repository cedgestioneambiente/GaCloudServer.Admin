using GaCloudServer.BusinnessLogic.DTOs.Base;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;

namespace GaCloudServer.BusinnessLogic.DTOs.Resources.Preventivi
{

    public class CreDebContoDto : GenericDto
    {
        public string ContoTari { get; set; }
        public string RagioneSociale { get; set; }
        public string CodFis { get; set; }
        public string PIva { get; set; }
        public string ContoNeta { get; set; }

    }

    public class CreDebCanaleDto : GenericDto
    {
        public string CodCanale { get; set; }
        public string DescCanale { get; set; }
        public string ContoNeta { get; set; }
        public bool Exclude { get; set; }

    }

    public class CreDebIncassiInObjectDto : GenericFileDto
    {
        public DateTime DtReg { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }

        public int NumPag { get; set; }
        public double TotPag { get; set; }
        public bool Contab { get; set; }

    }

    public class CreDebIncassiInObjectDetailDto : GenericDto
    {
        public long IdTask { get; set; }
        public string CodCli { get; set; }
        public string NumFat { get; set; }
        public DateTime DtFat { get; set; }
        public DateTime DtAvPag { get; set; }
        public DateTime DtReg { get; set; }
        public string ContoC { get; set; }
        public string Canale { get; set; }
        public double Incrim { get; set; }
        public string Descrizione { get; set; }
        public string Segno { get; set; }
        public string Conto { get; set; }
        public string UniqueKey { get; set; }

        public CreDebIncassiInObjectDto Task { get; set; }

    }

    public class CreDebIncassiInTestataDto
    {
        public string VERSIONE { get; set; } = "V0000"; // Lunghezza: 5, Posizione Inizio: 1, Posizione Fine: 5
        public string TIPO_RECORD { get; set; } = "T"; // Lunghezza: 1, Posizione Inizio: 6, Posizione Fine: 6
        public string CODICE_STUDIO { get; set; } = "1"; // Lunghezza: 1, Posizione Inizio: 7, Posizione Fine: 7
        public string CODICE_SOCIETA { get; set; } = "1"; // Lunghezza: 1, Posizione Inizio: 8, Posizione Fine: 8
        public string CODICE_DIVISIONE { get; set; } = "1"; // Lunghezza: 1, Posizione Inizio: 9, Posizione Fine: 9
        public DateTime DATA_REGISTRAZIONE { get; set; } // Lunghezza: 8, Posizione Inizio: 10, Posizione Fine: 17
        public int NUMERO_REGISTRAZIONE { get; set; } // Lunghezza: 6, Posizione Inizio: 18, Posizione Fine: 23
        public string TIPO_MOVIMENTO { get; set; } // Lunghezza: 1, Posizione Inizio: 24, Posizione Fine: 24
        public string CODICE_CAUSALE_MODELL { get; set; } // Lunghezza: 3, Posizione Inizio: 25, Posizione Fine: 27
        public string SEGNO_TOTALE_OPERAZIONE { get; set; } // Lunghezza: 1, Posizione Inizio: 28, Posizione Fine: 28
        public string TOTALE_OPERAZIONE { get; set; } // Lunghezza: 15, Posizione Inizio: 29, Posizione Fine: 43
        public string DESCRIZIONE_MOVIMENTO { get; set; } // Lunghezza: 50, Posizione Inizio: 44, Posizione Fine: 93
        public DateTime? DATA_DOCUMENTO { get; set; } // Lunghezza: 8, Posizione Inizio: 94, Posizione Fine: 101
        public string ESTREMI_DOCUMENTO { get; set; } // Lunghezza: 20, Posizione Inizio: 102, Posizione Fine: 121
        public string CODICE_SEZIONALE_IVA { get; set; } // Lunghezza: 2, Posizione Inizio: 122, Posizione Fine: 123
        public string PROTOCOLLO_IVA { get; set; } // Lunghezza: 10, Posizione Inizio: 124, Posizione Fine: 133
        public string TIPO_DOCUMENTO { get; set; } // Lunghezza: 2, Posizione Inizio: 134, Posizione Fine: 135
        public string CONTO_CLIENTE_FORNITORE { get; set; } // Lunghezza: 20, Posizione Inizio: 136, Posizione Fine: 155
        public string MODALITA_PAGAMENTO { get; set; } // Lunghezza: 15, Posizione Inizio: 156, Posizione Fine: 170
        public string CONDIZIONE_PAGAMENTO { get; set; } // Lunghezza: 15, Posizione Inizio: 171, Posizione Fine: 185
        public string SIMULATA { get; set; } // Lunghezza: 1, Posizione Inizio: 186, Posizione Fine: 186
        public DateTime? DATA_INTERCETTAZZIONE { get; set; } // Lunghezza: 8, Posizione Inizio: 187, Posizione Fine: 194
        public string CODICE_CLASSE_REGISTRAZIONE { get; set; } // Lunghezza: 2, Posizione Inizio: 195, Posizione Fine: 196
        public string CODICE_CAUSALE { get; set; } // Lunghezza: 4, Posizione Inizio: 197, Posizione Fine: 200
        public string CODICE_CENTER { get; set; } // Lunghezza: 4, Posizione Inizio: 201, Posizione Fine: 204
        public string NOTA_PARTITA { get; set; } // Lunghezza: 50, Posizione Inizio: 205, Posizione Fine: 254
        public string CODICE_CLASSE_ECONOMICA { get; set; } // Lunghezza: 5, Posizione Inizio: 255, Posizione Fine: 259
        public string CODICE_FACTOR { get; set; } // Lunghezza: 5, Posizione Inizio: 260, Posizione Fine: 264
        public decimal TOTALE_A_PAGARE { get; set; } // Lunghezza: 15, Posizione Inizio: 265, Posizione Fine: 279
        public string CODICE_VARIANTE { get; set; } // Lunghezza: 5, Posizione Inizio: 280, Posizione Fine: 284
        public string CODICE_AGENTE { get; set; } // Lunghezza: 5, Posizione Inizio: 285, Posizione Fine: 289
        public string CODICE_BLOCCO { get; set; } // Lunghezza: 5, Posizione Inizio: 290, Posizione Fine: 294
        public string MOTIVAZIONI { get; set; } // Lunghezza: 100, Posizione Inizio: 295, Posizione Fine: 394
        public string MASTRO_SOGGETTO { get; set; } // Lunghezza: 30, Posizione Inizio: 395, Posizione Fine: 424
        public string CODICE_FISCALE_SOGGETTO { get; set; } // Lunghezza: 16, Posizione Inizio: 425, Posizione Fine: 440
        public string PARTITA_IVA_SOGGETTO { get; set; } // Lunghezza: 11, Posizione Inizio: 441, Posizione Fine: 451
        public string RAGIONESOCIALE { get; set; } // Lunghezza: 50, Posizione Inizio: 452, Posizione Fine: 501
        public string VIA { get; set; } // Lunghezza: 50, Posizione Inizio: 502, Posizione Fine: 551
        public string NUMERO_CIVICO { get; set; } // Lunghezza: 10, Posizione Inizio: 552, Posizione Fine: 561
        public string CAP { get; set; } // Lunghezza: 5, Posizione Inizio: 562, Posizione Fine: 566
        public string LOCALITA { get; set; } // Lunghezza: 30, Posizione Inizio: 567, Posizione Fine: 596
        public string PROVINCIA { get; set; } // Lunghezza: 2, Posizione Inizio: 597, Posizione Fine: 598
        public string NAZIONE_SOGGETTO { get; set; } // Lunghezza: 2, Posizione Inizio: 599, Posizione Fine: 600
        public string TELEFONO { get; set; } // Lunghezza: 20, Posizione Inizio: 601, Posizione Fine: 620
        public string FAX { get; set; } // Lunghezza: 20, Posizione Inizio: 621, Posizione Fine: 640
        public string EMAIL_SOGGETTO { get; set; } // Lunghezza: 100, Posizione Inizio: 641, Posizione Fine: 740
        public string CIN_SOGGETTO { get; set; } // Lunghezza: 2, Posizione Inizio: 741, Posizione Fine: 742
        public string ABI_SOGGETTO { get; set; } // Lunghezza: 5, Posizione Inizio: 743, Posizione Fine: 747
        public string CAB_SOGGETTO { get; set; } // Lunghezza: 5, Posizione Inizio: 748, Posizione Fine: 752
        public string CC_SOGGETTO { get; set; } // Lunghezza: 12, Posizione Inizio: 753, Posizione Fine: 764

        // TIPO PAGAMENTO SOGGETTO (15 caratteri)
        public string TIPO_PAGAMENTO_SOGGETTO { get; set; }

        // CONDIZIONE PAGAMENTO SOGGETTO (15 caratteri)
        public string CONDIZIONE_PAGAMENTO_SOGGETTO { get; set; }

        // DATA SCADENZA (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_SCADENZA { get; set; }

        // FLAG SCADENZA UNICA (1 carattere)
        public string FLAG_SCADENZA_UNICA { get; set; }

        // CATEGORIA IVA (15 caratteri)
        public string CATEGORIA_IVA { get; set; }

        // CHECK DIGIT SOGGETTO (2 caratteri)
        public string CHECK_DIGIT_SOGGETTO { get; set; }

        // DATA ARRIVO (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_ARRIVO { get; set; }

        // CODICE SOGGETTO (15 caratteri)
        public string CODICE_SOGGETTO { get; set; }

        // TIPO CONTO (1 carattere)
        public string TIPO_CONTO { get; set; }

        // TIPO SEQUENZA (4 caratteri)
        public string TIPO_SEQUENZA { get; set; }

        // DATA SOTTOSCRIZIONE MANDATO (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_SOTTOSCRIZIONE_MANDATO { get; set; }

        // ID DOCUMENTO ESTERNO (50 caratteri)
        public string ID_DOCUMENTO_ESTERNO { get; set; }

        // INVIO INFO AGGIUNTIVE (1 carattere)
        public string INVIO_INFO_AGGIUNTIVE { get; set; }


        // Funzione che restituisce la stringa completa
        public string GetCompleteRecord()
        {
            StringBuilder sb = new StringBuilder();

            // VERSIONE (Alfa, lunghezza 5)
            sb.Append(VERSIONE?.PadRight(5) ?? "".PadRight(5));

            // TIPO RECORD (Alfa, lunghezza 1)
            sb.Append(TIPO_RECORD?.PadRight(1) ?? "".PadRight(1));

            // CODICE STUDIO (Alfa, lunghezza 15)
            sb.Append(CODICE_STUDIO?.PadRight(15) ?? "".PadRight(15));

            // CODICE SOCIETA (Alfa, lunghezza 15)
            sb.Append(CODICE_SOCIETA?.PadRight(15) ?? "".PadRight(15));

            // CODICE DIVISIONE (Alfa, lunghezza 15)
            sb.Append(CODICE_DIVISIONE?.PadRight(15) ?? "".PadRight(15));

            // DATA REGISTRAZIONE (Data, lunghezza 8)
            sb.Append(DATA_REGISTRAZIONE.ToString("ddMMyyyy").PadRight(8) ?? "".PadRight(8));

            // NUMERO REGISTRAZIONE (Num, lunghezza 8)
            sb.Append(NUMERO_REGISTRAZIONE.ToString().PadLeft(8, '0') ?? "".PadRight(8, '0'));

            // TIPO MOVIMENTO (Alfa, lunghezza 1)
            sb.Append(TIPO_MOVIMENTO?.PadRight(1) ?? "".PadRight(1));

            // CODICE CAUSALE MODELLO (Alfa, lunghezza 15)
            sb.Append(CODICE_CAUSALE_MODELL?.PadRight(15) ?? "".PadRight(15));

            // SEGNO TOTALE OPERAZIONE (Alfa, lunghezza 1)
            sb.Append(SEGNO_TOTALE_OPERAZIONE?.PadRight(1) ?? "".PadRight(1));

            // TOTALE OPERAZIONE (Num, lunghezza 15, 13+2)
            sb.Append(TOTALE_OPERAZIONE.ToString().PadLeft(15, '0') ?? "".PadRight(15, '0'));

            // DESCRIZIONE MOVIMENTO (Alfa, lunghezza 255)
            sb.Append(DESCRIZIONE_MOVIMENTO?.PadRight(255) ?? "".PadRight(255));

            // DATA DOCUMENTO (Data, lunghezza 8)
            sb.Append(DATA_DOCUMENTO?.ToString("ddMMyyyy").PadRight(8) ?? "".PadRight(8));

            // ESTREMI DOCUMENTO (Alfa, lunghezza 15)
            sb.Append(ESTREMI_DOCUMENTO?.PadRight(15) ?? "".PadRight(15));

            // CODICE SEZIONALE IVA (Alfa, lunghezza 15)
            sb.Append(CODICE_SEZIONALE_IVA?.PadRight(15) ?? "".PadRight(15));

            // PROTOCOLLO IVA (Num, lunghezza 10, 8+2)
            sb.Append(PROTOCOLLO_IVA?.PadRight(10) ?? "".PadRight(10));

            // TIPO DOCUMENTO (Alfa, lunghezza 1)
            sb.Append(TIPO_DOCUMENTO?.PadRight(1) ?? "".PadRight(1));

            // CONTO CLIENTE / FORNITORE (Alfa, lunghezza 15)
            sb.Append(CONTO_CLIENTE_FORNITORE?.PadRight(15) ?? "".PadRight(15));

            // MODALITA PAGAMENTO (Alfa, lunghezza 15)
            sb.Append(MODALITA_PAGAMENTO?.PadRight(15) ?? "".PadRight(15));

            // CONDIZIONE PAGAMENTO (Alfa, lunghezza 15)
            sb.Append(CONDIZIONE_PAGAMENTO?.PadRight(15) ?? "".PadRight(15));

            // SIMULATA (Alfa, lunghezza 1)
            sb.Append(SIMULATA?.PadRight(1) ?? "".PadRight(1));

            // DATA INTERCETTAZZIONE (Data, lunghezza 8)
            sb.Append(DATA_INTERCETTAZZIONE?.ToString("ddMMyyyy").PadRight(8) ?? "".PadRight(8));

            // CODICE CLASSE REGISTRAZIONE (Alfa, lunghezza 15)
            sb.Append(CODICE_CLASSE_REGISTRAZIONE?.PadRight(15) ?? "".PadRight(15));

            // CODICE CAUSALE (Alfa, lunghezza 15)
            sb.Append(CODICE_CAUSALE?.PadRight(15) ?? "".PadRight(15));

            // CODICE CENTER (Alfa, lunghezza 15)
            sb.Append(CODICE_CENTER?.PadRight(15) ?? "".PadRight(15));

            // NOTA PARTITA (Alfa, lunghezza 255)
            sb.Append(NOTA_PARTITA?.PadRight(255) ?? "".PadRight(255));

            // CODICE CLASSE ECONOMICA (Alfa, lunghezza 15)
            sb.Append(CODICE_CLASSE_ECONOMICA?.PadRight(15) ?? "".PadRight(15));

            // CODICE FACTOR (Alfa, lunghezza 15)
            sb.Append(CODICE_FACTOR?.PadRight(15) ?? "".PadRight(15));

            // TOTALE A PAGARE (Num, lunghezza 15)
            sb.Append(TOTALE_A_PAGARE.ToString("000").PadRight(15, '0') ?? "".PadRight(15, '0'));

            // CODICE VARIANTE (Alfa, lunghezza 15)
            sb.Append(CODICE_VARIANTE?.PadRight(15) ?? "".PadRight(15));

            // CODICE AGENTE (Alfa, lunghezza 15)
            sb.Append(CODICE_AGENTE?.PadRight(15) ?? "".PadRight(15));

            // CODICE BLOCCO (Alfa, lunghezza 15)
            sb.Append(CODICE_BLOCCO?.PadRight(15) ?? "".PadRight(15));

            // MOTIVAZIONI (Alfa, lunghezza 255)
            sb.Append(MOTIVAZIONI?.PadRight(255) ?? "".PadRight(255));

            // MASTRO SOGGETTO (Alfa, lunghezza 15)
            sb.Append(MASTRO_SOGGETTO?.PadRight(15) ?? "".PadRight(15));

            // CODICE FISCALE SOGGETTO (Alfa, lunghezza 16)
            sb.Append(CODICE_FISCALE_SOGGETTO?.PadRight(16) ?? "".PadRight(16));

            // PARTITA IVA SOGGETTO (Alfa, lunghezza 11)
            sb.Append(PARTITA_IVA_SOGGETTO?.PadRight(12) ?? "".PadRight(12));

            // RAGIONE SOCIALE (Alfa, lunghezza 50)
            sb.Append(RAGIONESOCIALE?.PadRight(255) ?? "".PadRight(255));

            // VIA (Alfa, lunghezza 50)
            sb.Append(VIA?.PadRight(50) ?? "".PadRight(50));

            // NUMERO CIVICO (Alfa, lunghezza 10)
            sb.Append(NUMERO_CIVICO?.PadRight(5) ?? "".PadRight(5));

            // CAP (Alfa, lunghezza 5)
            sb.Append(CAP?.PadRight(10) ?? "".PadRight(10));

            // LOCALITA (Alfa, lunghezza 30)
            sb.Append(LOCALITA?.PadRight(50) ?? "".PadRight(50));

            // PROVINCIA (Alfa, lunghezza 2)
            sb.Append(PROVINCIA?.PadRight(50) ?? "".PadRight(50));

            // NAZIONE SOGGETTO (Alfa, lunghezza 2)
            sb.Append(NAZIONE_SOGGETTO?.PadRight(2) ?? "".PadRight(2));

            // TELEFONO (Alfa, lunghezza 20)
            sb.Append(TELEFONO?.PadRight(50) ?? "".PadRight(50));

            // FAX (Alfa, lunghezza 20)
            sb.Append(FAX?.PadRight(50) ?? "".PadRight(50));

            // EMAIL SOGGETTO (Alfa, lunghezza 100)
            sb.Append(EMAIL_SOGGETTO?.PadRight(100) ?? "".PadRight(100));

            // CIN SOGGETTO (Alfa, lunghezza 2)
            sb.Append(CIN_SOGGETTO?.PadRight(1) ?? "".PadRight(1));

            // ABI SOGGETTO (Num, lunghezza 5)
            sb.Append(ABI_SOGGETTO?.PadRight(5) ?? "".PadRight(5));

            // CAB SOGGETTO (Num, lunghezza 5)
            sb.Append(CAB_SOGGETTO?.PadRight(5) ?? "".PadRight(5));

            // CC SOGGETTO (Num, lunghezza 12)
            sb.Append(CC_SOGGETTO?.PadRight(35) ?? "".PadRight(35));

            // TIPO PAGAMENTO SOGGETTO (15 caratteri)
            sb.Append(TIPO_PAGAMENTO_SOGGETTO?.PadRight(15) ?? "".PadRight(15));

            // CONDIZIONE PAGAMENTO SOGGETTO (15 caratteri)
            sb.Append(CONDIZIONE_PAGAMENTO_SOGGETTO?.PadRight(15) ?? "".PadRight(15));

            // DATA SCADENZA (8 caratteri in formato GGMMAAAA)
            sb.Append(DATA_SCADENZA?.ToString("ddMMyyyy").PadRight(8) ?? "".PadRight(8));

            // FLAG SCADENZA UNICA (1 carattere)
            sb.Append(FLAG_SCADENZA_UNICA?.PadRight(1) ?? "".PadRight(1));

            // CATEGORIA IVA (15 caratteri)
            sb.Append(CATEGORIA_IVA?.PadRight(15) ?? "".PadRight(15));

            // CHECK DIGIT SOGGETTO (2 caratteri)
            sb.Append(CHECK_DIGIT_SOGGETTO?.PadRight(2) ?? "".PadRight(2));

            // DATA ARRIVO (8 caratteri in formato GGMMAAAA)
            sb.Append(DATA_ARRIVO?.ToString("ddMMyyyy").PadRight(8) ?? "".PadRight(8));

            // CODICE SOGGETTO (15 caratteri)
            sb.Append(CODICE_SOGGETTO?.PadRight(15) ?? "".PadRight(15));

            // TIPO CONTO (1 carattere)
            sb.Append(TIPO_CONTO?.PadRight(1) ?? "".PadRight(1));

            // TIPO SEQUENZA (4 caratteri)
            sb.Append(TIPO_SEQUENZA?.PadRight(4) ?? "".PadRight(4));

            // DATA SOTTOSCRIZIONE MANDATO (8 caratteri in formato GGMMAAAA)
            sb.Append(DATA_SOTTOSCRIZIONE_MANDATO?.ToString("ddMMyyyy").PadRight(8) ?? "".PadRight(8));

            // ID DOCUMENTO ESTERNO (50 caratteri)
            sb.Append(ID_DOCUMENTO_ESTERNO?.PadRight(50) ?? "".PadRight(50));

            // INVIO INFO AGGIUNTIVE (1 carattere)
            sb.Append(INVIO_INFO_AGGIUNTIVE?.PadRight(1) ?? "".PadRight(1));

            return sb.ToString();
        }

    }
    public class CreDebIncassiInCogeDto
    {
        // VERSIONE (5 caratteri)
        public string VERSIONE { get; set; } = "V0000";

        // TIPO RECORD (1 carattere)
        public string TIPO_RECORD { get; set; } = "C";

        // CODICE STUDIO (15 caratteri)
        public string CODICE_STUDIO { get; set; } = "1";

        // CODICE SOCIETA (15 caratteri)
        public string CODICE_SOCETA { get; set; }

        // CODICE DIVISIONE (15 caratteri)
        public string CODICE_DIVISIONE { get; set; }

        // DATA REGISTRAZIONE (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_REGISTRAZIONE { get; set; }

        // NUMERO REGISTRAZIONE (8 caratteri interi)
        public int NUMERO_REGISTRAZIONE { get; set; }

        // PROGRESSIVO RIGA (4 caratteri interi)
        public int PROGRESSIVO_RIGA { get; set; } = 1;

        // CONTO (15 caratteri)
        public string CONTO { get; set; }

        // IMPORTO (15 caratteri con 2 decimali)
        public string? IMPORTO { get; set; }

        // SEGNO (1 carattere)
        public string SEGNO { get; set; }

        // DESCRIZIONE RIGA (255 caratteri)
        public string DESCRIZIONE_RIGA { get; set; }

        // CODICE CAUSALE (15 caratteri)
        public string CODICE_CAUSALE { get; set; }

        // CODICE CENTER (15 caratteri)
        public string CODICE_CENTER { get; set; }

        // DATA INIZIO COMPETENZA (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_INIZIO_COMPETENZA { get; set; }

        // DATA FINE COMPETENZA (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_FINE_COMPETENZA { get; set; }

        // DATA VALUTA (8 caratteri in formato GGMMAAAA)
        public DateTime? DATA_VALUTA { get; set; }

        // NUMERO REG PARCELLA (8 caratteri interi)
        public int? NUMERO_REG_PARCELLA { get; set; }

        // CODICE TRIBUTO (15 caratteri)
        public string CODICE_TRIBUTO { get; set; }

        // SEGNO IMPONIBILE (1 carattere)
        public string SEGNO_IMPONIBILE { get; set; }

        // IMPONIBILE (15 caratteri con 2 decimali)
        public decimal? IMPONIBILE { get; set; }

        // SEGNO RITENUTA (1 carattere)
        public string SEGNO_RITENUTA { get; set; }

        // RITENUTA (15 caratteri con 2 decimali)
        public decimal? RITENUTA { get; set; }

        // NOTA (255 caratteri)
        public string NOTA { get; set; }

        // CATEGORIA IVA (15 caratteri)
        public string CATEGORIA_IVA { get; set; }

        // Funzione per restituire il record completo formattato
        public string GetCompleteRecord()
        {
            return $"{VERSIONE.PadRight(5)}" +
                   $"{(TIPO_RECORD?.PadRight(1) ?? string.Empty.PadRight(1))}" +
                   $"{(CODICE_STUDIO?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{(CODICE_SOCETA?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{(CODICE_DIVISIONE?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{(DATA_REGISTRAZIONE.HasValue ? DATA_REGISTRAZIONE.Value.ToString("ddMMyyyy") : string.Empty).PadRight(8)}" +
                   $"{NUMERO_REGISTRAZIONE.ToString().PadLeft(8, '0')}" +
                   $"{PROGRESSIVO_RIGA.ToString().PadRight(4)}" +
                   $"{(CONTO?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{IMPORTO?.ToString().PadLeft(15, '0') ?? string.Empty.PadLeft(15, '0')}" +
                   $"{(SEGNO?.PadRight(1) ?? string.Empty.PadRight(1))}" +
                   $"{(DESCRIZIONE_RIGA?.PadRight(255) ?? string.Empty.PadRight(255))}" +
                   $"{(CODICE_CAUSALE?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{(CODICE_CENTER?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{(DATA_INIZIO_COMPETENZA.HasValue ? DATA_INIZIO_COMPETENZA.Value.ToString("ddMMyyyy") : string.Empty).PadRight(8)}" +
                   $"{(DATA_FINE_COMPETENZA.HasValue ? DATA_FINE_COMPETENZA.Value.ToString("ddMMyyyy") : string.Empty).PadRight(8)}" +
                   $"{(DATA_VALUTA.HasValue ? DATA_VALUTA.Value.ToString("ddMMyyyy") : string.Empty).PadRight(8)}" +
                   $"{NUMERO_REG_PARCELLA?.ToString().PadRight(8) ?? String.Empty.PadRight(8)}" +
                   $"{(CODICE_TRIBUTO?.PadRight(15) ?? string.Empty.PadRight(15))}" +
                   $"{(SEGNO_IMPONIBILE?.PadRight(1) ?? string.Empty.PadRight(1))}" +
                   $"{IMPONIBILE?.ToString().PadLeft(15, '0') ?? String.Empty.PadRight(15)}" +
                   $"{(SEGNO_RITENUTA?.PadRight(1) ?? string.Empty.PadRight(1))}" +
                   $"{RITENUTA?.ToString().PadRight(15, '0') ?? String.Empty.PadRight(15)}" +
                   $"{(NOTA?.PadRight(255) ?? string.Empty.PadRight(255))}" +
                   $"{(CATEGORIA_IVA?.PadRight(15) ?? string.Empty.PadRight(15))}";
        }
    }
    public class CreDebRecordDto
    {
        public CreDebIncassiInTestataDto testata { get; set; }
        public List<CreDebIncassiInCogeDto> cogeRows { get; set; }


        public CreDebRecordDto()
        {
            cogeRows = new List<CreDebIncassiInCogeDto>();
        }



    }


    #region Api
    public class CreDebIncassiExportResponseApiDto
    {
        public DateTime DataRegistrazione { get; set; }
        public DateTime DataDocumento { get; set; }
        public string DescrizioneMovimento { get; set; }
        public string ContoClienteFornitore { get; set; }
        public string TotaleOperazione { get; set; }  // valuta conversione in decimal
        public DateTime DataValuta { get; set; }
        public string ContoPagamento { get; set; }
        public DateTime DataPagamento { get; set; }
        public string Nota { get; set; }
        public string NumFat { get; set; }
        public string RagSoc { get; set; }
        public string CodCli { get; set; }
        public string ContoC { get; set; }
        public string Canale { get; set; }
        public string UniqueKey { get; set; }

        public void Clean()
        {
            foreach (var prop in this.GetType().GetProperties().Where(p => p.PropertyType == typeof(string)))
            {
                var val = prop.GetValue(this) as string;
                if (val != null)
                    prop.SetValue(this, val.Trim());
            }
        }
    }

    public class CreDebIncassiExportRequestApiDto
    {
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
    }

    #endregion
}