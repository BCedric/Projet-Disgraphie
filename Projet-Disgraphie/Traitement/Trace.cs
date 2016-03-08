using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Projet_Disgraphie.Traitement.Tracé;

namespace Projet_Disgraphie.Traitement
{
    class Trace
    {
        private List<Point> points;
        private List<Bloc> blocs;

        public Trace(String[] lines)
        {
            this.points = new List<Point>();
            foreach (String line in lines)
            {
                String[] elments = Regex.Split(line, "\t");
                if (elments.Length == 11 && elments[1] != "SN")
                {
                    this.ajouterPoint(elments);
                }
                    
            }
            points.Sort();

            this.blocs = new List<Bloc>();
            this.separerBlocs();
        }

        public void ajouterPoint(String[] elts)
        {
            this.points.Add(new Point(elts[0], elts[1], elts[2], elts[3], elts[4], elts[5], elts[6], elts[7], elts[8], elts[9], elts[10]));
        }

        private void separerBlocs()
        {
            Bloc b = null;
            foreach(Point p in this.points)
            {
                if (b == null)
                {
                    if(p.z == 0)
                    {
                        b = new Bloc();
                        b.ajouterPoint(p);
                    }
                } else
                {
                    if(p.z != 0)
                    {
                        this.blocs.Add(b);
                        b = null;
                    } else
                    {
                        b.ajouterPoint(p);
                    }
                }
            }
        }
    }
}
