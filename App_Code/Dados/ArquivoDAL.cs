using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ArquivoDAL
/// </summary>
public class ArquivoDAL
{
    //private static string connString = "Data Source=ACS-LAPTOP;Initial Catalog=web2text;"
    //                    + "Integrated Security=True;Pooling=False";
    private static string connString = "Data Source=w2t.dyndns.info;Initial Catalog=web2text;"
                          + "Persist Security Info=True;User ID=sa;Password=TROIKA;";

	public ArquivoDAL()
	{
	}

    public DataTable select(int ordenacao)
    {
        string query = "SELECT " +
                           "idTexto," +
                           "Titulo," +
                           "Texto," +
                           "Intro," +
                           "DataArq," +
                           "username," +
                           "Link " +
                        "FROM " +
                            "Arquivo " + 
                        "ORDER BY Titulo;";

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(connString))
        {
            // Utilizado para preencher o objeto DataSet
            // fazendo a query na BD
            SqlDataAdapter dAdapter = new SqlDataAdapter(query, conn);
            
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
}