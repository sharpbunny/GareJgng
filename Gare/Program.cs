using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace Gare
{
    class Program
    {

        static void Main(string[] args)
        {

            if (args.Length > 1)
            {
                switch (args[0])
                {
                    case "-f":

                        dynamic stuff = lireJson(args[1]);
                        stockeDansLaBase(stuff);
                        break;
                    default:
                        help();
                        break;
                }

            }
            else
            {
                help();
            }
        }

        private static void stockeDansLaBase(dynamic stuff)
        {
            using (var db = new GareContest())
            {

                foreach (var item in stuff)
                {
                    Nature nomNature = new Nature
                    {
                        nomNature = item.fields.nature,
                    };
                    db.Natures.Add(nomNature);
                    db.SaveChanges();

                    CodePostal cp = new CodePostal
                    {
                        CPVille = item.fields.cp,

                    };
                    db.CodePostals.Add(cp);
                    db.SaveChanges();

                    Ligne lignedetrain = new Ligne
                    {
                        CodeLigne = item.fields.code_ligne,

                    };
                    db.Lignes.Add(lignedetrain);
                    db.SaveChanges();

                    Ville VilleFrance = new Ville
                    {
                        nom = item.fields.ville,
                        dept = item.fields.dept

                    };
                    db.Villes.Add(VilleFrance);
                    db.SaveChanges();

                    Gare garetrain = new Gare
                    {
                        nom = item.fields.nom,
                        wgs84 = item.fields.wgs84
                    };
                    db.Gares.Add(garetrain);
                    db.SaveChanges();

                    Console.WriteLine(garetrain);
                    Console.ReadLine();
                }
            }
        }

        private static dynamic lireJson(string nomdufichier) //fonction permettant de lire le fichier Json
        {
            dynamic stuff;
            using (StreamReader r = new StreamReader(nomdufichier))
            {
                string json = r.ReadToEnd();
                stuff = JsonConvert.DeserializeObject(json);
                foreach (var item in stuff)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} ",
                     item.datasetid, item.recordid, item.fields.ville, item.fields.wgs84, item.fields.nature, item.fields.code_ligne,
                     item.fields.dept, item.fields.nom, item.fields.latitude_wgs84, item.fields.longitude_wgs84, item.fields.cp);
                }
            }
            return stuff;
        }



        private static void help()
        {
            Console.WriteLine("erreur argument");
        }
    }
}


