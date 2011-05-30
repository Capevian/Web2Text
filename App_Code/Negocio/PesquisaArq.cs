using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Text.RegularExpressions;

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

        // Este IF cria um objecto com a mensagem de que não há resultados na pesquisa.
        if ((String.Compare(tituloAux, "") == 0) && (String.Compare(texAux, "") == 0))
        {
            zonaPalavra = "<center>A sua pesquisa não obteve qualquer resultado.</center>";
        }
        else
        {
            zonaPalavra = encontraPalavra();
        }
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
        int nPalavras = 50;
        
        string textoAux;
        string[] palavrasFinais = new String[nPalavras];

        // Remove os \n substituindo-os por espaços
        textoAux = tex.Replace(Environment.NewLine, " ");

        // Obtém um array de palavras
        //string[] palavras = Regex.Split(textoAux, "\r\n ");
        string[] palavras = textoAux.Split(' ');

        // Obtém um array com todos os termos da pesquisa
        string[] listaTermos = termos.Split(' ');

        // Obtém o tamanho do array palavras
        int tamanhoArray = palavras.Length;

        //Faz o acerto para os textos que tenham menos de 20 palavras
        if (tamanhoArray < 20){nPalavras = tamanhoArray;}

        // Encontra a primeira ocurencia de uma das palavras e guarda-a em i
        int i = getPosicao(listaTermos,palavras);

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
                    palavrasFinais[j] = String.Copy(palavras[tamanhoArray + j - nPalavras]);
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

        // Forma a string final com as 20 palavras para ser retornada
        StringBuilder textoFinal = new StringBuilder();
        bool encontrou = false;
        for (int x = 0; x < nPalavras; x++)
        {
            foreach (string t in listaTermos)
            {
                if (String.Compare(palavrasFinais[x], t, true) == 0)
                {
                    encontrou = true;
                }
            }
            if (encontrou)
            {
                textoFinal.Append("<i><font color=\"#FF8C00\">");
                textoFinal.Append(palavrasFinais[x]);
                textoFinal.Append("</font></i>");
            }
            else
            {
                textoFinal.Append(palavrasFinais[x]);
            }
            textoFinal.Append(" ");
            encontrou = false;
        }
        return textoFinal.ToString();
    }

    // Função que retorna a primeira ocurrencia de uma das palavras pesquisadas
    private int getPosicao(string[] termos, string[] texto)
    {
        int i = 0;

        foreach (string palavra in texto)
        {
            foreach (string t in termos)
            {
                if (String.Compare(palavra, t, true) == 0)
                    return i;
            }
            i++;
        }
        return i;
    }
}