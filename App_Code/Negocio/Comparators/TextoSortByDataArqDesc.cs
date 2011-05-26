using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TextoSortByDataArqDesc
/// </summary>
public class TextoSortByDataArqDesc : IComparer<TextoArq>
{
    #region IComparer<TextoEdit> Members

    public int Compare(TextoArq x, TextoArq y)
    {
        if (DateTime.Compare(x.DataArq, y.DataArq) == 1) return -1;
        else
        {
            if (DateTime.Compare(x.DataArq, y.DataArq) == 0) return 0;
            else return 1;
        }
    }

    #endregion
	
}