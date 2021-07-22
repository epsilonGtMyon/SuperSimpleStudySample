using System;
using System.Linq;
using System.Collections.Generic;

namespace SuperSimpleStudySample.App.Commons.SelectItems
{
  public static class SelectItemFactory
  {


    public static List<SelectItem> AsSelectItem<T>(this IEnumerable<T> seq, Func<T, string> valueSelector, Func<T, string> textSelector)
    {
      return seq.Select(x => new SelectItem(valueSelector(x), textSelector(x))).ToList();
    }
  }
}