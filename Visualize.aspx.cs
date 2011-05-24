using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Visualize : System.Web.UI.Page
{
    private TextoArq txt = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        // verifica qual o id passado para saber
        // qual o texto que deve apresentar
        string id = Request.QueryString["id"];

        ArquivoBLL arquivo = new ArquivoBLL();

        // Descarrega da Base de Dados o texto com o id passado na QueryString
        txt = arquivo.getTexto(Convert.ToInt32(id));

        // Altera o titulo da pagina
        this.Title = "Web2Text : " + txt.Titulo;

        // Altera titulo do texto em vizualizacao
        LabelTitulo.Text = txt.Titulo;
        
        // Altera conteudo da Area de texto
        TextBox1.Text = txt.TextContent;
        TextBox1.ReadOnly = true;

        // Detalhes do texto
        labelUser.Text = txt.User;
        labelData.Text = txt.DataArq.ToString();
        linkWWW.NavigateUrl = txt.Link;

        dlButton.ToolTip = "Download";
        

        //TextBox1.Attributes.Add("onFocus", "setbg('"+TextBox1.ClientID+"','white');");
        //TextBox1.Attributes.Add("onBlur", "setbg('" + TextBox1.ClientID + "','#E1E1E1');");
    }

    protected void downloadFile()
    {
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment; filename=ficheiro.txt");
        Response.Flush();
        Response.Write(TextBox1.Text);
        Response.End();
    }

    protected void moveEdicao()
    {
        /* !!!! TO DO !!!!! */
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        downloadFile();
    }
    protected void LinkDownload_Click(object sender, EventArgs e)
    {
        downloadFile();
    }
    protected void LinkEdit_Click(object sender, EventArgs e)
    {
        moveEdicao();
    }
    protected void edButton_Click(object sender, ImageClickEventArgs e)
    {
        moveEdicao();
    }
}