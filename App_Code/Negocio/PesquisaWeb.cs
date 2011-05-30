using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using net.live.search.api;

/// <summary>
/// Summary description for PesquisaWeb
/// </summary>
public class PesquisaWeb
{
    private uint nLinksRes = 100;
    private uint nLinksSeed = 10;
    private int profundidade = 2;
    private int modoPesquisa = 1;
    private HistoricoBLL histBLL; 

	public PesquisaWeb()
	{
        histBLL = new HistoricoBLL();
	}

    public List<Link> efectuaPesquisa(string termos, bool flagTodosTermos, bool ignorarHist)
    {
        List<Link> temp = new List<Link>();

        switch (modoPesquisa)
        {
            case 0:
                temp = procuraBing(termos, nLinksRes, flagTodosTermos);
                break;
            case 1:
                temp = procuraCrawler(termos, flagTodosTermos);
                break;
            default:
                break;
        }


        List<Link> resultado = new List<Link>();
        List<Link> historico = histBLL.getHistorico();

        // resultado = temp.Intersect(historico);

        return resultado;
    }

    public List<Link> procuraCrawler(string query, bool flagTodosTermos)
    {        
        Spider spider = new Spider();

        List<Link> tempLinks = this.procuraBing(query, nLinksSeed, flagTodosTermos);

        List<Uri> links = new List<Uri>();

        foreach (Link link in tempLinks)
        {
            links.Add(new Uri(link.LinkContent));
        }

        spider.run(query, links, flagTodosTermos);

        return spider.Paginas;
    }

    #region funcao de pesquisa no Bing

    public List<Link> procuraBing(String query, uint nLinks, bool flagTodosTermos)
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