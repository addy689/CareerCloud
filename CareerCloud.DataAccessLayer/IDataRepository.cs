using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel;

namespace CareerCloud.DataAccessLayer
{
    public interface IDataRepository<T>
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        void Add(params T[] items);
        void Update(params T[] items);
        void Remove(params T[] items);
        void CallStoredProc(string name, params Tuple<string, string>[] parameters);
        IList<T> GetAllSorted<TKey>(params Tuple<Func<T, TKey>, ListSortDirection>[] orderProperties);
        IList<T> GetSearchResults<TKey>(Func<T, bool> where, params Tuple<Func<T, TKey>, ListSortDirection>[] orderProperties);
    }
}
