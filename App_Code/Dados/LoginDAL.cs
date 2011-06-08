using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;
using System.Security.Cryptography;
/// <summary>
/// Summary description for LoginDAL
/// </summary>
public class LoginDAL
{
    private static string db = "web2textRemote";
    //private static string db = "web2textLocal";

	public LoginDAL()
	{
	}

    public bool findLogin(string username, string passSimples)
    {
        int i = 0;

        String password = this.CalculaMD5(passSimples);

        StringBuilder q1 = new StringBuilder();

        q1.Append(" SELECT ");

        q1.Append(" Count(username) ");

        q1.Append(" FROM ");

        q1.Append(" Utilizadores ");

        q1.Append(" WHERE ");

        q1.Append(" (username = @user) ");

        q1.Append(" AND (password = @pass) ");

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            conn.Open();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn);

            cmd1.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar)).Value = username;
            cmd1.Parameters.Add(new SqlParameter("@pass", SqlDbType.NChar)).Value = password;

            i = Convert.ToInt32(cmd1.ExecuteScalar());

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        if (i == 1) return true;
        else return false;
    }

    public bool insert(string username, string email, string passSimples)
    {
        int i = 0;

        StringBuilder q1 = new StringBuilder();

        q1.Append(" SELECT ");
        q1.Append("  Count(username) ");
        q1.Append(" FROM ");
        q1.Append("  Utilizadores ");
        q1.Append(" WHERE ");
        q1.Append("  username = @user ");

        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            conn.Open();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn);

            cmd1.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar)).Value = username;

            i = Convert.ToInt32(cmd1.ExecuteScalar());

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        if (i > 0)
        {
            return false;
        }
        else
        {
            string password = this.CalculaMD5(passSimples);

            StringBuilder q2 = new StringBuilder();

            q2.Append(" INSERT INTO ");
            q2.Append("  Utilizadores (username, password, email, nlinksSeed, depth, mode) ");
            q2.Append(" VALUES ");
            q2.Append("  (@user, @pass, @email, 5, 2, 0) ");

            using (SqlConnection conn =
                new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
            {
                SqlCommand cmd2 = new SqlCommand(q2.ToString(), conn);

                cmd2.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar)).Value = username;

                cmd2.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar)).Value = password;

                cmd2.Parameters.Add(new SqlParameter("@email", SqlDbType.NVarChar)).Value = email;


                conn.Open();

                i = cmd2.ExecuteNonQuery();

                conn.Close();
            }

            if (i == 1) return true;
            else return false;
        }
    }

    public int[] getDefinicoes(string username)
    {
        int[] defs = new int[3];

        StringBuilder q1 = new StringBuilder();

        q1.Append(" SELECT ");

        q1.Append(" nlinksSeed, depth, mode ");

        q1.Append(" FROM ");

        q1.Append(" Utilizadores ");

        q1.Append(" WHERE ");

        q1.Append(" (username = @user) ");       

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            conn.Open();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn);

            cmd1.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar)).Value = username;

            DataSet dataSet = new DataSet();

            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd1);
            // preenche uma tabela do DataSet e da-lhe o nome arquivo
            dAdapter.Fill(dataSet, "Defs");

            // cria uma tabela que retira do DataSet
            DataTable dt = dataSet.Tables["Defs"];

            foreach(DataRow dtr in dt.Rows)
            {
                defs[0] = Convert.ToInt32(dtr[0]);
                defs[1] = Convert.ToInt32(dtr[1]);
                defs[2] = Convert.ToInt32(dtr[2]);
            }

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
        return defs;

    }

    public int setDefinicoes(string username, int nlinksSeed, int depth, int mode)
    {
        int i = 0;

        StringBuilder q = new StringBuilder();

        q.Append(" UPDATE ");
        q.Append("  Utilizadores ");
        q.Append(" SET ");
        q.Append("  nlinksSeed = @seed, ");
        q.Append("  depth = @dep, ");
        q.Append("  mode = @mod ");
        q.Append(" WHERE ");
        q.Append("  username = @user ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(q.ToString(), conn);

            cmd.Parameters.Add(new SqlParameter("@seed", SqlDbType.Int)).Value = nlinksSeed;
            cmd.Parameters.Add(new SqlParameter("@dep",  SqlDbType.Int)).Value = depth;
            cmd.Parameters.Add(new SqlParameter("@mod",  SqlDbType.Int)).Value = mode;
            cmd.Parameters.Add(new SqlParameter("@user", SqlDbType.NVarChar)).Value = username;

            conn.Open();

            i = cmd.ExecuteNonQuery();

            conn.Close();
        }

        return i;
    }
    
    private string CalculaMD5(string input)
    {
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);

        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("x2"));
        }
        return sb.ToString();
    }
}