﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

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

    public int IdTexto
    {
        get { return idTexto; }
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string TextContent
    {
        get { return texto; }
        set { texto = value; }
    }

    public string Intro
    {
        get { return intro; }
        set { intro = value; }
    }

    public string User
    {
        get { return username; }
        set { username = value; }
    }

    public string Link
    {
        get { return link; }
        set { link = value; }
    }

    public string limpaTexto(string s)
    {
        const string HTML_TAG = "<.*?>";
        const string HTML_TAG_SCRIPT = "<script.*>[\\s\\S]?</script>";          //Caso em que script nao tem nada entre as tags
        const string HTML_TAG_SCRIPT_2 = "<script.*>[\\s\\S]*?</script>";       //Caso em que realmente tem algo entre as tags
        const string HTML_TAG_NOSCRIPT = "<noscript.*>[\\s\\S]?</noscript>";    //Caso em que noscript nao tem nada entre as tags
        const string HTML_TAG_NOSCRIPT_2 = "<noscript.*>[\\s\\S]*?</noscript>"; //Caso em que realmente tem algo entre as tags

       
        /*Limpeza progressiva, dos especiais ate as tags isoladas*/
        s = Regex.Replace(s, HTML_TAG_SCRIPT, "");
        s = Regex.Replace(s, HTML_TAG_SCRIPT_2, "");
        s = Regex.Replace(s, HTML_TAG_NOSCRIPT, "");
        s = Regex.Replace(s, HTML_TAG_NOSCRIPT_2, "");
        s = Regex.Replace(s, HTML_TAG, "");

        return s;
        
    }
}