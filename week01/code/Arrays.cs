public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  
    /// For example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  
    /// Assume that length is a positive integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // PLAN:
        // 1. Create a new array of size 'length'.
        // 2. For each index i from 0 to length-1:
        //    a. Set array[i] = number * (i + 1)
        // 3. Return the array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  
    /// For example, if the data is List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  
    /// The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // PLAN:
        // 1. Get the last 'amount' elements from the list (using GetRange).
        // 2. Remove those 'amount' elements from the end of the list (using RemoveRange).
        // 3. Insert those elements at the beginning of the list (using InsertRange).

        int n = data.Count;
        if (amount <= 0 || amount >= n) return; // No rotation needed if amount is 0 or equal to list size

        List<int> tail = data.GetRange(n - amount, amount);
        data.RemoveRange(n - amount, amount);
        data.InsertRange(0, tail);
    }
}
