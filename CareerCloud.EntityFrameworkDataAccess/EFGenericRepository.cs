using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class EFGenericRepository<T> : IDataRepository<T>
        where T : class
    {
        private CareerCloudContext _context;

        public EFGenericRepository(bool createProxy = true)
        {
            _context = new CareerCloudContext(createProxy);
        }

        public void Add(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }

            _context.SaveChanges();
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigationProperty);
            }

            return dbQuery.AsNoTracking().ToList();
        }

        public IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigationProperty);
            }

            return dbQuery.AsNoTracking().Where(where).ToList();
        }

        public T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            IQueryable<T> dbQuery = _context.Set<T>();

            foreach (var navigationProperty in navigationProperties)
            {
                dbQuery = dbQuery.Include(navigationProperty);
            }

            return dbQuery.AsNoTracking().FirstOrDefault(where);
        }

        public void Remove(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Deleted;
            }

            _context.SaveChanges();
        }

        public void Update(params T[] items)
        {
            foreach (T item in items)
            {
                _context.Entry(item).State = EntityState.Modified;
            }

            _context.SaveChanges();
        }

        public IList<T> GetAllSorted<TKey>(params Tuple<Func<T, TKey>, ListSortDirection>[] orderProperties)
        {
            IList<T> result = GetAll();
            return SortResultData(result, orderProperties).ToList();
        }

        public IList<T> GetSearchResults<TKey>(Func<T, bool> where, params Tuple<Func<T, TKey>, ListSortDirection>[] orderProperties)
        {
            IList<T> searchResult = GetList(where);
            return SortResultData(searchResult, orderProperties).ToList();
        }

        /// <summary>
        /// Helper method for sorting a collection
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="result"></param>
        /// <param name="orderProperties"></param>
        /// <returns></returns>
        private IOrderedEnumerable<T> SortResultData<TKey>(IList<T> result, params Tuple<Func<T, TKey>, ListSortDirection>[] orderProperties)
        {
            IOrderedEnumerable<T> sortedResult = result as IOrderedEnumerable<T>;
            foreach (var orderProperty in orderProperties)
            {
                Func<T, TKey> keySelector = orderProperty.Item1;
                ListSortDirection order = orderProperty.Item2;

                switch (order)
                {
                    case ListSortDirection.Ascending:
                        sortedResult = sortedResult.ThenBy(keySelector);
                        break;

                    case ListSortDirection.Descending:
                        sortedResult = sortedResult.ThenByDescending(keySelector);
                        break;
                }
            }

            return sortedResult;
        }
    }
}
