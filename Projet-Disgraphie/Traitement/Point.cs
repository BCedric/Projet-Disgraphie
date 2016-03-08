using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Disgraphie.Traitement
{
    class Point
    {
        private double id;
        private double sn;
        private double t;
        private double x;
        private double y;
        private double z;
        private double p;
        private double alt;
        private double azi;
        private double twi;
        private double lever;

        public Point(String id, String sn, String t, String x, String y, String z, String p, String alt, String azi, String twi, String lever)
        {
            this.id = Convert.ToDouble(id);
            this.sn = Convert.ToDouble(sn);
            this.t = Convert.ToDouble(t);
            this.x = Convert.ToDouble(x);
            this.y = Convert.ToDouble(y);
            this.z = Convert.ToDouble(z);
            this.p = Convert.ToDouble(p);
            this.alt = Convert.ToDouble(alt);
            this.azi = Convert.ToDouble(azi);
            this.twi = Convert.ToDouble(twi);
            this.lever = Convert.ToDouble(lever); 
        }
    }
}
