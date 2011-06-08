using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    private TextoEdit txt;
    private EdicaoBLL edi = new EdicaoBLL();

    protected void Page_Load(object sender, EventArgs e)
    {
        // Funcoes Javascript para alterar o titulo
        LabelTitulo.Attributes.Add("onclick", "ShowEditBox();");
        ButtonUpdate.Attributes.Add("onclick", "SaveEditBox();");
        ButtonClose.Attributes.Add("onclick", "HideEditBox();");
        
        LabelTitulo.Text = HiddenField1.Value;

        // verifica qual o id passado para saber
        // qual o texto que deve apresentar
        string id = Request.QueryString["id"];

        // Descarrega da Base de Dados o texto com o id passado na QueryString
        txt = edi.getTexto(Convert.ToInt32(id));

        // Altera o titulo da pagina
        this.Title = "Web2Text : " + txt.Titulo;

        // Se nao foi feito um PostBack da pagina
        // (ou seja quando se entra na pagina pela primeira vez )
        if (!IsPostBack) 
        {
            // Altera titulo do texto em vizualizacao
            LabelTitulo.Text = txt.Titulo;
            HiddenField1.Value = txt.Titulo;

            // Altera conteudo da Area de texto
            TextBox1.Text = txt.TextContent;
            
            // Detalhes do texto
            labelUser.Text = txt.User;
            labelDtMod.Text = txt.DtMod.ToString();
            linkWWW.NavigateUrl = txt.Link;
            labelDtAcess.Text = txt.DtAcesso.ToString();
        }
    }

    #region Download do conteudo do texto
    protected void downloadFile()
    {
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AppendHeader("content-disposition", "attachment; filename=ficheiro.txt");
        Response.Flush();
        Response.Write(TextBox1.Text);
        Response.End();
    }
    #endregion

    #region Limpar o HTML do texto
    protected void limparHTML()
    {
        string s = txt.limpaTexto(TextBox1.Text);
        TextBox1.Text = s;
    }
    #endregion


    protected void guardarAlteracoes()
    {
        string username = System.Web.HttpContext.Current.User.Identity.Name;
        edi.saveTexto(txt.IdTexto,TextBox1.Text,LabelTitulo.Text,username);
    }

    protected void arquivarTexto()
    {
        string username = System.Web.HttpContext.Current.User.Identity.Name;
        edi.archiveTexto(txt.IdTexto, TextBox1.Text, LabelTitulo.Text,username);
        Response.Redirect("Arquivo.aspx");
    }
  
    protected void dlButton_Click(object sender, ImageClickEventArgs e)
    {
        downloadFile();
    }

    protected void linkDownload_Click(object sender, EventArgs e)
    {
        downloadFile();
    }

    protected void LinkLimparHTML_Click(object sender, EventArgs e)
    {
        limparHTML();
    }
    protected void clButton_Click(object sender, ImageClickEventArgs e)
    {
        limparHTML();
    }
    protected void svButton_Click(object sender, ImageClickEventArgs e)
    {
        guardarAlteracoes();
    }
    protected void LinkGravar_Click(object sender, EventArgs e)
    {
        guardarAlteracoes();
    }
    protected void LinkArquivar_Click(object sender, EventArgs e)
    {
        arquivarTexto();
    }
    protected void arqButton_Click(object sender, ImageClickEventArgs e)
    {
        arquivarTexto();
    }

    protected void LinkSair_Click(object sender, EventArgs e)
    {
        Response.Redirect("Edicao.aspx");
    }

    protected void sairButton_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Edicao.aspx");
    }
}