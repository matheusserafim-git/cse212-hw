using System.Diagnostics;
using System.IO.Pipelines;

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
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: Create  an array taht will store the multiples.
        double[] multiples = new double[length];

        //step 2: use the loop to fill each position of the array, the loop will run from 0 until - 1.
        for (int i = 0; i < length; i++ )
        {
            //step 3: Claculate the multiple for the current position.
            // Since arrays start at index 0, we multiply start by (i + 1)
            multiples[i] = number * (i + 1);
            
        }


        return multiples; // replace this return statement with your own
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
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        // Step 1: The function receives a List<int> called data and an integer called amount.
        // The goal is to rotate the list to the right by the number of positions specified in amount.

        // Step 2: Create a new list to temporarily store the rotated values.

        List<int> rotated = new List<int>();

        // Step 3: Add the last "amount" elements from the original list
        // to the new list. These elements will move to the front.

        for (int i = data.Count - amount; i < data.Count; i++)
        {
            rotated.Add(data[i]);
        }

        // Step 4: Add the remaining elements from the beginning of the list
        // up to (data.Count - amount).
        for (int i = 0; i < data.Count - amount; i++)
        {
            rotated.Add(data[i]);
        }

        // Step 5: Clear the original list.
        data.Clear();

        // Step 6: Replace the contents of the original list with the rotated values.
        // This can be done by clearing the list and adding the new elements.
        // Step 6: Copy the rotated elements back into the original list.
        foreach (int item in rotated)
        {
            data.Add(item);
        }

        // Step 7: After this process, the list will be rotated to the right.
    }
}
