using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8QueenProblem
{
    public partial class Form1 : Form
    {
        private int labelLocationX = 12;
        private int labelLocationY = 48;
        private int labelSize = 80;

        private Label[,] chessBoard=new Label[8,8];
        private bool[,] chessMatrix = new bool[8, 8];
        private Queen[] queens = new Queen[8];
        private List<Queen[]> allQueens = new List<Queen[]>();

        public Form1()
        {
            InitializeComponent();
            printchessBoard();
            firstMatrix();
            solveQueenProblem(0);
            addComboBox();
        }

        #region alghorithm
        public void solveQueenProblem(int j)
        {
            for (int i = 0; i < 8; i++)
            {
                if (chessMatrix[i, j] == true)
                {
                    queens[j] = new Queen(i, j);
                    if (j == 7)
                    {
                        copytolist();
                        continue;
                    }
                    queens[j].copyNotAvailableMoves(chessMatrix);
                    solveQueenProblem(j + 1);
                    queens[j].deleteNotAvailableMoves(chessMatrix);
                }
            }
        }
        #endregion

        #region needfunctions
        private void addComboBox()
        {
            comboBox1.TabStop = false;
            button1.Enabled = false;
            comboBox1.Text = "განლაგების ვარიანტები";
            comboBox1.Enabled = true;
            comboBox1.Visible = true;
            int k = 1;
            foreach (Queen[] q in allQueens)
            {
                comboBox1.Items.Add(k);
                k++;
            }
        }

        private void copytolist()
        {
            Queen[] q = new Queen[8];
            for (int i = 0; i < 8; i++)
            {    
                q[i]=new Queen(queens[i].Row, queens[i].Column);

            }
            allQueens.Add(q);
        }

        private void printchessBoard()
        {
            for (int i = 0; i < 8; i++)
                for(int j=0;j<8;j++)
            {
                chessBoard[i,j] = new Label();
                chessBoard[i,j].AutoSize = false;
                chessBoard[i,j].Name = "label" + (i + 1).ToString();
                chessBoard[i,j].Size = new Size(labelSize,labelSize);
                chessBoard[i,j].Location = new Point(labelLocationX, labelLocationY); 
                if ((j+1) % 8 == 0)
                {
                    labelLocationY += labelSize;
                    labelLocationX = 12;
                }
                else
                {
                    labelLocationX += labelSize;
                }
                if ((i+1) % 2 == 1 && (j+1) % 2==1 || (i+1) % 2==0 && (j+1) % 2==0)
                {
                    chessBoard[i,j].BackColor = Color.FromArgb(128, 64, 0);
                }
                else
                {
                    chessBoard[i,j].BackColor = Color.Chocolate;
                }
            }
            for (int i = 0; i < 8; i++)
                for(int j=0;j<8;j++)
            {
                this.Controls.Add(chessBoard[i,j]);
            }
        }

        private void firstMatrix()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    chessMatrix[i, j] = true;
                }
        }
        
        private void printQueensLocation(Queen[] q)
        {
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    Image im = Image.FromFile("black-queen.png");
                    chessBoard[q[i].Row, q[i].Column].Image=im;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
        #endregion

        #region not need functions
        private void selectNotAvailableMoves()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (!chessMatrix[i, j])
                        chessBoard[i, j].BackColor = Color.Red;
        }

        private void printQueensLocation()
        {
            for (int i = 0; i < 8; i++)
            {
                try
                {
                    chessBoard[queens[i].Row, queens[i].Column].BackColor = Color.Blue;
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }
        #endregion

        #region getter,setter
        public bool[,] ChessMatrix
        {
            get { return chessMatrix; }
            set { chessMatrix = value; }
        }

        public Queen[] Queens
        {
            get { return queens; }
            set { queens = value; }
        }

        public List<Queen[]> AllQueens
        {
            get { return allQueens; }
            set { allQueens = value; }
        }

        public int LabelLocationX
        {
            get { return labelLocationX; }
            set { labelLocationX = value; }
        }

        public int LabelLocationY
        {
            get { return labelLocationY; }
            set { labelLocationY = value; }
        }

        public int LabelSize
        {
            get { return labelSize; }
            set { labelSize = value; }
        }
        #endregion
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= allQueens.Count-1)
                comboBox1.SelectedIndex = 0;
            else
            comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button2.Enabled = true;
            int k = comboBox1.SelectedIndex;
            int l = 0;
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    if (chessBoard[i, j].Image != null)
                    {
                        chessBoard[i, j].Image = null;
                    }
            foreach (Queen[] q in allQueens)
            {
                if (l == k)
                {
                    printQueensLocation(q);
                }
                l++;
            }
            for(int i=0;i<8;i++)
                for(int j=0;j<8;j++)
                    if (chessBoard[i, j].Image == null)
                    {
                        if ((i + 1) % 2 == 1 && (j + 1) % 2 == 1 || (i+ 1) % 2 == 0 && (j + 1) % 2 == 0)
                            chessBoard[i,j].BackColor = Color.FromArgb(128, 64, 0);
                        else chessBoard[i,j].BackColor = Color.Chocolate;
                    }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
                comboBox1.SelectedIndex = allQueens.Count-1;
            else
                comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
        }

    }
}
