using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoSortByDataAsc
/// </summary>
public class TextoSortByDataAsc : IComparer<TextoEdit>
{
    #region IComparer<TextoEdit> Members

    public int Compare(TextoEdit x, TextoEdit y)
    {
        return (DateTime.Compare(x.DtMod, y.DtMod));
    }

    #endregion
}