using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO; 


public class SimpleCrawler
{

    public static void Main(string[] args)
    {
        string Mylink = null;
        string Mystr;
        string answer;

        int curPoint;
        if (args.Length != 1)
        {
            Console.WriteLine("Please use proper URL");
            return;
        }

        string Myuristr = args[0];

        try
        {

            do
            {
                
                Console.WriteLine("Connecting to " + Myuristr);

                HttpWebRequest MyHttpWebRequest = (HttpWebRequest)
                WebRequest.Create(Myuristr);
                Myuristr = null;
                HttpWebResponse MyHttpWebResponse = (HttpWebResponse)
                MyHttpWebRequest.GetResponse();

                
                Stream MyInputString = MyHttpWebResponse.GetResponseStream();

                StreamReader MyStreamReader = new StreamReader(MyInputString);

                string Mystring = MyStreamReader.ReadToEnd();

                curPoint = 0;

                do
                {

                    Mylink = FindMyLink(Mystring, ref curPoint);
                    if (Mylink != null)
                    {
                        Console.WriteLine("Found the link :  " + Mylink);
                        Console.Write("Link, More, Quit?");
                        answer = Console.ReadLine();

                        if (string.Compare(answer, "L", true) == 0)
                        {
                            Myuristr = string.Copy(Mylink);
                            break;
                        }
                        else if (string.Compare(answer, "Q", true) == 0)
                        {
                            break;
                        }
                        else if (string.Compare(answer, "M", true) == 0)
                        {
                            Console.WriteLine("Searching for another link.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No link found.");
                        break;
                    }

                } while (Mylink.Length > 0);


                MyHttpWebResponse.Close();
            } while (Myuristr != null);

        }
        catch (Exception exc)
        {
            Console.WriteLine(exc.Message);
        }
        Console.WriteLine("Terminating Sample Crawler.");
    }

    static string FindMyLink(string MyHtmlstr,
                           ref int MystartPoint)
    {
        int startPoint, endPoint;
        string Myuri = null;
        string Mylowcasestr = MyHtmlstr.ToLower();
        int i = Mylowcasestr.IndexOf("href=\"http", MystartPoint);
        if (i != -1)
        {
            startPoint = MyHtmlstr.IndexOf('"', i) + 1;
            endPoint = MyHtmlstr.IndexOf('"', startPoint);
            Myuri = MyHtmlstr.Substring(startPoint, endPoint - startPoint);
            MystartPoint = endPoint;
        }

        return Myuri;
    }

}
