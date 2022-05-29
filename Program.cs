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
        long ret = 0;
        int d = queries.Count();
        int[,] arr = new int[d, n];

        // Initialize with all zeros, not sure if there a built-in method to handle this:
        for (int i = 0; i < d; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr[i,j] = 0;
            }
        }

        // Implement Algorithm Here:
        for (int i = 0; i < d; i++)
        {
            var row = queries[i][0];
            var depth = queries[i][1] - 1;
            var k = queries[i][2];
            // Inner indexeing:
            for (int l = row; l <= depth; l++)
            {
                for (int q = row; q < d; q++)
                {
                    arr[q, l] += k;
                }
            }
        }
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
