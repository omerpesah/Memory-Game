using System;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public partial class WelcomeForm : Form
    {
        private const int k_MaxSizeOfBoard = 6;
        private const int k_MinSizeOfBoard = 4;
        private bool m_closeByX = true;

        public bool CloseByX 
        {
            get
            {
                return m_closeByX;
            }
        }

        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void secondPlayerButton_Click(object sender, EventArgs e)
        {
            if (secondPlayerTextBox.Enabled)
            {
                secondPlayerButton.Text = "Against a Friend";
                secondPlayerTextBox.Text = "-Computer-";
                secondPlayerTextBox.Enabled = false;
                GameManager.Bot = true;
            }
            else
            {
                secondPlayerButton.Text = "Against Computer";
                secondPlayerTextBox.Enabled = true;
                GameManager.Bot = false;
            }
        }

        private void boardSizeButton_Click(object sender, EventArgs e)
        {
            if((GameManager.Height * (GameManager.Width + 1) % 2 == 0) && GameManager.Width < k_MaxSizeOfBoard)
            {
                GameManager.Width++;
            }
            else if(GameManager.Width == k_MaxSizeOfBoard)
            {
                GameManager.Height++;
                GameManager.Width = k_MinSizeOfBoard;
            }
            else
            {
                GameManager.Width += 2;
            }

            if (GameManager.Height > k_MaxSizeOfBoard)
            {
                GameManager.Height = k_MinSizeOfBoard;
                GameManager.Width = k_MinSizeOfBoard;
            }

            boardSizeButton.Text = string.Format("{0} x {1}", GameManager.Height, GameManager.Width);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            m_closeByX = false;
            GameManager.FirstPlayerName = firstPlayerTextBox.Text;
            if (!GameManager.Bot)
            {
                GameManager.SecondPlayerName = secondPlayerTextBox.Text;
            }

            this.Close();
        }

        private void WelcomeForm_Load(object sender, EventArgs e)
        {
        }
    }
}
