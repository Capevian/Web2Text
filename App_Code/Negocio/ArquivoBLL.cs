using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Arquivo
/// </summary>
public class ArquivoBLL
{
    private ArquivoDAL arq;

	public ArquivoBLL()
	{
        arq = new ArquivoDAL();	
	}

    public List<TextoArq> getListaArquivados(int ordenacao)
    {   
        List<TextoArq> lista = new List<TextoArq>();

        DataTable dt = arq.select(ordenacao);

        foreach (DataRow row in dt.Rows)
        {

            TextoArq text = 
                new TextoArq( (int) row[0],
                             row[1].ToString(),
                             row[2].ToString(),
                             row[3].ToString(),
                             Convert.ToDateTime(row[4]),
                             row[5].ToString(),
                             row[6].ToString()
                             );
            lista.Add(text);
        }
        
        return lista;
    }

    public TextoArq getTexto(int idTexto)
    {
        DataRow row = arq.pesquisaID(idTexto);
        
        return(new TextoArq( (int) row[0],
                             row[1].ToString(),
                             row[2].ToString(),
                             row[3].ToString(),
                             Convert.ToDateTime(row[4]),
                             row[5].ToString(),
                             row[6].ToString()
                            ));
    }

    public List<PesquisaArq> efectuaPesquisa(string termos, int option)
    {
        List<PesquisaArq> lista = new List<PesquisaArq>();

        //retorna lista vazia se o termos pesquisado for null
        if (termos == "") return lista;
        
        DataTable dt = arq.pesquisaPalavras(termos, option);
        foreach (DataRow row in dt.Rows)
        {
            lista.Add(new PesquisaArq(termos,
                                (int)row[0],
                                row[1].ToString(),
                                row[2].ToString(),
                                row[3].ToString()));
        }
        return lista;
    }

    public int moveToEdicao(int idTexto)
    {
        return(arq.moveToEdicao(idTexto));
    }
}