using System;
using System.Diagnostics.CodeAnalysis;
using TicTakTok.Utilities.Exceptions;

namespace TicTakTok.Board
{
	public class IndexBoard : IComparable<IndexBoard>
	{
		private int row;
		private int col;

		public IndexBoard(int row, int col)
		{
			this.Row = row;
			this.Col = col;
		}

		public IndexBoard(string str)
		{
			string[] parts = str.Split(", ", StringSplitOptions.RemoveEmptyEntries);

			int r;
			int c;
			if (!int.TryParse(parts[0], out r))
			{
				throw new InvalidArgumentException("Invalid row format");
			}
			else
			{
				this.Row = r;
			}

			if (!int.TryParse(parts[1], out c))
			{
				throw new InvalidArgumentException("Invalid col format");
			}
			else
			{
				this.Col = c;
			}
		}

		

		public int Row 
		{
			get => this.row;
			private set => this.row = value;
		}

		public int Col 
		{
			get => this.col;
			private set => this.col = value;
		}

		public override string ToString() => $"{this.Row}, {this.Col}";

		public int CompareTo([AllowNull] IndexBoard other)
		{
			int cmp = this.Row.CompareTo(other.Row);

			if (cmp == 0)
			{
				cmp = this.Col.CompareTo(other.Col);
			}
			
			return cmp;
		}
	}
}
