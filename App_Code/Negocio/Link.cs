using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link
{
    private string titulo;
    private string link;
    private string intro;

    public Link(string link)
    {
        this.titulo = "";
        this.link = link;
        this.intro = "";
    }
    
    public Link(string link, string intro)
	{
        this.titulo = "";
        this.link = link;
        this.intro = intro;
	}

    public Link(string titulo, string link, string intro)
    {
        this.titulo = titulo;
        this.link = link;
        this.intro = intro;
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string LinkContent
    {
        get { return link; }
        set { link = value; }        
    }
    public string LinkDesc
    {
        get { return intro; }
        set { intro = value; }
    }
}