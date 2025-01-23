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
                new { Id=1, CfPiva = "00443150065", Indirizzo = "VIA ROMA, 81 - 15050 MOLINO DEI TORTI (AL)", Descrizione = "COMUNE DI MOLINO DEI TORTI", ComuneId = 945 },
               
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

        public double CalculateSimilarityV2(
        string ragioneSociale1, string indirizzo1, string piva1, int comuneId1,
        string ragioneSociale2, string indirizzo2, string piva2, int comuneId2)
        {
            // Funzione per calcolare la similitudine tra stringhe
            double StringSimilarity(string s1, string s2)
            {
                // Normalizzazione e confronto case insensitive
                s1 = s1?.ToLowerInvariant().Trim() ?? string.Empty;
                s2 = s2?.ToLowerInvariant().Trim() ?? string.Empty;

                // Se sono identiche, massimo punteggio
                if (s1 == s2) return 1.0;

                // Calcolo approssimativo usando il numero di caratteri comuni
                int commonChars = 0;
                int maxLength = Math.Max(s1.Length, s2.Length);

                foreach (char c in s1)
                    if (s2.Contains(c)) commonChars++;

                return (double)commonChars / maxLength;
            }

            // Confronto dei campi
            double ragioneSocialeScore = StringSimilarity(ragioneSociale1, ragioneSociale2);
            double indirizzoScore = StringSimilarity(indirizzo1, indirizzo2);
            double pivaScore = piva1 == piva2 ? 1.0 : 0.0;
            double comuneIdScore = comuneId1 == comuneId2 ? 1.0 : 0.0;

            // Pesi per ogni campo (aggiusta in base alle priorità)
            double ragioneSocialeWeight = 0.4;
            double indirizzoWeight = 0.3;
            double pivaWeight = 0.2;
            double comuneIdWeight = 0.1;

            // Calcolo della percentuale finale
            double similarity =
                (ragioneSocialeScore * ragioneSocialeWeight) +
                (indirizzoScore * indirizzoWeight) +
                (pivaScore * pivaWeight) +
                (comuneIdScore * comuneIdWeight);

            // Converti in percentuale
            return similarity * 100;
        }
    }
}
