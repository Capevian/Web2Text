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
        BindListView();
    }

    private void BindListView()
    {
        PesquisaBing bing = new PesquisaBing();
        string termos = TextBox1.Text;
        
        if (termos != "")
        {
            List<Link> links = bing.search(termos, 1);
            List<Link> resultado = new List<Link>();

            Label1.Text = links[0].LinkContent;
            Uri uri = new Uri(links[0].LinkContent);

            IEnumerable<WebPage> pages = WebPage.GetAllPagesUnder(uri);

            List<WebPage> listPages = new List<WebPage>(pages);

            foreach (WebPage p in listPages)
            {
                WebClient client = new WebClient();
                Label1.Text = p.Url.ToString();
                //String htmlCode = client.DownloadString(p.Url);
                String htmlCode = "bananas";

                if (htmlCode.IndexOf(termos) == -1)
                {
                    //Label1.Text += p.Url.ToString() + " Cool <br />";
                }
                else
                {
                    Link temp = new Link(p.Url.ToString(), "Teste");
                    resultado.Add(temp);
                }   
            }

            ListView1.DataSource = links;
            ListView1.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindListView();
    }
}