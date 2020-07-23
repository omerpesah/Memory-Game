using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public class GameLogic
    {
        private static Random m_Random;

        internal static bool IsGameOver(GameBoard i_GameBoard)
        {
            return GameLogic.isAllFliped(i_GameBoard);
        }

        private static bool isAllFliped(GameBoard i_GameBoard)
        {
            bool isfliped = true;

            for (int i = 0; i < i_GameBoard.Height; i++)
            {
                for (int j = 0; j < i_GameBoard.Width; j++)
                {
                    if (!i_GameBoard.CurrentBoard[i, j].IsMatched)
                    {
                        isfliped = false;
                    }
                }
            }

            return isfliped;
        }

        internal static bool CheckIfMoveIsLegal(int i_Row, int i_Col, GameBoard i_GameBorad)
        {
            return !(i_GameBorad.CurrentBoard[i_Row, i_Col].IsMatched || i_GameBorad.CurrentBoard[i_Row, i_Col].Flip);
        }

        public static void FlipCard(int i_Row, int i_Col, GameBoard i_GameBorad)
        {
            i_GameBorad.CurrentBoard[i_Row, i_Col].Flip = true;
        }

        public static List<CardSquare> ComputerTurnMove(GameBoard i_GameBoard)
        {
            m_Random = new Random();
            List<CardSquare> computerIndexes = new List<CardSquare>();
            int row = 0, col = 0;
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    row = m_Random.Next(0, i_GameBoard.Height);
                    col = m_Random.Next(0, i_GameBoard.Width);
                }
                while (!CheckIfMoveIsLegal(row, col, i_GameBoard));
                FlipCard(row, col, i_GameBoard);
                computerIndexes.Add(i_GameBoard.CurrentBoard[row, col]);
            }

            return computerIndexes;
        }
    }
}
