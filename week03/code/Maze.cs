// ======== COMMENT ======== //  (by Jéssica Seniw)
/*
Refactored Maze movement methods to fix duplicate and incorrect implementations.

BEFORE:
The Maze class contained duplicated method implementations for MoveRight and MoveUp, and the MoveDown
method was incorrectly defined as another MoveUp method. This caused compilation errors due to method
duplication and incorrect behavior.

ISSUES IDENTIFIED:
- Duplicate method definitions for MoveRight and MoveUp
- Missing implementation of MoveDown method
- Code would not compile due to duplicate method signatures
- Incorrect method naming leading to logic errors

CHANGES MADE:
- Removed duplicate method implementations
- Ensured each movement method (MoveLeft, MoveRight, MoveUp, MoveDown) is defined exactly once
- Corrected method naming to match intended functionality
- Preserved original logic for movement using the maze dictionary

AFTER:
The class now correctly implements all four movement methods without duplication, ensuring proper
compilation and expected behavior when navigating the maze.
*/

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

        // BEFORE: (no movement logic)

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

    // ======== CODE ======== //  (by Jéssica Seniw)

    {
        // BEFORE: duplicate method removed (original implementation was duplicated)

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

        // BEFORE: duplicate method removed (original implementation was duplicated)

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

        // BEFORE: duplicate method removed (incorrectly implemented as MoveUp)

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