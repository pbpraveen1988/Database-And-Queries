# Database-And-Queries

 Repository and Unit of Work Pattern and Implementing Generic Repository in ASP.NET MVC using Fluent NHibernate.
 Right now we written the library in C# , working for VB also , will release soon.
 
 The following the are the features of the library:
 a) User Can easily connect to any database due to Fluent NHibernate ORM
 b) Already tested with MsSql2005,MsSql2008,MsSql2012,MYSQL,SQLITE. Working with ORACLE,POSTGRESQL.
 c) Dont have to create the Mapping File, we implemented the AutoMapping, just have to create the class according tables.


Technical Specifications:

As you can see, there are two classes : 1) Queries.cs 
                                        2) SessionFactory.cs
                                        
SessionFactory.cs:
            This is the Main File or Configuration File , We have to set the Few Paramters here to Connect the Database 
            like Hostname,Database Name, Database password , Database Type (which we have to use like Mysql,MS sql etc.)
            To make the AutoMapping : have to set True or False, if true , have to provide the NameSpace of Models (where we put the classes)
            <b><u>Parameters</u></b>
            DatabaseName  : Name of the database.
            DatabaseHost  : Ip or Domain name of host of database.
            DatabaseUser  : Username of the database 
            DatabasePassword : Password of the database.
            AssemblyName : We have to Provide the name of the Assembly , where the models is placed.
            NameSpaceM : Namespace of the Models only (if Automapping is true then only).
            AutoMapping : True or False

Queries.cs :
            In this file we write the Complete queries for CRUD operations and also with Multiple Conditions ,Order By, Sort By etc.
            You can see the example in Attached Example Project.
            
            

                                        

