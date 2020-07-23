using System;
using System.Drawing;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public partial class GameBoardForm : Form
    {
        internal Label m_CurrentPlayerLable;
        internal Label m_FirstPlayerLable;
        internal Label m_SecondPlayerLable;

        public GameBoardForm(int i_Height, int i_Width, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            InitializeComponent();
            initizalizeForm(i_Height, i_Width, i_FirstPlayerName, i_SecondPlayerName);
        }

        private void initizalizeForm(int i_Height, int i_Width, string i_FirstPlayerName, string i_SecondPlayerName)
        {
            m_CurrentPlayerLable = new Label();
            m_FirstPlayerLable = new Label();
            m_SecondPlayerLable = new Label();

            int topOfPictureBox = 4, leftOfPictureBox = 4;

            for (int i = 0; i < i_Height; i++)
            {
                for (int j = 0; j < i_Width; j++)
                {
                    PictureBox button = new PictureBox();
                    button.Width = 100;
                    button.Height = 100;
                    button.Left = leftOfPictureBox;
                    button.Top = topOfPictureBox;
                    button.Click += PictureBox_Click;
                    Controls.Add(button);
                    leftOfPictureBox += button.Width;
                    button.BorderStyle = BorderStyle.FixedSingle;
                }

                leftOfPictureBox = 4;
                topOfPictureBox += 100;
            }

            this.Width = (i_Width * 100) + 25;
            this.Height = topOfPictureBox + 130;
            m_CurrentPlayerLable.Text = "Current Player: ";
            m_CurrentPlayerLable.BackColor = Color.PaleGreen;
            m_FirstPlayerLable.Text = i_FirstPlayerName + " : ";
            m_FirstPlayerLable.BackColor = Color.PaleGreen;
            m_SecondPlayerLable.BackColor = Color.LightSteelBlue;
            m_SecondPlayerLable.Text = i_SecondPlayerName + " : ";
            m_CurrentPlayerLable.Top = topOfPictureBox + 10;
            m_FirstPlayerLable.Top = m_CurrentPlayerLable.Bottom + 5;
            m_SecondPlayerLable.Top = m_FirstPlayerLable.Bottom + 5;
            m_CurrentPlayerLable.AutoSize = true;
            m_FirstPlayerLable.AutoSize = true;
            m_SecondPlayerLable.AutoSize = true;
            Controls.Add(m_CurrentPlayerLable);
            Controls.Add(m_FirstPlayerLable);
            Controls.Add(m_SecondPlayerLable);
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public void PictureBox_Click(object sender, EventArgs e)
        {
            GameManager.SetIndex((PictureBox)sender);
        }

        private void GameBoardForm_Load(object sender, System.EventArgs e)
        {
        }

        public Label CurrentPlayerLable
        {
            get
            {
                return m_CurrentPlayerLable;
            }
        }

        public Label FirstPlayerLable
        {
            get
            {
                return m_FirstPlayerLable;
            }
        }

        public Label SecondPlayerLable
        {
            get
            {
                return m_SecondPlayerLable;
            }
        }
    }
}
