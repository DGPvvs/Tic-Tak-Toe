using System;
using System.Collections.Generic;
using System.Text;
using TicTakTok.Utilities.Enums;

namespace TicTakTok.Board.Contract
{
	public interface IBoardGame
	{
		public bool IsFull();
		public void PlaceSymbol(IndexBoard index, Symbol symbol);
		public IEnumerable<IndexBoard> GetemptyPositions();
		public Symbol IsRowFull(int row);
		public Symbol IsColFull(int col);
		public Symbol IsMainDiagonalFull();
		public Symbol IsSecondDiagonalFull();
	}
}
