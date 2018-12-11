using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Ado
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connexion a la Base de Donnée");
            Console.WriteLine("Host:");
            string h = Convert.ToString(Console.ReadLine());
            Console.WriteLine("database:");
            string db = Convert.ToString(Console.ReadLine());
            Console.WriteLine("user:");
            string u = Convert.ToString(Console.ReadLine());
            Console.WriteLine("mot de passe:");
            string pswd = Convert.ToString(Console.ReadLine());
            Requetes rqt = new Requetes(h, u, db, pswd);
            string choix;

            do
            {

                Console.WriteLine("Choix");
                Console.WriteLine("0. Cree Employer");
                Console.WriteLine("1. liste employe");
                Console.WriteLine("2. salaire employer");
                Console.WriteLine("3. update budget");
                Console.WriteLine("4. moyenne diplomeSup");
                int choixCall = Convert.ToInt32(Console.ReadLine());
                switch (choixCall)
                {
                    case 0:
                        Console.WriteLine("Creer Employé");
                        rqt.CreationEmployer();
                        break;
                    case 1:
                        Console.WriteLine("la liste employe");
                        Console.WriteLine(rqt.ListeEmploye());
                        break;
                    case 2:
                        Console.WriteLine("salaire employer");
                        Console.WriteLine(rqt.SalaireEmployé());
                        break;
                    case 3:
                        Console.WriteLine("Mise a Jour budget");
                        rqt.MajBudget();
                        break;
                    case 4:
                        Console.WriteLine("AVG diplome Sup");
                        Console.WriteLine(rqt.AvgDiplomeSup());
                        break;
                    default:
                        
                        break;
                }
                Console.WriteLine("quitter? O/N");
                choix = Console.ReadLine();
            } while (choix != "O");
            Console.ReadLine();
        }
 
    }
}
