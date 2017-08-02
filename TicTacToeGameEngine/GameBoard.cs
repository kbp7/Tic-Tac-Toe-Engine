namespace TicTacToeKata
{
    public class GameBoard
    {
        public int minimumMovesToWin { get; private set; }
        public int maximumMovesToWin { get; private set; }
        public int rows { get; private set; }
        public int columns { get; private set; }
        public players[,] gameTiles { get; private set; }
        public bool isValidBoard { get; private set; }
        public void initializeStandardBoard()
        {
            rows = 3;
            columns = 3;
            gameTiles = new players[rows, columns];
            minimumMovesToWin = 5;
            maximumMovesToWin = 9;
            isValidBoard = true;
        }
        public void initializeCustomBoard(int customRows, int customColumns)
        {
            if (customRows == customColumns && customRows > 0)
            {
                rows = customRows;
                columns = customColumns;
                gameTiles = new players[rows, columns];
                minimumMovesToWin = (2 * rows - 1);
                maximumMovesToWin = (rows * columns);
                isValidBoard = true;
            }
            else
            {
                //invalid board
                isValidBoard = false;
            }
        }
    }
}