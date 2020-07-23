using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public static class GameManager
    {
        private static int s_HeightOfBoard = 4;
        private static int s_WidthOfBoard = 4;
        private static int m_FirstRow = 0;
        private static int m_FirstCol = 0;
        private static bool s_IsBot = true;
        public static bool m_SecondFlip = false;
        private static string s_FirstPlayerName;
        private static string s_SecondPlayerName;
        private static GameBoard s_GameBoard;
        public static PictureBox m_FirstChoisePictureBox = null;
        public static PictureBox m_SecondChoisePictureBox = null;

        public static int Height
        {
            get
            {
                return s_HeightOfBoard;
            }

            set
            {
                s_HeightOfBoard = value;
            }
        }

        public static int Width
        {
            get
            {
                return s_WidthOfBoard;
            }

            set
            {
                s_WidthOfBoard = value;
            }
        }

        public static string FirstPlayerName
        {
            set
            {
                s_FirstPlayerName = value;
            }
        }

        public static string SecondPlayerName
        {
            set
            {
                s_SecondPlayerName = value;
            }
        }

        public static bool Bot
        {
            get
            {
                return s_IsBot;
            }

            set
            {
                s_IsBot = value;
            }
        }

        public static void StartNewGame()
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();
            if (Bot)
            {
                s_GameBoard = new GameBoard(Height, Width, s_FirstPlayerName);
            }
            else
            {
                s_GameBoard = new GameBoard(Height, Width, s_FirstPlayerName, s_SecondPlayerName);
            }
            

            gameInPrograss();
        }

        private static void gameInPrograss()
        {
            s_GameBoard.Show();
            if (!s_GameBoard.GameIsFinish)
            {
                turnIsOk();
            }
        }

        private static void turnIsOk()
        {
            bool gameOver = GameLogic.IsGameOver(s_GameBoard);
            if (gameOver)
            {
                s_GameBoard.GameIsFinish = true;
                GetResultFromUser();
            }
        }

        public static void GetResultFromUser()
        {
            DialogResult dialog = MessageBox.Show(string.Format("{0}{1}{2}", s_GameBoard.PrintDetails(), Environment.NewLine, "Would You want start a new game?"), string.Empty, MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                s_GameBoard.InitzalizeMatrix();
                ResetBoard();
            }
            else
            {
                s_GameBoard.BoardForm.Close();
            }
        }

        public static void SetIndex(PictureBox i_PictureBox)
        {
            for (int i = 0; i < s_GameBoard.Height; i++)
            {
                for (int j = 0; j < s_GameBoard.Width; j++)
                {
                    if (s_GameBoard.MatrixPictureBox[i, j] == i_PictureBox)
                    {
                        if(GameLogic.CheckIfMoveIsLegal(i, j, s_GameBoard))
                        {
                            if (!m_SecondFlip)
                            {
                                GameLogic.FlipCard(i, j, s_GameBoard);
                                changePictureBoxAfterFlip(i_PictureBox, i, j);
                                m_FirstRow = i;
                                m_FirstCol = j;
                                m_FirstChoisePictureBox = i_PictureBox;
                                m_SecondFlip = true;
                            }
                            else
                            {
                                GameLogic.FlipCard(i, j, s_GameBoard);
                                changePictureBoxAfterFlip(i_PictureBox, i, j);
                                m_SecondChoisePictureBox = i_PictureBox;
                                if (s_GameBoard.CheckIfMatch(m_FirstRow, m_FirstCol, i, j))
                                {
                                    s_GameBoard.Score++;
                                }
                                else
                                {
                                    HidePictureBoxs(m_FirstChoisePictureBox, i_PictureBox);
                                    s_GameBoard.SwitchTurn();
                                    if (s_GameBoard.Turn == eGameTurn.Computer)
                                    {
                                        while (s_GameBoard.Turn == eGameTurn.Computer && !s_GameBoard.GameIsFinish)
                                        {
                                            turnIsOk();
                                            changeBotMoveOnForm(GameLogic.ComputerTurnMove(s_GameBoard));
                                        }
                                    }
                                }

                                m_SecondFlip = false;
                                s_GameBoard.UpdateLableOnBoard();
                                turnIsOk();
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void changeBotMoveOnForm(List<CardSquare> i_CardToChange)
        {
            s_GameBoard.UpdateLableOnBoard();
            PictureBox botFirstPictureBox = s_GameBoard.MatrixPictureBox[i_CardToChange[0].Row, i_CardToChange[0].Col];
            PictureBox botSecondPictureBox = s_GameBoard.MatrixPictureBox[i_CardToChange[1].Row, i_CardToChange[1].Col];
            changePictureBoxAfterFlip(botFirstPictureBox, i_CardToChange[0].Row, i_CardToChange[0].Col);
            changePictureBoxAfterFlip(botSecondPictureBox, i_CardToChange[1].Row, i_CardToChange[1].Col);
            if (s_GameBoard.CheckIfMatch(i_CardToChange[0].Row, i_CardToChange[0].Col, i_CardToChange[1].Row, i_CardToChange[1].Col))
            {
                s_GameBoard.Score++;
                s_GameBoard.UpdateBotScoreOnBoard();
                System.Threading.Thread.Sleep(1000);
            }
            else
            {
                s_GameBoard.SwitchTurn();
                HidePictureBoxs(botFirstPictureBox, botSecondPictureBox);
            }
        }

        internal static void ResetBoard()
        {
            for (int i = 0; i < s_HeightOfBoard; i++)
            {
                for (int j = 0; j < s_WidthOfBoard; j++)
                {
                    if (s_GameBoard.CurrentBoard[i, j].IsMatched)
                    {
                        s_GameBoard.CurrentBoard[i, j].IsMatched = false;
                        s_GameBoard.CurrentBoard[i, j].Flip = false;
                    }
                }
            }

            s_GameBoard.createIcons();
            s_GameBoard.AssignIconsToSquareCards();
        }

        internal static void HidePictureBoxs(PictureBox i_FirstPictureBox, PictureBox i_SecondPictureBox)
        {
            System.Threading.Thread.Sleep(1000);
            i_FirstPictureBox.Image = null;
            i_SecondPictureBox.Image = null;
            i_FirstPictureBox.BackColor = Color.Empty;
            i_SecondPictureBox.BackColor = Color.Empty;
            i_FirstPictureBox.Update();
            i_SecondPictureBox.Update();
        }

        private static void changePictureBoxAfterFlip(PictureBox i_PictureBox, int i_PictureBoxRow, int i_PictureBoxCol)
        {
            i_PictureBox.Image = s_GameBoard.CurrentBoard[i_PictureBoxRow, i_PictureBoxCol].CardImage;
            i_PictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
            if (s_GameBoard.Turn == eGameTurn.FirstPlayer)
            {
                i_PictureBox.BackColor = Color.PaleGreen;
            }
            else
            {
                i_PictureBox.BackColor = Color.LightSteelBlue;
            }

            i_PictureBox.Update();
        }
    }
}
