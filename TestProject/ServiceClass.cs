using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TestProject
{
    public class AnagraficaServiceStandalone
    {
        private readonly double indirizzoWeight;
        private readonly double ragSoWeight;
        private readonly double similarityThreshold;

        public AnagraficaServiceStandalone(double indirizzoWeight = 0.5, double ragSoWeight = 0.5, double similarityThreshold = 0.65)
        {
            // Normalizza i pesi
            double totalWeight = indirizzoWeight + ragSoWeight;
            this.indirizzoWeight = indirizzoWeight / totalWeight;
            this.ragSoWeight = ragSoWeight / totalWeight;

            // Soglia di similarità dinamica
            this.similarityThreshold = similarityThreshold;
        }


        public Task<PercentValidateDto> ValidateConsistentRegistryAsync(long id, string cfPiva, string indirizzo, string ragSo, long comuneId)
        {
            // Dati di test hardcoded
            var aziendePredefinite = new[]
            {
                new { Id=1, CfPiva = "1492290067", Indirizzo = "EX S.S. 35 DEI GIOVI 42, 15057 TORTONA (AL)", Descrizione = "GESTIONE AMBIENTE S.p.A.", ComuneId = 1196 },
                new { Id=2,CfPiva = "03083200109", Indirizzo = "STRADA SAVONESA, 8 - 15057 TORTONA (AL)", Descrizione = "RELIFE RECYCLING S.P.L.", ComuneId = 1196 },
                new { Id=3,CfPiva = "03083200109", Indirizzo = "STRADA SAVONESA, 8 - 15057 TORTONA (AL)", Descrizione = "RELIFE RECYCLING S.R.L.", ComuneId = 1196 }
            };

            PercentValidateDto bestMatch = new PercentValidateDto { foundId = -1, percent = 0, Message = "Nessun soggetto simile trovato",Subject="" };

            //double totalScore = new List<double>() { indirizzoSimilarityScore, ragSoSimilarityScore }.Average();

            // Controllo per soggetti simili
            foreach (var azienda in aziendePredefinite)
            {
                if (azienda.CfPiva == cfPiva && azienda.ComuneId == comuneId)
                {
                    double indirizzoSimilarityScore = CalculateSimilarity(azienda.Indirizzo, indirizzo);
                    double ragSoSimilarityScore = CalculateSimilarity(azienda.Descrizione, ragSo);

                    // Calcola la media ponderata
                    double weightedAverage = (indirizzoSimilarityScore * indirizzoWeight) + (ragSoSimilarityScore * ragSoWeight);


                    // Controlla se la media ponderata supera la soglia impostata
                    if (weightedAverage > similarityThreshold && weightedAverage > bestMatch.percent)
                    {
                        bestMatch = new PercentValidateDto
                        {
                            foundId = azienda.Id, // ID fittizio
                            percent = weightedAverage,
                            Message = "Trovato soggetto simile",
                            Subject=String.Concat(azienda.Descrizione,"-",azienda.CfPiva,"-",azienda.Indirizzo)
                        };
                    }
                }
            }

            return Task.FromResult(bestMatch);
        }

        private double CalculateSimilarity(string str1, string str2)
        {
            // Normalizza le stringhe
            str1 = NormalizeString(str1);
            str2 = NormalizeString(str2);

            // Calcola la distanza di Levenshtein
            int distance = LevenshteinDistance(str1, str2);
            int maxLength = Math.Max(str1.Length, str2.Length);

            // Ritorna il punteggio di similarità normalizzato
            return (maxLength - distance) / (double)maxLength;
        }

        private string NormalizeString(string input)
        {
            // Rimuove caratteri speciali, spazi extra e converte in minuscolo
            if (string.IsNullOrEmpty(input)) return string.Empty;

            input = Regex.Replace(input, @"[^\w\s]", ""); // Rimuove caratteri speciali
            input = Regex.Replace(input, @"\s+", " "); // Sostituisce spazi multipli con uno singolo
            return input.Trim().ToLower(); // Converte in minuscolo
        }

        private int LevenshteinDistance(string s, string t)
        {
            // Algoritmo per calcolare la distanza di Levenshtein
            int n = s.Length;
            int m = t.Length;
            var d = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++) d[i, 0] = i; // Deletion
            for (int j = 0; j <= m; j++) d[0, j] = j; // Insertion

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;

                    d[i, j] = Math.Min(Math.Min(
                        d[i - 1, j] + 1,    // Deletion
                        d[i, j - 1] + 1),   // Insertion
                        d[i - 1, j - 1] + cost); // Substitution
                }
            }

            return d[n, m];
        }
    }
}
