using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;


public partial class _Default : System.Web.UI.Page
{
    int CurrentPage = 0;
    private List<Link> listaLinks;
    private string username;
    private HistoricoBLL historico = new HistoricoBLL();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        username = System.Web.HttpContext.Current.User.Identity.Name;
        
        string erro = Request.QueryString["erro"];
        
        if(erro != null && Convert.ToInt32(erro) == 1)
        {
            LabelResultados.Text = "Uma das páginas que requisitou não pode ser descarregada. <br /> Tente Novamente.";
        }

        if (!IsPostBack)
        {
            CheckBoxRejeitadas.Checked = true;
        }
    }

    #region Botao "Pesquisar"

    protected void ButtonPesquisar_Click(object sender, EventArgs e)
    {
       BindListView();
    }

    #endregion

    #region Botao "Limpar Historico"

    protected void ButtonLimparHistorico_Click(object sender, EventArgs e)
    {
        historico.cleanHistorico();
    }

    #endregion

    #region Botao "Seleccionar" links para edicao

    protected void ButtonEditItems_Click(object sender, EventArgs e)
    {
        EdicaoBLL edi = new EdicaoBLL();

        List<Link> linksToEdit = new List<Link>();

        foreach (ListViewItem item in ListView1.Items)
        {
            CheckBox cb = (CheckBox)item.FindControl("chkSelect");

            if (cb != null && cb.Checked)
            {
                //Label1.Text += item.DisplayIndex;
                //Label1.Text += Convert.ToInt32(ListView1.DataKeys[item.DisplayIndex]);
                HyperLink link = (HyperLink)item.FindControl("linkSite");
                Label intro = (Label)item.FindControl("linkIntro");

                linksToEdit.Add(new Link(
                    link.Text,
                    link.NavigateUrl.ToString(),
                    intro.Text)
                    );
            }
        }

        try
        {
            edi.adicionaLinks(linksToEdit, username);
        }
        catch (Exception exc)
        {
            Response.Redirect("Default.aspx?erro=1");
        }

        historico.addHistorico(linksToEdit);

        Response.Redirect("Edicao.aspx");
    }
    #endregion

    #region Funcao executada quando se muda de pagina

    protected void listView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
    {
        this.DtPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
    
        BindListView();
    }
    #endregion

    #region Funcao executada quando e' escolhida uma pagina na dropDownList

    protected void ddlPage_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddl = sender as DropDownList;
        CurrentPage = int.Parse(ddl.SelectedValue);
        int PageSize = DtPager.PageSize;
        DtPager.SetPageProperties(CurrentPage * PageSize, PageSize, true);
        //BindListView();
    }

    #endregion

    #region Funcao que preenche a listView (BindListView)

    private void BindListView()
    { 
        PesquisaWeb search = new PesquisaWeb(username);
        //bool flagTodosTermos = CheckBoxTodosTermos.Checked;
        bool flagTodosTermos = true;
        bool ignorarHist = CheckBoxRejeitadas.Checked;

        
        string termos = TextBox1.Text;

        if (termos != "")
        {
            List<Link> resultado = 
                 search.efectuaPesquisa(termos, flagTodosTermos, ignorarHist);
            
            if (resultado.Count() > 0)
            {
                ListView1.DataSource = resultado;
                ListView1.DataBind();
            }
            else
            {
                LabelResultados.Text = "Não foram encontrados resultados";
            }
        }
        else
        {
            LabelResultados.Text = "Não introduziu termos de pesquisa";
        }
    }

    #endregion

    public void CheckBoxHeader_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkHeader = sender as CheckBox;
        for (int i = 0; i < ListView1.Items.Count; i++)
        {
            CheckBox chk = ListView1.Items[i].FindControl("chkSelect") as CheckBox;
            chk.Checked = chkHeader.Checked;
        }
    }
    
    #region Funcoes para apagar
    /*
    protected void firstRun()
    {
        PesquisaBing bing = new PesquisaBing();
        string termos = TextBox1.Text;

        Spider spider = new Spider();

        if (termos != "")
        {
            List<Link> tempLinks = bing.search(termos, 20);
            List<Uri> links = new List<Uri>();

            foreach (Link link in tempLinks)
            {
                links.Add(new Uri(link.LinkContent));
            }

            spider.run(termos, links);

            listaLinks = spider.Paginas;
        }
    }
    */
    /* Funcao executada quando a listView e' carregada de elementos
     * neste caso preenche a dropDownlist*/
    /*
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

    */
    /*
    protected void DataPager1_PreRender(object sender, EventArgs e)
    {
        BindListView();
    }
    */

    /*
        PesquisaBing bing = new PesquisaBing();
        string termos = TextBox1.Text;
        List<Link> tempLinks = bing.search(termos, 20);
        
        Spider spider = new Spider();

        if (termos != "")
        {
            List<Link> tempLinks = bing.search(termos, 5);
            List<Uri> links = new List<Uri>();

            foreach (Link link in tempLinks)
            {
                links.Add(new Uri(link.LinkContent));
            }

            spider.run(termos, links);

            List<Link> list = spider.Paginas;
        */
    //ListView1.DataSource = list;
    //    ListView1.DataSource = tempLinks;
    //    ListView1.DataBind();

    //}

    //PesquisaBing bing = new PesquisaBing();
    //string termos = TextBox1.Text;
    //List<Link> links = bing.search(termos, 1);

    //Spider sp = new Spider();

    //        Spider.Run();

    //if (termos != "")
    //{
    //    List<Link> links = bing.search(termos, 1);
    //    List<Link> resultado = new List<Link>();

    //    Label1.Text = links[0].LinkContent;
    //    Uri uri = new Uri(links[0].LinkContent);

    //    IEnumerable<WebPage> pages = WebPage.GetAllPagesUnder(uri);

    //    List<WebPage> listPages = new List<WebPage>(pages);

    //    foreach (WebPage p in listPages)
    //    {
    //        WebClient client = new WebClient();
    //        Label1.Text = p.Url.ToString();
    //        //String htmlCode = client.DownloadString(p.Url);
    //        String htmlCode = "bananas";

    //        if (htmlCode.IndexOf(termos) == -1)
    //        {
    //            //Label1.Text += p.Url.ToString() + " Cool <br />";
    //        }
    //        else
    //        {
    //            Link temp = new Link(p.Url.ToString(), "Teste");
    //            resultado.Add(temp);
    //        }   
    //    }

    //    ListView1.DataSource = links;
    //    ListView1.DataBind();
    //    }
    #endregion
}