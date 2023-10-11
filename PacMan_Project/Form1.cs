using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacMan_Project
{
    public partial class Form1 : Form
    {
        SoundPlayer player = new SoundPlayer("pacman_beginning.wav");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            player.PlayLooping();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name = richTextBox1.Text;
            using (StreamWriter sw = File.AppendText("players.txt"))
                sw.Write("Player: " + name + "\n");
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void musicOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Stop();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox2.LoadFile("players.txt", RichTextBoxStreamType.PlainText);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String name = richTextBox1.Text;
            using (StreamWriter sw = File.AppendText("players.txt"))
                sw.Write("Player: " + name + "\n");
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void musicOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            player.Play();
        }
    }
}
