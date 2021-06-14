namespace NameSorter
{
    public static class SortNames
    {
        // Merge sort was chosen to accommodate larger input files.
        public static Person[] MergeSort(Person[] InputArray)
        {
            return Sort(InputArray);
        }

        // This method recursively splits the array to single elements. Each element is then sent to the merge method.
        private static Person[] Sort(Person[] input)
        {
            // If the input length is 1 then the process has been completed.
            if (input.Length == 1)
                return input;

            // Otherwise the division process continues.
            int size = input.Length / 2;

            Person[] leftArray = new Person[size];
            Person[] rightArray = new Person[input.Length - size];

            for (var i = 0; i < input.Length; i++)
            {
                if (i < leftArray.Length)
                {
                    leftArray[i] = input[i];
                }
                else
                {
                    rightArray[i - size] = input[i];
                }
            }
            // Recursive call to further divide arrays. Outputs should be single elements.
            leftArray = Sort(leftArray);
            rightArray = Sort(rightArray);

            // Prevents null elements being merged.
            if (rightArray[0] == null)
            {
                return leftArray;
            }


            return Merge(leftArray, rightArray);
        }

        // This recursively joins all arrays back into a single array.
        private static Person[] Merge(Person[] leftArray, Person[] rightArray)
        {

            Person[] combinedArray = new Person[leftArray.Length + rightArray.Length];
            int leftArrayIndex = 0;
            int rightArrayIndex = 0;
            int counter = 0;

            // This populates the final array.
            for (int i = counter; i < combinedArray.Length; i++)
            {
                // Both arrays have elements and the next element from the Left array is smaller.  
                if (leftArrayIndex < leftArray.Length && rightArrayIndex < rightArray.Length && leftArray[leftArrayIndex].CompareTo(rightArray[rightArrayIndex]) < 1)
                {
                    combinedArray[i] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
                // Next element from the right array is smaller or left array has no more elements.
                else if (rightArrayIndex < rightArray.Length)
                {
                    combinedArray[i] = rightArray[rightArrayIndex];
                    rightArrayIndex++;
                }
                // Right array has run out of elements.
                else
                {
                    combinedArray[i] = leftArray[leftArrayIndex];
                    leftArrayIndex++;
                }
            }
            return combinedArray;

        }

    }
}

