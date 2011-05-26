using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoSortByTitulo
/// </summary>
public class TextoSortByTituloDesc : IComparer<Texto>
{
    #region IComparer<TextoEdit> Members

    public int Compare(Texto x, Texto y)
    {
        if (string.Compare(x.Titulo, y.Titulo) == 1) return -1;
        else
        {
            if (string.Compare(x.Titulo, y.Titulo) == 0) return 0;
            else return 1;
        }        
    }

    #endregion
}