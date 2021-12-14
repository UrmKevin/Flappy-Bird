using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8;
        int gravity = 15;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            downPipe.Left -= pipeSpeed;
            upPipe.Left -= pipeSpeed;
            scoreText.Text = "Score: " + score;

            if (downPipe.Left < -150)
            {
                downPipe.Left = 800;
                score++;
            }
            if(upPipe.Left < -180)
            {
                upPipe.Left = 950;
                score++;
            }  

            if (flappyBird.Bounds.IntersectsWith(downPipe.Bounds) ||
                flappyBird.Bounds.IntersectsWith(upPipe.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();
            }


            if(score > 5)
            {
                pipeSpeed = 15;
            }

        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Game Over!!! ";
        }
    }
}
