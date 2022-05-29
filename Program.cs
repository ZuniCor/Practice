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
        int[] arr = new int[n];
        var possibleResults = new List<int>();

        // Initialize with all zeros, not sure if there a built-in method to handle this:
        for (int i = 0; i < d; i++)
        {
            arr[i] = 0;
        }

        //  5 3
        //  1 2 100
        //  2 5 100
        //  3 4 100

        // Implement Algorithm Here: (this one is too slow for their liking)
        /*foreach (var q in queries)
        {
            var left = q[0];
            var right = q[1];
            var k = q[2];

            for (int j = left - 1; j <= (right - 1); j++)
            {
                arr[j] += k;
            }

            possibleResults.Add(arr.Max());
        }*/


        for (int i = 1; i < queries.Count(); i++)
        {
            // Trailing row:
            var pLeft = queries[i - 1][0];
            var pRight = queries[i- 1][1];
            var prevK = queries[i - 1][2];

            // Current row;
            var left = queries[i][0];
            var right = queries[i][1];
            var k = queries[i][2];

            var prevSequence = Enumerable.Range(pLeft, Math.Abs(pRight - pLeft));
            var sequence = Enumerable.Range(left, Math.Abs(right - left));

            // Need to find a way to tell if 
            // indices overlap:
            bool sequencesOverlap = false;
            var both = prevSequence.Intersect(sequence);

            if (both.Any()) 
                sequencesOverlap = true;

            both = sequence.Intersect(prevSequence);
            if (both.Any())
                sequencesOverlap = true;

            if (sequencesOverlap)
            {
                var res = k;
                k += prevK;
                possibleResults.Add(k);
            }
                
        }

        ret = possibleResults.Max();
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
