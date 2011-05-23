using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link
{
    private string link;
    private string desc;
    
    public Link(string s, string d)
	{
        link = s;
        desc = d;
	}
    public string LinkContent
    {
        get { return link; }
        set { link = value; }        
    }
    public string LinkDesc
    {
        get { return desc; }
        set { desc = value; }
    }
}