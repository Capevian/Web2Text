using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoSortByDataAsc
/// </summary>
public class TextoSortByDataArqAsc : IComparer<TextoArq>
{
    #region IComparer<TextoEdit> Members

    public int Compare(TextoArq x, TextoArq y)
    {
        return (DateTime.Compare(x.DataArq, y.DataArq));
    }

    #endregion
}