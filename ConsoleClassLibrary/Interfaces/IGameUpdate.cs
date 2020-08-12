namespace ConsoleClassLibrary
{
    public interface IGameUpdate
    {
        void Board(int width, int height, bool[,] readBoard, out bool[,] updateBoard);
    }
}