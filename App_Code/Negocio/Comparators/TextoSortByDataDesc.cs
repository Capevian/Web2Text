using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoSortByDataDesc
/// </summary>
public class TextoSortByDataDesc : IComparer<TextoEdit>
{
    #region IComparer<TextoEdit> Members

    public int Compare(TextoEdit x, TextoEdit y)
    {
        if (DateTime.Compare(x.DtMod, y.DtMod) == 1) return -1;
        else
        {
            if (DateTime.Compare(x.DtMod, y.DtMod) == 0) return 0;
            else return 1;
        }
    }

    #endregion
	
}