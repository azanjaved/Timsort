# Timsort
Timsort is a hybrid stable sorting algorithm, derived from merge sort and insertion sort, designed to perform well on many kinds of real-world data.
# Working
We divide the Array into blocks known as Run. We sort those runs using insertion sort one by one and then merge those runs using merge sort. If the size of Array is less than run, then Array get sorted just by using Insertion Sort. In my implementation the size of run is 32. 
Note that merge function performs well when sizes subarrays are powers of 2. The idea is based on the fact that insertion sort performs well for small arrays.
# Input
On running the code user is asked for input for the size of the array. The array is then filled with random numbers upto the size of the array and then the algorithm proceeds to sort the data.
# Group Members
Azan javed(17B-011-CS) Amna Mehmood(17B-004-CS)
