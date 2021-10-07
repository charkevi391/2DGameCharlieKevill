//Charlie Kevill
//ICS4U
//Mr.T
//Oct 7t, 2021
//2D Game Submission

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2DGameCharlieKevill
{
    public partial class MainScreen : UserControl
    {
        public MainScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //changing to gaem screen on startup
            Form f = this.FindForm();
            f.Controls.Remove(this);
            GameScreen gs = new GameScreen();
            f.Controls.Add(gs);
            gs.Focus();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //stops gaem from runnning
            Application.Exit();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            //Checking to see if the game has ended
            if (GameScreen.gameOver == true)
            {
                //displaying the score
                scoreLabel.Visible = true;
                scoreLabel.Text = "Your score is " + GameScreen.scoreCounter;
            }
        }
    }
}
