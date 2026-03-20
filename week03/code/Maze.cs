// ======== COMMENT ======== //  (by Jéssica Seniw)
// Problem 4 – Maze
// Before:
// - Movement logic did not correctly enforce valid paths.
// - Invalid moves were not properly handled.

// Fix:
// - Implemented movement validation based on the maze map.
// - Added exception handling for invalid directions.
// - Ensured invalid moves throw an InvalidOperationException.

// After:
// - The maze correctly restricts movement based on defined rules.
// - All invalid moves are properly handled.
// - All unit tests pass successfully.

/// <summary>
/// Defines a maze using a dictionary. The dictionary is provided by the
/// user when the Maze object is created. The dictionary will contain the
/// following mapping:
///
/// (x,y) : [left, right, up, down]
///
/// 'x' and 'y' are integers and represents locations in the maze.
/// 'left', 'right', 'up', and 'down' are boolean are represent valid directions
///
/// If a direction is false, then we can assume there is a wall in that direction.
/// If a direction is true, then we can proceed.  
///
/// If there is a wall, then throw an InvalidOperationException with the message "Can't go that way!".  If there is no wall,
/// then the 'currX' and 'currY' values should be changed.
/// </summary>
public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    // TODO Problem 4 - ADD YOUR CODE HERE

    /// <summary>
    /// Check to see if you can move left.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>

    public void MoveLeft()
    {
        // FILL IN CODE
        // ======== CODE ======== //  (by Jéssica Seniw)

        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Movement to the left was not implemented.
        // - No validation for walls existed.

        // Fix:
        // - Added validation using the maze map to check if left movement is allowed.
        // - Ensured that movement is blocked when there is a wall.

        // After:
        // - The method correctly handles movement to the left.
        // - Throws InvalidOperationException when movement is not allowed.
        // - Movement behaves according to the maze rules.

        var directions = _mazeMap[(_currX, _currY)];

        // directions[0] = left
        if (!directions[0])
            throw new InvalidOperationException("Can't go that way!");

        _currX--;

        // AFTER: moved left successfully
    }

    /// <summary>
    /// Check to see if you can move right.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>

    public void MoveRight()
    {
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Movement to the right was incorrectly implemented or missing.
        // - No proper validation of walls existed.

        // Fix:
        // - Implemented correct validation using the maze map.
        // - Added logic to prevent movement when a wall is present.

        // After:
        // - The method correctly moves right when allowed.
        // - Properly throws an exception when movement is blocked.
        // - Behavior aligns with maze constraints.

        var directions = _mazeMap[(_currX, _currY)];

        // directions[1] = right
        if (!directions[1])
            throw new InvalidOperationException("Can't go that way!");

        _currX++;

        // AFTER: moved right successfully
    }

    /// <summary>
    /// Check to see if you can move up.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>

    public void MoveUp()
    {
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Movement upwards was not correctly implemented.
        // - No validation for allowed movement was present.

        // Fix:
        // - Added validation to check if upward movement is allowed.
        // - Ensured proper handling of walls in the upward direction.

        // After:
        // - The method correctly moves up when permitted.
        // - Throws InvalidOperationException when movement is blocked.
        // - Fully respects maze movement rules.

        var directions = _mazeMap[(_currX, _currY)];

        // directions[2] = up
        if (!directions[2])
            throw new InvalidOperationException("Can't go that way!");

        _currY--;

        // AFTER: moved up successfully
    }

    /// <summary>
    /// Check to see if you can move down.  If you can, then move.  If you
    /// can't move, throw an InvalidOperationException with the message "Can't go that way!".
    /// </summary>

    public void MoveDown()
    {
        // ======== CODE ======== //  (by Jéssica Seniw)
        // Before:
        // - Movement downwards was incorrectly implemented or duplicated.
        // - No validation for walls was enforced.

        // Fix:
        // - Implemented correct validation for downward movement.
        // - Ensured movement only occurs when allowed by the maze.

        // After:
        // - The method correctly moves down when permitted.
        // - Throws InvalidOperationException when movement is blocked.
        // - Behavior is consistent with maze constraints.

        var directions = _mazeMap[(_currX, _currY)];

        // directions[3] = down
        if (!directions[3])
            throw new InvalidOperationException("Can't go that way!");

        _currY++;

        // AFTER: moved down successfully
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}