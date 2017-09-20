using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Cell
    {
        char display = ' ';
        int priority = -1;

        public char Display
        {
            get { return display; }
            set { display = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }
    }
}
