using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeKata;

namespace TicTacToeTest
{
    [TestClass]
    public class TestGame
    {
 

        [TestMethod]
        public void createGame()
        {
            //hardcoded 3x3 board as array of size 9
            TicTacToeGame myGame = new TicTacToeGame();
            Assert.IsNotNull(myGame);
        }
        [TestMethod]
        public void initializeStandardGame()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            Assert.AreEqual(players.Blank, myGame.gameBoard.gameTiles[1, 1]);
            Assert.AreEqual(gameStates.Playing, myGame.gameState);
            Assert.IsNotNull(myGame.gameBoard.gameTiles);
        }
        [TestMethod]
        public void initializeCustomGame()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeCustomGame(5,5);
            Assert.AreEqual(players.Blank, myGame.gameBoard.gameTiles[1, 1]);
            Assert.AreEqual(gameStates.Playing, myGame.gameState);
            Assert.IsNotNull(myGame.gameBoard.gameTiles);
        }
        [TestMethod]
        public void initializeCustomGameNotSquare()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeCustomGame(5, 6);
            Assert.IsTrue(myGame.gameBoard.rows == 3);
        }
        [TestMethod]
        public void createPlayers()
        {
            //player X always goes first
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);
            Assert.IsNotNull(playerX);
            Assert.AreEqual(0, playerX.playerTotalMoves);
            Assert.IsNotNull(playerO);
            Assert.AreEqual(0, playerO.playerTotalMoves);
        }
        [TestMethod]
        public void winWithMinimumMoves()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 1);
            myGame.makeMove(playerO, 0, 2);
            myGame.makeMove(playerX, 2, 2);

            Assert.AreEqual(gameStates.Won, myGame.gameState);

        }
        [TestMethod]
        public void draw()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 1, 0);
            myGame.makeMove(playerX, 1, 1);
            myGame.makeMove(playerO, 2, 2);
            myGame.makeMove(playerX, 0, 1);
            myGame.makeMove(playerO, 2, 1);
            myGame.makeMove(playerX, 2, 0);
            myGame.makeMove(playerO, 0, 2);
            myGame.makeMove(playerX, 1, 2);
            
            Assert.AreEqual(gameStates.Draw, myGame.gameState);

        }
        [TestMethod]
        public void winCustomGame()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeCustomGame(4,4);
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 1, 0);
            myGame.makeMove(playerX, 0, 1);
            myGame.makeMove(playerO, 1, 1);
            myGame.makeMove(playerX, 0, 2);
            myGame.makeMove(playerO, 1, 2);
            myGame.makeMove(playerX, 0, 3);

            Assert.AreEqual(gameStates.Won, myGame.gameState);
            Assert.AreEqual(players.X, myGame.gameWinner);

        }
        [TestMethod]
        public void winWithMaxMoves()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 2);
            myGame.makeMove(playerO, 2, 1);
            myGame.makeMove(playerX, 1, 1);
            myGame.makeMove(playerO, 2, 2);
            myGame.makeMove(playerX, 2, 0);
            myGame.makeMove(playerO, 0, 2);
            myGame.makeMove(playerX, 1, 0);

            Assert.AreEqual(gameStates.Won, myGame.gameState);

        }
        [TestMethod]
        public void winDiagonalDown()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 1);
            myGame.makeMove(playerO, 0, 2);
            myGame.makeMove(playerX, 2, 2);

            Assert.AreEqual(gameStates.Won, myGame.gameState);
            Assert.AreEqual(players.X, myGame.gameWinner);
        }
        [TestMethod]
        public void winDiagonalUp()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 2, 0);
            myGame.makeMove(playerX, 1, 0);
            myGame.makeMove(playerO, 1, 1);
            myGame.makeMove(playerX, 0, 1);
            myGame.makeMove(playerO, 0, 2);

            Assert.AreEqual(gameStates.Won, myGame.gameState);
            Assert.AreEqual(players.O, myGame.gameWinner);
        }
        [TestMethod]
        public void winVertical()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 0);
            myGame.makeMove(playerO, 1, 1);
            myGame.makeMove(playerX, 2, 0);
            Assert.AreEqual(myGame.totalGameMoves, 5);
            Assert.AreEqual(myGame.gameBoard.gameTiles[0, 0], players.X);
            Assert.AreEqual(myGame.gameBoard.gameTiles[1, 0], players.X);
            Assert.AreEqual(myGame.gameBoard.gameTiles[2, 0], players.X);
            Assert.AreEqual(playerX.playerTotalMoves, 3);
            Assert.IsTrue(myGame.checkForVerticalWin(0));
            Assert.AreEqual(myGame.gameWinner, players.X);
        }
        [TestMethod]
        public void winHorizontal()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 1, 0);
            myGame.makeMove(playerX, 0, 1);
            myGame.makeMove(playerO, 1, 1);
            myGame.makeMove(playerX, 0, 2);
            Assert.AreEqual(myGame.totalGameMoves, 5);
            Assert.AreEqual(myGame.gameBoard.gameTiles[0, 0], players.X);
            Assert.AreEqual(myGame.gameBoard.gameTiles[0, 1], players.X);
            Assert.AreEqual(myGame.gameBoard.gameTiles[0, 2], players.X);
            Assert.AreEqual(playerX.playerTotalMoves, 3);
            Assert.IsTrue(myGame.checkForHorizontalWin(0));
            Assert.AreEqual(myGame.gameWinner, players.X);
        }
        [TestMethod]
        public void invalidMoveOutsideBoard()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, -1, 0);
            Assert.AreEqual(myGame.gameState, gameStates.Error);
            myGame.makeMove(playerO, 0, 1);
            Assert.AreEqual(myGame.gameState, gameStates.Error);

            myGame.initializeStandardGame();
            myGame.makeMove(playerX, 0, 3);
            Assert.AreEqual(myGame.gameState, gameStates.Error);

        }
        [TestMethod]
        public void tooManyMoves()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 2);
            myGame.makeMove(playerO, 2, 1);
            myGame.makeMove(playerX, 1, 1);
            myGame.makeMove(playerO, 2, 2);
            myGame.makeMove(playerX, 2, 0);
            myGame.makeMove(playerO, 0, 2);
            myGame.makeMove(playerX, 1, 0);
            myGame.makeMove(playerO, 1, 1);

            Assert.AreEqual(myGame.gameBoard.gameTiles[1, 1], players.X);
            Assert.AreEqual(myGame.gameState, gameStates.Error);
            Assert.AreEqual(myGame.gameWinner, playerX.playerName);
        }
        [TestMethod]
        public void gameInProgress()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 2);
            myGame.makeMove(playerO, 2, 1);

            Assert.AreEqual(myGame.gameState, gameStates.Playing);
            Assert.AreEqual(myGame.gameWinner, players.Blank);
        }
        [TestMethod]
        public void trackGameMoves()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerO, 0, 1);
            myGame.makeMove(playerX, 1, 2);
            myGame.makeMove(playerO, 2, 1);

            Assert.AreEqual(playerX.playerTotalMoves, 2);
            Assert.AreEqual(playerX.getPlayerMoveTileLocation(1), "0,0");
            Assert.AreEqual(playerX.getPlayerMoveTileLocation(2), "1,2");
        }
        [TestMethod]
        public void playerOGoesFirst()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerO, 0, 0);
            myGame.makeMove(playerX, 0, 1);

            Assert.AreEqual(myGame.gameState, gameStates.Error);
        }
        [TestMethod]
        public void playerMovesTwice()
        {
            TicTacToeGame myGame = new TicTacToeGame();
            myGame.initializeStandardGame();
            var playerX = new Players(players.X);
            var playerO = new Players(players.O);

            myGame.makeMove(playerX, 0, 0);
            myGame.makeMove(playerX, 0, 1);
            myGame.makeMove(playerO, 0, 2);

            Assert.AreEqual(myGame.gameState, gameStates.Error);
            Assert.AreEqual(myGame.gameBoard.gameTiles[0, 1], players.Blank);
        }

    }
}
