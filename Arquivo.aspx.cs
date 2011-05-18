using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Arquivo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ArquivoC arq = new ArquivoC();
       
        List<TextoArq> listaArq = arq.getListaArquivados(0);

        TextoArq tex = null;

        tex = listaArq[0];

        HyperLink1.Text = tex.ToString();

    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}