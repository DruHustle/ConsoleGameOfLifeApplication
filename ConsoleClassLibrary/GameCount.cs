using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class GameCount : IGameCount
    {
        // True if cell rules can loop around edges.
        readonly bool loopEdges = true;

        // Returns the number of live neighbors around the cell at position (x,y).
        public int LiveNeighbours(int x, int y, int width, int height, bool[,] board)
        {
            // The number of live neighbors.
            int value = 0;

            // This nested loop enumerates the 9 cells in the specified cells neighborhood.
            for (var j = -1; j <= 1; j++)
            {
                // Loop around the edges if y+j is off the board.
                int k = (y + j + height) % height;

                for (var i = -1; i <= 1; i++)
                {
                    // Loop around the edges if x+i is off the board.
                    int h = (x + i + width) % width;

                    // Count the neighbor cell at (h,k) if it is alive.
                    value += board[h, k] ? 1 : 0;
                }
            }

            // Subtract 1 if (x,y) is alive since we counted it as a neighbor.
            return value - (board[x, y] ? 1 : 0);
        }
    }
}
