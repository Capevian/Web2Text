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
/// Summary description for EdicaoDAL
/// </summary>
public class EdicaoDAL
{
    //private static string db = "web2textLocal";
    private static string db = "web2textRemote";
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

    public void updateTexto(int idTexto, string texto, string titulo)
    {
        StringBuilder q = new StringBuilder();

        q.Append("UPDATE ");
        q.Append("Edicao ");
        q.Append("SET ");
        q.Append("Titulo = @tit, ");
        q.Append("Texto = @tex, ");
        q.Append("DataModificacao = CURRENT_TIMESTAMP ");
        q.Append("WHERE ");
        q.Append("idLink = @idTex; ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {          
            SqlCommand cmd = new SqlCommand(q.ToString(), conn);
                        
            cmd.Parameters.Add(new SqlParameter("@tit", SqlDbType.NVarChar)).Value = titulo;

            cmd.Parameters.Add(new SqlParameter("@tex", SqlDbType.NVarChar)).Value = texto;
            
            cmd.Parameters.Add(new SqlParameter("@idTex", SqlDbType.Int)).Value = idTexto;

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();
        }
    }

    public void archiveTexto(int idTexto, string texto, string titulo)
    {

        SqlTransaction tn ;

        StringBuilder q1 = new StringBuilder();

        q1.Append(" UPDATE ");
        q1.Append(" Edicao ");
        q1.Append(" SET ");
        q1.Append(" Titulo = @titulo, ");
        q1.Append(" Texto = @texto ");
        q1.Append(" WHERE ");
        q1.Append(" idLink = @idTexto; ");
        
        StringBuilder q2 = new StringBuilder();

        q2.Append(" INSERT INTO ");
        q2.Append(" Arquivo ( Titulo, Texto, Intro, DataArq, username, Link ) ");
        q2.Append(" SELECT ");
        q2.Append(" e.Titulo, e.Texto, e.Intro, CURRENT_TIMESTAMP as Expr1, e.username, e.Link ");
        q2.Append(" FROM Edicao AS e ");
        q2.Append(" WHERE (e.idLink = @idTexto) ");

        StringBuilder q3 = new StringBuilder();

        q3.Append(" DELETE ");
        q3.Append(" FROM Edicao ");
        q3.Append(" WHERE ");
        q3.Append(" (idLink = @idTexto) ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {

            conn.Open();

            tn = conn.BeginTransaction();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn, tn);

            cmd1.Parameters.Add("@titulo", SqlDbType.NVarChar).Value = titulo;

            cmd1.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;

            cmd1.Parameters.Add("@idTexto", SqlDbType.Int).Value = idTexto;

            SqlCommand cmd2 = new SqlCommand(q2.ToString(), conn, tn);

            cmd2.Parameters.Add("@idTexto", SqlDbType.Int).Value = idTexto;

            SqlCommand cmd3 = new SqlCommand(q3.ToString(), conn, tn);

            cmd3.Parameters.Add("@idTexto", SqlDbType.Int).Value = idTexto;

            try
            {
                // Actualiza primeiro os dados da tabela edicao
                cmd1.ExecuteNonQuery();

                // Insere o novo texto no arquivo
                cmd2.ExecuteNonQuery();

                // Remove da tabela edicao
                cmd3.ExecuteNonQuery();

                tn.Commit();
            }
            catch (SqlException ex)
            {
                Debug.Assert(false, ex.ToString());
                tn.Rollback();
            }

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }
    }
}