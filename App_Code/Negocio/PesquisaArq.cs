using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for PesquisaArq
/// </summary>
public class PesquisaArq
{
    private int idT;
    private string tex;
    private string rank;

	public PesquisaArq(int idT, string tex, string rank) 
    {
	}
    public int PesqArqIdT
    {
        get { return idT; }
        set { idT = value; }
    }
    public string PesqArqTex
    {
        get { return tex; }
        set { tex = value; }
    }
    public string PesqArqRank
    {
        get { return rank; }
        set { rank = value; }
    }
}