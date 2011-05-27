using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using net.live.search.api;

/// <summary>
/// Summary description for PesquisaBing
/// </summary>
public class PesquisaBing
{
    public List<Link> search(String query, uint nLinks)
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
            list.Add(new Link(result.Title, result.Url,result.Description));
        }
        return list;
    }

	public PesquisaBing()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}