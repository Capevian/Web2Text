using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PesquisaArquivo : System.Web.UI.Page
{
    int CurrentPage = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindListView();
        }
    }
    /* Funcao executada quando se muda de pagina*/
    protected void listView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DtPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //custom function to bind your listview
        BindListView();
    }

    /* Funcao executada quando a listView e' carregada de elementos
     * neste caso preenche a dropDownlist*/
    protected void listView1_DataBound(object sender, EventArgs e)
    {
        if (DtPager.TotalRowCount != 0)
        {
            DropDownList ddl = DtPager.Controls[3].FindControl("DropDownList1") as DropDownList;

            int PageCount = (DtPager.TotalRowCount / DtPager.PageSize);

            if (PageCount * DtPager.PageSize != DtPager.TotalRowCount)
            {
                PageCount = PageCount + 1;
            }

            for (int i = 0; i < PageCount; i++)
            {
                ddl.Items.Add(new ListItem((i + 1).ToString(), i.ToString()));
            }

            ddl.Items.FindByValue(CurrentPage.ToString()).Selected = true;
        }
    }

    /* Funcao executada quando e' escolhida uma pagina na dropDownList*/
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddl = sender as DropDownList;
        CurrentPage = int.Parse(ddl.SelectedValue);
        int PageSize = DtPager.PageSize;
        DtPager.SetPageProperties(CurrentPage * PageSize, PageSize, true);

        //BindListView();
    }

    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        BindListView();
    }

    private void BindListView()
    {
        ArquivoBLL arq = new ArquivoBLL();
        string termos;
        int option = 0;

        if (Session["Termos"] != null)
            termos = (string)Session["Termos"];
        else termos = null;

        if (Session["OpcaoPesquisa"] != null)
            option = (int)Session["OpcaoPesquisa"];

        List<PesquisaArq> lista = arq.efectuaPesquisa(termos, option);
        
        // Este caso trara a situacao em a pesquisa não tem resultados
        // Desta forma, vai ser criado um objecto PesquisaArq com uma mensagem
        // no parametro zonaPalavra
        if (lista.Count == 0)
        {
            lista.Add(new PesquisaArq(termos, 0, "", "", ""));
        }
        
        ListView1.DataSource = lista;
        ListView1.DataBind();
    }
}
