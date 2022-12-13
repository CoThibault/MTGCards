using System;
using System.Collections.Generic;
using MTGCards.gui.Adapters;

namespace MTGCards.gui.Services.Cards.Helpers;

internal static class CardSearchHelper
{
    public static IReadOnlyCollection<string> GetSplitParts(string searchFilter)
    {
        return searchFilter.Split(" ");
    }

    public static bool FilterNames(object item, string filter)
    {
        if (item is ICardAdapter cardAdapter)
        {
            if (cardAdapter.CardName.ToLower().Contains(filter.ToLower()))
            {
                return true;
            }
        }
        return false;
    }
}