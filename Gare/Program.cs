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

                        lireJson(args[1]);
                        stockeDansLaBase();
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

        private static void stockeDansLaBase()
        {
            using (var db = new GareContest())
            {
                var Gare = new Gare
                {
                    Ligne  = 984000,
                    nom = "St-Michel-Notre-Dame",
                    wgs84 = "2.3471 - 48.85312",
                    
                    //cpVille = 75005,
                    //Villes = "Paris"

                };

                //db.gares.Add(gare);
                db.SaveChanges();
            }

            //foreach (var garelignes in Gare)
            // {

            // }

        }

        private static void lireJson(string nomdufichier) //fonction permettant de lire le fichier Json
        {
            using (StreamReader r = new StreamReader(nomdufichier))
            {
                string json = r.ReadToEnd();
                dynamic stuff = JsonConvert.DeserializeObject(json);
                foreach (var item in stuff)
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} {9} {10} {11} {12}",
                     item.datasetid, item.recordid, item.fields.ville, item.fields.wgs84, item.fields.nature, item.fields.code_ligne,
                     item.fields.dept, item.fields.nom, item.fields.latitude_wgs84, item.fields.longitude_wgs84, item.fields.cp);
                }

            }
        }



        private static void help()
        {
            Console.WriteLine("erreur argument");
        }
    }
}


