public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static void Run()
    {
        double[] multiples = MultiplesOf(3,5);
        Console.WriteLine("<List>{" + string.Join(", ", multiples) + "}"); // <List>{3, 6, 9, 12, 15}

        List<int> numbers = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        RotateListRight(numbers, 3);
        Console.WriteLine("<List>{" + string.Join(", ", numbers) + "}"); // <
    }
   
    
    public static double[] MultiplesOf(double number, int length)
    {
        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * ( 1 + i);
        }
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> numbers, int amount)
    {
        //Step1 Find the index where the last 'amount' of numbers start
        int startedIndex = numbers.Count - amount;

        // Copy the amount of numbers from the end to a temporary list
        // Example if data = {1,2,3,4,5,6,7,8,9} and amount = 3 
        // this will copy {7,8,9}
        List<int> rightPart = numbers.GetRange(startedIndex, amount);

        // Step2 Remove the last 'amount' of numbers from the original list
        numbers.RemoveRange(startedIndex, amount);

        // Step3 Insert the temporary list at the start of the original list
        numbers.InsertRange(0, rightPart);
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.
    }
}
