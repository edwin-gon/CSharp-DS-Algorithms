using System.Collections.Generic;
using Xunit;

namespace algorithms.sorting.tests
{
    public class SortingTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void InsertionSort(int[] unsorted, int[] expected)
        {
            var result = Sort.InsertionSort(unsorted);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void SelectionSort(int[] unsorted, int[] expected)
        {
            var result = Sort.SelectionSort(unsorted);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void BubbleSort(int[] unsorted, int[] expected)
        {
            var result = Sort.BubbleSort(unsorted);
            Assert.Equal(expected, result);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[] { new int[]{  }, new int[]{  } },
                new object[] { new int[]{ 1 }, new int[]{ 1 } },
                new object[] { new int[]{ 0, 1 }, new int[]{ 0, 1 } },
                new object[] { new int[]{ 1, 0 }, new int[]{ 0, 1 } },
                new object[] { new int[]{ 0, 2, 1 }, new int[]{ 0, 1, 2 } },
                new object[] { new int[]{ 2, 0, 1 }, new int[]{ 0, 1, 2 } },
                new object[] { new int[]{ 1, 2, 0 }, new int[]{ 0, 1, 2 } },
                new object[] { new int[]{ 2, 8, 5, 3, 9, 4, 1 }, new int[]{ 1, 2, 3, 4, 5, 8, 9 } },
                new object[] { new int[]{ 3, 5, 7, 2, 1 }, new int[]{ 1, 2, 3, 5, 7 } },
            };
    }
}