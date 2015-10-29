﻿using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using LooxLikeAPI.Mapper;
using LooxLikeAPI.Models.JSONModel.Mapper;
using LooxLikeAPI.Repository;
using LooxLikeAPI.Services;
using Simple.Data;
using LooxLikeAPI.Models;
using LooxLikeAPI.Models.JSONModel;
﻿using LooxLikeAPI.Models.Model.Mapper;
﻿using LooxLikeAPI.Services.UploaderAdapter;
using Newtonsoft.Json;

namespace LooxLikeAPI.Windsor.Installer
{
    public class LooxLikeDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //Register Simple Data Connection
                Component.For<dynamic>().UsingFactoryMethod(CreateSimpleDataConnection),
                //Register mapper
                Component.For(typeof(IUserMapper)).ImplementedBy(typeof(UserMapper)).LifestyleTransient(),
                Component.For(typeof(IPostMapper)).ImplementedBy(typeof(PostMapper)).LifestyleTransient(),
                Component.For(typeof(IResponseRequestPostMapper)).ImplementedBy(typeof(ResponseRequestPostMapper)).LifestyleTransient(),
				Component.For(typeof(ILikedPostMapper)).ImplementedBy(typeof(LikedPostMapper)),
				Component.For(typeof(IResponseRequestLikePostMapper)).ImplementedBy(typeof(ResponseRequestLikePostMapper)),
                //Register repositories
                Component.For(typeof(IPostRepository)).ImplementedBy(typeof(PostRepository)).LifestyleTransient(),
                Component.For(typeof(IUserRepository)).ImplementedBy(typeof(UserRepository)).LifestyleTransient(),
				Component.For(typeof(ILikeRepository)).ImplementedBy(typeof(LikeRepository)).LifestyleTransient(),
                //Register upload adapter
                Component.For(typeof(IUploaderAdapter)).ImplementedBy(typeof(AmazonClientAdapter)).LifestyleTransient(),

                //Register services
                Component.For(typeof(IPostService)).ImplementedBy(typeof(PostService)).LifestyleTransient(),
                Component.For(typeof(IUserService)).ImplementedBy(typeof(UserService)).LifestyleTransient(),
                Component.For(typeof(IPhotoUploaderService)).ImplementedBy(typeof(PhotoUploaderService)).LifestyleTransient(),
				Component.For(typeof(ILikedPostService)).ImplementedBy(typeof(LikedPostService)),
                //Register controllers
                Classes.FromThisAssembly().BasedOn<ApiController>().LifestyleScoped()
                );
        }


        private static dynamic CreateSimpleDataConnection()
        {
            /* const string DATABASE_NAME = "testdb.sdf" ;
            
             if (File.Exists(DATABASE_NAME))
                 File.Delete(DATABASE_NAME);

             SqlCeEngine _en = new SqlCeEngine("Data Source = " + DATABASE_NAME);
             _en.CreateDatabase();
             _en.Dispose();
             SqlCeConnection conn = new SqlCeConnection("Data Source = " + DATABASE_NAME);
             conn.Open();
             SqlCeCommand comm = new SqlCeCommand("create table Post (id bigint identity(1,1) primary key, message nvarchar(100))", conn);
             Console.WriteLine("Response: " + comm.ExecuteNonQuery());
             conn.Close();

             return Database.OpenFile(DATABASE_NAME);*/

            //return Database.OpenConnection("data source=looxlike-aws-db.cgh0nwmobyrc.eu-central-1.rds.amazonaws.com;initial catalog=LooxLikeDB;user id=looxlike_admin;password=LaPa$$w0rdDB");
            //return Database.OpenConnection("data source=.;initial catalog=LooxLikeDB;user id=looxlikelogin;password=LaPa$$w0rdDB");
            //return Database.OpenConnection("data source=54.93.89.176;initial catalog=LooxLikeDB;user id=looxlikelogin;password=LaPa$$w0rdDB");
            var connectionString = GetConnectionString("c:\\connection_string\\connection_string.conf");
            return Database.OpenConnection(connectionString);
            ////return Database.OpenConnection("data source=.;initial catalog=LooxLikeDB;user id=sa;password=LaPa$$w0rdDB");
        }

        private static string GetConnectionString(string configFilePath)
        {
            var streamReader = new StreamReader(configFilePath);
            var connectionString = streamReader.ReadToEnd();
            streamReader.Close();
            return connectionString;
        }
    }
}