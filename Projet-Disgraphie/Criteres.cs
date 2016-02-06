using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WintabDN;

namespace Projet_Disgraphie
{
    class Criteres
    {
        private int pos = 0;
        private int[,] listeData = new int[100000,2];
        private double[] vitesse = new double[100000];
        private double vitesseMoyenne = 0;
        private double vitesseActuelle = 0;
        private List<double> temps = new List<double>();
        private System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
        private Boolean timerOn = false;
        //private int bloc;

      

        public void Ajouter(int x, int y)
        {
            if (timerOn == false)
            {
                timer.Start();
                timerOn = true;
            }
            this.listeData[this.pos,0] =  x;
            this.listeData[this.pos,1] =  y ;
            this.RafraichirDonnées();
            this.pos++;

        }

        private void RafraichirDonnées()
        {
            
            this.Date();
            this.CalculVitesse();


        }
        private void Date()
        {
            this.temps.Add(timer.Elapsed.Milliseconds);
        }



        private void CalculVitesse()
        {
            if (this.temps.Count() > 5)
            {
                if (this.temps.Count() % 5 == 0)
                {
                    int longueur_x = Math.Abs(listeData[this.pos, 0] - listeData[this.pos - 5, 0]);
                    int longueur_y = Math.Abs(listeData[this.pos, 1] - listeData[this.pos - 5, 1]);
                    Console.WriteLine(" x = " + longueur_x + " |  y = " + longueur_y);
                    double longueur_x_pow = Math.Pow(longueur_x, 2);
                    double longueur_y_pow = Math.Pow(longueur_y, 2);
                    Console.WriteLine("pow( x ) = " + longueur_x_pow + " |  pow ( y ) = " + longueur_y_pow);
                    double temps_passé = Math.Abs(this.temps[this.pos] - this.temps[this.pos - 5]);

                    Console.WriteLine("temps passe  " + temps_passé);
                    this.vitesseActuelle = Math.Sqrt(longueur_x_pow + longueur_y_pow) / temps_passé;

                    this.vitesse[this.pos] = this.vitesseActuelle;
                }
                else
                {
                    this.vitesse[this.pos] = this.vitesseActuelle; 
                }
            }
            double v = 0;
            foreach (double vi in this.vitesse)
            {
                v = v + vi;
            }
            this.vitesseMoyenne = v / this.vitesse.Count();

        }

        public string GetCriteresToString()
        {
            
            return " vitesse = " + this.vitesseActuelle + " vitesse moyenne = " + this.vitesseMoyenne;
        }
    }
}
