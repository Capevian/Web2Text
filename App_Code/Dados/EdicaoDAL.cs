using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for EdicaoDAL
/// </summary>
public class EdicaoDAL
{
    private static string db = "web2textLocal";

	public EdicaoDAL()
	{
	}

    public DataTable select(int ordenacao)
    {
        StringBuilder query = new StringBuilder();
        
        query.Append("SELECT ");
            query.Append("idLink, ");
            query.Append("Titulo, ");
            query.Append("Texto, ");
            query.Append("Intro, ");
            query.Append("username, ");
            query.Append("Link, ");
            query.Append("DataAcesso,");
            query.Append("DataModificacao ");
        query.Append("FROM ");
            query.Append("Edicao ");
        query.Append("ORDER BY Titulo;");

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            // Utilizado para preencher o objeto DataSet
            // fazendo a query na BD
            SqlDataAdapter dAdapter = new SqlDataAdapter(query.ToString(), conn);

            DataSet dataSet = new DataSet();

            // preenche uma tabela do DataSet e da-lhe o nome arquivo
            dAdapter.Fill(dataSet, "Edicao");

            // cria uma tabela que retira do DataSet
            DataTable dt = dataSet.Tables["Edicao"];

            // fecha ligacao com a BD
            conn.Close();

            return dt;
        }
    }

    public DataRow pesquisaID(int idTexto)
    {
        DataRow dataRow = null;

        StringBuilder query = new StringBuilder();

        query.Append("SELECT ");
            query.Append("idLink, ");
            query.Append("Titulo, ");
            query.Append("Texto, ");
            query.Append("Intro, ");
            query.Append("username, ");
            query.Append("Link, ");
            query.Append("DataAcesso, ");
            query.Append("DataModificacao ");
        query.Append("FROM ");
            query.Append("Edicao ");
        query.Append("WHERE ");
            query.Append("idLink = @idVal ;");

        SqlParameter param = new SqlParameter("@idVal", idTexto);

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {

            SqlCommand cmd = new SqlCommand(query.ToString(), conn);
            cmd.Parameters.Add(param);

            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

            DataSet dataSet = new DataSet();

            dAdapter.Fill(dataSet, "Edicao");

            // Se existir um resultado 
            if (dataSet.Tables["Edicao"].Rows.Count == 1)
            {
                dataRow = dataSet.Tables["Edicao"].Rows[0];
            }

            conn.Close();
        }

        return dataRow;
    }
}