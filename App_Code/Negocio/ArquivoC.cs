using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for Arquivo
/// </summary>
public class ArquivoC
{
    private ArquivoDAL arq;

	public ArquivoC()
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
}