using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NT.Gui
{
    public static class Extensions
    {
        public static void ReplaceWith<T>(this ObservableCollection<T> observableCollection, IEnumerable<T> collection)
        {
            if(collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            observableCollection.Clear();
            foreach(T item in collection)
            {
                observableCollection.Add(item);
            }
        }

        public static Exception GetOriginalException(this Exception ex)
        {
            return ex.InnerException == null ? ex : ex.InnerException.GetOriginalException();
        }
    }
}