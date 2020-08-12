namespace ConsoleClassLibrary
{
    public interface IGameCount
    {
        int LiveNeighbours(int x, int y, int width, int height, bool[,] board);
    }
}