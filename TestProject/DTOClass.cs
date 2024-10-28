using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class PercentValidateDto
    {
        public double percent { get; set; }
        public long foundId { get; set; }
        public string Message { get; set; }  // Messaggio per i risultati
    }

    public static class SimilarityHelper
    {
        public static double CalculateSimilarity(string str1, string str2)
        {
            int maxLen = Math.Max(str1.Length, str2.Length);
            int levenshteinDistance = CalculateLevenshtein(str1, str2);
            return 1.0 - (double)levenshteinDistance / maxLen;
        }

        private static int CalculateLevenshtein(string str1, string str2)
        {
            // Implementazione algoritmo di Levenshtein per il calcolo della distanza
            // ...
            return 0; // Placeholder, aggiungi la logica per Levenshtein
        }
    }
}
