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
        private static void Swap(int[] collection, int indexOne, int indexTwo)
        {
            int temp = collection[indexOne];
            collection[indexOne] = collection[indexTwo];
            collection[indexTwo] = temp;
        }
    }
}
