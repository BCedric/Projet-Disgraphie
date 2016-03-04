using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Disgraphie.Utils
{
    class OutilMathematic
    {
        //Retourne la dérivée de la vitesse
        public static double deriveSurTemps(double distance, double t, int indice)
        {
            double tPrime = t;
            for(int i = 0; i < indice; i++)
            {
                tPrime = tPrime * t;
            }
            return distance / tPrime;
        }
    }
}
