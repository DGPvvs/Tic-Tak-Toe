using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Board.Contract;
using TicTakTok.Utilities.Enums;
using TicTakTok.Utilities.Messages;

namespace TicTakTok.Board
{
	public class BoardGame : IBoardGame
	{
		private Symbol[,] board;
		private int rows;
		private int cols;


		public BoardGame() : this(3)
		{

		}

		public BoardGame(int rows)
		{
			this.board = new Symbol[rows, rows];
			this.rows = rows;
			this.cols = rows;
		}

		public int Rows
		{
			get =>this.rows;			
		}

		public int Cols
		{
			get => this.cols;
		}

		public Symbol[,] BoardState => this.board;

		public IEnumerable<IndexBoard> GetemptyPositions()
		{
			List<IndexBoard> positions = new List<IndexBoard>();

			for (int r = 0; r < this.Rows; r++)
			{
				for (int c = 0; c < this.Cols; c++)
				{
					if (this.BoardState[r, c] == Symbol.Empty)
					{
						positions.Add(new IndexBoard(r, c));
					}
				}

			}

			return positions;
		}

		public bool IsFull()
		{
			int sum = 0;
			foreach (Symbol symbol in this.board)
			{
				if (symbol == Symbol.Empty)
				{
					return false;
				}
			}

			return true;
		}

		public void PlaceSymbol(IndexBoard index, Symbol symbol)
		{
			if (!this.IsValidIndex(index))
			{
				throw new IndexOutOfRangeException(ExceptionMessages.IndexOutOfRange);
			}

			this.board[index.Row, index.Col] = symbol;
		}

		private bool IsValidIndex(IndexBoard index) => ((index.Row >= 0) && (index.Row < this.board.GetLength(0)) && (index.Col >= 0) && (index.Col < this.board.GetLength(1)));

		public Symbol IsRowFull(int row)
		{
			int c = 0;
			Symbol symbol = this.board[row, 0];
			if (symbol == Symbol.Empty)
			{
				return Symbol.Empty;
			}

			bool result = true;

			while (c < this.board.GetLength(0))
			{
				result = (result && (symbol == this.board[row, c]));
				c++;
			}

			if (result)
			{
				return symbol;
			}

			return Symbol.Empty;
		}

		public Symbol IsColFull(int col)
		{
			int r = 0;
			Symbol symbol = this.board[0, col];
			if (symbol == Symbol.Empty)
			{
				return Symbol.Empty;
			}

			bool result = true;

			while (r < this.board.GetLength(1))
			{
				result = (result && (symbol == this.board[r, col]));
				r++;
			}

			if (result)
			{
				return symbol;
			}

			return Symbol.Empty;
		}

		public Symbol IsMainDiagonalFull()
		{
			int r = 0;
			Symbol symbol = this.board[0, 0];
			if (symbol == Symbol.Empty)
			{
				return Symbol.Empty;
			}

			bool result = true;

			while (r < this.board.GetLength(0))
			{
				result = (result && (symbol == this.board[r, r]));
				r++;
			}

			if (result)
			{
				return symbol;
			}

			return Symbol.Empty;
		}

		public Symbol IsSecondDiagonalFull()
		{
			int r = 0;
			int maxCol = this.board.GetLength(1) - 1;

			Symbol symbol = this.board[0, maxCol];
			if (symbol == Symbol.Empty)
			{
				return Symbol.Empty;
			}

			bool result = true;

			while (r < this.board.GetLength(0))
			{
				result = (result && (symbol == this.board[r, maxCol - r]));
				r++;
			}

			if (result)
			{
				return symbol;
			}

			return Symbol.Empty;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			for (int row = 0; row < this.Rows; row++)
			{
				for (int col = 0; col < this.Cols; col++)
				{
					if (board[row, col] == Symbol.Empty)
					{
						sb.Append('.');
					}
					else
					{
						sb.Append(board[row, col].ToString());
					}
				}
				sb.AppendLine();
			}

			return sb.ToString().TrimEnd();			
		}
	}
}
