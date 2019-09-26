using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Domain
{
    public class AmigoRepositorio
    {
        private SqlConnection con;
        private SqlTransaction transacao;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GerenciadorAmigo"].ConnectionString;
            con = new SqlConnection(constr);
        }

        public bool InserirAmigo(Amigos amigoObj)
        {
            Connection();
            int i;
            using (SqlCommand cmd = new SqlCommand("InserirAmigo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", amigoObj.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", amigoObj.Sobrenome);
                cmd.Parameters.AddWithValue("@DataDeAniversario", amigoObj.DataDeAniversario);

                con.Open();
                i = cmd.ExecuteNonQuery();
                transacao.Commit();

            }
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Amigos> ListarAmigo()
        {
            Connection();
            List<Amigos> amigos = new List<Amigos>();

            using (SqlCommand cmd = new SqlCommand("ListarAmigo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Amigos amigo = new Amigos()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Sobrenome = Convert.ToString(reader["Sobrenome"]),
                        DataDeAniversario = Convert.ToDateTime(reader["DataDeAniversario"])
                    };
                    amigos.Add(amigo);
                }
                con.Close();

                return amigos;
            }
        }

        public bool AtualizarAmigo(Amigos amigoObj)
        {
            Connection();
            int i;
            using (SqlCommand cmd = new SqlCommand("AtualizarAmigo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", amigoObj.Id);
                cmd.Parameters.AddWithValue("@Nome", amigoObj.Nome);
                cmd.Parameters.AddWithValue("@Sobrenome", amigoObj.Sobrenome);
                cmd.Parameters.AddWithValue("@DataDeAniversario", amigoObj.DataDeAniversario);

                con.Open();
                i = cmd.ExecuteNonQuery();

            }
            con.Close();
            return i >= 1;
        }

        public bool ExcluirAmigo(int id)
        {
            Connection();
            int i;
            using (SqlCommand cmd = new SqlCommand("ExcluirAmigo", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);

                con.Open();
                i = cmd.ExecuteNonQuery();
            }
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            return false;

        }
    }
}
