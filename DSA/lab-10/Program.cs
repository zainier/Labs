using System.Diagnostics;

class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 100000;
            int iterations = 3;
            Random rand = new Random();

            int[] originalArray = new int[arraySize];
            for (int i = 0; i < arraySize; i++)
            {
                originalArray[i] = rand.Next(1, 1000000);
            }

            Console.WriteLine($"Кількість елементів у масиві: {arraySize}");
            Console.WriteLine($"Кількість повторень: {iterations}\n");

            for (int i = 1; i <= iterations; i++)
            {
                Console.WriteLine($"--- Спроба {i} ---");

                int[] arrayForBubble = (int[])originalArray.Clone();
                int[] arrayForMerge = (int[])originalArray.Clone();

                Stopwatch bubbleTimer = Stopwatch.StartNew();
                BubbleSort(arrayForBubble);
                bubbleTimer.Stop();
                Console.WriteLine($"Сортування бульбашкою: {bubbleTimer.ElapsedMilliseconds} мс");

                Stopwatch mergeTimer = Stopwatch.StartNew();
                MergeSort(arrayForMerge, 0, arrayForMerge.Length - 1);
                mergeTimer.Stop();
                Console.WriteLine($"Сортування злиттям:    {mergeTimer.ElapsedMilliseconds} мс\n");
            }
        }

        static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }

        static void MergeSort(int[] arr, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;

                MergeSort(arr, left, mid);
                MergeSort(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }

        static void Merge(int[] arr, int left, int mid, int right)
        {
            int n1 = mid - left + 1;
            int n2 = right - mid;

            int[] leftArr = new int[n1];
            int[] rightArr = new int[n2];

            for (int i = 0; i < n1; ++i) leftArr[i] = arr[left + i];
            for (int j = 0; j < n2; ++j) rightArr[j] = arr[mid + 1 + j];

            int iIndex = 0, jIndex = 0, k = left;

            while (iIndex < n1 && jIndex < n2)
            {
                if (leftArr[iIndex] <= rightArr[jIndex])
                {
                    arr[k] = leftArr[iIndex];
                    iIndex++;
                }
                else
                {
                    arr[k] = rightArr[jIndex];
                    jIndex++;
                }
                k++;
            }

            while (iIndex < n1) arr[k++] = leftArr[iIndex++];
            while (jIndex < n2) arr[k++] = rightArr[jIndex++];
        }
    }