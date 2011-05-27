using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PaginaWeb
/// </summary>
public class PaginaWeb
{
    private string url;
    private string conteudo;

	public PaginaWeb(string u, string c)
	{
        this.url = u;
        this.conteudo = c;
	}

    public string Url
    {
        get { return url; }
        set { url = value; }
    }

    public string Conteudo
    {
        get { return conteudo; }
        set { conteudo = value; }
    }
}