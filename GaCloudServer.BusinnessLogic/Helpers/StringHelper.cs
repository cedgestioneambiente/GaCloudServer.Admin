using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaCloudServer.BusinnessLogic.Helpers
{
    internal class StringHelper
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

        static double CalculateEqualityJaccard(string stringa1, string stringa2)
        {
            var set1 = new HashSet<char>(stringa1);
            var set2 = new HashSet<char>(stringa2);

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
    }
}
