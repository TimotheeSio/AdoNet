using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Ado
{
    class Requetes
    {
        private MySqlConnection cnx;

        public Requetes(string h, string u, string db, string pswd)
        {
            connection2 cn = new connection2(h, u, db, pswd);
            this.cnx = cn.Cnx2;  
        }
        public void CreationEmployer()
        {
            string nom = "Kharsa";
            string prenom = "Rani";
            string sexe = "M";
            int cadre = 0;
            decimal salaire = 2500;
            int service = 2;
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "creationEmployer";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add(new MySqlParameter("nom", MySqlDbType.String));
            cmdSql.Parameters["nom"].Value = nom;
            cmdSql.Parameters.Add(new MySqlParameter("prenom", MySqlDbType.String));
            cmdSql.Parameters["prenom"].Value = prenom;
            cmdSql.Parameters.Add(new MySqlParameter("sexe", MySqlDbType.String));
            cmdSql.Parameters["sexe"].Value = sexe;
            cmdSql.Parameters.Add(new MySqlParameter("cadre", MySqlDbType.Int32));
            cmdSql.Parameters["cadre"].Value = cadre;
            cmdSql.Parameters.Add(new MySqlParameter("salaire", MySqlDbType.Decimal));
            cmdSql.Parameters["salaire"].Value = salaire;
            cmdSql.Parameters.Add(new MySqlParameter("service", MySqlDbType.Int32));
            cmdSql.Parameters["service"].Value = service;
            this.cnx.Open();
            cmdSql.ExecuteNonQuery();
            this.cnx.Close();
        }

        public string ListeEmploye()
        {
            string result = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "listeEmploye";
            cmdSql.CommandType = CommandType.StoredProcedure;

            this.cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}\n",
                    reader[0], reader[1], reader[2]);
            }
            this.cnx.Close();
            return result;
        }

        public string SalaireEmployé()
        {
            decimal param1 = 2000;
            decimal param2 = 3000;
            string result = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "salaireEmployer";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add(new MySqlParameter("param1", MySqlDbType.Decimal));
            cmdSql.Parameters["param1"].Value = param1;
            cmdSql.Parameters.Add(new MySqlParameter("param2", MySqlDbType.Decimal));
            cmdSql.Parameters["param2"].Value = param2;

            this.cnx.Open(); MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}\n",
                    reader[0], reader[1]);
            }
            this.cnx.Close();
            return result;
        }

        public void MajBudget()
        {
            int id = 3;
            decimal taux = 10;
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "majBudget";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add(new MySqlParameter("id", MySqlDbType.Int32));
            cmdSql.Parameters["id"].Value = id;
            cmdSql.Parameters.Add(new MySqlParameter("taux", MySqlDbType.Decimal));
            cmdSql.Parameters["taux"].Value = taux;

            this.cnx.Open();
            cmdSql.ExecuteNonQuery();
            this.cnx.Close();
        }

        public string AvgDiplomeSup()
        {
            string result = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "avgDiplomeSup";
            cmdSql.CommandType = CommandType.StoredProcedure;

            this.cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}\n",
                    reader[0], reader[1], reader[2]);
            }
            this.cnx.Close();
            return result;
        }


        //Requete 1
        public string ListeEmployes()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select * from employe";
            cmdSql.CommandType = CommandType.Text;

            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}, {3}, {4} {5} {6}\n",
                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5], reader[6]);
            }

            this.cnx.Close();
            return result;
        }

        //Requete 2
        public string ListeServices()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "service";
            cmdSql.CommandType = CommandType.TableDirect;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}, {3}, {4} {5}\n",
                    reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
            }

            this.cnx.Close();
            return result;
        }

        //Requete 3
        public string MajSalaire(string nom, int pourcent)
        {
            string result = "mise à jour OK";
            this.cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();

            cmdSql.Connection = cnx;
            cmdSql.CommandText = "MajSalaire";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("nom", MySqlDbType.String);
            cmdSql.Parameters["nom"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["nom"].Value = nom;
            cmdSql.Parameters.Add("pourcent", MySqlDbType.Int32);
            cmdSql.Parameters["pourcent"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["pourcent"].Value = pourcent;
            cmdSql.Prepare();
            try
            {
                cmdSql.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            cnx.Close();
            return result;

        }

        //Requete 4
        public decimal MasseSalariale(string nomService)
        {
            decimal result;
            this.cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "MasseSalariale";
            cmdSql.CommandType = CommandType.StoredProcedure;
            cmdSql.Parameters.Add("nomService", MySqlDbType.String);
            cmdSql.Parameters["nomService"].Direction = ParameterDirection.Input;
            cmdSql.Parameters["nomService"].Value = nomService;
            result = (decimal)cmdSql.ExecuteScalar();
            cnx.Close();
            return result;


        }
        //Requete 5
        public string SuperCadre()
        {
            string result = "";
            cnx.Open();
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select emp_nom from Cadres where emp_salaire > (select AVG(emp_salaire) from Cadres)";
            cmdSql.CommandType = CommandType.Text;
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}\n", reader[0]);
            }

            this.cnx.Close();
            return result;
        }
    }
}
