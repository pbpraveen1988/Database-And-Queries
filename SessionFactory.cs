using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAndQueries
{
    public class SessionFactory
    {

        private static NHibernate.ISessionFactory sFactory;
        public static string FilePath { get; set; }

        public static string DatabaseName { get; set; }
        public static string DatabaseHost { get; set; }
        public static string DatabaseUser { get; set; }
        public static string DatabasePassword { get; set; }
        public static string DatabaseType { get; set; }
        public static string AssemblyName { get; set; }
        public static string NameSpaceM { get; set; }
        public static bool AutoMapping { get; set; }

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

                if (!AutoMapping)
                {
                    switch (DatabaseType)
                    {
                        case "MySql":
                            var mysqlconfig = MySQLConfiguration.Standard.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(mysqlconfig)
                          .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                          .BuildSessionFactory();
                            break;

                        case "MsSql2005":
                            var ConfigurationString = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(ConfigurationString)
                              .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                              .BuildSessionFactory();
                            break;

                        case "MsSql2008":
                            var ConfigurationString1 = MsSqlConfiguration.MsSql2008.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(ConfigurationString1)
                              .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                              .BuildSessionFactory();
                            break;

                        case "MsSql2012":
                            var ConfigurationString2 = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(ConfigurationString2)
                              .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                              .BuildSessionFactory();
                            break;

                        case "Oracle": break;
                        case "PostGreSql": break;
                        case "SqlLite":
                            sFactory = Fluently.Configure()
                                         .Database(
                                         SQLiteConfiguration.Standard
                                         .UsingFile(FilePath))
                                         .Mappings(m =>
                                              m.FluentMappings.AddFromAssembly(Assembly.LoadWithPartialName(AssemblyName)))
                                        // .ExposeConfiguration(BuildSchema)
                                         .BuildSessionFactory();
                            break;
                        case "MSAccess":
                             // JetDriverConfiguration.Standard.C

                              
                            
                            break;
                    }
                }
                else
                {

                    switch (DatabaseType)
                    {
                        case "MySql":
                            var mysqlconfig = MySQLConfiguration.Standard.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                          sFactory =  Fluently.Configure().Database(mysqlconfig)
                            .Mappings(m => m.AutoMappings.Add(AutoMap.Assembly(
                            Assembly.LoadWithPartialName(AssemblyName))
                            .UseOverridesFromAssembly
                            (Assembly.LoadWithPartialName(AssemblyName)).Where(t => t.Namespace == NameSpaceM)))
                            .BuildSessionFactory();
                            break;

                        case "MsSql2005":
                            var ConfigurationString = MsSqlConfiguration.MsSql2005.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(ConfigurationString)
                            .Mappings(m => m.AutoMappings.Add(AutoMap.Assembly(
                            Assembly.LoadWithPartialName(AssemblyName))
                            .UseOverridesFromAssembly
                            (Assembly.LoadWithPartialName(AssemblyName)).Where(t => t.Namespace == NameSpaceM)))
                            .BuildSessionFactory();
                            break;

                        case "MsSql2008":
                            var ConfigurationString1 = MsSqlConfiguration.MsSql2008.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(ConfigurationString1)
                              .Mappings(m => m.AutoMappings.Add(AutoMap.Assembly(
                              Assembly.LoadWithPartialName(AssemblyName))
                              .UseOverridesFromAssembly
                              (Assembly.LoadWithPartialName(AssemblyName)).Where(t => t.Namespace == NameSpaceM)))
                              .BuildSessionFactory();
                            break;

                        case "MsSql2012":
                            var ConfigurationString2 = MsSqlConfiguration.MsSql2012.ConnectionString(c => c.Is("Data Source=" + DatabaseHost + ";User ID=" + DatabaseUser + ";Password=" + DatabasePassword + ";persist security info=False;initial catalog=" + DatabaseName + ";charset=utf8;"));
                            sFactory = Fluently.Configure().Database(ConfigurationString2)
                              .Mappings(m => m.AutoMappings.Add(AutoMap.Assembly(
                              Assembly.LoadWithPartialName(AssemblyName))
                              .UseOverridesFromAssembly
                              (Assembly.LoadWithPartialName(AssemblyName)).Where(t => t.Namespace == NameSpaceM)))
                              .BuildSessionFactory();
                            break;

                        case "Oracle": break;
                        case "PostGreSql": break;
                        case "SqlLite":
                            var sqliteconfig = SQLiteConfiguration.Standard.UsingFile(FilePath);
                            sFactory = Fluently.Configure().Database(sqliteconfig)
                            .Mappings(m => m.AutoMappings.Add(AutoMap.Assembly(
                            Assembly.LoadWithPartialName(AssemblyName))
                            .UseOverridesFromAssembly
                            (Assembly.LoadWithPartialName(AssemblyName)).Where(t => t.Namespace == NameSpaceM)))
                            .BuildSessionFactory();
                            break;

                        case "MSAccess": break;
                    }
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
                    if (DatabaseType == DBTYPE.SqlLite.ToString())
                    {
                        if (string.IsNullOrEmpty(FilePath))
                        {
                            throw new Exception("FilePath is not Defined");
                        }
                        else
                        {
                            Init();
                        }
                    }

                    else if (!string.IsNullOrEmpty(DatabaseHost))
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

        private static void BuildSchema(Configuration config)
        {
            if (File.Exists(FilePath)) File.Delete(FilePath);

            var se = new SchemaExport(config);
            se.Create(false, true);
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
        SqlLite,
        MSAccess
    }
}
