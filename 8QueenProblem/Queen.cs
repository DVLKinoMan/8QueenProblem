using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8QueenProblem
{
    public class Queen
    {
        private int row;  
        private int column;


        private bool[,] chessMatrix = new bool[8, 8];


        public Queen(int x, int y)
        {
            row = x;
            column = y;
            firstMatrix();
            notAvailableMoves(this);
        }

        #region copy,delete moves
        public void copyNotAvailableMoves(bool[,] matrix)
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    if (chessMatrix[i, j] == false && matrix[i, j] == false)
                        chessMatrix[i, j] = true;
                    if (chessMatrix[i, j] == false && matrix[i, j] == true)
                        matrix[i, j] = false;
                    
                }
        }

        public void deleteNotAvailableMoves(bool[,] matrix)
        {
                for (int i = 0; i < 8; i++)
                    for (int j = 0; j < 8; j++)
                        if (chessMatrix[i, j] == false)
                            matrix[i, j] = true;
            
        }
        #endregion

        #region need functions
        private void firstMatrix()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    chessMatrix[i, j] = true;
                }
        }

        private void notAvailableMoves(Queen q1)
        {
            for (int j = 0; j < 8; j++)
                chessMatrix[q1.row, j] = false;
            for (int i = 0; i < 8; i++)
                chessMatrix[i, q1.column] = false;
            int k = 1;
            for (int i = q1.row - 1; i >= 0; i--)
            {
                if (q1.column - k >= 0)
                    chessMatrix[i, q1.column - k] = false;
                if (q1.column + k < 8)
                    chessMatrix[i, q1.column + k] = false;
                k++;
            }
            k = 1;
            for (int i = q1.row + 1; i < 8; i++)
            {
                if (q1.column - k >= 0)
                    chessMatrix[i, q1.column - k] = false;
                if (q1.column + k < 8)
                    chessMatrix[i, q1.column + k] = false;
                k++;
            }
        }
        #endregion

        #region getter,setter
        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public int Column
        {
            get { return column; }
            set { column = value; }
        }

        public bool[,] ChessMatrix
        {
            get { return chessMatrix; }
            set { chessMatrix = value; }
        }
        #endregion

    }
}
