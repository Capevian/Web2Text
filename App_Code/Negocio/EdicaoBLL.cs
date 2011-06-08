using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Net;
using System.Text;

/// <summary>
/// Summary description for EdicaoBLL
/// </summary>
public class EdicaoBLL
{
    private EdicaoDAL edi;

	public EdicaoBLL()
	{
        edi = new EdicaoDAL();
	}

    public int adicionaLinks(List<Link> linksToEdit, string username)
    {
        string texto;
        int addedLinks = 0;
        
        WebClient webCli = new WebClient();

        foreach (Link l in linksToEdit)
        {
            //Byte[] PageHTMLBytes;

            //PageHTMLBytes = webCli.DownloadData(l.LinkContent);
            
            //UTF8Encoding oUTF8 = new UTF8Encoding();
            //texto = oUTF8.GetString(PageHTMLBytes);

            texto = webCli.DownloadString(l.LinkContent);

            addedLinks += edi.insert(texto, l.Titulo, l.LinkContent, l.LinkDesc, username);
        }

        return addedLinks;
    }

    public List<TextoEdit> getLista(string ordenacao)
    {
        List<TextoEdit> lista = new List<TextoEdit>();

        DataTable dt = edi.select();

        foreach (DataRow row in dt.Rows)
        {

            TextoEdit text =
                new TextoEdit((int)row[0],               // idTexto
                             row[1].ToString(),          // Titulo
                             row[2].ToString(),          // Texto
                             row[3].ToString(),          // Intro
                             row[4].ToString(),          // user
                             row[5].ToString(),          // link
                             Convert.ToDateTime(row[6]), // Data Acesso
                             Convert.ToDateTime(row[7])  // Data Mod
                             );
            lista.Add(text);
        }

        if (ordenacao.Equals("TitAsc"))
        {
            TextoSortByTituloAsc sorter = new TextoSortByTituloAsc();
            lista.Sort(sorter);
        }
        if (ordenacao.Equals("TitDesc"))
        {
            TextoSortByTituloDesc sorter = new TextoSortByTituloDesc();
            lista.Sort(sorter);
        }
        if (ordenacao.Equals("DateAsc"))
        {
            TextoSortByDataAsc sorter = new TextoSortByDataAsc();
            lista.Sort(sorter);
        }
        if (ordenacao.Equals("DateDesc"))
        {
            TextoSortByDataDesc sorter = new TextoSortByDataDesc();
            lista.Sort(sorter);
        }

        return lista;
    }

    public TextoEdit getTexto(int idTexto)
    {
        DataRow row = edi.pesquisaID(idTexto);

        return (new TextoEdit((int)row[0],               // idTexto
                             row[1].ToString(),          // Titulo
                             row[2].ToString(),          // Texto
                             row[3].ToString(),          // Intro
                             row[4].ToString(),          // user
                             row[5].ToString(),          // link
                             Convert.ToDateTime(row[6]), // Data Acesso
                             Convert.ToDateTime(row[7])  // Data Mod
                            ));
    }

    public int saveTexto(int idTexto, string texto, string titulo, string username)
    {
        return(edi.updateTexto(idTexto, texto, titulo,username));
    }

    public int archiveTexto(int idTexto, string texto, string titulo, string username)
    {
        return(edi.archiveTexto(idTexto, texto, titulo,username));
    }

    public int removeTexto(int idTexto)
    {
        return (edi.remove(idTexto));
    }
}