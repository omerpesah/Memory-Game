using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryGameForm
{
    public class Player
    {
        private string m_PlayerName;
        private int m_PlayerScore;

        public Player(string i_PlayerName)
        {
            this.m_PlayerName = i_PlayerName;
            m_PlayerScore = 0;
        }

        public string PlayerName
        {
            get
            {
                return m_PlayerName;
            }

            set
            {
                m_PlayerName = value;
            }
        }

        public int PlayerScore
        {
            get
            {
                return m_PlayerScore;
            }

            set
            {
                m_PlayerScore = value;
            }
        }
    }
}
