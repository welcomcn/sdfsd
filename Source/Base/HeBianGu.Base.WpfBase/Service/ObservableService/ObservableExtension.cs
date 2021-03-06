﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeBianGu.Base.WpfBase
{
    public static class ObservableExtension
    {
        public static void Sort<TSource, TKey>(this Collection<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> sortedList = source.OrderBy(keySelector).ToList();
            source.Clear();
            foreach (var sortedItem in sortedList)
                source.Add(sortedItem);
        }

        public static void Sort<TSource, TKey>(this Collection<TSource> source, Func<TSource, TKey> keySelector, bool isdesc)
        {
            List<TSource> sortedList = isdesc ? source.OrderByDescending(keySelector).ToList() : source.OrderBy(keySelector).ToList();
            source.Clear();
            foreach (var sortedItem in sortedList)
                source.Add(sortedItem);
        }

        public static void SortDesc<TSource, TKey>(this Collection<TSource> source, Func<TSource, TKey> keySelector)
        {
            List<TSource> sortedList = source.OrderByDescending(keySelector).ToList();
            source.Clear();
            foreach (var sortedItem in sortedList)
                source.Add(sortedItem);
        }

        public static void Sort<T>(this ObservableCollection<T> collection) where T : IComparable
        {
            List<T> sortedList = collection.OrderBy(x => x).ToList();
            for (int i = 0; i < sortedList.Count(); i++)
            {
                collection.Move(collection.IndexOf(sortedList[i]), i);
            }
        }

        public static ObservableCollection<T> ToObservable<T>(this IEnumerable<T> collection)
        {

            //ObservableCollection<T> result = new ObservableCollection<T>();
            //foreach (var item in collection)
            //{
            //    result.Add(item);
            //}
            return new ObservableCollection<T>(collection);

        }

        public static void Refresh<T>(this ObservableCollection<T> collection)
        {

            //ObservableCollection<T> result = new ObservableCollection<T>();

            //foreach (var item in collection)
            //{
            //    result.Add(item);
            //}

            //collection = result;

            collection = new ObservableCollection<T>(collection);
        }


        public static void Foreach<T>(this ObservableCollection<T> collection, Action<T> action)
        {
            foreach (var item in collection)
            {
                action(item);
            }
        }
    }
}
