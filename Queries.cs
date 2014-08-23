using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;

namespace DatabaseAndQueries
{
    public class Queries
    {

        /// <summary>
        /// Inserts The Data Into Table Related To Class
        /// </summary>
        public static void Add<T>(T newobject)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(newobject);

                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        /// <summary>
        /// BulkInsertion Will Be Done On The Table Related To The Class
        /// </summary>
        public static void BulkInsert<T>(List<T> objList)
        {
            using (NHibernate.IStatelessSession session = SessionFactory.GetNewStateLessSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        int count = objList.Count();
                        session.SetBatchSize(count);

                        foreach (var item in objList)
                        {
                            session.Insert(item);
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves All The Data From Table Related to the Class
        /// </summary>
        public static List<T> GetAllData<T>()
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {

                    try
                    {
                        return session.CreateCriteria(typeof(T)).List<T>().ToList<T>();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves All The Data From Table 
        /// Related to the Class with Sorting Order
        /// Provided at the Time Of Calling
        /// </summary>
        public static List<T> GetAllDataWithOrder<T, K>(Expression<Func<T, K>> Sortorder, bool OrderByDescending)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (OrderByDescending)
                        {

                            return session.Query<T>().OrderByDescending(Sortorder).ToList<T>();
                        }
                        else
                        {
                            return session.Query<T>().OrderBy(Sortorder).ToList<T>();
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the Specified number of elements from the
        /// Specified Start
        /// </summary>
        public static List<T> GetAllDataWithOrderAndCount<T, K>(Expression<Func<T, K>> SortOrder, bool OrderByDescending, int StartCount, int MaxResults)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (OrderByDescending)
                        {

                            return session.Query<T>().OrderByDescending(SortOrder).Skip<T>(StartCount).Take<T>(MaxResults).ToList<T>();
                        }
                        else
                        {
                            return session.Query<T>().OrderBy(SortOrder).Skip<T>(StartCount).Take<T>(MaxResults).ToList<T>();
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Retrieves the Specified number of elements from the
        /// Specified Start with filteration 
        /// </summary>
        public static List<T> GetAllDataWithOrderConditionAndCount<T, K>(Expression<Func<T, bool>> Predicate, Expression<Func<T, K>> SortOrder, bool OrderByDescending, int StartCount, int MaxResults)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {

                        if (OrderByDescending)
                        {

                            return session.Query<T>().Where<T>(Predicate).OrderByDescending(SortOrder).Skip<T>(StartCount).Take<T>(MaxResults).ToList<T>();
                        }
                        else
                        {
                            return session.Query<T>().Where<T>(Predicate).OrderBy(SortOrder).Skip<T>(StartCount).Take<T>(MaxResults).ToList<T>();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Retrieve the Data from Table Related to Class With Filteration
        /// </summary>
        public static T GetDataByCondition<T>(Expression<Func<T, bool>> predicate)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        return session.Query<T>().Where(predicate).FirstOrDefault<T>();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }



        /// <summary>
        /// Retrieve All Data from Table Related to Class With Filteration
        /// </summary>
        public static List<T> GetAllByCondition<T>(Expression<Func<T, bool>> predicate)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        return session.Query<T>().Where(predicate).ToList<T>();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Retrieve All Data from Table Related to Class
        /// With Filteration with Sorting According to time of 
        /// Calling
        /// </summary>
        public static List<T> GetAllByConditionWithOrder<T, K>(Expression<Func<T, bool>> predicate, Expression<Func<T, K>> OrderPredicate, bool OrderByDescending)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        if (OrderByDescending)
                        {
                            return session.Query<T>().Where(predicate).OrderByDescending(OrderPredicate).ToList<T>();

                        }
                        else
                        {
                            return session.Query<T>().Where(predicate).OrderBy(OrderPredicate).ToList<T>();
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }

        }


        /// <summary>
        /// Delete the Elements from the Database 
        /// according to the Object
        /// </summary>
        public static void Delete<T>(T newObject)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(newObject);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Delete the Elements from the Database 
        /// by Filteration
        /// </summary>
        public static int Delete<T>(Expression<Func<T, bool>> predicate)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<T> obj = GetAllByCondition(predicate);
                        foreach (var item in obj)
                        {
                            session.Delete(item);
                        }
                        transaction.Commit();
                        return obj.Count;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Check whether the provided Condition is Exists or Not in Database
        /// </summary>
        public static bool IsExists<T>(Expression<Func<T, bool>> Predicate)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<T> _ListT = session.Query<T>().Where(Predicate).ToList<T>();
                        if (_ListT != null)
                        {
                            if (_ListT.Count > 0)
                                return true;
                            else
                                return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }



        /// <summary>
        /// Update the Particular Data in Table Related to the class
        /// </summary>
        public static void Update<A>(A newobject)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(newobject);
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
        /// <summary>
        /// Update the Particular Data in Table Related to the class
        /// with Filteration
        /// </summary>
        public static void UpdateWithCondition<T>(Expression<Func<T, bool>> predicate)
        {
            using (NHibernate.ISession session = SessionFactory.GetNewSession())
            {
                using (NHibernate.ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        List<T> _ListT = GetAllByCondition(predicate);
                        foreach (var item in _ListT)
                        {
                            session.Update(item);

                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
