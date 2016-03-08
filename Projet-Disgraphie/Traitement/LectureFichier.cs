using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace Projet_Disgraphie.Traitement
{
    class LectureFichier
    {
        public static Trace ouvrirFichier(String url)
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(url);
                return new Trace(lines);
            }

            catch(FileNotFoundException)
            {
                Console.WriteLine("Fichier introuvable");
                return null;
            }
        }


    }
}
