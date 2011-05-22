using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    private TextoEdit txt = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        // verifica qual o id passado para saber
        // qual o texto que deve apresentar
        string id = Request.QueryString["id"];

        EdicaoBLL arquivo = new EdicaoBLL();

        // Descarrega da Base de Dados o texto com o id passado na QueryString
        //txt = arquivo.getTexto(Convert.ToInt32(id));

        // Altera o titulo da pagina
        this.Title = "Web2Text : " + txt.Titulo;

        // Altera titulo do texto em vizualizacao
        LabelTitulo.Text = txt.Titulo;

        // Altera conteudo da Area de texto
        TextBox1.Text = txt.TextContent;
        TextBox1.ReadOnly = true;

        // Detalhes do texto
        labelUser.Text = txt.User;
        //labelData.Text = txt..ToString();
        linkWWW.NavigateUrl = txt.Link;

        dlButton.ToolTip = "Download";
    }
}