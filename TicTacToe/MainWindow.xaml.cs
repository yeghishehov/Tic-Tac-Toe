using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        int r, c;
        Cell[,] matrix = new Cell[3,3];

        public MainWindow()
        {
            InitializeComponent();
            for (r = 0; r < 3; r++)
                for (c = 0; c < 3; c++)
                    matrix[r, c] = new Cell(); 
        }

 // GameLogic
        void GameLogic()
        {
            Win();
            Draw();
            OMove();
            Win();
            Draw();
        }
// Restart game
        void AppRestart()
        {
            btn00.Content = btn01.Content = btn02.Content = btn10.Content = btn11.Content = btn12.Content = btn20.Content = btn21.Content = btn22.Content = "";
            for (r = 0; r < 3; r++)
                for (c = 0; c < 3; c++)
                    matrix[r,c].Display = ' ';            
        }

// Check the winner
        void Win()
        {
            if (btn00.Content != "" && btn00.Content == btn01.Content && btn01.Content == btn02.Content)
            {
                if (btn00.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if(btn10.Content != "" && btn10.Content == btn11.Content && btn11.Content == btn12.Content)
            { 
                if (btn10.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if (btn20.Content != "" && btn20.Content == btn21.Content && btn21.Content == btn22.Content)
            { 
                if (btn20.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if (btn00.Content != "" && btn00.Content == btn10.Content && btn10.Content == btn20.Content)
            { 
                if (btn00.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if (btn01.Content != "" && btn01.Content == btn11.Content && btn11.Content == btn21.Content)
            { 
                if (btn01.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if (btn02.Content != "" && btn02.Content == btn12.Content && btn12.Content ==btn22.Content)
            { 
                if (btn02.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if (btn00.Content != "" && btn00.Content == btn11.Content && btn11.Content == btn22.Content)
            { 
                if (btn00.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                AppRestart();
            }
            if (btn02.Content != "" && btn02.Content == btn11.Content && btn11.Content == btn20.Content)
            { 
                if (btn02.Content == "X") MessageBox.Show("WIN");
                else MessageBox.Show("LOSS");
                    AppRestart();
            }
        }

// Check a draw
        void Draw()
        {
            if (btn00.Content != "" && btn01.Content != "" && btn02.Content != "" && btn10.Content != "" && btn11.Content != "" && btn12.Content != "" && btn20.Content != "" && btn21.Content != "" && btn22.Content != "")
            {
                MessageBox.Show("DROW");
                AppRestart();
            }
        }

// Player move
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string btnName = button.Name;

            if (button.Content == "")
            {
                button.Content = "X";
                switch (btnName)
                {
                    case "btn00":
                        matrix[0,0].Display= 'X';
                        break;
                    case "btn01":
                        matrix[0,1].Display = 'X';
                        break;
                    case "btn02":
                        matrix[0,2].Display = 'X';
                        break;
                    case "btn10":
                        matrix[1,0].Display = 'X';
                        break;
                    case "btn11":
                        matrix[1,1].Display = 'X';
                        break;
                    case "btn12":
                        matrix[1,2].Display = 'X';
                        break;
                    case "btn20":
                        matrix[2,0].Display = 'X';
                        break;
                    case "btn21":
                        matrix[2,1].Display = 'X';
                        break;
                    case "btn22":
                        matrix[2,2].Display = 'X';
                        break;
                }
                GameLogic();
            }

        }

// Opponent's move
        public void OMove()
        {

            for (r = 0; r < 3; r++)
                for (c = 0; c < 3; c++)
                    if (matrix[r,c].Display == ' ')
                        matrix[r,c].Priority = 0;
                    else
                        matrix[r,c].Priority = -1;

            for (r = 0; r < 3; r++)
                for (c = 0; c < 3; c++)
                    if (matrix[r, c].Display == ' ')
                        matrix[r, c].Priority = 1;

                  
            
            for (int r = 0; r < 3; r++)
            {
                if (matrix[r,0].Display != ' ' && matrix[r,0].Display == matrix[r,1].Display && matrix[r,2].Display == ' ')
                    if ( matrix[r, 0].Display == 'X')
                        matrix[r, 2].Priority = 3;
                    else matrix[r, 2].Priority = 4;
                
                if (matrix[r,0].Display != ' ' && matrix[r,0].Display == matrix[r,2].Display && matrix[r,1].Display == ' ')
                    if ( matrix[r, 0].Display == 'X')
                        matrix[r, 1].Priority = 3;
                    else matrix[r, 1].Priority = 4;

                if (matrix[r,1].Display != ' ' && matrix[r,1].Display == matrix[r,2].Display && matrix[r,0].Display == ' ')
                    if (matrix[r, 1].Display == 'X')
                        matrix[r, 0].Priority = 3;
                    else matrix[r, 0].Priority = 4;
            }

            for (int c = 0; c < 3; c++)
            {
                if (matrix[0,c].Display != ' ' && matrix[0,c].Display == matrix[1,c].Display && matrix[2,c].Display == ' ')
                    if (matrix[0, c].Display == 'X')
                        matrix[2, c].Priority = 3;
                    else matrix[2, c].Priority = 4;

                if (matrix[0,c].Display != ' ' && matrix[0,c].Display == matrix[2,c].Display && matrix[1,c].Display == ' ')
                    if (matrix[0, c].Display == 'X')
                        matrix[1, c].Priority = 3;
                    else matrix[1, c].Priority = 4;

                if (matrix[1,c].Display != ' ' && matrix[1,c].Display == matrix[2,c].Display && matrix[0,c].Display == ' ')
                    if (matrix[1, c].Display == 'X')
                        matrix[0, c].Priority = 3;
                    else matrix[0, c].Priority = 4;
            }

            if (matrix[0,0].Display != ' ' && matrix[0,0].Display == matrix[1,1].Display && matrix[2,2].Display == ' ')
                if (matrix[0, 0].Display == 'X')
                    matrix[2, 2].Priority = 3;
                else matrix[2, 2].Priority = 4;

            if (matrix[0,0].Display != ' ' && matrix[0,0].Display == matrix[2,2].Display && matrix[1,1].Display == ' ')
                if (matrix[0, 0].Display == 'X')
                    matrix[1, 1].Priority = 3;
                else matrix[1, 1].Priority = 4;

            if (matrix[1,1].Display != ' ' && matrix[1,1].Display == matrix[2,2].Display && matrix[0,0].Display == ' ')
                    if (matrix[1, 1].Display == 'X')
                    matrix[0, 0].Priority = 3;
                    else matrix[0, 0].Priority = 4;

            if (matrix[0,2].Display != ' ' && matrix[0,2].Display == matrix[1,1].Display && matrix[2,0].Display == ' ')
                    if (matrix[0, 2].Display == 'X')
                    matrix[2, 0].Priority = 3;
                    else matrix[2, 0].Priority = 4;

            if (matrix[0,2].Display != ' ' && matrix[0,2].Display == matrix[2,0].Display && matrix[1,1].Display == ' ')
                    if (matrix[0, 2].Display == 'X')
                    matrix[1, 1].Priority = 3;
                    else matrix[1, 1].Priority = 4;

            if (matrix[1,1].Display != ' ' && matrix[1,1].Display == matrix[2,0].Display && matrix[0,2].Display == ' ')
                    if (matrix[1, 1].Display == 'X') matrix[0, 2].Priority = 3;
                    else matrix[0, 2].Priority = 4;
            

            List<int> maxC = new List<int>();
            List<int> maxR = new List<int>();
            int maxPriority = -1;

            for (r = 0; r < 3; r++)
                for (c = 0; c < 3; c++)
                    if (matrix[r, c].Priority > maxPriority)
                        maxPriority = matrix[r, c].Priority;

            for (r = 0; r < 3; r++)
                for (c = 0; c < 3; c++)
                    if (matrix[r,c].Priority == maxPriority)
                    {
                        maxC.Add(c);
                        maxR.Add(r);
                    }

            Random rnd = new Random();
            int index = rnd.Next(maxC.Count());

            matrix[maxR[index],maxC[index]].Display = 'O';
            string btnNumb="";
            btnNumb = ""+ maxR[index] + maxC[index];

            switch (btnNumb)
            {
                case "00":
                    btn00.Content = "O";
                    break;
                case "01":
                    btn01.Content = "O";
                    break;
                case "02":
                    btn02.Content = "O";
                    break;
                case "10":
                    btn10.Content = "O";
                    break;
                case "11":
                    btn11.Content = "O";
                    break;
                case "12":
                    btn12.Content = "O";
                    break;
                case "20":
                    btn20.Content = "O";
                    break;
                case "21":
                    btn21.Content = "O";
                    break;
                case "22":
                    btn22.Content = "O";
                    break;
            }

        }
    }
}
