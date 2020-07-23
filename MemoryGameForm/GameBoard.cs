using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public class GameBoard
    {
        private readonly int r_BoardWidth = 0;
        private readonly int r_BoardHeight = 0;
        private Player m_FirstPlayer = null;
        private Player m_SecondPlayer = null;
        private bool m_ComputerPlay = true;
        private CardSquare[,] m_CardSquare;
        private eGameTurn m_GameTurn = eGameTurn.FirstPlayer;
        private PictureBox[,] m_PictureBoxs;
        public List<char> m_Icons;
        internal GameBoardForm m_GameBoardForm;
        private bool m_GameIsFinishGame = false;
        private Random m_Random;
        private List<PictureBox> images;

        public GameBoard(int i_HeightOfBoard, int i_WidthOfBoard, string i_FirstPlayerName, string i_SecondPlayerName) : this(i_HeightOfBoard, i_WidthOfBoard, i_FirstPlayerName)
        {
            m_SecondPlayer.PlayerName = i_SecondPlayerName;
            m_ComputerPlay = false;
            m_GameBoardForm.SecondPlayerLable.Text = i_SecondPlayerName + " : " + m_SecondPlayer.PlayerScore;
        }

        public GameBoard(int i_HeightOfBoard, int i_WidthOfBoard, string i_FirstPlayer)
        {
            m_FirstPlayer = new Player(i_FirstPlayer);
            m_SecondPlayer = new Player("Computer");
            m_GameBoardForm = new GameBoardForm(i_HeightOfBoard, i_WidthOfBoard, i_FirstPlayer, m_SecondPlayer.PlayerName);
            m_CardSquare = new CardSquare[i_HeightOfBoard, i_WidthOfBoard];
            r_BoardWidth = i_WidthOfBoard;
            r_BoardHeight = i_HeightOfBoard;
            m_PictureBoxs = new PictureBox[r_BoardHeight, r_BoardWidth];
            images = new List<PictureBox>();
            m_Random = new Random();
            createIcons();
            AssignIconsToSquareCards();
            InitzalizeMatrix();
        }

        internal void createIcons()
        {
            //m_Icons = new List<char>()
            //{
            //'s', 's', 't', 't', 'u', 'u', 'v', 'v',
            //'w', 'w', 'x', 'x', 'y', 'y', 'z', 'z'
            //};
            //int i = 0;
            //while (m_Icons.Count < Height * Width)
            //{
            //    char firstAdd = char.ToUpper(m_Icons[i]);
            //    char secondAdd = char.ToUpper(m_Icons[i + 1]);
            //    m_Icons.Add(firstAdd);
            //    m_Icons.Add(secondAdd);
            //    i += 2;
            //    if (m_Icons.Count == 32)
            //    {
            //        m_Icons.Add('r');
            //        m_Icons.Add('r');
            //        m_Icons.Add('q');
            //        m_Icons.Add('q');
            //    }
            //}
            while (images.Count < (Height * Width) / 2)
            {
                PictureBox pictureBoxToAdd = new PictureBox();
                pictureBoxToAdd.Load("https://picsum.photos/80");
                if (pictureBoxToAdd.Image != null)
                {
                    images.Add(pictureBoxToAdd);
                }
            }
        }
        
        internal bool IsGameOver()
        {
            bool valToReturn = true;
            for (int i = 0; i < r_BoardHeight; i++)
            {
                for (int j = 0; j < r_BoardWidth; j++)
                {
                    if(m_CardSquare[i, j].IsMatched == false)
                    {
                        valToReturn = false;
                    }
                }
            }

            return valToReturn;
        }

        internal void AssignIconsToSquareCards()
        {
            //for (int i = 0; i < r_BoardHeight; i++)
            //{
            //    for (int j = 0; j < r_BoardWidth; j++)
            //    {
            //        int randomNumber = m_Random.Next(m_Icons.Count);
            //        m_CardSquare[i, j] = new CardSquare(m_Icons[randomNumber], i, j);
            //        m_Icons.RemoveAt(randomNumber);
            //    }
            //}
            int counter = 0;
            int imageIndex = 0;
            Random random = new Random();
            while (counter < Height * Width)
            {
                int row = random.Next(0, Height);
                int col = random.Next(0, Width);
                if (m_CardSquare[row, col] == null)
                {
                    m_CardSquare[row, col] = new CardSquare(row, col);
                    m_CardSquare[row, col].CardImage = images[imageIndex].Image;
                    if (counter % 2 != 0 && counter != 0)
                    {
                        imageIndex++;
                    }
                    counter++;
                }
                else
                {
                    continue;
                }
            }
        }

        internal string PrintDetails()
        {
            string stringToReturn = string.Empty;
            if(m_FirstPlayer.PlayerScore > m_SecondPlayer.PlayerScore)
            {
                stringToReturn = string.Format("The winner is: {0}!!!", m_FirstPlayer.PlayerName);
            }
            else if(m_FirstPlayer.PlayerScore < m_SecondPlayer.PlayerScore)
            {
                stringToReturn = string.Format("The winner is: {0}!!!", m_SecondPlayer.PlayerName);
            }
            else
            {
                stringToReturn = string.Format("The game ended in draw!");
            }

            return stringToReturn;
        }

        public void InitzalizeMatrix()
        {
            int k = 0;
            m_GameIsFinishGame = false;
            m_GameBoardForm.Text = "Memory Game";
            Turn = eGameTurn.FirstPlayer;
            for (int i = 0; i < r_BoardHeight; i++)
            {
                for (int j = 0; j < r_BoardWidth; j++)
                {
                    m_PictureBoxs[i, j] = (PictureBox)m_GameBoardForm.Controls[k++];
                    m_PictureBoxs[i, j].Text = string.Empty;
                    m_PictureBoxs[i, j].BackColor = Color.Empty;
                    m_PictureBoxs[i, j].BackgroundImage = null;
                }
            }

            m_FirstPlayer.PlayerScore = 0;
            m_SecondPlayer.PlayerScore = 0;
            m_GameBoardForm.CurrentPlayerLable.Text = string.Format("Current Player: {0}", m_FirstPlayer.PlayerName);
            m_GameBoardForm.FirstPlayerLable.Text = string.Format("{0} : {1} Pairs", m_FirstPlayer.PlayerName, m_FirstPlayer.PlayerScore);
            m_GameBoardForm.SecondPlayerLable.Text = string.Format("{0} : {1} Pairs", m_SecondPlayer.PlayerName, m_SecondPlayer.PlayerScore);
            m_GameBoardForm.Update();
        }

        public void SwitchTurn()
        {
            if (m_ComputerPlay == false)
            {
                if (m_GameTurn == eGameTurn.FirstPlayer)
                {
                    m_GameTurn = eGameTurn.SecondPlayer;
                }
                else
                {
                    m_GameTurn = eGameTurn.FirstPlayer;
                }
            }
            else
            {
                if (m_GameTurn == eGameTurn.FirstPlayer)
                {
                    m_GameTurn = eGameTurn.Computer;
                }
                else
                {
                    m_GameTurn = eGameTurn.FirstPlayer;
                }
            }
        }

        internal bool CheckIfMatch(int i_FirstRow, int i_FirstCol, int i_SecondRow, int i_SecondCol)
        {
            bool valueToReturn = false;
            if (Image.ReferenceEquals(m_CardSquare[i_FirstRow, i_FirstCol].CardImage, m_CardSquare[i_SecondRow, i_SecondCol].CardImage) && !(i_FirstRow == i_SecondRow && i_FirstCol == i_SecondCol))
            {
                m_CardSquare[i_FirstRow, i_FirstCol].IsMatched = true;
                m_CardSquare[i_SecondRow, i_SecondCol].IsMatched = true;
                m_CardSquare[i_FirstRow, i_FirstCol].Flip = false;
                m_CardSquare[i_SecondRow, i_SecondCol].Flip = false;
                valueToReturn = true;
            }
            else
            {
                m_CardSquare[i_FirstRow, i_FirstCol].Flip = false;
                m_CardSquare[i_SecondRow, i_SecondCol].Flip = false;
            }

            return valueToReturn;
        }

        internal void UpdateLableOnBoard()
        {
            if (Turn == eGameTurn.FirstPlayer)
            {
                m_GameBoardForm.CurrentPlayerLable.Text = "Current Player: " + m_FirstPlayer.PlayerName;
                m_GameBoardForm.CurrentPlayerLable.BackColor = Color.PaleGreen;
                m_GameBoardForm.FirstPlayerLable.Text = string.Format("{0}: {1}", m_FirstPlayer.PlayerName, m_FirstPlayer.PlayerScore);
            }
            else if (Turn == eGameTurn.SecondPlayer)
            {
                m_GameBoardForm.CurrentPlayerLable.Text = "Current Player: " + m_SecondPlayer.PlayerName;
                m_GameBoardForm.CurrentPlayerLable.BackColor = Color.LightSteelBlue;
                m_GameBoardForm.SecondPlayerLable.Text = string.Format("{0}: {1}", m_SecondPlayer.PlayerName, m_SecondPlayer.PlayerScore);
            }
            else
            {
                m_GameBoardForm.CurrentPlayerLable.Text = "Current Player: Computer";
                m_GameBoardForm.CurrentPlayerLable.BackColor = Color.LightSteelBlue;
                m_GameBoardForm.CurrentPlayerLable.Update();
            }
        }

        internal void UpdateBotScoreOnBoard()
        {
            m_GameBoardForm.SecondPlayerLable.Text = string.Format("Computer: {0}", m_SecondPlayer.PlayerScore);
            m_GameBoardForm.SecondPlayerLable.Update();
        }

        public PictureBox[,] MatrixPictureBox
        {
            get
            {
                return m_PictureBoxs;
            }
        }

        public void Show()
        {
            m_GameBoardForm.ShowDialog();
        }

        public int Width
        {
            get
            {
                return r_BoardWidth;
            }
        }

        public int Height
        {
            get
            {
                return r_BoardHeight;
            }
        }

        public CardSquare[,] CurrentBoard
        {
            get
            {
                return m_CardSquare;
            }
        }

        public eGameTurn Turn
        {
            get
            {
                return m_GameTurn;
            }

            set
            {
                m_GameTurn = value;
            }
        }

        public bool GameIsFinish
        {
            get
            {
                return m_GameIsFinishGame;
            }

            set
            {
                m_GameIsFinishGame = value;
            }
        }

        public Form BoardForm
        {
            get
            {
                return m_GameBoardForm;
            }
        }

        public int Score
        {
            get
            {
                int score = m_FirstPlayer.PlayerScore;

                if (m_GameTurn == eGameTurn.FirstPlayer)
                {
                    score = m_FirstPlayer.PlayerScore;
                }
                else
                {
                    if (m_GameTurn == eGameTurn.SecondPlayer || m_GameTurn == eGameTurn.Computer)
                    {
                        score = m_SecondPlayer.PlayerScore;
                    }
                }

                return score;
            }

            set
            {
                if (m_GameTurn == eGameTurn.FirstPlayer)
                {
                    m_FirstPlayer.PlayerScore = value;
                }
                else
                {
                    if (m_GameTurn == eGameTurn.SecondPlayer || m_GameTurn == eGameTurn.Computer)
                    {
                        m_SecondPlayer.PlayerScore = value;
                    }
                }
            }
        }
    }
}