using System;

namespace TicTacToeKata
{
    public class TicTacToeGame
    {
        public gameStates gameState { get; private set; }
        public int totalGameMoves { get; private set; }
        public players playerTurn { get; private set; }
        public players gameWinner { get; private set; }
        public GameBoard gameBoard { get; private set; }
        public void initializeStandardGame()
        {
            gameBoard = new GameBoard();
            gameBoard.initializeStandardBoard();
            totalGameMoves = 0;
            gameState = gameStates.Playing;
            gameWinner = players.Blank;
            playerTurn = players.X;
        }
        public void initializeCustomGame(int customRows, int customColumns)
        {
            //must still be square
            if (customRows == customColumns && customRows > 0)
            {
                gameBoard = new GameBoard();
                gameBoard.initializeCustomBoard(customRows, customColumns);
                totalGameMoves = 0;
                gameState = gameStates.Playing;
                gameWinner = players.Blank;
                playerTurn = players.X;
            }
            else
            {
                //invalid custom board. create default 3x3 board.
                initializeStandardGame();
            }
        }
        public bool gameCanBeWon()
        {
            int minimumMoves = gameBoard.minimumMovesToWin;
            int maxMoves = gameBoard.maximumMovesToWin;
            if ((totalGameMoves < minimumMoves) || totalGameMoves > maxMoves || gameState != gameStates.Playing)
            {
                //either impossible to win or already in a draw
                return false;
            }
            else return true;
        }
        public void updateGameState(gameStates newState)
        {
            if (gameState == gameStates.Playing || newState == gameStates.Error)
            {
                gameState = newState;
            }
        }
        public void makeMove(Players currentPlayer, int tileIndexX, int tileIndexY)
        {
            if ((totalGameMoves == 0) && (currentPlayer.playerName != playerTurn))
            {
                //player X must go first
                updateGameState(gameStates.Error);
            }
            else if(playerTurn != currentPlayer.playerName)
            {
                updateGameState(gameStates.Error);
            }
            else if (checkIfTileIsValid(currentPlayer.playerName, tileIndexX, tileIndexY))
            {
                //valid, make the move
                gameBoard.gameTiles[tileIndexX, tileIndexY] = currentPlayer.playerName;
                totalGameMoves++;
                currentPlayer.playerMoveCounter();
                currentPlayer.recordPlayerMove(tileIndexX, tileIndexY);
                if (gameCanBeWon() && checkAllWinConditions(tileIndexX, tileIndexY))
                {
                    //declare the winner
                    declareGameWinner(currentPlayer.playerName);
                }
                else if(totalGameMoves >= gameBoard.maximumMovesToWin)
                {
                    declareGameWinner(players.Blank);
                }
                else
                {
                    switchPlayer();
                }
            }
            else updateGameState(gameStates.Error);
        }
        public bool checkIfTileIsValid(players currentPlayer, int tileIndexX, int tileIndexY)
        {
            try
            {
                if (gameBoard.gameTiles[tileIndexX, tileIndexY] == players.Blank)
                {
                    //tile is available
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid move by " + currentPlayer);
                    updateGameState(gameStates.Error);
                    return false;
                }  
            }
            catch(IndexOutOfRangeException e)
            {
                //invalid tile chosen
                updateGameState(gameStates.Error);
                return false;
            }
        }
        public void declareGameWinner(players currentPlayer)
        {
            if(currentPlayer == players.Blank)
            {
                //draw game
                Console.WriteLine("Draw Game");
                updateGameState(gameStates.Draw);
            }
            else if (gameWinner == players.Blank && gameCanBeWon())
            {
                Console.WriteLine(currentPlayer + " won game in "+ totalGameMoves + " moves");
                gameWinner = currentPlayer;
                updateGameState(gameStates.Won);
            }
          
            else
            {
                Console.WriteLine("Error at move " + totalGameMoves + " by " + currentPlayer);
                //the game has already been won
                updateGameState(gameStates.Error);
            }
        }
        public bool checkAllWinConditions(int row, int column)
        {
            if (checkForHorizontalWin(row) || checkForVerticalWin(column) || 
                checkForDiagonalDownWin()  || checkForDiagonalUpWin())
            {
                return true;
            }
            else return false;
        }
        public bool checkForHorizontalWin(int row)
        {
            //check row that move was in
            for (int column = 0; column < gameBoard.columns; column++)
            {
                if(gameBoard.gameTiles[row, column] != playerTurn)
                {
                    return false;
                }
            }
            //if all belong to player
            return true; 
        }
        public bool checkForVerticalWin(int column)
        {
            //check column that move was in
            for (int row = 0; row < gameBoard.rows; row++)
            {
                if (gameBoard.gameTiles[row, column] != playerTurn)
                {
                    return false;
                }
            }
            return true;
        }
        public bool checkForDiagonalDownWin()
        {
            int row = 0;
            //check row that move was in
            for (int column = 0; column < gameBoard.columns; column++)
            {
                if (gameBoard.gameTiles[row, column] != playerTurn)
                {
                    return false;
                }
                row++;
            }
            return true;
        }
        public bool checkForDiagonalUpWin()
        {
            int row = 0;
            //check row that move was in
            for (int column = gameBoard.columns - 1; column >= 0; column--)
            {
                if (gameBoard.gameTiles[row, column] != playerTurn)
                {
                    return false;
                }
                else
                    row++;
            }
            return true;
        }
        
        public void switchPlayer()
        {
            if(playerTurn.Equals(players.X))
            {
                playerTurn = players.O;
            }
            else if (playerTurn.Equals(players.O))
            {
                playerTurn = players.X;
            }
            else
            {
                updateGameState(gameStates.Error);
            }
        }
    }
    public enum gameStates { Playing, Draw, Won, Error }
    

    
}
