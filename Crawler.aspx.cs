using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crawler : System.Web.UI.Page
{
    LoginDAL login = new LoginDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        string user = System.Web.HttpContext.Current.User.Identity.Name;

        if (!IsPostBack)
        {
            int[] defs = new int[3];
            defs = login.getDefinicoes(user);

            TextBoxNlinks.Text = defs[0].ToString();
            TextBoxDepth.Text = defs[1].ToString();

            if (defs[2] == 0)
                RadioButtonList1.Items[0].Selected = true;
            else
                RadioButtonList1.Items[1].Selected = true;
        }
    }

    protected void ButtonGravar_Click(object sender, EventArgs e)
    {
        string user = System.Web.HttpContext.Current.User.Identity.Name;

        int modoPesquisa = Convert.ToInt32(RadioButtonList1.SelectedItem.Value);
        /*** ATENCAO: FALTA VERIFICAR SE A CAIXA DE TEXTO TEM INT ***/
        int nLinks = Convert.ToInt32(TextBoxNlinks.Text);
        int depth = Convert.ToInt32(TextBoxDepth.Text);
        
        login.setDefinicoes(user, nLinks, depth, modoPesquisa);
        Response.Redirect("Default.aspx");
    }
}