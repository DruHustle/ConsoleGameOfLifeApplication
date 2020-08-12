using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class GameDraw : IGameDraw
    {
        //CLI unicode character printing.
        readonly char emptyBlockChar = ' ';
        readonly char fullBlockChar = '\u2588';


        // Draws the board to the console.
        public void Board(int height, int width, bool [,] board)
        {
            // One Console.Write call is much faster than writing each cell individually.
            var builder = new StringBuilder();

            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    char c = board[x, y] ? fullBlockChar : emptyBlockChar;

                    // Each cell is two characters wide.
                    builder.Append(c);
                    builder.Append(c);
                }
                builder.Append('\n');
            }

            // Write the string to the console.
            Console.SetCursorPosition(0, 0);
            Console.Write(builder.ToString());
        }

    }
}
