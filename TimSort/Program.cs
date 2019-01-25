using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Timsort t = new Timsort();
            t.Operator();
        }

    }

    //Timsort Algorithm
    class Timsort
    {

        public void Operator()
        {
            /*
             * you just need to to enter the size of array
             * 
             */
            Console.WriteLine("Enter the size of array :");
            int n = int.Parse(Console.ReadLine());

            int[] array = randomNumber(n);

            run(n);//Calculating chunk size

            Console.WriteLine("The unsorted array:");
            print(array, n);

            /** Sorting chunks by Insertion Sort which are created according to run */
            for (int i = 0; i < n; i += RUN)
            {
                array = insertionSort(array, i, Math.Min((i + 31), (n - 1)));
            }

            /** Iterating the loop according to run to merge them */
            for (int size = RUN; size < n; size = 2 * size)
            {
                for (int left = 0; left < n; left = 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left + 2 * size - 1), (n - 1));

                    //Calling MergeSort
                    array = MergeSort(array, left, mid, right);
                }

            }

            /** Now we print array */
            Console.WriteLine("Sorted array:");
            print(array, n);

        }

        //Generate random number for array
        public int[] randomNumber(int n)
        {
            int[] array = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next(n);
            }
            return array;
        }


        /// <summary>
        /// We are calculating run to divide array into chunks
        /// 
        ///   we have to divide it in such way that:
        ///   
        ///     *the size of chunk must be not to large 
        ///      because insertion sort will take more time
        ///     
        ///     *chunks should be not in large amount 
        ///      because merge sort will take more time
        ///      
        /// </summary>
        int RUN;

        public void run(int n)
        {

            if (n % 2 == 0)//When n is even
            {
                RUN = n / 2;
            }

            else
            {
                RUN = 32;
                /*
                 * we choice 32 or 64 because insertion sort work
                 * efficient on these two values
                 */
            }

        }

        /*
         * It is efficient to Sort small data
         */
        public int[] insertionSort(int[] array, int left, int right)
        {
            for (int i = 1; i <= right; i++)
            {
                for (int j = i; j > 0 && array[j - 1] > array[j]; j--)
                {
                    int temp = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temp;
                }

            }

            return array;
        }

        /*
         * Merge sort is used to merge sub arrays into one large array in sorted array
         */
        public int[] MergeSort(int[] array, int start, int mid, int end)
        {
            int a = 0;
            int b = mid;
            int c = 0;

            int[] temp = new int[end + 1];//Temporary array

            while (a < mid && b < end + 1)
            {
                if (array[a] <= array[b])
                {
                    temp[c] = array[a];
                    a++;
                }
                else
                {
                    temp[c] = array[b];
                    b++;
                }
                c++;
            }

            //To copy remaining elements of chunckA
            while (a < mid)
            {
                temp[c] = array[a];
                a++;
                c++;
            }

            //To copy remaining elements of chunckB
            while (b < end + 1)
            {
                temp[c] = array[b];
                b++;
                c++;
            }

            return temp;
        }

        //uitiliy function to print array
        public void print(int[] array, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(array[i] + "  ");
            }
            Console.WriteLine();
        }
    }
}
