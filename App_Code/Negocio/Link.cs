using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Link
/// </summary>
public class Link : IEquatable<Link>
{
    private string titulo;
    private string link;
    private string intro;

    public Link(string link)
    {
        this.titulo = "";
        this.link = link;
        this.intro = "";
    }
    
    public Link(string link, string intro)
	{
        this.titulo = "";
        this.link = link;
        this.intro = intro;
	}

    public Link(string titulo, string link, string intro)
    {
        this.titulo = titulo;
        this.link = link;
        this.intro = intro;
    }

    public string Titulo
    {
        get { return titulo; }
        set { titulo = value; }
    }

    public string LinkContent
    {
        get { return link; }
        set { link = value; }        
    }
    public string LinkDesc
    {
        get { return intro; }
        set { intro = value; }
    }

    public override bool  Equals(object obj)
    {        
        if (obj == null)
        {
            return false;
        }

        
        Link l = obj as Link;
        if ((System.Object)l == null)
        {
            return false;
        }

        //Check whether the compared object is null.
        if (Object.ReferenceEquals(l, null)) return false;

        //Check whether the compared object references the same data.
        if (Object.ReferenceEquals(this, l)) return true;

        //return (this.link == l.LinkContent);
             // && (this.titulo == l.titulo) && 
             //(this.intro == l.LinkDesc);
        return base.Equals(l);
    }

    public bool Equals(Link l)
    {
        return (this.link == l.LinkContent);
    }

    public override int GetHashCode()
    {

        //Get hash code for the Name field if it is not null.
        int hashLinkContent = LinkContent == null ? 0 : LinkContent.GetHashCode();

        //Get hash code for the Code field.
        //int hashProductCode = Code.GetHashCode();

        //Calculate the hash code for the product.
        //return hashProductName ^ hashProductCode;
        return hashLinkContent;
    }
    
}