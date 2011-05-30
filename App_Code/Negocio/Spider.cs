using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Globalization;
using System.Text.RegularExpressions;

using NCrawler;
using NCrawler.Extensions;
using NCrawler.HtmlProcessor;
using NCrawler.LanguageDetection.Google;
using NCrawler.Interfaces;
//using NCrawler.MP3Processor;
using NCrawler.Services;

/// <summary>
/// Summary description for Spider
/// </summary>
public class Spider
{
    public static IFilter[] ExtensionsToSkip = new[]
			{
				(RegexFilter)new Regex(@"(\.jpg|\.css|\.js|\.gif|\.jpeg|\.png|\.ico)",
					RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase)
			};

    private  List<Link> paginas = new List<Link>();

	public Spider()
	{
		
	}

    public void pesquisa(string termo, List<Uri> seeds, bool flagTodosTermos)
    {
        NCrawlerModule.Setup();
            // Setup crawler to crawl http://ncrawler.codeplex.com
			// with 1 thread adhering to robot rules, and maximum depth
			// of 2 with 4 pipeline steps:
			//	* Step 1 - The Html Processor, parses and extracts links, text and more from html
			//  * Step 2 - Processes PDF files, extracting text
			//  * Step 3 - Try to determine language based on page, based on text extraction, using google language detection
			//  * Step 4 - Dump the information to the console, this is a custom step, see the DumperStep class
        using (Crawler c = new Crawler(
                //new Uri("http://forcaavense.com/"),
                seeds[0],
                new AddUrls(seeds),
				new HtmlDocumentProcessor(), // Process html
				new GoogleLanguageDetection(), // Add language detection
				//new Mp3FileProcessor(),
				//new DumperStep(),
                new Web2TextStep(termo, paginas))
				{
                    AdhereToRobotRules = true,
                    
					// Custom step to visualize crawl
					MaximumThreadCount = 1,
					MaximumCrawlDepth = 5,
                    MaximumCrawlCount = 20,
					ExcludeFilter = ExtensionsToSkip,
                    
                    //ExcludeFilter = new IFilter[]
                    //{
                    //    new LambdaFilter((uri, crawlStep) => !uri.ToString().Contains(""));
                    //}
				})
			{
				// Begin crawl
				c.Crawl();
			}


    }

    public List<Link> Paginas
    {
        get { return paginas; }
        set { paginas = value; }
    }
}
    internal class Web2TextStep : IPipelineStep
    {
        private string ContentToBeFound;
        private List<Link> paginas;

        public void Process(Crawler crawler, PropertyBag propertyBag)
        {
            string text = propertyBag.Text;

            if (text.IsNullOrEmpty())
            {
                return;
            }

            if (text.IndexOf(ContentToBeFound) != -1)
            {
                paginas.Add(new Link(propertyBag.Step.Uri.ToString(),propertyBag.Step.Uri.ToString(), propertyBag.Text.Remove(100)));
            }
        }

        public Web2TextStep(string c, List<Link> pgs)
        {
            this.ContentToBeFound = c;
            this.paginas = pgs;
        }
    }

    internal class AddUrls : IPipelineStep
    {
        private List<Uri> seeds;

        public AddUrls(List<Uri> s)
        {
            this.seeds = s;
        }

        public void Process(Crawler crawler, PropertyBag propertyBag)
        {
            foreach (Uri uri in seeds)
            {
                crawler.AddStep(uri, 2);
            }
        }
    }

    //#region Nested type: DumperStep

    ///// <summary>
    ///// Custom pipeline step, to dump url to console
    ///// </summary>
    //internal class DumperStep : IPipelineStep
    //{
    //    #region IPipelineStep Members

    //    /// <summary>
    //    /// </summary>
    //    /// <param name="crawler">
    //    /// The crawler.
    //    /// </param>
    //    /// <param name="propertyBag">
    //    /// The property bag.
    //    /// </param>
    //    public void Process(Crawler crawler, PropertyBag propertyBag)
    //    {
    //        CultureInfo contentCulture = (CultureInfo)propertyBag["LanguageCulture"].Value;
    //        string cultureDisplayValue = "N/A";
    //        if (!contentCulture.IsNull())
    //        {
    //            cultureDisplayValue = contentCulture.DisplayName;
    //        }

    //        lock (this)
    //        {
    //            Console.Out.WriteLine(ConsoleColor.Gray, "Url: {0}", propertyBag.Step.Uri);
    //            Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent type: {0}", propertyBag.ContentType);
    //            Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent length: {0}", propertyBag.Text.IsNull() ? 0 : propertyBag.Text.Length);
    //            //Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tContent: {0}", propertyBag.Text);
    //            Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tDepth: {0}", propertyBag.Step.Depth);
    //            Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tCulture: {0}", cultureDisplayValue);
    //            Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tThreadId: {0}", System.Threading.Thread.CurrentThread.ManagedThreadId);
    //            Console.Out.WriteLine(ConsoleColor.DarkGreen, "\tThread Count: {0}", crawler.ThreadsInUse);
    //            Console.Out.WriteLine();
    //        }
    //    }

    //    #endregion
    //}

    //#endregion