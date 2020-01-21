using System;
namespace StringMetric
{
    /// <summary>
    /// Jaro similarity algorithm.
    /// </summary>
    /// <remarks>
    /// https://rosettacode.org/wiki/Jaro_distance
    /// </remarks>
    public static class Jaro
    {
        /// <summary>
        /// Compute Jaro similarity.
        /// </summary>
        /// <param name="s1">one string to compare</param>
        /// <param name="s2">the other string to compare</param>
        /// <returns>similarity value</returns>
        public static double Similarity(string s1, string s2)
        {
            var l1 = s1.Length;
            var l2 = s2.Length;

            // handle zero exception
            if (l1 == 0)
            {
                if (l2 == 0) return 1;
                else return 0;
            }

            var matches1 = new bool[l1];
            var matches2 = new bool[l2];

            var m = (double)numberOfMatching();

            // handle no matching characters
            if (m == 0) return 0;

            // regular path
            var t = numberOfTranspositions() * 0.5;

            return (m / l1 + m / l2 + (m - t) / m) / 3;


            int numberOfMatching()
            {
                var matchDistance = Math.Max(l1, l2) / 2 - 1;
                var count = 0;
                for (var i = 0; i < l1; ++i)
                {
                    var jmax = Math.Min(i + matchDistance + 1, l2);
                    for (int j = Math.Max(0, i - matchDistance); j < jmax; ++j)
                        if (!matches2[j] && s1[i] == s2[j])
                        {
                            matches1[i] = true;
                            matches2[j] = true;
                            count++;
                            break;
                        }
                }
                return count;
            }

            int numberOfTranspositions()
            {
                var count = 0;
                var k = 0;
                for (var i = 0; i < l1; ++i)
                {
                    if (matches1[i])
                    {
                        while (!matches2[k])
                        {
                            ++k;
                        }
                        if (s1[i] != s2[k])
                        {
                            ++count;
                        }
                        ++k;
                    }
                }
                return count;
            }
        }
    }
}
