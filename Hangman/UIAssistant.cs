using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Hangman
{
    public static class UIAssistant
    {
        public static IEnumerable<T> GetVisualChildren<T>(DependencyObject ancestor, string tag) where T : DependencyObject
        {
            int count = VisualTreeHelper.GetChildrenCount(ancestor);
            for (int i = 0; i < count; i++)
            {
                DependencyObject element = VisualTreeHelper.GetChild(ancestor, i);
                if (element is T type && Convert.ToString(((FrameworkElement)element).Tag) == tag)
                {
                    yield return (T)element;
                }
                foreach (T other in GetVisualChildren<T>(element, tag))
                {
                    yield return other;
                }
            }
        }
    }
}
