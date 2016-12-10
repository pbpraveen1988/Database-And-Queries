using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DatabaseAndQueries.SessionFactory.DatabaseType = DatabaseAndQueries.DBTYPE.MySql.ToString();
            DatabaseAndQueries.SessionFactory.DatabaseHost = "localhost";
            DatabaseAndQueries.SessionFactory.DatabaseName = "TestGithub";
            DatabaseAndQueries.SessionFactory.DatabasePassword = "123456";
            DatabaseAndQueries.SessionFactory.DatabaseUser = "root";
            DatabaseAndQueries.SessionFactory.NameSpaceM = "Example.Models";
            DatabaseAndQueries.SessionFactory.AutoMapping = true;
            DatabaseAndQueries.SessionFactory.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().ToString();


            Application.Run(new Form1());
        }
    }
}
