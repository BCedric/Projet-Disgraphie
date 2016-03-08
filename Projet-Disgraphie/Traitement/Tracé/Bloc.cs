using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Projet_Disgraphie.Traitement.Tracé
{
    class Bloc
    {
        private List<Point> points;

        public Bloc()
        {
            points = new List<Point>();
        }

        public void ajouterPoint(Point p)
        {
            this.points.Add(p);
            this.points.Sort();
        }
    }
}
