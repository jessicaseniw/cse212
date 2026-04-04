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
        // TODO Start Problem 1
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Function always returned 0.
        // - Recursive logic was not implemented.
        // - Sum of squares was not calculated.

        // Fix:
        // - Added a base case to handle values where n <= 0.
        // - Implemented recursion using n^2 + SumSquaresRecursive(n - 1).
        // - Removed the need for any loops as required.

        // After:
        // - Function correctly calculates the sum 1^2 + 2^2 + ... + n^2.
        // - Uses recursion with a clear base case.
        // - Works for all valid values of n.

        if (n <= 0)
            return 0;

        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // TODO Start Problem 2
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Function did not generate any permutations.
        // - No recursive logic existed to build words of the desired size.
        // - Results list remained empty.

        // Fix:
        // - Added a base case to add the word to results when its length equals size.
        // - Used recursion to build permutations character by character.
        // - Removed the chosen character from the available letters at each recursive call.

        // After:
        // - Function correctly generates all permutations of the given size.
        // - Uses recursion without loops for permutation depth control.
        // - Results list contains all valid permutations.

        // Base case: when the word has reached the desired size
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: choose each letter and recurse
        for (int i = 0; i < letters.Length; i++)
        {
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + letters[i]);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// Imagine that there was a staircase with 's' stairs.  
    /// We want to count how many ways there are to climb 
    /// the stairs.  If the person could only climb one 
    /// stair at a time, then the total would be just one.  
    /// However, if the person could choose to climb either 
    /// one, two, or three stairs at a time (in any order), 
    /// then the total possibilities become much more 
    /// complicated.  If there were just three stairs,
    /// the possible ways to climb would be four as follows:
    ///
    ///     1 step, 1 step, 1 step
    ///     1 step, 2 step
    ///     2 step, 1 step
    ///     3 step
    ///
    /// With just one step to go, the ways to get
    /// to the top of 's' stairs is to either:
    ///
    /// - take a single step from the second to last step, 
    /// - take a double step from the third to last step, 
    /// - take a triple step from the fourth to last step
    ///
    /// We don't need to think about scenarios like taking two 
    /// single steps from the third to last step because this
    /// is already part of the first scenario (taking a single
    /// step from the second to last step).
    ///
    /// These final leaps give us a sum:
    ///
    /// CountWaysToClimb(s) = CountWaysToClimb(s-1) + 
    ///                       CountWaysToClimb(s-2) +
    ///                       CountWaysToClimb(s-3)
    ///
    /// To run this function for larger values of 's', you will need
    /// to update this function to use memoization.  The parameter
    /// 'remember' has already been added as an input parameter to 
    /// the function for you to complete this task.
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // TODO Start Problem 3
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Function used pure recursion without memoization.
        // - Repeated calculations caused exponential time complexity.
        // - Performance degraded significantly for large values of s.

        // Fix:
        // - Initialized the memoization dictionary when null.
        // - Checked if the result for the current step already exists.
        // - Stored computed results to avoid redundant recursive calls.

        // After:
        // - Function efficiently computes the number of ways to climb stairs.
        // - Time complexity is reduced from exponential to linear.
        // - Works correctly for large values of s.

        // Initialize memoization dictionary if needed
        if (remember == null)
            remember = new Dictionary<int, decimal>();

        // Return cached result if it exists
        if (remember.ContainsKey(s))
            return remember[s];

        // Solve using recursion
        // Recursive computation with memoization
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        remember[s] = ways;
        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// A binary string is a string consisting of just 1's and 0's.  For example, 1010111 is 
    /// a binary string.  If we introduce a wildcard symbol * into the string, we can say that 
    /// this is now a pattern for multiple binary strings.  For example, 101*1 could be used 
    /// to represent 10101 and 10111.  A pattern can have more than one * wildcard.  For example, 
    /// 1**1 would result in 4 different binary strings: 1001, 1011, 1101, and 1111.
    ///	
    /// Using recursion, insert all possible binary strings for a given pattern into the results list.  You might find 
    /// some of the string functions like IndexOf and [..X] / [X..] to be useful in solving this problem.
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        // TODO Start Problem 4
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - WildcardBinary was not implemented.
        // - Patterns containing '*' could not be expanded.
        // - Results list always remained empty.

        // Fix:
        // - Used recursion to locate the first wildcard '*'.
        // - Replaced '*' with both '0' and '1' recursively.
        // - Added completed binary strings (without '*') to results.

        // After:
        // - All possible binary strings matching the pattern are generated.
        // - Supports multiple wildcards in the pattern.
        // - Results list contains every valid binary combination.

        int index = pattern.IndexOf('*');

        // Base case: no wildcards left
        if (index == -1)
        {
            results.Add(pattern);
            return;
        }

        // Replace '*' with '0' and '1' and recurse
        string withZero = pattern[..index] + "0" + pattern[(index + 1)..];
        string withOne = pattern[..index] + "1" + pattern[(index + 1)..];

        WildcardBinary(withZero, results);
        WildcardBinary(withOne, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
    {
        // If this is the first time running the function, then we need
        // to initialize the currPath list.
        if (currPath == null)
        {
            currPath = new List<ValueTuple<int, int>>();
        }
    }
    // currPath.Add((1,2)); // Use this syntax to add to the current path

    // TODO Start Problem 5
    // ADD CODE HERE
    // ======== CODE ======== //  (by Jéssica Seniw)
    // Before:
    // - SolveMaze had compilation and logic errors.
    // - IsValidMove was called with incorrect parameter order.
    // - Path conversion relied on AsString(), which was not defined in the project.
    // - Output format did not match the expected test results.
    // - Tests for SolveMaze failed due to incorrect path formatting and validation.

    // Fix:
    // - Corrected the IsValidMove call to match the method signature.
    // - Implemented proper recursive backtracking to explore all valid paths.
    // - Ensured each position is added before recursion and removed after (backtracking).
    // - Added explicit path string formatting to match test expectations.
    // - Separated concerns to keep recursion logic clear and readable.

    // After:
    // - All valid paths from (0,0) to the end are found correctly.
    // - The maze is solved using recursion without revisiting positions.
    // - Output format exactly matches the expected results.
    // - All SolveMaze unit tests pass successfully.

    // Problem 5
    // Use recursion to insert all paths that start at (0,0) and end at the
    // 'end' square into the results list.
    public static void SolveMaze(List<string> results, Maze maze)
    {
        List<(int, int)> path = new();
        SolveMazeHelper(results, maze, path, 0, 0);
    }

    private static void SolveMazeHelper(
        List<string> results,
        Maze maze,
        List<(int, int)> path,
        int x,
        int y)
    {
        // Check if move is valid
        if (!maze.IsValidMove(path, x, y))
            return;

        // Add current position
        path.Add((x, y));

        // If we reached the end, store the path
        if (maze.IsEnd(x, y))
        {
            results.Add(PathToString(path));
        }
        else
        {
            // Explore all directions
            SolveMazeHelper(results, maze, path, x + 1, y); // right
            SolveMazeHelper(results, maze, path, x - 1, y); // left
            SolveMazeHelper(results, maze, path, x, y + 1); // down
            SolveMazeHelper(results, maze, path, x, y - 1); // up
        }

        // Backtrack
        path.RemoveAt(path.Count - 1);
    }

    private static string PathToString(List<(int, int)> path)
    {
        return "<List>{" +
            string.Join(", ", path.Select(p => $"({p.Item1}, {p.Item2})")) +
            "}";
    }
}