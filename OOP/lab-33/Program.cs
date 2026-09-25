using System;
using System.Collections.Generic;

namespace ArrayHelperLibrary
{
    public static class ArrayHelper
    {
        public static int IndexOf<T>(T[] array, T value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], value))
                {
                    return i;
                }
            }

            return -1;
        }

        public static void Reverse<T>(T[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
                T temp = array[left];
                array[left] = array[right];
                array[right] = temp;

                left++;
                right--;
            }
        }

        public static T Min<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            T minValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(minValue) < 0)
                {
                    minValue = array[i];
                }
            }

            return minValue;
        }

        public static T Max<T>(T[] array) where T : IComparable<T>
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array cannot be empty.");
            }

            T maxValue = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].CompareTo(maxValue) > 0)
                {
                    maxValue = array[i];
                }
            }

            return maxValue;
        }

        public static void Main(string[] args)
        {
            int[] numbers = { 5, 2, 9, 1, 5, 6 };

            Console.WriteLine("Index of 9: " + IndexOf(numbers, 9));

            Reverse(numbers);
            Console.WriteLine("Reversed array: " + string.Join(", ", numbers));

            Console.WriteLine("Minimum value: " + Min(numbers));
            Console.WriteLine("Maximum value: " + Max(numbers));

            Console.WriteLine();

            string[] words = { "apple", "banana", "cherry" };

            Console.WriteLine("Index of 'banana': " + IndexOf(words, "banana"));

            Reverse(words);
            Console.WriteLine("Reversed array: " + string.Join(", ", words));

            Console.WriteLine("Minimum value: " + Min(words));
            Console.WriteLine("Maximum value: " + Max(words));
        }
    }
}