using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClassLibrary
{
    public class GameConsole : IGameConsole
    {
        // The cell colors.
        readonly ConsoleColor deadColor = ConsoleColor.White;
        readonly ConsoleColor liveColor = ConsoleColor.Black;

        // The color of the cells that are off of the board.
        readonly ConsoleColor backGroundColor = ConsoleColor.Gray;

        // Sets up the Console.
        public void Initialize(int width, int height)
        {
            Console.BackgroundColor = backGroundColor;
            Console.Clear();

            Console.CursorVisible = false;

            // Each cell is two characters wide.
            // Using an extra row on the bottom to prevent scrolling when drawing the board.
            int setWidth = Math.Max(width, 8) * 2 + 1;
            int setHeight = Math.Max(height, 8) + 1;
            Console.SetWindowSize(setWidth, setHeight);
            Console.SetBufferSize(setWidth, setHeight);

            Console.BackgroundColor = deadColor;
            Console.ForegroundColor = liveColor;
        }
    }
}
