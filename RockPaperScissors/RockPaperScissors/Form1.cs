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
        public int randomNumber;
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
            //Wlaczenie zegara
            timer1.Enabled = true;
            //Poczatkowy wybor gracza - brak wyboru
            playerChoice = "none";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Ustawienie papieru
            playerChoice = "paper";
            pictureBox1.Image = Properties.Resources.paper;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ustawienie kamienia
            playerChoice = "rock";
            pictureBox1.Image = Properties.Resources.rock;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Ustawienie nozyczek
            playerChoice = "scissor";
            pictureBox1.Image = Properties.Resources.scissiors;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Aktualizacja rundy
            label6.Text = Convert.ToString(rounds);
            //Wyswietlenie wyniku biezacego
            label9.Text = Convert.ToString(playerWins);
            label10.Text = Convert.ToString(computerWins);
            //Zmniejszenie czasu o 1
            timePerRound--;
            //Aktualizacja wyswietlonego czasu w okreslonej labelce
            label4.Text = Convert.ToString(timePerRound);
            //Akcje do zrobienia gdy skonczy się czas: wylaczenie timera, wybor zagrania komputera, obsluga konca gry lub nastepnej runy
            if (timePerRound < 1)
            {
                //Wylaczenie timera
                timer1.Enabled = false;
                //Restart czasu do wartosci poczatkowej
                timePerRound = 6;
                //Losowy wybor liczby pod zagrywke komputera
                //Losowy wybor liczby pod zagrywke komputera
                randomNumber = rnd.Next(0, 3);
                //Zagrywka komputera - wybor na podstawie liczby losowej
                computerCommand = computerChoice[randomNumber];
                
                //Ustawienie prawidlowego obrazka dla zagrywki komputera
                switch (computerCommand)
                {
                    case "rock":
                        pictureBox2.Image = Properties.Resources.rock;
                        break;
                    case "paper":
                        pictureBox2.Image = Properties.Resources.paper;
                        break;
                    case "scissor":
                        pictureBox2.Image = Properties.Resources.scissiors;
                        break;
                    default:
                        break;
                }

                //Sprawdzenie ile run zostalo do gry - rezultat: zakonczenie gry lub dalsza rozgrywka
                if (rounds > 1)
                {
                    checkGame();
                }
                else
                {
                    decisionEngine();
                }    
            }

        }

        //Sprawdzenie wyniku gry
        private void checkGame()
        {
            if ((playerChoice == "rock" && computerCommand == "scissor") | (playerChoice == "paper" && computerCommand == "rock") | (playerChoice == "scissor" && computerCommand == "paper"))
            {
                MessageBox.Show("Wygral Gracz");
                playerWins++;
                rounds--;
                nextRound();
            }
            else if ((playerChoice == "rock" && computerCommand == "paper") | (playerChoice == "paper" && computerCommand == "scissor") | (playerChoice == "scissor" && computerCommand == "rock"))
            {
                MessageBox.Show("Wygral komputer");
                computerWins++;
                rounds--;
                nextRound();
            }
            else if (playerChoice == "none")
            {
                MessageBox.Show("Dokonaj wyboru");
                nextRound();
            }
            else
            {
                MessageBox.Show("Remis");
                nextRound();
            }

        }

        //Sprawdzenie ilosci wygranych i wyswietlenie finalnego zwyciezcy
        private void decisionEngine()
        {
            if (playerWins > computerWins)
            {
                MessageBox.Show("Zwyciezca gry: Gracz\n z wynikiem: " + Convert.ToString(playerWins));
            }
            else
            {
                MessageBox.Show("Zwyciezca gry: Komputer\n z wynikiem: " + Convert.ToString(computerWins));
            }    
        }

        private void nextRound()
        {
            //Reset parametrow i ustawienie znakow zapytania w obrazkach
            playerChoice = "none";
            pictureBox1.Image = Properties.Resources.question;
            timer1.Enabled = true;
            pictureBox2.Image = Properties.Resources.question;

        }
    }
}
