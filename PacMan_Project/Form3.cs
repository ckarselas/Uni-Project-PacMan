using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan_Project
{
    public partial class Form3 : Form
    {
        Random r;
        double distance = 30;
        int score = 0;
        int countdown = 9;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            r = new Random();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            label2.Text = countdown.ToString();
            countdown = countdown - 1;
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            this.Close();
            using (StreamWriter sw = File.AppendText("Scores.txt"))
                sw.Write("Score: " + score + "\n");
            this.Close();
            Application.OpenForms[0].Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             pictureBox3.Location = new Point(r.Next(Width - pictureBox3.Width),
                r.Next(Height - pictureBox3.Height));
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString().Equals("Right"))
            {
                pictureBox1.ImageLocation = "pacman_right.png";
                pictureBox1.Location = new Point(pictureBox1.Location.X + 20, pictureBox1.Location.Y);
            }
            else if (e.KeyCode.ToString().Equals("Up"))
            {
                pictureBox1.ImageLocation = "pacman_up.png";
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 20);

            }
            else if (e.KeyCode.ToString().Equals("Down"))
            {

                pictureBox1.ImageLocation = "pacman_down.png";
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 20);
            }
            else if (e.KeyCode.ToString().Equals("Left"))
            {
                pictureBox1.ImageLocation = "pacman_left.png";
                pictureBox1.Location = new Point(pictureBox1.Location.X - 20, pictureBox1.Location.Y);
            }
            double pacmanX, pacmanY, foodX, foodY;
            pacmanX = pictureBox1.Location.X + (pictureBox1.Width / 2);
            pacmanY = pictureBox1.Location.Y + (pictureBox1.Height / 2);
            foodX = pictureBox3.Location.X + (pictureBox3.Width / 2);
            foodY = pictureBox3.Location.Y + (pictureBox3.Height / 2);
            double r = Math.Sqrt(Math.Pow((pacmanX - foodX), 2) + Math.Pow((pacmanY - foodY), 2));
            if (r < distance)
            {

                score += 150;
                label1.Text = score.ToString();
                timer1_Tick(this, null);
            }
        }
    }
}
