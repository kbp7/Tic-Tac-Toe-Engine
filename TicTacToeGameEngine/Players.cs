using System.Collections.Generic;

namespace TicTacToeKata
{
    public class Players
    {
        public int maximumPlayerMoves { get; private set; }
        public int minimumPlayerMoves { get; private set; }
        public int playerTotalMoves { get; private set; }
        public List<string> playerMoveList { get; private set; }
        public players playerName { get; private set; }
        public Players(players name)
        {
            playerName = name;
            playerTotalMoves = 0;
            playerMoveList = new List<string>();
        }
        public void setMoveLimits(int boardRows)
            //columns = rows is checked previously in the call stack 
        {
            minimumPlayerMoves = boardRows;
            maximumPlayerMoves = 2 * boardRows - 1;
        }
        public void playerMoveCounter()
        {
            playerTotalMoves++;
        }
        public void recordPlayerMove(int row, int column)
        {
            playerMoveList.Add(row.ToString() + "," + column.ToString());
        }
        public string getPlayerMoveTileLocation(int playerMove)
        {
            return playerMoveList[(playerMove - 1)];
        }
    }
    public enum players { Blank, X, O }
}
