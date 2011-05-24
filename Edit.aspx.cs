﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    private TextoEdit txt;
    private EdicaoBLL edi;

    protected void Page_Load(object sender, EventArgs e)
    {
        LabelTitulo.Attributes.Add("onclick", "ShowEditBox();");
        ButtonUpdate.Attributes.Add("onclick", "SaveEditBox();");
        ButtonClose.Attributes.Add("onclick", "HideEditBox();");

        LabelTitulo.Text = HiddenField1.Value;
        // verifica qual o id passado para saber
        // qual o texto que deve apresentar
        string id = Request.QueryString["id"];

        edi = new EdicaoBLL();

        // Descarrega da Base de Dados o texto com o id passado na QueryString
        txt = edi.getTexto(Convert.ToInt32(id));

        // Altera o titulo da pagina
        this.Title = "Web2Text : " + txt.Titulo;

        // Altera titulo do texto em vizualizacao
        if (!IsPostBack) 
        { 
            LabelTitulo.Text = txt.Titulo;
            HiddenField1.Value = txt.Titulo;
        }

        // Altera conteudo da Area de texto
        TextBox1.Text = txt.TextContent;

        // Detalhes do texto
        labelUser.Text = txt.User;
        labelDtMod.Text = txt.DtMod.ToString();
        linkWWW.NavigateUrl = txt.Link;
        labelDtAcess.Text = txt.DtAcesso.ToString();

        // Tooltips icons
        //dlButton.ToolTip = "Download";    
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

    protected void limparHTML()
    {
        string s = txt.limpaTexto(TextBox1.Text);
        TextBox1.Text = s;
    }

    protected void guardarAlteracoes()
    {
        // Username a rever...
        edi.saveTexto(txt.IdTexto,TextBox1.Text,LabelTitulo.Text);
    }

    protected void arquivarTexto()
    {
        /* !!!TO BE DONE!!! */
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
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        arquivarTexto();
    }
}