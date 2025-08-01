using System.Collections;

public static class Recursion
{
    /// <summary>
    /// Problem 1: sum of squares 1^2 + 2^2 + ... + n^2 using recursion.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0)
            return 0; // base case
        return n * n + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// Problem 2: permutations of length 'size' from unique letters.
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        for (int i = 0; i < letters.Length; i++)
        {
            char c = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + c);
        }
    }

    /// <summary>
    /// Problem 3: ways to climb s stairs with steps of 1,2,3 using memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        if (remember.TryGetValue(s, out decimal cached))
            return cached;

        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);
        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// Problem 4: expand wildcard binary pattern recursively.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int starIndex = pattern.IndexOf('*');
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        string withZero = pattern.Substring(0, starIndex) + '0' + pattern.Substring(starIndex + 1);
        string withOne = pattern.Substring(0, starIndex) + '1' + pattern.Substring(starIndex + 1);
        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// Problem 5: solve maze via DFS, collecting all paths from (0,0) to the end.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        if (currPath == null)
            currPath = new List<ValueTuple<int, int>>();

        // invalid move?
        if (!maze.IsValidMove(currPath, x, y))
            return;

        // add current position
        currPath.Add((x, y));

        // reached end?
        if (maze.IsEnd(x, y))
        {
            results.Add(currPath.AsString());
            currPath.RemoveAt(currPath.Count - 1); // backtrack
            return;
        }

        // explore neighbors
        SolveMaze(results, maze, x + 1, y, currPath);
        SolveMaze(results, maze, x - 1, y, currPath);
        SolveMaze(results, maze, x, y + 1, currPath);
        SolveMaze(results, maze, x, y - 1, currPath);

        // backtrack
        currPath.RemoveAt(currPath.Count - 1);
    }
}