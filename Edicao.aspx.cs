using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edicao : System.Web.UI.Page
{
    int CurrentPage = 0;
    private EdicaoBLL edi = new EdicaoBLL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["SortTit"] = true;
            Session["SortDate"] = true;
            Session["SortingBy"] = "Titulo";
            BindListView("Ascending");
        }
    }

    /* Funcao executada quando se muda de pagina*/
    protected void listView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DtPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
        //custom function to bind your listview
        callBindListView(Session["SortingBy"].ToString());
        //BindListView("");
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
        //BindListView("");
        //callBindListView();
    }
    
    private void BindListView(string sortDirection)
    {
        List<TextoEdit> listaEdit = edi.getLista(0);

        if (sortDirection.Equals("TitAsc"))
        {
            TextoSortByTituloAsc sorter = new TextoSortByTituloAsc();
            listaEdit.Sort(sorter);
        }
        if (sortDirection.Equals("TitDesc"))
        {
            TextoSortByTituloDesc sorter = new TextoSortByTituloDesc();
            listaEdit.Sort(sorter);
        }
        if (sortDirection.Equals("DateAsc"))
        {
            TextoSortByDataAsc sorter = new TextoSortByDataAsc();
            listaEdit.Sort(sorter);
        }
        if (sortDirection.Equals("DateDesc"))
        {
            TextoSortByDataDesc sorter = new TextoSortByDataDesc();
            listaEdit.Sort(sorter);
        }

        ListView1.DataSource = listaEdit;
        ListView1.DataBind();
    }

    protected void clicklinkRemover(object sender, CommandEventArgs e)
    {
        edi.removeTexto(Convert.ToInt32(e.CommandArgument.ToString()));
    }

    protected void linkDownloadClick(object sender, CommandEventArgs e)
    {
        TextoEdit txt;
        txt = edi.getTexto( Convert.ToInt32(e.CommandArgument.ToString()));

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment; filename=ficheiro.txt");
        Response.Flush();
        Response.Write(txt.TextContent);
        Response.End();
    }

    protected void sortTituloClick(object sender, EventArgs e)
    {
        Session["SortingBy"] = "Titulo";
        callBindListView("Titulo");
    }

    protected void sortDataClick(object sender, EventArgs e)
    {
        Session["SortingBy"] = "Date";
        callBindListView("Date");
    }

    protected void callBindListView(string by)
    {
        if (by.Equals("Titulo"))
        {
            bool sort = !(bool)Session["SortTit"];

            Session["SortTit"] = sort;

            if (sort)
            {
                BindListView("TitAsc");
            }
            else
            {
                BindListView("TitDesc");
            }
        }
        else
        {
            bool sort = !(bool)Session["SortDate"];

            Session["SortDate"] = sort;

            if (sort)
            {
                BindListView("DateAsc");
            }
            else
            {
                BindListView("DateDesc");
            }
        }
    }
}