namespace algorithms.sorting
{
    public static class Sort
    {
        public static int[] InsertionSort(int[] collection)
        {
            // Compare two values and sort everything on the left side
            // Called insertion sort because you are inserting and shifting smaller elements to the sort
            // portion of the array

            for (int i = 1; i < collection.Length; i++)
            {
                int j = i - 1;
                int current = collection[i];

                while (j >= 0 && collection[j] > current)
                {
                    collection[j + 1] = collection[j];
                    j--;
                }
                collection[j + 1] = current;
            }

            return collection;
        }
        public static int[] SelectionSort(int[] collection)
        {
            // Find the min value and update value if other minimum found
            // Minimum should be placed at the end of the sequence and (n - i) values need to be searched through
            var length = collection.Length;
            for (int i = 0; i < length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (collection[minIndex] > collection[j])
                        minIndex = j;
                }

                Swap(collection, i, minIndex);
            }

            return collection;
        }
        public static int[] BubbleSort(int[] collection)
        {
            // Neighbour comparission and bubble up the largest value to the right
            int length = collection.Length;
            for (int i = 0; i < length - 1; i++)
            {
                for (int j = 0; j < length - i - 1; j++)
                {
                    int next = j + 1;
                    if (collection[j] > collection[next])
                        Swap(collection, j, next);
                }
            }
            return collection;
        }
        public static int[] QuickSort(int[] collection, int left, int right)
        {
            // Set first element as a pivot and on the left find the smallest item on the right hand side and largest on the left hand side
            // Once found swap pivot with the smallest value and right most value and pick next item and repeat process from the left neighbour of the pivot and repeat
            // with right neighbor

            // Find the partition and then sort the left and right array

            var index = Partition(collection, left, right);
            if (left < index - 1)
            {
                QuickSort(collection, left, index - 1);
            }
            if (right > index)
            {
                QuickSort(collection, index, right);
            }

            return collection;
        }
        public static int[] MergeSort(int[] collection)
        {
            // Recursively sort array by doing sorting by piece by piece 
            // Lastly, once sorted merge the values
            if (collection.Length == 1 || collection.Length == 0) return collection;

            var partition = (0 + collection.Length - 1) / 2;
            // Split array and sort each 
            var arr1 = Split(collection, 0, partition);
            var arr2 = Split(collection, partition + 1, collection.Length - 1);

            arr1 = MergeSort(arr1);
            arr2 = MergeSort(arr2);
            return Merge(arr1, arr2);
        }
        private static int[] Merge(int[] arr1, int[] arr2)
        {
            int i = 0;
            int j = 0;
            int[] result = new int[arr1.Length + arr2.Length];

            while (i <= arr1.Length - 1 && j <= arr2.Length - 1)
            {
                if (arr1[i] <= arr2[j])
                {
                    result[i + j] = arr1[i];
                    i++;
                }
                else if (arr1[i] > arr2[j])
                {
                    result[i + j] = arr2[j];
                    j++;
                }
            }

            if (i > arr1.Length - 1)
            {
                for (; j < arr2.Length; j++)
                {
                    result[i + j] = arr2[j];
                }
            }
            else
            {
                for (; i < arr1.Length; i++)
                {
                    result[i + j] = arr1[i];
                }
            }

            return result;
        }
        private static int[] Split(int[] arr, int start, int end)
        {
            int[] result = new int[end - start + 1]; // 0,1 => 2 elements, // 1,2 => 2 elements
            int index = 0;

            for (int i = start; i <= end; i++)
            {
                result[index] = arr[i];
                index++;
            }

            return result;
        }
        private static int Partition(int[] collection, int left, int right)
        {
            var pivot = collection[(left + right) / 2];
            while (left <= right)
            {
                while (collection[left] < pivot) left++;
                while (collection[right] > pivot) right--;

                if (left <= right)
                {
                    Swap(collection, left, right);
                    left++;
                    right--;
                }
            }
            return left;
        }
        private static void Swap(int[] collection, int indexOne, int indexTwo)
        {
            int temp = collection[indexOne];
            collection[indexOne] = collection[indexTwo];
            collection[indexTwo] = temp;
        }
    }
}
