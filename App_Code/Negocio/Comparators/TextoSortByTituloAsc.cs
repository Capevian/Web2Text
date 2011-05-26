using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoEditSortByTituloDesc
/// </summary>
public class TextoSortByTituloAsc : IComparer<TextoEdit>
{
    #region IComparer<TextoEdit> Members

    public int Compare(TextoEdit x, TextoEdit y)
    {
        return(string.Compare(x.Titulo, y.Titulo));
    }

    #endregion
}