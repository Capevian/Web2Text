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
            Session["SortingBy"] = "TitAsc";
            BindListView("TitAsc");
        }
    }

    #region Funcao executada quando se clica no titulo para reordenar

    protected void sortTituloClick(object sender, EventArgs e)
    {
        string orderby = Session["SortingBy"].ToString();

        switch (orderby)
        {
            case "TitAsc":
                Session["SortingBy"] = "TitDesc";
                orderby = "TitDesc";
                break;
            case "TitDesc":
                Session["SortingBy"] = "TitAsc";
                orderby = "TitAsc";
                break;
            default:
                Session["SortingBy"] = "TitAsc";
                orderby = "TitAsc";
                break;
        }
        BindListView(orderby);
    }

    #endregion

    #region Funcao executada quando se clica na data para reordenar

    protected void sortDataClick(object sender, EventArgs e)
    {
        string orderby = Session["SortingBy"].ToString();

        switch (orderby)
        {
            case "DateAsc":
                Session["SortingBy"] = "DateDesc";
                orderby = "DateDesc";
                break;
            case "DateDesc":
                Session["SortingBy"] = "DateAsc";
                orderby = "DateAsc";
                break;
            default:
                Session["SortingBy"] = "DateAsc";
                orderby = "DateAsc";
                break;
        }
        BindListView(orderby);
    }

    #endregion

    #region Funcao que preenche a listView

    private void BindListView(string sortDirection)
    {
        List<TextoEdit> listaEdit = edi.getLista(sortDirection);

        ListView1.DataSource = listaEdit;
        ListView1.DataBind();
    }

    #endregion

    #region Funcao executada quando se muda de pagina
    
    protected void listView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DtPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

        BindListView(Session["SortingBy"].ToString());
    }

    #endregion

    #region Funcao executada quando a listView e' carregada de elementos
     
    /* neste caso preenche a dropDownlist com paginas*/
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

    #endregion

    #region Funcao executada quando e' escolhida uma pagina na dropDownList
    
    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = sender as DropDownList;
        CurrentPage = int.Parse(ddl.SelectedValue);
        int PageSize = DtPager.PageSize;
        DtPager.SetPageProperties(CurrentPage * PageSize, PageSize, true);
    }

    #endregion

    #region Funcao executada quando se clica em Download

    protected void linkDownloadClick(object sender, CommandEventArgs e)
    {
        TextoEdit txt;
        txt = edi.getTexto(Convert.ToInt32(e.CommandArgument.ToString()));

        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment; filename=ficheiro.txt");
        Response.Flush();
        Response.Write(txt.TextContent);
        Response.End();
    }

    #endregion

    #region Funcao executada quando se clica em Remover texto

    protected void clicklinkRemover(object sender, CommandEventArgs e)
    {
        edi.removeTexto(Convert.ToInt32(e.CommandArgument.ToString()));
    }

    #endregion
}