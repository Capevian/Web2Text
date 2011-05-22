using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoArq
/// </summary>
public class TextoArq : Texto
{
    private DateTime dataArq;

	public TextoArq(int idT,
                    string tit, 
                    string tex, 
                    string intro, 
                    DateTime da, 
                    string user, 
                    string link) 
        : base(idT,tit,tex,intro,user,link)
	{
        this.dataArq = da;
	}

    public DateTime DataArq
    {
        get { return dataArq; }
        set { dataArq = value; }
    }


}