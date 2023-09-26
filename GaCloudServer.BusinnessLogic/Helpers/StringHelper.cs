using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    public class StringHelper
    {
        public static Dictionary<string, double> CalculateEquality(string inputString, string[] arrayDiStringhe)
        {
            Dictionary<string, double> percentualiDiSomiglianza = new Dictionary<string, double>();

            foreach (string confrontaStringa in arrayDiStringhe)
            {
                double somiglianza = CalculateEqualityJaccard(inputString, confrontaStringa);
                percentualiDiSomiglianza.Add(confrontaStringa, somiglianza);
            }

            return percentualiDiSomiglianza;
        }

        public static double CalculateEqualityJaccard(string stringa1, string stringa2)
        {
            var set1 = new HashSet<char>(stringa1.ToLower());
            var set2 = new HashSet<char>(stringa2.ToLower());

            int intersezioneCount = 0;
            int unioneCount = set1.Count + set2.Count;

            foreach (var elemento in set1)
            {
                if (set2.Contains(elemento))
                {
                    intersezioneCount++;
                    unioneCount--;
                }
            }

            double similarita = (double)intersezioneCount / unioneCount;
            return similarita;
        }

        public static double CalculateSimilarity(string str1, string str2)
        {
            int maxLen = Math.Max(str1.Length, str2.Length);
            int levenshteinDistance = CalculateEqualityLevenshtein(str1, str2);
            double similarity = (1.0 - (double)levenshteinDistance / maxLen);
            return similarity;
        }

        private static int CalculateEqualityLevenshtein(string str1, string str2)
        {
            int[,] dp = new int[str1.Length + 1, str2.Length + 1];

            for (int i = 0; i <= str1.Length; i++)
            {
                for (int j = 0; j <= str2.Length; j++)
                {
                    if (i == 0)
                        dp[i, j] = j;
                    else if (j == 0)
                        dp[i, j] = i;
                    else if (str1[i - 1] == str2[j - 1])
                        dp[i, j] = dp[i - 1, j - 1];
                    else
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                }
            }

            return dp[str1.Length, str2.Length];
        }
    }
}
