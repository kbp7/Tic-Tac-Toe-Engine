Kevin Poon
2017

Tic Tac Toe Kata

Goal: Create a program to track a game of TicTacToe between two human players.

Requirements

	•   There should be no user interface.
	•   The code should be unit tested.
	•   Track all player moves on the board.
	•   Do not allow invalid moves.
	•   Track the win state of the game (in progress, win, which player won, etc).
	•   Player X always goes first.
	•   Write the code in such a way that an independent module could use it.

            
Wikipedia entry: http://en.wikipedia.org/wiki/Tic-tac-toe

The standard game board is represented using a 2D array of size 3x3:

	[0,0] [1,0] [2,0]
	[0,1] [1,1] [2,1]
	[0,2] [1,2] [2,2]

Custom sized boards can also be made so long as the rows and columns
are equal. Otherwise it defaults to a standard board. 
Each tile is marked using enums:

	Blank, X, O

The "gameWinner" is set to "Blank" to indicate a draw. Win conditions are only
checked when a win is possible. There must be a minimum of 5 total game moves
and a maximum of 9 for a standard 3x3 board. If no winner is found after 9 moves,
the game is considered a draw.

For custom boards, the minimum number of total moves = 2 * rows - 1
and the maximum = rows * columns

Moves are made by checking each tile if it is set to "Blank" and assigning the player 
name if it is true. No moves are made if the number of moves exceeds the maximum.
If at any point an invalid move occurs, the program will change the game state to
"Error" and further moves are disallowed. 

Invalid moves include:

	- Index out of range
	- taking a tile that is not blank
	- exceeding 9 total game moves
	- moving twice in a row
	- Player O goes first
