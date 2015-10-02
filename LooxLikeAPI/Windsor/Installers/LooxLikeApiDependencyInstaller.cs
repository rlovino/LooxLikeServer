using System;
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
using LooxLikeAPI.Repository;
using LooxLikeAPI.Services;
using Simple.Data;

namespace LooxLikeAPI.Windsor.Installer
{
    public class LooxLikeDependencyInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                //Register Simple Data Connection
                Component.For<dynamic>().UsingFactoryMethod(CreateSimpleDataConnection),
                //Register repositories
                Component.For(typeof (IPostRepository)).ImplementedBy(typeof (PostRepository)).LifestyleTransient(),
                Component.For(typeof(IUserRepository)).ImplementedBy(typeof(UserRepository)).LifestyleTransient(),
                //Register mapper
                Component.For(typeof (IPostMapper)).ImplementedBy(typeof (PostMapper)).LifestyleTransient(),
                Component.For(typeof (IUserMapper)).ImplementedBy(typeof (UserMapper)).LifestyleTransient(),
                //Register services
                Component.For(typeof (IPostService)).ImplementedBy(typeof (PostService)).LifestyleTransient(),
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

            return Database.OpenConnection("data source=.;initial catalog=Xyz;etc");
        }


    }
}