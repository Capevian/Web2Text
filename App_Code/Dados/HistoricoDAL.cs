using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

/// <summary>
/// Summary description for HistoricoDAL
/// </summary>
public class HistoricoDAL
{
    private static string db = "web2textRemote";

	public HistoricoDAL()
	{
	}

    public DataTable select()
    {
        StringBuilder q1 = new StringBuilder();

        q1.Append(" SELECT ");

        q1.Append(" Link ");

        q1.Append(" FROM ");

        q1.Append(" Historico ");

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            // Utilizado para preencher o objeto DataSet
            // fazendo a query na BD
            SqlDataAdapter dAdapter = new SqlDataAdapter(q1.ToString(), conn);

            DataSet dataSet = new DataSet();

            // preenche uma tabela do DataSet e da-lhe o nome arquivo
            dAdapter.Fill(dataSet, "Historico");

            // cria uma tabela que retira do DataSet
            DataTable dt = dataSet.Tables["Historico"];

            // fecha ligacao com a BD
            conn.Close();

            return dt;
        }

    }

    public int addHistorico(string link)
    {
        int i = 0;

        StringBuilder q = new StringBuilder();

        q.Append(" INSERT INTO ");
        q.Append(" Historico ");
        q.Append(" (Link) ");
        q.Append(" VALUES ");
        q.Append(" (@link) ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            SqlCommand cmd = new SqlCommand(q.ToString(), conn);

            cmd.Parameters.Add(new SqlParameter("@link", SqlDbType.NVarChar)).Value = link;

            conn.Open();

            i = cmd.ExecuteNonQuery();

            conn.Close();
        }
        return i; 
    }

    public int deleteAll()
    {
        int i = -1;

        StringBuilder q1 = new StringBuilder();

        q1.Append(" DELETE ");
        q1.Append(" FROM Historico ");
        q1.Append(" WHERE (1 = 1) ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            conn.Open();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn);

            i = cmd1.ExecuteNonQuery();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return i;
    }
}