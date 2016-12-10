# Database-And-Queries

 Repository and Unit of Work Pattern and Implementing Generic Repository in ASP.NET MVC using Fluent NHibernate.<br>
 Right now we written the library in C# , working for VB also , will release soon.<br>
 <br>
 The following the are the features of the library:<br>
 a) User Can easily connect to any database due to Fluent NHibernate ORM<br>
 b) Already tested with MsSql2005,MsSql2008,MsSql2012,MYSQL,SQLITE. Working with ORACLE,POSTGRESQL.<br>
 c) Dont have to create the Mapping File, we implemented the AutoMapping, just have to create the class according tables.<br>
<br>
<br>
Technical Specifications:<br>
<br>
As you can see, there are two classes : <br>
1) Queries.cs <br>
2) SessionFactory.cs <br>
<br>
 <b><u>SessionFactory.cs: </u></b><br>
            This is the Main File or Configuration File , We have to set the Few Paramters here to Connect the Database <br>
            like Hostname,Database Name, Database password , Database Type (which we have to use like Mysql,MS sql etc.)<br>
            To make the AutoMapping : have to set True or False, if true , have to provide the NameSpace of Models (where we put the classes)<br>
            <b><u>Parameters</u></b><br>
            DatabaseName  : Name of the database.<br>
            DatabaseHost  : Ip or Domain name of host of database.<br>
            DatabaseUser  : Username of the database <br>
            DatabasePassword : Password of the database.<br>
            AssemblyName : We have to Provide the name of the Assembly , where the models is placed.<br>
            NameSpaceM : Namespace of the Models only (if Automapping is true then only).<br>
            AutoMapping : True or False<br>
<br>
 <b><u>Queries.cs : </u></b><br>
            In this file we write the Complete queries for CRUD operations and also with Multiple Conditions ,Order By, Sort By etc.<br>
            You can see the example in Attached Example Project.<br>
            
            
<b>Example With Mysql </b><br>
<br>
We created the Windows Desktop for Example, we put the code in Program.cs, we have to initialize on Start of project.<br>
<br>
 DatabaseAndQueries.SessionFactory.DatabaseType = DatabaseAndQueries.DBTYPE.MySql.ToString();<br>
 DatabaseAndQueries.SessionFactory.DatabaseHost = "localhost";<br>
 DatabaseAndQueries.SessionFactory.DatabaseName = "TestGithub";<br>
 DatabaseAndQueries.SessionFactory.DatabasePassword = "123456";<br>
 DatabaseAndQueries.SessionFactory.DatabaseUser = "root";<br>
 DatabaseAndQueries.SessionFactory.NameSpaceM = "Example.Models";<br>
 DatabaseAndQueries.SessionFactory.AutoMapping = true;<br>
 DatabaseAndQueries.SessionFactory.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly().ToString();<br>
 <br>
 <br>
 Insert data in to table <br>
 -----------------------<br>
   User _user = new User();<br>
   _user.Name = textBox1.Text;<br>
   Queries.Add&lt;User&gt;(_user);<br>
   <br>
   
   
   
   
 
 



                                        

