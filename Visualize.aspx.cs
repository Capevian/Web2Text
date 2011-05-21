using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Visualize : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // verifica qual o id passado para saber
        // qual o texto que deve apresentar
        string id = Request.QueryString["id"];

        ArquivoBLL arquivo = new ArquivoBLL();

        // Descarrega da Base de Dados o texto com o id passado na QueryString
        TextoArq txt = arquivo.getTexto(Convert.ToInt32(id));

        // Altera o titulo da pagina
        this.Title = "Web2Text : " + txt.Titulo;

        // Altera titulo do texto em vizualizacao
        LabelTitulo.Text = txt.Titulo;
        
        // Altera conteudo da Area de texto
        TextBox1.Text = txt.TextContent;
        TextBox1.ReadOnly = true;

        //TextBox1.Attributes.Add("onFocus", "setbg('"+TextBox1.ClientID+"','white');");
        //TextBox1.Attributes.Add("onBlur", "setbg('" + TextBox1.ClientID + "','#E1E1E1');");
    }
}