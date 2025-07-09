public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // 1. Create an array of type double with the given length.
        // 2. Use a for loop to fill in each index with the appropriate multiple 
        // 3. Return the populated array.

        double[] result = new double[length];
        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }
        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // 1. Calculate the starting index for the rotated section: data.Count - amount.
        // 2. Use GetRange to get the last 'amount' elements.
        // 3. Use GetRange again to get the beginning of the list (up to data.Count - amount).
        // 4. Clear the original list and add both ranges back in the correct rotated order.

         // Step 1: Extract the last 'amount' elements using GetRange
        List<int> endPart = data.GetRange(data.Count - amount, amount);

        // Step 2: Extract the remaining front part
        List<int> frontPart = data.GetRange(0, data.Count - amount);

        // Step 3: Clear the original list
        data.Clear();

        // Step 4: Add the two parts in rotated order
        data.AddRange(endPart);
        data.AddRange(frontPart);
    }
}
