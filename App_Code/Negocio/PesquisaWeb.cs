﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using net.live.search.api;

/// <summary>
/// Summary description for PesquisaWeb
/// </summary>
public class PesquisaWeb
{
    private uint nLinksRes = 40;
    private uint nLinksSeed;
    private int profundidade;
    private int modoPesquisa;
    private HistoricoBLL histBLL;
    private LoginDAL log;
    private Spider spider;

	public PesquisaWeb(string username)
	{
        log = new LoginDAL();
        histBLL = new HistoricoBLL();
        spider = new Spider();

        int[] defs = log.getDefinicoes(username);

        this.nLinksSeed = Convert.ToUInt32(defs[0]);
        this.profundidade = defs[1];
        this.modoPesquisa = defs[2];
	}

    public List<Link> efectuaPesquisa(string termos, bool flagTodosTermos, bool ignorarHist)
    {
        List<Link> temp = new List<Link>();

        switch (modoPesquisa)
        {
            case 0:
                temp = this.procuraBing(termos, nLinksRes, flagTodosTermos);
                break;
            case 1:
                temp = this.procuraCrawler(termos, flagTodosTermos);
                break;
            default:
                break;
        }

        return temp;
        /*
        List<Link> resultado = new List<Link>();
        List<Link> historico = histBLL.getHistorico();

        resultado = temp.Intersect(historico);
        return resultado;*/
    }

    #region funcao de pesquisa usando o crawler

    private List<Link> procuraCrawler(string query, bool flagTodosTermos)
    {               

        List<Link> tempLinks = this.procuraBing(query, nLinksSeed, flagTodosTermos);

        List<Uri> links = new List<Uri>();

        foreach (Link link in tempLinks)
        {
            links.Add(new Uri(link.LinkContent));
        }

        spider.pesquisa(query, links, flagTodosTermos);

        return spider.Paginas;
    }

    #endregion 

    #region funcao de pesquisa no Bing

    private List<Link> procuraBing(string query, uint nLinks, bool flagTodosTermos)
    {
        List<Link> list = new List<Link>();

        BingService service = new BingService();

        SearchRequest request = new SearchRequest();

        // Usar a AppID do Bing
        request.AppId = "FC90D229624ED0C50F60665F288516BD9FF1F40A";
        request.Query = query;

        //Conteudo Adulto Off
        request.Adult = AdultOption.Off;
        request.AdultSpecified = true;

        // Pesquisar fontes na web
        request.Sources = new SourceType[] { SourceType.Web };

        //Limitar numero de links
        request.Web = new WebRequest();
        request.Web.Count = nLinks;
        request.Web.CountSpecified = true;

        SearchResponse response = service.Search(request);

        foreach (WebResult result in response.Web.Results)
        {
            list.Add(new Link(result.Title, result.Url, result.Description));
        }
        return list;
    }

    #endregion
}