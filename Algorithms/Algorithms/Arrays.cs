using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

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
        
        public List<int> getPascalRow(int A) {
            if (A == 0)
                return new List<int>{1};
        
            var outArray = new List<int>(Enumerable.Range(0, A + 1));
            outArray[0] = 1;
            outArray[1] = 1;
            int lastElementIndex = 1;
        
            for(int i = 1; i < A; i ++)
            {
                outArray[lastElementIndex + 1] = outArray[lastElementIndex];
                for (int j = lastElementIndex; j > 0; j --)
                {
                    outArray[j] = outArray [j] + outArray[j - 1];
                }
                lastElementIndex++;
            }
        
            return outArray;
        }
        
        public static List<int> maxNonNegativeSubarray(List<int> A) {
            var currentFirstIndex = -1;
            long currentSum = 0;
            long currentMaxSum = -1;
            var currentMaxFirstIndex = -1;
            var currentMaxLen = 0;
            
            for (var i = 0; i < A.Count; i++)
            {
                if (A[i] < 0)
                {
                    if (currentFirstIndex != -1)
                    {
                        var currentLen = i - currentFirstIndex;
                        if (currentMaxSum < currentSum || (currentSum == currentMaxSum && currentLen > currentMaxLen))
                        {
                            currentMaxSum = currentSum;
                            currentMaxLen = currentLen;
                            currentMaxFirstIndex = currentFirstIndex;
                        }

                        currentFirstIndex = -1;
                        currentSum = 0;
                    }
                }
                else
                {
                    if (currentFirstIndex == -1)
                        currentFirstIndex = i;
                    currentSum += A[i];
                }
            }

            if (currentFirstIndex != -1)
            {
                var currentLen = A.Count - currentFirstIndex;
                if (currentMaxSum < currentSum || (currentSum == currentMaxSum && currentLen > currentMaxLen))
                {
                    currentMaxSum = currentSum;
                    currentMaxLen = currentLen;
                    currentMaxFirstIndex = currentFirstIndex;
                }
            }
            
            if (currentMaxFirstIndex == -1)
                return new List<int>();

            var result = A.GetRange(currentMaxFirstIndex, currentMaxLen);

            return result;
        }
        
        public static int maximumGap(List<int> A)
        {
            var i = 0;
            var j = A.Count - 1;

            while ( j >= 0)
            {
                var maxD = A.Count - i - 1;
                for (var k = A.Count - 1; k >= j; k--)
                {
                    if (A[k - maxD] <= A[k])
                    {
                        return maxD;
                    }
                }
                
                j--;
                i++;
            }
            
            return -1;
        }
        
        public static List<int> wave(List<int> A) {
            for (var i = 1; i < A.Count; i += 2)
            {
                var minIndex = GetMinIndex(i - 1, A);
                Swap(minIndex, i, A);

                var nextMinIndex = GetMinIndex(i + 1, i - 1, A);
                Swap(nextMinIndex, i - 1, A);
            }

            return A;
        }

        public static List<int> waveQuicker(List<int> A)
        {
            A.Sort();

            for (var i = 0; i < A.Count - 1; i += 2)
            {
                var temp = A[i];
                A[i] = A[i + 1];
                A[i + 1] = temp;
            }

            return A;
        }
        
        private static int GetMinIndex(int start, List<int> list)
        {
            var min = start;
            for (var i = start + 1; i < list.Count; i++)
            {
                if (list[min] > list[i])
                    min = i;
            }

            return min;
        }

        private static int GetMinIndex(int start, int firstIndex, List<int> list)
        {
            var min = firstIndex;

            for (var i = start; i < list.Count; i++)
            {
                if (list[min] > list[i])
                    min = i;
            }
            
            return min;
        }
        
        private static void Swap(int firstIndex, int secondIndex, List<int> list)
        {
            var temp = list[firstIndex];
            list[firstIndex] = list[secondIndex];
            list[secondIndex] = temp;
        }
        
        public static int[] TwoSum(int[] nums, int target) {
            var valueIndexDictionary = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                valueIndexDictionary[i] = nums[i];
            }
            
            var dictionaryList = valueIndexDictionary.OrderBy(x => x.Value).ToArray();

            for (var i = 0; i < nums.Length - 1; i++)
            {
                var subtraction = target - dictionaryList[i].Value;
                var subtractionIndex = BinarySearch(dictionaryList, subtraction, i + 1);
                if (subtractionIndex != -1)
                {
                    return new[] {dictionaryList[i].Key, dictionaryList[subtractionIndex].Key};
                }
            }

            return Array.Empty<int>();
        }

        private static int BinarySearch(KeyValuePair<int, int>[] nums, int target, int startIndexSearch)
        {
            var left = startIndexSearch;
            var right = nums.Length - 1;

            while (left <= right)
            {
                var mid = (right + left) / 2;
                
                if (nums[mid].Value == target)
                {
                    return mid;
                }

                if (nums[mid].Value < target)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
            
            return -1;
        }
        
        public int[] TwoSumFastSolution(int[] nums, int target) {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            for(int i = 0; i < nums.Length; i++) {
                if(dict.ContainsKey(target - nums[i])) {
                    return new int[] {dict[target - nums[i]], i};
                }
                else {
                    if(dict.ContainsKey(nums[i])) {
                        dict[nums[i]] = i;
                    }
                    else {
                        dict.Add(nums[i], i);
                    }
                }
            }
            return null;
        }
        
        public static int Reverse(int x)
        {
            var endMultiplier = 1;
            if (x < 0)
            {
                try
                {
                    checked
                    {
                        x *= -1;   
                    }
                }
                catch (OverflowException)
                {
                    return 0;
                }
                endMultiplier = -1;
            }
            
            var reminder = x % 10;
            var integer = x / 10;
            var result = reminder;

            while (integer > 0)
            {
                reminder = integer % 10;
                integer /= 10;
                try
                {
                    checked
                    {
                        result *= 10;
                        result += reminder;   
                    }
                }
                catch (OverflowException)
                {
                    return 0;
                }
            }

            result *= endMultiplier;

            return result;
        }
        
        public static int MaxArea(int[] height)
        {
            var maxSquere = -1;

            for (var i = 0; i < height.Length - 1; i++)
            {
                for (var j = i + 1; j < height.Length; j++)
                {
                    var minHeight = Math.Min(height[i], height[j]);
                    var currentSquare = minHeight * (j - i);
                    if (currentSquare > maxSquere)
                    {
                        maxSquere = currentSquare;
                    }
                }
            }

            return maxSquere;
        }
        
        public static int maxAreaTheBestPerformance(int[] height) {
            int maxarea = 0, l = 0, r = height.Length - 1;
            while (l < r) {
                maxarea = Math.Max(maxarea, Math.Min(height[l], height[r]) * (r - l));
                if (height[l] < height[r])
                    l++;
                else
                    r--;
            }
            return maxarea;
        }
        
        public static int repeatedNumber(List<int> A) {
            var set = new HashSet<int>();

            foreach (var item in A)
            {
                if (set.Contains(item))
                {
                    return item;
                }
                else
                {
                    set.Add(item);
                }
            }

            return -1;
        }
        
        public static int nobleInteger(List<int> A)
        {
            A.Sort();
            var index = 0;
            while (index < A.Count)
            {
                var currentNumber = A[index];
                var sameElemCount = 0;
                while ((index + sameElemCount + 1) < A.Count && A[index + sameElemCount + 1] == currentNumber)
                {
                    sameElemCount++;
                }

                index += sameElemCount;
                var greaterNumbersCount = A.Count - 1 - index;
                if (greaterNumbersCount == currentNumber)
                {
                    return 1;
                }

                index++;
            }

            return -1;
        }
        
        public static int firstMissingPositive(List<int> A)
        {
            var result = 1;
            var set = new HashSet<int>();
            
            for (var i = 0; i < A.Count; i++)
            {
                set.Add(A[i]);
                if (A[i] == result)
                {
                    result++;
                    while (true)
                    {
                        if (set.Contains(result) && result != Int32.MaxValue)
                        {
                            result++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            
            return result;
        }
        
        public static int firstMissingPositiveQuickMethod(List<int> A)
        {
            var array = new int[A.Count + 1];

            foreach (var val in A)
            {
                if (val > 0 && val <= A.Count + 1)
                {
                    array[val - 1] = 1;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == 0)
                {
                    return i + 1;
                }
            }
            
            return 1;
        }
        
        public static string largestNumber(List<int> A)
        {
            var list = A.Select(x => x.ToString()).ToList();
            list.Sort(CompareByLargestFirstNumber);
            list.Reverse();

            var result = "";
            bool wasNumber = false;
            for (var i = 0; i < list.Count - 1; i++)
            {
                if (list[i] != "0")
                {
                    wasNumber = true;
                    result += list[i];
                }
                else if (wasNumber)
                {
                    result += list[i];
                }
            }
            
            result += list[list.Count - 1];
            
            return result;
        }

        public static int CompareByLargestFirstNumber(string x, string y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    if (x.Length == y.Length)
                    {
                        return x.CompareTo(y);
                    }
                    else
                    {
                        if (x.Length > y.Length)
                        {
                            int j = 0;
                            for (var i = 0; i < x.Length; i++)
                            {
                                if (x[i] != y[j])
                                {
                                    return x[i].CompareTo(y[j]);
                                }

                                if (j < y.Length - 1)
                                {
                                    j++;
                                }
                            }

                            return -1;
                        }
                        else
                        {
                            int j = 0;
                            for (var i = 0; i < y.Length; i++)
                            {
                                if (x[j] != y[i])
                                {
                                    return x[j].CompareTo(y[i]);
                                }

                                if (j < x.Length - 1)
                                {
                                    j++;
                                }
                            }

                            return 1;
                        }
                    }
                }
            }
        }

        public static int[,] GetAllVariants(List<int> list)
        {
            var countOfVariants = Factorial(list.Count);
            var result = new int[countOfVariants, list.Count];
            var circleValues = GetCircleValues(list);

            for (var i = 0; i < list.Count - 1; i++)
            {
                //var currentCo = 
            }
            
            return result;
        }

        public static void AddVariants(int[,] variants, int[,] circleCombinations, int verticalIndex, int horizontalIndex)
        {
            var countOfCombinationsVariants = Factorial(variants.GetLength(1) - verticalIndex - 1);
            
        }
        
        public static int Factorial(int n)
        {
            var factorial = 1;

            for (var i = 2; i <= n; i++)
            {
                factorial *= i;
            }

            return factorial;
        }

        public static int[,] GetCircleValues(List<int> list)
        {
            var variants = new int[list.Count, list.Count];
            for (var i = 0; i < list.Count; i++)
            {
                var offset = i;

                for (var j = offset; j < list.Count; j++)
                {
                    variants[i, j - offset] = list[j];
                }

                var leftOffset = list.Count - offset;
                for (var j = 0; j < offset; j++)
                {
                    variants[i, j + leftOffset] = list[j];
                }
            }

            return variants;
        }
    }
}
