using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;

/// <summary>
/// Summary description for ArquivoDAL
/// </summary>
public class ArquivoDAL
{
    //private static string connString = "Data Source=ACS-LAPTOP;Initial Catalog=web2text;"
    //                    + "Integrated Security=True;Pooling=False";
    //private static string connString = "Data Source=w2t.dyndns.info;Initial Catalog=web2text;"
    //                      + "Persist Security Info=True;User ID=sa;Password=TROIKA;";
    private static string db = "web2textRemote";
    //private static string db = "web2textLocal";

	public ArquivoDAL()
	{
	}

    public DataTable select(int ordenacao)
    {
        StringBuilder query = new StringBuilder();
        query.Append("SELECT ");
            query.Append("idTexto, ");
            query.Append("Titulo, ");
            query.Append("Texto, ");
            query.Append("Intro, ");
            query.Append("DataArq ,");
            query.Append("username, ");
            query.Append("Link ");
        query.Append("FROM ");
            query.Append("Arquivo ");
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
            dAdapter.Fill(dataSet, "Arquivo");

            // cria uma tabela que retira do DataSet
            DataTable dt = dataSet.Tables["Arquivo"];
            
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
            query.Append("idTexto, ");
            query.Append("Titulo, ");
            query.Append("Texto, ");
            query.Append("Intro, ");
            query.Append("DataArq, ");
            query.Append("username, ");
            query.Append("Link ");
        query.Append("FROM ");
            query.Append("Arquivo ");
        query.Append("WHERE ");
            query.Append("idTexto = @idVal ;");

        SqlParameter param = new SqlParameter("@idVal",idTexto);

        using ( SqlConnection conn = 
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            
            SqlCommand cmd = new SqlCommand(query.ToString(),conn);
            cmd.Parameters.Add(param);

            SqlDataAdapter dAdapter = new SqlDataAdapter(cmd);

            DataSet dataSet = new DataSet();

            dAdapter.Fill(dataSet,"Arquivo");

            // Se existir um resultado 
            if (dataSet.Tables["Arquivo"].Rows.Count == 1)
            {
                dataRow = dataSet.Tables["Arquivo"].Rows[0];
            }

            conn.Close();
        }

        return dataRow;
    }
}