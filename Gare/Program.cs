﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Collections;
using System.Data.Entity.Validation;


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
                        natureToBdd(stuff);
                        LignedetrainToBdd(stuff);
                        codePostaltoBdd(stuff);
                        VilletoBdd(stuff);
                        GaretoBdd(stuff);

                        break;
                    default:
                        //help();
                        break;
                }

            }

        }

        private static void natureToBdd(dynamic stuff)                                  //methode pour envoyer la nature des gars vers la bdd 
        {
            using (var db = new GareContest())
            {
                foreach (var item in stuff)
                {
                    string nameNature = item.fields.nature;
                    Console.WriteLine(nameNature);
                    var recherchedoublonNature = from N in db.Natures
                                                 where N.nomNature == nameNature
                                                 select N;
                    Nature nature = recherchedoublonNature.FirstOrDefault();
                    if (nature == null)                                                      ///sans les doublons
                    {
                        Nature nomNature = new Nature
                        {
                            nomNature = item.fields.nature,
                        };

                        try
                        {
                            db.Natures.Add(nomNature);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }

                        db.SaveChanges();
                    }
                    
                    
                }
            }
        }

        private static void LignedetrainToBdd(dynamic stuff)
        {
            using (var db = new GareContest())

            {
                foreach (var item in stuff)
                {
                    int numlignedetrain = item.fields.code_ligne;
                    var rechercherdoublonlignetrain = from L in db.Lignes
                                                      where L.CodeLigne == numlignedetrain
                                                      select L;
                    Ligne ligne = rechercherdoublonlignetrain.FirstOrDefault();

                    if (ligne == null)
                    {
                        Ligne lignedetrain = new Ligne
                        {
                            CodeLigne = item.fields.code_ligne,


                        };

                        try
                        {
                            db.Lignes.Add(lignedetrain);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        private static void codePostaltoBdd(dynamic stuff)
        {
            using (var db = new GareContest())
            {
                foreach (var item in stuff)
                {
                    int numCP = item.fields.cp;
                    Console.WriteLine(numCP);
                    var recherchedoublonCp = from cp in db.CodePostals
                                             where cp.CPVille == numCP
                                             select cp;
                    CodePostal codePostal = recherchedoublonCp.FirstOrDefault();

                    if (numCP == null)
                    {
                        CodePostal cp = new CodePostal
                        {
                            CPVille = item.fields.cp,

                        };

                        try
                        {
                            db.CodePostals.Add(cp);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }

                        db.SaveChanges();
                    }


                  
                }
            }
        }

        private static void VilletoBdd(dynamic stuff)
        {
            using (var db = new GareContest())
            {
                foreach (var item in stuff)
                {

                    string nomVille = item.fields.ville;

                    var rechercheDoublonVille = from doublon in db.Villes
                                                where doublon.nom == nomVille
                                                select doublon;

                    Ville doublonVille = rechercheDoublonVille.FirstOrDefault();
                    if (doublonVille == null)
                    {

                        Ville Villefrance = new Ville
                        {
                            nom = item.fields.ville,
                            dept = item.fields.dept,

                        };


                        try
                        {
                            db.Villes.Add(Villefrance);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }
                        db.SaveChanges();
                    }
                }
            }
        }

        private static void GaretoBdd(dynamic stuff)
        {
            using (var db = new GareContest())
            {
                foreach (var item in stuff)
                {

                    // ici faire une requète pour trouver l'id de la ville

                    string nomGare = item.fields.nom;
                    Console.WriteLine(nomGare);
                    var chercherNomGare = from v in db.Gares
                                          where v.nom == nomGare
                                          select v;
                    Gare gare = chercherNomGare.FirstOrDefault();

                    if (gare == null)
                    {

                        Gare GareTrain = new Gare
                        {
                            nom = item.fields.nom,
                            wgs84 = item.fields.wgs84[0].ToString() + "-" + item.fields.wgs84[1].ToString(),
                           
                        };

                        try
                        {
                            db.Gares.Add(GareTrain);
                        }
                        catch (Exception e)
                        {

                            Console.WriteLine(e.Message);
                        }

                    }

                    db.SaveChanges();
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
                    //    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8} ",
                    //    item.fields.ville, item.fields.wgs84, item.fields.nature, item.fields.code_ligne,
                    //    item.fields.dept, item.fields.nom, item.fields.latitude_wgs84, item.fields.longitude_wgs84, item.fields.cp);
                }
            }
            return stuff;
        }
    }
}











