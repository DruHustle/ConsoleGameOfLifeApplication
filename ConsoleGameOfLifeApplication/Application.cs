using ConsoleClassLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleUI
{
    public class Application : IApplication
    {
        IGameCreate _boards;
        IGameDraw _draw;
        IGameUpdate _update;
        IGameConsole _setUp;
        IPrintOutput _printOutput;
        IUserInput _userInput;


        public Application(IGameCreate boards, IGameDraw draw, IGameUpdate update, IGameConsole setUp, IPrintOutput printOutput, IUserInput userInput)
        {
            _boards = boards;
            _draw = draw;
            _update = update;
            _setUp= setUp;
            _printOutput = printOutput;
            _userInput = userInput;

        }

        // The delay in milliseconds between board updates.
        readonly int DELAY = 50;

        //Bounderies for the acceptable board width and height.
        readonly int lowerBound = 5;
        readonly int widthUpperBound =84;
        readonly int heightUpperBound = 43;

        //The values entered by the user.
        int width;
        int height;
        int generations;

        // Holds the current state of the board.
        bool[,] board;

        //Runs the Game Of Life application.
        public void Run()
        {
            Console.Title = "Conway’s Game of Life";
            _printOutput.Message("\nWelcome to the Conway’s Game of Life. To play, enter the prompted width, height and generations values. Press the \"Esc\" key to exit game at any time.\n\nPress any key to continue...");
            Console.ReadKey();

            // The dimensions of the board .
            width = _userInput.GetValues("\nWidth: Enter integer values between 5 and 84.",lowerBound, widthUpperBound, out bool widthIsParsable); //width accepted values 5 < w <84
            height = _userInput.GetValues("\nHeight: Enter integer values between 5 and 43.",lowerBound, heightUpperBound, out bool heightIsParsable);//height accepted values 5 < w <43

            // Get number of generations.
            generations = _userInput.GetValues(out bool generationsIsParsable);

            // Create initial board with a random state.      
            board = _boards.RandomBoard(width, height);          

            // Initialize Console.
            _setUp.Initialize(width, height);

            int i =0;
            // Run the game until the Escape key is pressed, for the generations given.
            while ((!Console.KeyAvailable || Console.ReadKey(true).Key != ConsoleKey.Escape)&& generations>0)
            {
                //count number of genarations left
                generations = generations-i;
                i++;

                // Draws the board to the console.
                _draw.Board(height, width, board);

                // Moves the board to the next state based on Conway's rules.
                _update.Board(width, height, board, out board);

                // Wait for a bit between updates.
                Thread.Sleep(DELAY);
            }

            Console.ResetColor();
            Console.SetWindowSize(120,30);
            Console.Clear();
            _printOutput.Message("\nExiting game.\n\nPress any key to proceed...");
            Console.ReadKey();

        }

    }
}
