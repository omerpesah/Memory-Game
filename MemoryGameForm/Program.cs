using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MemoryGameForm
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            GameManager.StartNewGame();
        }
    }
}
