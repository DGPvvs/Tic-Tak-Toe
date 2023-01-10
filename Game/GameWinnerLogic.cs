using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Board;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Game
{
	public class GameWinnerLogic
	{

		public GameWinnerLogic()
		{

		}

		public  bool IsGameOver(BoardGame board)
		{
			for (int row = 0; row < board.Rows; row++)
			{
				if (board.IsRowFull(row) != Symbol.Empty)
				{
					return true;
				}
			}

			for (int col = 0; col < board.Cols; col++)
			{
				if (board.IsColFull(col) != Symbol.Empty)
				{
					return true;
				}
			}

			if (board.IsMainDiagonalFull() != Symbol.Empty)
			{
				return true;
			}

			if (board.IsSecondDiagonalFull() != Symbol.Empty)
			{
				return true;
			}

			return board.IsFull();
		}

		public  Symbol GetWinner(BoardGame board)
		{
			Symbol winner;
			for (int row = 0; row < board.Rows; row++)
			{
				winner = board.IsRowFull(row);
				if (winner != Symbol.Empty)
				{
					return winner;
				}
			}

			for (int col = 0; col < board.Cols; col++)
			{
				winner = board.IsColFull(col);
				if (winner != Symbol.Empty)
				{
					return winner;
				}
			}

			winner = board.IsMainDiagonalFull();
			if (winner != Symbol.Empty)
			{
				return winner;
			}

			winner = board.IsSecondDiagonalFull();
			if (winner != Symbol.Empty)
			{
				return winner;
			}

			return Symbol.Empty;
		}
	}
}
