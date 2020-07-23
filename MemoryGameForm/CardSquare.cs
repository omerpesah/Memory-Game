using System.Drawing;

namespace MemoryGameForm
{
    public class CardSquare
    {
        private char m_Value;
        private bool m_IsMatched = false;
        internal bool m_Flip = false;
        internal int m_Row, m_Col;
        private Image m_Image = null;

        public CardSquare(int i_Row, int i_Col)
        {
            this.m_Row = i_Row;
            this.m_Col = i_Col;
        }

        public Image CardImage
        {
            get
            {
                return m_Image;
            }

            set
            {
                m_Image = value;
            }
        }

        public int Row
        {
            get
            {
                return m_Row;
            }

            set
            {
                m_Row = value;
            }
        }

        public int Col
        {
            get
            {
                return m_Col;
            }

            set
            {
                m_Col = value;
            }
        }

        public bool IsMatched
        {
            get
            {
                return m_IsMatched;
            }

            set
            {
                m_IsMatched = value;
            }
        }

        public bool Flip
        {
            get
            {
                return m_Flip;
            }

            set
            {
                m_Flip = value;
            }
        }
    }
}