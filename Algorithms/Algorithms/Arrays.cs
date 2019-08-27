using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    public class Arrays
    {
        public static int coverPoints(List<int> A, List<int> B) 
        {
            var previousX = A[0];
            var previousY = B[0];
            var len = 0;

            for (var i = 1; i < A.Count; i++)
            {
                if (A[i] == previousX)
                {
                    len += Math.Abs(B[i] - previousY);
                } else if (B[i] == previousY)
                {
                    len += Math.Abs(A[i] - previousX);
                }
                else
                {
                    var maxDiagonal = Math.Abs(A[i] - previousX);
                    int potentialY;
                    if (B[i] > previousY)
                    {
                        potentialY = previousY + maxDiagonal;
                    }
                    else
                    {
                        potentialY = previousY - maxDiagonal;
                    }
                    
                    if (potentialY == B[i] || (B[i] > previousY && potentialY > B[i]) || (B[i] < previousY && potentialY < B[i]))
                    {
                        len += Math.Abs(maxDiagonal);
                    }
                    else
                    {
                        len += Math.Abs(maxDiagonal) + Math.Abs(B[i] - potentialY);
                    }
                }
                
                previousX = A[i];
                previousY = B[i];
            }

            return len;
        }

        public static int coverPointsBestSolution(List<int> A, List<int> B)
        {
            var len = 0;
            for (var i = 0; i < A.Count - 1; i++)
            {
                len += Math.Max(Math.Abs(A[i + 1] - A[i]), Math.Abs(B[i + 1] - B[i]));
            }

            return len;
        }
        
        public static List<List<int>> pascalTriangle(int A) {
            var result = new List<List<int>>();

            for (var i = 0; i < A; i++)
            {
                var count = i + 1;
                var median = count / 2;
                median += (count % 2) == 1 ? 1 : 0;
                
                result.Add(new List<int>(Enumerable.Range(0, count)));
                result[i][0] = 1;

                for (var j = 1; j < median; j++)
                {
                    var newValue = result[i - 1][j] + result[i - 1][j - 1];
                    result[i][j] = newValue;
                    result[i][count - j - 1] = newValue;
                }
                
                if (i > 0)
                    result[i][i] = 1;
            }

            return result;
        }

        public static List<List<int>> antiDiagonal(List<List<int>> A)
        {
            var result = new List<List<int>>();

            for (var i = 0; i < A.Count; i++)
            {
                var diag = new List<int>();
                var first = 0;
                var second = i;

                while (second >= 0 && first < A.Count)
                {
                    diag.Add(A[first][second]);
                    first++;
                    second--;
                }
                
                result.Add(diag);
            }
            
            for (var i = 1; i < A.Count; i++)
            {
                var diag = new List<int>();
                var first = i;
                var second = A.Count - 1;

                while (second >= 0 && first < A.Count)
                {
                    diag.Add(A[first][second]);
                    first++;
                    second--;
                }
                
                result.Add(diag);
            }

            return result;
        }
    }
}
