using System;
using System.Windows;
using System.Windows.Media;

namespace MTGCards.gui.Services.Cards.Helpers;

internal static class CardAdapterColorHelper
{
    private static readonly Color _noColor = Colors.DarkGray;

    private static readonly Color[] _availableColors = 
    {
        Colors.White,
        Colors.DarkBlue,
        Colors.DarkRed,
        Colors.Black,
    };
    
    public static Brush GetBorderColorForAdapter()
    {
        var rand = new Random();
        var cardColorNumber = rand.Next(_availableColors.Length);
        if (cardColorNumber == 0)
        {
            return new SolidColorBrush(_noColor);
        }

        if (cardColorNumber == 1)
        {
            var index = rand.Next(_availableColors.Length - 1);
            return new SolidColorBrush(_availableColors[index]);
        }

        var gradientStops = GetGradientStops(cardColorNumber);
        return new LinearGradientBrush
        {
            StartPoint = new Point(0,0),
            EndPoint = new Point(1,1),
            GradientStops = gradientStops
        };
    }

    private static GradientStopCollection GetGradientStops(int nb)
    {
        var rand = new Random();
        var grads = new GradientStopCollection(nb);

        if (nb == 2)
        {
            var firstIndex = rand.Next(4);
            var secondIndex = rand.Next(4); 
            while (secondIndex == firstIndex)
            {
                secondIndex = rand.Next(4);
            }
            
            grads.Add(new GradientStop(_availableColors[firstIndex], 0));
            grads.Add(new GradientStop(_availableColors[secondIndex], 1));
        }

        if (nb == 3)
        {
            var firstIndex = rand.Next(4);
            var secondIndex = rand.Next(4);
            while (secondIndex == firstIndex)
            {
                secondIndex = rand.Next(4);
            }
            var thirdIndex = rand.Next(4);
            while (thirdIndex == firstIndex || thirdIndex == secondIndex)
            {
                thirdIndex = rand.Next(4);
            }
            
            grads.Add(new GradientStop(_availableColors[firstIndex], 0));
            grads.Add(new GradientStop(_availableColors[secondIndex], 0.5));
            grads.Add(new GradientStop(_availableColors[thirdIndex], 1));
        }

        if (nb == 4)
        {
            grads.Add(new GradientStop(_availableColors[0], 0));
            grads.Add(new GradientStop(_availableColors[1], 0.25));
            grads.Add(new GradientStop(_availableColors[2], 0.75));
            grads.Add(new GradientStop(_availableColors[3], 1));
        }

        return grads;
    }
}