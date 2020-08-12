using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class GameUpdate : IGameUpdate
    {
        IGameCount _count;
        public GameUpdate(IGameCount count)
        {
            _count =count;

        }
        public void Board(int width, int height, bool[,] readBoard, out bool[,] updateBoard)
        {
            // A temp variable to hold the next state while it's being calculated.
            bool[,] newBoard = new bool[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    // Returns the number of live neighbors around the cell at position (x,y).
                    var n = _count.LiveNeighbours(x, y, width, height, readBoard);
                    var c = readBoard[x, y];

                    // A live cell dies unless it has exactly 2 or 3 live neighbors.
                    // A dead cell remains dead unless it has exactly 3 live neighbors.
                    newBoard[x, y] = c && (n == 2 || n == 3) || !c && n == 3;
                }
            }

            // Set the board to its new state.
            updateBoard = newBoard;
        }
    }
}
