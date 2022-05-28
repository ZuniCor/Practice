class Result
{

    /*
     * Complete the 'arrayManipulation' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. 2D_INTEGER_ARRAY queries
     */

    public static long arrayManipulation(int n, List<List<int>> queries)
    {
      long ret = 1000;
      return ret;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = args[0].Split(' ');
     
        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]) + 1;

        List<List<int>> queries = new List<List<int>>();

        for (int i = 1; i < m; i++)
        {
            queries.Add(args[i].
            TrimEnd()
            .Split(' ')
            .ToList()
            .Select(queriesTemp => Convert.ToInt32(queriesTemp))
            .ToList());
        }   

        long result = Result.arrayManipulation(n, queries);
        Console.WriteLine(result.ToString());
    }
}
