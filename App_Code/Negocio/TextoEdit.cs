using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoEdit
/// </summary>
public class TextoEdit : Texto
{
    private DateTime dtAcesso;
    private DateTime dtMod;

	public TextoEdit(int idT, 
                    string tit, 
                    string tex, 
                    string intro, 
                    string user, 
                    string link,
                    DateTime dtAcesso,
                    DateTime dtMod) :
        base(idT, tit, tex, intro, user, link)
	{
        this.dtAcesso = dtAcesso;
        this.dtMod = dtMod;
	}

    public DateTime DtAcesso 
    {
        get { return dtAcesso; }
        set { dtAcesso = value; }
    }

    public DateTime DtMod
    {
        get { return dtMod; }
        set { dtMod = value; }
    }
}