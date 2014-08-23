using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAndQueries
{
    public class SessionFactory
    {
        private static NHibernate.ISessionFactory sFactory;

        public static string DatabaseName { get; set; }
        public static string DatabaseHost { get; set; }
        public static string DatabaseUser { get; set; }
        public static string DatabasePassword { get; set; }
        public static string DatabaseType { get; set; }
        public static string AssemblyName { get; set; }

        public SessionFactory(string DBName, string DBHost, string DBType, string DBUser, string DBPassword, string ProjectName)
        {
            DatabaseName = DBName;
            DatabaseHost = DBHost;
            DatabaseUser = DBUser;
            DatabasePassword = DBPassword;
            DatabaseType = DBType;
            AssemblyName = ProjectName;
        }

        public static void Init()
        {
            try
            {


                if (DatabaseType == DBTYPE.MySql.ToString())
                {
                    var ConfigurationString = MySQLConfiguration.Standard.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                    sFactory = sFactory = Fluently.Configure().Database(ConfigurationString)
                      .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                      .BuildSessionFactory();

                    //Fluently.Configure()
                    //            .Database(ConfigurationString)
                    //            .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)).Conventions.Add(
                    //             ForeignKey.Format((x, y) =>
                    //             String.Concat(y.Name, "Id"))))
                    //            .BuildSessionFactory();

                }
                else if (DatabaseType == DBTYPE.MsSql2005.ToString())
                {
                    var ConfigurationString = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                    sFactory = Fluently.Configure().Database(ConfigurationString)
                      .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                      .BuildSessionFactory();
                }
                else if (DatabaseType == DBTYPE.MsSql2008.ToString())
                {
                    var ConfigurationString = MsSqlConfiguration.MsSql2008.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                    sFactory = Fluently.Configure().Database(ConfigurationString)
                      .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                      .BuildSessionFactory();
                }
                else if (DatabaseType == DBTYPE.MsSql2012.ToString())
                {
                    var ConfigurationString = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                    sFactory = Fluently.Configure().Database(ConfigurationString)
                      .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                      .BuildSessionFactory();
                }
                else if (DatabaseType == DBTYPE.Oracle.ToString())
                {

                }
                else if (DatabaseType == DBTYPE.PostGreSql.ToString())
                {

                }
                else if (DatabaseType == DBTYPE.SqlLite.ToString())
                {

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static NHibernate.ISessionFactory GetSessionFactory()
        {
            if (sFactory == null)
            {
                if (!string.IsNullOrEmpty(DatabaseType))
                {
                    if (!string.IsNullOrEmpty(DatabaseHost))
                    {
                        if (!string.IsNullOrEmpty(DatabaseName))
                        {
                            if (!string.IsNullOrEmpty(DatabaseUser))
                            {
                                Init();
                            }
                            else
                            {
                                throw new Exception("Database UserName is not Defined");
                            }
                        }
                        else
                        {
                            throw new Exception("Database Name is not Defined");
                        }
                    }
                    else
                    {
                        throw new Exception("Database Host is not Defined");
                    }
                }
                else
                {
                    throw new Exception("Database Type is not Defined");
                }
            }
            return sFactory;
        }

        public static NHibernate.ISession GetNewSession()
        {
            return GetSessionFactory().OpenSession();
        }

        public static NHibernate.IStatelessSession GetNewStateLessSession()
        {
            return GetSessionFactory().OpenStatelessSession();
        }
        public static void CloseSession()
        {
            GetSessionFactory().Close();
            sFactory.Close();
            sFactory = null;
        }


    }

    public enum DBTYPE
    {
        MySql,
        MsSql2005,
        MsSql2008,
        MsSql2012,
        Oracle,
        PostGreSql,
        SqlLite
    }
}
