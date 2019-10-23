using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class MathTasks
    {
        public static int hammingDistance(List<int> A)
        {
            long result = 0;
            var cachedValues = new Dictionary<(int i, int j), int>();

            for (var i = 0; i < A.Count; i++)
            {
                for (var j = 0; j < A.Count; j++)
                {
                    int hamingDistance;
                    if (cachedValues.ContainsKey((i, j)))
                    {
                        hamingDistance = cachedValues[(i, j)];
                    } 
                    else if(cachedValues.ContainsKey((j, i)))
                    {
                        hamingDistance = cachedValues[(j, i)];
                    }
                    else
                    {
                        hamingDistance = GetHamingDistance(A[i], A[j]);
                        cachedValues.Add((i, j), hamingDistance);
                    }
                    
                    result += hamingDistance;
                }
            }

            return (int)(result % 1000000007);
        }

        public static int hammingDistanceWithoutTuples(List<int> A)
        {
            long result = 0;
            var cachedValues = new Dictionary<KeyValuePair<int, int>, int>();
            
            for (var i = 0; i < A.Count; i++)
            {
                for (var j = 0; j < A.Count; j++)
                {
                    int hamingDistance;
                    if (i == j)
                    {
                        hamingDistance = 0;
                    }
                    else
                    {
                        if (i < j)
                        {
                            var ijKeyValuePair = new KeyValuePair<int, int>(i, j);
                            hamingDistance = GetHamingDistance(A[i], A[j]);
                            cachedValues.Add(ijKeyValuePair, hamingDistance);
                        }
                        else
                        {
                            var jiKeyValuePair = new KeyValuePair<int, int>(j, i);
                            hamingDistance = cachedValues[jiKeyValuePair];
                        }
                    }

                    result += hamingDistance;
                }
            }

            return (int)(result % 1000000007);
        }
        
        public static int GetHamingDistance(int a, int b)
        {
            var result = 0;
            if (a == b)
            {
                return result;
            }

            var xorResult = a ^ b;
            var xorString = Convert.ToString(xorResult, 2);

            foreach (var ch in xorString)
            {
                if (ch == '1')
                {
                    result += 1;
                }
            }
            
            return result;
        }
    }
}