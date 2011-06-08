using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Configuration;
using System.Diagnostics;

/// <summary>
/// Summary description for ArquivoDAL
/// </summary>
public class ArquivoDAL
{
    private static string db = "web2textRemote";

	public ArquivoDAL()
	{
	}

    public DataTable select()
    {
        StringBuilder q1 = new StringBuilder();
        
        q1.Append(" SELECT ");

        q1.Append(" idTexto, ");
        q1.Append(" Titulo, ");
        q1.Append(" Texto, ");
        q1.Append(" Intro, ");
        q1.Append(" DataArq ,");
        q1.Append(" username, ");
        q1.Append(" Link ");

        q1.Append(" FROM ");

        q1.Append(" Arquivo ");

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            // Utilizado para preencher o objeto DataSet
            // fazendo a query na BD
            SqlDataAdapter dAdapter = new SqlDataAdapter(q1.ToString(), conn);
            
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

    public int remove(int idTexto)
    {
        int i = -1;

        StringBuilder q1 = new StringBuilder();

        q1.Append(" DELETE ");
        q1.Append(" FROM Arquivo ");
        q1.Append(" WHERE (idTexto = @idTexto) ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            conn.Open();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn);

            cmd1.Parameters.Add("@idTexto", SqlDbType.Int).Value = idTexto;

            i = cmd1.ExecuteNonQuery();

            if (conn.State != ConnectionState.Closed)
            {
                conn.Close();
            }
        }

        return i;
    }

    public DataRow pesquisaID(int idTexto)
    {
        DataRow dataRow = null;

        StringBuilder q1 = new StringBuilder();

        q1.Append("SELECT ");
        
        q1.Append("idTexto, ");
        q1.Append("Titulo, ");
        q1.Append("Texto, ");
        q1.Append("Intro, ");
        q1.Append("DataArq, ");
        q1.Append("username, ");
        q1.Append("Link ");
        
        q1.Append("FROM ");
        
        q1.Append("Arquivo ");
        
        q1.Append("WHERE ");
        
        q1.Append("idTexto = @idVal ;");

        SqlParameter param = new SqlParameter("@idVal",idTexto);

        using ( SqlConnection conn = 
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            
            SqlCommand cmd = new SqlCommand(q1.ToString(),conn);
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

    public DataTable pesquisaPalavras(string termos, int option)
    {
        StringBuilder query = new StringBuilder();

        if (termos.IndexOf(" ") == -1)
        {
            query.Append("SELECT Tex.idTexto, Tex.Titulo, Tex.Texto, KEY_TBL.RANK ");
            query.Append("FROM web2text.dbo.Arquivo AS Tex ");
            query.Append("INNER JOIN CONTAINSTABLE(web2text.dbo.Arquivo, *, '");
            query.Append(termos);
            query.Append("') AS KEY_TBL ");
            query.Append("ON Tex.idTexto = KEY_TBL.[KEY] ");
            query.Append("WHERE KEY_TBL.RANK > 1 ");
            query.Append("ORDER BY KEY_TBL.RANK DESC;");
        }
        else
        {
            // Opcao 0 - Pesquisar todos os termos implicitamente. Tipicamente AND
            if (option == 0)
            {
                string[] todosTermos = termos.Split(' ');
                int nTermos = todosTermos.Length;

                query.Append("SELECT Tex.idTexto, Tex.Titulo, Tex.Texto, KEY_TBL.RANK ");
                query.Append("FROM web2text.dbo.Arquivo AS Tex ");
                query.Append("INNER JOIN CONTAINSTABLE(web2text.dbo.Arquivo, *, '");
                query.Append(todosTermos[0]);
                for (int i = 1; i < nTermos; i++)
                {
                    query.Append(" AND ");
                    query.Append(todosTermos[i]);
                }
                query.Append("') AS KEY_TBL ");
                query.Append("ON Tex.idTexto = KEY_TBL.[KEY] ");
                query.Append("WHERE KEY_TBL.RANK > 1 ");
                query.Append("ORDER BY KEY_TBL.RANK DESC;");
            }
            // Opcao 1 - Pesquisar termos isoladamente. Tipicamente OU
            if (option == 1)
            {
                string[] todosTermos = termos.Split(' ');
                int nTermos = todosTermos.Length;

                query.Append("SELECT Tex.idTexto, Tex.Titulo, Tex.Texto, KEY_TBL.RANK ");
                query.Append("FROM web2text.dbo.Arquivo AS Tex ");
                query.Append("INNER JOIN CONTAINSTABLE(web2text.dbo.Arquivo, *, '");
                query.Append(todosTermos[0]);
                for (int i = 1; i < nTermos; i++)
                {
                    query.Append(" OR ");
                    query.Append(todosTermos[i]);
                }
                query.Append("') AS KEY_TBL ");
                query.Append("ON Tex.idTexto = KEY_TBL.[KEY] ");
                query.Append("WHERE KEY_TBL.RANK > 1 ");
                query.Append("ORDER BY KEY_TBL.RANK DESC;");
            }
        }

        // O bloco using garante a libertação dos recursos quando o código terminar
        // Semelhante ao try...finally
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {
            // Utilizado para preencher o objeto DataSet
            // fazendo a query na BD
            SqlDataAdapter dAdapter = new SqlDataAdapter(query.ToString(), conn);

            DataSet dataSet = new DataSet();

            // preenche uma tabela do DataSet e da-lhe o nome arquivo
            dAdapter.Fill(dataSet, "PesquisaArquivo");

            // cria uma tabela que retira do DataSet
            DataTable dt = dataSet.Tables["PesquisaArquivo"];

            // fecha ligacao com a BD
            conn.Close();

            return dt;
        }
    }

    public int moveToEdicao(int idTexto)
    {
        int i = -1;

        SqlTransaction tn; 
        
        StringBuilder q1 = new StringBuilder();

        q1.Append(" INSERT INTO ");
        q1.Append(" Edicao ( DataAcesso, DataModificacao, Texto, Titulo, Link, Intro, username ) ");
        q1.Append(" SELECT ");
        q1.Append(" CURRENT_TIMESTAMP as Expr1, CURRENT_TIMESTAMP as Expr1, ");
        q1.Append(" a.Texto, a.Titulo, a.Link, a.Intro, a.username ");
        q1.Append(" FROM Arquivo AS a ");
        q1.Append(" WHERE (a.idTexto = @idTexto) ");

        StringBuilder q2 = new StringBuilder();

        q2.Append(" DELETE ");
        q2.Append(" FROM Arquivo ");
        q2.Append(" WHERE (idTexto = @idTexto) ");

        using (SqlConnection conn =
            new SqlConnection(ConfigurationManager.ConnectionStrings[db].ConnectionString))
        {

            conn.Open();

            tn = conn.BeginTransaction();

            SqlCommand cmd1 = new SqlCommand(q1.ToString(), conn, tn);

            cmd1.Parameters.Add("@idTexto", SqlDbType.Int).Value = idTexto;

            SqlCommand cmd2 = new SqlCommand(q2.ToString(), conn, tn);

            cmd2.Parameters.Add("@idTexto", SqlDbType.Int).Value = idTexto;

            try
            {
                // Copia a entidade para a tabela Edicao
                i = cmd1.ExecuteNonQuery();

                // Remove do arquivo a entidade
                i += cmd2.ExecuteNonQuery();

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

        return i;
    }

}