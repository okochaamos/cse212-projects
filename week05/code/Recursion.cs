using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        if (n <= 0) {
            return 0;  
        }
        return n * n + SumSquaresRecursive(n - 1);  
    }
       
    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        if (size == 0) {
            results.Add(word);  
            return;
        }
        for (int i = 0; i < letters.Length; i++) {
            char ch = letters[i];
            string remaining = letters.Substring(0, i) + letters.Substring(i + 1); 
            PermutationsChoose(results, remaining, size - 1, word + ch);  
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Count ways to climb stairs using recursion + memoization.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Base cases
        if (s == 0) return 0;
        if (s == 1) return 1;
        if (s == 2) return 2;
        if (s == 3) return 4;

        // Check memoization
        if (remember.ContainsKey(s))
            return remember[s];

        // Recursive relation
        decimal ways = CountWaysToClimb(s - 1, remember) +
                       CountWaysToClimb(s - 2, remember) +
                       CountWaysToClimb(s - 3, remember);

        // Store result
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// Generate all binary strings for a given pattern with '*' wildcards.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        if (!pattern.Contains('*')) {
            results.Add(pattern);  
            return;
        }
        int index = pattern.IndexOf('*');  // Find the first wildcard
        WildcardBinary(pattern.Substring(0, index) + '0' + pattern.Substring(index + 1), results);  // Replace * with 0
        WildcardBinary(pattern.Substring(0, index) + '1' + pattern.Substring(index + 1), results);  // Replace * with 1
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, List<(int, int)> currPath = null, int x = 0, int y = 0)
    {
        if (currPath == null)
            currPath = new List<(int, int)>();

        // Add current position to path
        currPath.Add((x, y));

        // Base case: Check if we have reached the end
        if (maze.IsEnd(x, y))
        {
            // Use the expected <List>{ ... } format
            results.Add("<List>{" + string.Join(", ", currPath.Select(p => $"({p.Item1}, {p.Item2})")) + "}");
            return;
        }

        // Explore in four directions (up, down, left, right)
        foreach (var (dx, dy) in new (int, int)[] { (0, 1), (1, 0), (0, -1), (-1, 0) })
        {
            int newX = x + dx;
            int newY = y + dy;

            // Check if move is valid and avoid revisiting the current cell
            if (maze.IsValidMove(currPath, newX, newY))
            {
                SolveMaze(results, maze, new List<(int, int)>(currPath), newX, newY);
            }
        }
    }


}
