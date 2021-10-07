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
using System.Threading;

namespace _2DGameCharlieKevill
{
    public partial class GameScreen : UserControl
    { 
        Boolean rightArrowDown;
        Boolean leftArrowDown;

        public static Boolean gameOver;

        ufoClass newUfo;

        playerClass newPlayer;

        beamClass newBeam;

        Random randGen = new Random();

        List<ufoClass> ufoList = new List<ufoClass>();

        List<beamClass> beamList = new List<beamClass>();

        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SolidBrush beamBrush = new SolidBrush(Color.LightGoldenrodYellow);

        int counter = 60;
        int drawCounter = 0;

        public static int scoreCounter = 0;

        string stage = "down";
        public GameScreen()
        {
            InitializeComponent();
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {
            int wval = randGen.Next(50, 200);
            int xval = randGen.Next(10, 479);
            int spval = randGen.Next(1, 10);
            //Ufo
            newUfo = new ufoClass(wval, xval, -20, spval);
            //Player
            newPlayer = new playerClass(this.Width / 2, this.Height - 60, 50, 20, 7);
            //Beam
            newBeam = new beamClass(xval + 10, 10, wval - 10);
        }
        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            //draw Ufos to screen
            foreach (ufoClass uc in ufoList)
            {
                e.Graphics.FillRectangle(blackBrush, uc.x, uc.y, uc.width, uc.width / 4);
            }
            //draw beams to screen
            foreach (beamClass bc in beamList)
            {
                if (drawCounter >= 20)
                {
                    e.Graphics.FillRectangle(beamBrush, bc.x + 10, bc.y, bc.width, 500);
                }
            }
            //draw player to screen
            e.Graphics.FillRectangle(blackBrush, newPlayer.x, newPlayer.y, newPlayer.width, newPlayer.height);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            //starts the game when the button is pressed
            startButton.Enabled = true;
            startButton.Visible = false;
            moveLabel.Visible = false;
            Thread.Sleep(1000);
            gameEngine.Enabled = true;
        }
        public void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //checking if keys are pressed
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
            }
        }

        public void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            //checking if key is released
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
            }
        }
        private void gameEngine_Tick(object sender, EventArgs e)
        {
            scoreCounter++;
            if (counter == 60 && stage == "down")
            {
                int wval = randGen.Next(50, 200);
                int xval = randGen.Next(10, 479);
                int spval = randGen.Next(1, 10);
                ufoClass Ufo = new ufoClass(wval, xval, -20, spval);
                ufoList.Add(Ufo);
                beamClass Beam = new beamClass(xval, 30, wval - 20);
                beamList.Add(Beam);
                counter = 0;
            }
            //removes beams and ufos from the screen and the list
            if (ufoList.Count > 1)
            {
                ufoList.RemoveAt(0);
                beamList.RemoveAt(0);
            }
            //makes player move left
            if (leftArrowDown == true)
            {
                newPlayer.x -= newPlayer.speed;
            }
            //makes player move right
            if (rightArrowDown == true)
            {
                newPlayer.x += newPlayer.speed;
            }
            //checking if the beam is ready to be drawn
            if (stage == "beam")
            {
                drawCounter++;
            }
            //stopping the player from going off the screen
            if (newPlayer.x >= this.Width - newPlayer.width)
            {
                newPlayer.x -= 20;
            }

            if (newPlayer.x <= 0)
            {
                newPlayer.x += 20;
            }
            
            foreach (ufoClass newUfo in ufoList)
            {
                if (newUfo.y <= 10 && stage == "down")
                {
                    //Brings the Ufos down from the top of the screen 
                    newUfo.Move("down");
                }

                if (newUfo.y >= 10)
                {
                    //draw beam
                    stage = "beam";
                }

                if (drawCounter > 100)
                {
                    //makes the ufo go back off the screen
                    stage = "up";
                }

                if (stage == "up")
                {
                    //ufo goes up and dissapears
                    drawCounter = 0;
                    newUfo.Move("up");
                    if (newUfo.y <= -50)
                    {
                        counter = 60;
                        stage = "down";
                    }

                }

                foreach (beamClass newBeam in beamList)
                {
                    //ending the game if there is a collision
                    if (newBeam.Collision(newPlayer) == true && drawCounter >=20 && drawCounter < 100)
                    {
                        gameOver = true;
                        Form f = this.FindForm();
                        f.Controls.Remove(this);
                        MainScreen ms = new MainScreen();
                        f.Controls.Add(ms);
                        gameEngine.Enabled = false;
                    }
                }
            }
            Refresh();
        }
    }
}
