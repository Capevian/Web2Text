using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Texto
/// </summary>
public abstract class Texto
{
    private int idTexto;
    private string titulo;
    private string texto;
    private string intro;
    private string username;
    private string link;

	public Texto(int idT, string tit, string tex, string intro, string user, string link)
	{
        this.idTexto = idT;
        this.titulo = tit;
        this.texto = tex;
        this.intro = intro;
        this.username = user;
        this.link = link;
	}

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }
}