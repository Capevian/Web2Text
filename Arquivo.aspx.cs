using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Arquivo : System.Web.UI.Page
{
    private ArquivoBLL arq = new ArquivoBLL();

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

        List<TextoArq> listaArq = arq.getListaArquivados(0);

        ListView1.DataSource = listaArq;
        ListView1.DataBind();

    }

    private void BindListView()
    {       
        List<TextoArq> listaArq = arq.getListaArquivados(0);

        ListView1.DataSource = listaArq;
        ListView1.DataBind();
       
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["Termos"] = TextBox1.Text;
        string selected = RadioButtonList1.SelectedItem.Value;
        
        if(String.Compare(selected,"0") == 0)
        {
            Session["OpcaoPesquisa"] = 0;
        }
        else
        {
            Session["OpcaoPesquisa"] = 1;
        }
        Response.Redirect("PesquisaArquivo.aspx");
    }

    protected void clicklinkRemover(object sender, CommandEventArgs e)
    {
        arq.removeTexto(Convert.ToInt32(e.CommandArgument.ToString()));
    }
}