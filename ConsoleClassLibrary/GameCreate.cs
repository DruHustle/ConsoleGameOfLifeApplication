using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class GameCreate : IGameCreate
    {
        // Create initial board with a random state.
        public bool [,] RandomBoard(int width, int height)
        {
            var random = new Random();

            bool[,] board = new bool[width, height];

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    // Equal probability of being true or false.
                    board[x, y] = random.Next(2) == 0;
                }
            }

            return board ;
        }

    }
}
