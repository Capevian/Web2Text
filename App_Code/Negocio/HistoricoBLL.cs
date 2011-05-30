using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for HistoricoBLL
/// </summary>
public class HistoricoBLL
{
    private HistoricoDAL hist;

	public HistoricoBLL()
	{
        hist = new HistoricoDAL();
	}

    public List<Link> getHistorico()
    {
        List<Link> lista = new List<Link>();

        DataTable dt = hist.select();

        foreach (DataRow row in dt.Rows)
        {
            Link l = new Link(row[0].ToString());

            lista.Add(l);
        }

        return lista;
    }

    public int cleanHistorico()
    {
        return hist.deleteAll();
    }
}