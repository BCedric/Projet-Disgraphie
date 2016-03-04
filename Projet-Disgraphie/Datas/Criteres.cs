using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Projet_Disgraphie.Datas;
using Projet_Disgraphie.Utils;
using WintabDN;

namespace Projet_Disgraphie
{
    class Criteres
    {
        //Thread Properties
        private Thread thread;
        private static Object lockObject = new Object();
        private List<DataPoint> synchronizedList;
        private List<DataPoint> ListComplete = new List<DataPoint>();

        //Nombre points par thread ====>   5 1 points
        private int drawSpeed = 100;
        private long previousTime = 0;
        private long pauseTime = 20;

        //Liste datas calculées
        private List<double> vitesse = new List<double>();
        private List<double> jerk = new List<double>();
        private double vitesseMoyenne = 0;
        private double vitesseActuelle = 0;
        private double jerkActuel = 0;

        public void AddPoint(DataPoint p)
        {
            ListComplete.Add(p);
            //Lock part for synchronizedList access
            lock (lockObject)
            {
                synchronizedList.Add(p);
            }
        }

        public void Start()
        {
            Reset();
            thread.Start();
        }
        private void Reset()
        {
            // LIST
            if (synchronizedList == null)
            {
                synchronizedList = new List<DataPoint>();

            }
            synchronizedList.Clear();

            // THREAD
            if (thread == null)
            {
                thread = new Thread(new ThreadStart(Calcul));
            }


        }
        private void Calcul()
        {

            // Tant que le thread n'est pas tué, on travaille
            Console.WriteLine("Start thread...");
            while (Thread.CurrentThread.IsAlive)
            {
                Thread.Sleep(drawSpeed);

                DataPoint[] copyList = new DataPoint[synchronizedList.Count];
                if (copyList.Length > 0)
                {
                    //Lock part for synchronizedList access
                    lock (lockObject)
                    {
                        this.synchronizedList.CopyTo(copyList);
                        this.calculDonnees(copyList);
                        synchronizedList.Clear();
                    }



                    // Affichage dans la console
                    Console.WriteLine("Nb point a calculer : " + copyList.Length);

                }

                //Pause detection
                long currentTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                if (previousTime + pauseTime < currentTime)
                {
                    //TODO
                }
            }
        }

        private void calculDonnees(DataPoint[] copyList)
        {
           this.CalculVitesse(copyList);
        }
        private void CalculVitesse(DataPoint[] Datas)
        {
            if (Datas.Length > 3)
            {
                int longueur_x = Math.Abs(Datas[0].X - Datas[Datas.Length - 1].X);
                int longueur_y = Math.Abs(Datas[0].Y - Datas[Datas.Length - 1].Y);
                Console.WriteLine(" x = " + longueur_x + " |  y = " + longueur_y);

                double longueur_x_pow = Math.Pow(longueur_x, 2);
                double longueur_y_pow = Math.Pow(longueur_y, 2);
                Console.WriteLine("pow( x ) = " + longueur_x_pow + " |  pow ( y ) = " + longueur_y_pow);

                double temps_passé = Math.Abs(Datas[0].temps - Datas[Datas.Length - 1].temps);
                Console.WriteLine("temps passe  " + temps_passé);
                double d = Math.Sqrt(longueur_x_pow + longueur_y_pow) ;


                this.vitesseActuelle = OutilMathematic.deriveSurTemps(d, temps_passé, 1);
                Console.WriteLine("vitesse actuelle : " + this.vitesseActuelle);

                this.jerkActuel = OutilMathematic.deriveSurTemps(d, temps_passé, 2);
                Console.WriteLine("jerk actuel : " + this.jerkActuel);

                this.jerk.Add(this.jerkActuel);
                this.vitesse.Add(this.vitesseActuelle);


                double v = 0;
                foreach (double vi in this.vitesse)
                {
                    v = v + vi;
                }
                this.vitesseMoyenne = v / this.vitesse.Count();
                Console.WriteLine("vitesse moyenne : " + this.vitesseMoyenne);
            }
        }





        public int GetNbPoint()
        {
            return this.ListComplete.Count;
        }


        public double GetVitesseActuelle()
        {
            return this.vitesseActuelle;
        }
        public double GetVitesseMoyenne()
        {
            return this.vitesseMoyenne;
        }
        public string GetCriteresToString()
        {

            return " vitesse = " + this.vitesseActuelle + " vitesse moyenne = " + this.vitesseMoyenne;
        }



    }
}
