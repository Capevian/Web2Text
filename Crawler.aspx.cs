using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Crawler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RadioButtonList1.Items[0].Selected = true;
    }

    protected void ButtonGravar_Click(object sender, EventArgs e)
    {
        int modoPesquisa = Convert.ToInt32(RadioButtonList1.SelectedItem.Value);
        /*** ATENCAO: FALTA VERIFICAR SE A CAIXA DE TEXTO TEM INT ***/
        int nLinks = Convert.ToInt32(TextBoxNlinks.Text);
        int depth = Convert.ToInt32(TextBoxDepth.Text);
    }
}