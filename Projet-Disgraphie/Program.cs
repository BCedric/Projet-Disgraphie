using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Projet_Disgraphie.Traitement;

namespace Projet_Disgraphie
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string current_path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            System.Console.WriteLine("Lecture : ");
            System.Console.WriteLine(current_path);
            Trace t = LectureFichier.ouvrirFichier("exemples-ecriture\\S1_Stim1_bhk.TXT");
            Console.WriteLine("coucou");
            
            
            // Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

        }
    }
}
