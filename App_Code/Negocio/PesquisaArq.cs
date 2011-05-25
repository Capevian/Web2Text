using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for PesquisaArq
/// </summary>
public class PesquisaArq
{
    private string termos;
    private int idT;
    private string titulo;
    private string tex;
    private string zonaPalavra;
    private string rank;

	public PesquisaArq(string termosAux, int idTAux, string tituloAux, string texAux, string rankAux) 
    {
        termos = termosAux;
        idT = idTAux;
        titulo = tituloAux;
        tex = texAux;
        rank = rankAux;
        zonaPalavra = encontraPalavra();
	}
    public int PesqArqIdT
    {
        get { return idT; }
        set { idT = value; }
    }
    public string PesqArqTitulo
    {
        get { return titulo; }
        set { titulo = value; }
    }
    public string PesqArqTex
    {
        get { return tex; }
        set { tex = value; }
    }
    public string PesqArqRank
    {
        get { return rank; }
        set { rank = value; }
    }
    public string PesqArqZonaPalavra
    {
        get { return zonaPalavra; }
        set { zonaPalavra = value; }
    }
    public string encontraPalavra()
    {
        //Numero que define quantas palavras devem estar no preview
        //Deve ter sempre um numero par
        int nPalavras = 20;
        
        string textoAux;
        int i=0;
        string[] palavrasFinais = new String[nPalavras];

        // Remove os \n substituindo-os por espaços
        textoAux = tex.Replace(Environment.NewLine, " ");

        // Obtém um array de palavras
        string[] palavras = textoAux.Split(' ');

        // Obtém o tamanho do array palavras
        int tamanhoArray = palavras.Length;

        // Encontra a primeira ocurencia da palavra e fica com a posicao em i
        foreach(string palavra in palavras)
        {
            if(string.Compare(palavra,termos,true)==0) break;
            i++;
        }

        // Preenche string[20] com as 20 palavras mais próximas.
        if ((i < nPalavras/2) || (i+nPalavras/2 > tamanhoArray))
        {
            if (i < nPalavras/2)
            {
                for (int j = 0; j < nPalavras; j++)
                {
                    palavrasFinais[j] = String.Copy(palavras[j]);
                }
            }
            else
            {
                for (int j = 0; j < nPalavras; j++)
                {
                    palavrasFinais[j] = String.Copy(palavras[tamanhoArray + j - 20]);
                }
            }
        }
        else
        {
            for (int j = 0; j < nPalavras; j++)
            {
                palavrasFinais[j] = String.Copy(palavras[i + j - nPalavras/2]);
            }
        }

        // Forma a string final com as 20 palavras para ser returnada
        StringBuilder textoFinal = new StringBuilder();
        for(int x=0; x<nPalavras; x++)
        {
            textoFinal.Append(palavrasFinais[x]);
            textoFinal.Append(" ");
        }

        return textoFinal.ToString();
    }
}