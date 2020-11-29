using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockPaperScissors
{
    public partial class Form1 : Form
    {
        //Deklaracja zmiennych
        //Rozgrywka toczy sie do 3 wygranych
        public int rounds = 3;
        //Czas na wybor zagrania to 5 sekund
        public int timePerRound = 6;
        //Mozliwe zagrywki komputera
        public string[] computerChoice = { "rock", "paper", "scissor" };
        //Zmienne do wyboru zagrywki komputera
        public int randomnumber;
        public string computerCommand;
        Random rnd = new Random();
        //Wybór gracza
        public string playerChoice;
        //Zmienne do sumowania wygranych gracza i komputera
        public int playerWins = 0;
        public int computerWins = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
