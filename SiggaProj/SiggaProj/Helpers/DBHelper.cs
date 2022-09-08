using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SiggaProj.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace SiggaProj.Services
{
    public class DBHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "SiggaDB.db";
        public DBHelper ( )
        {
            var pasta = new LocalRootFolder ( );
            var arquivo = pasta.CreateFile ( DbFileName, CreationCollisionOption.OpenIfExists );
            sqliteconnection = new SQLiteConnection ( arquivo.Path );
            sqliteconnection.CreateTable<PostsResponseModel> ( );
            sqliteconnection.CreateTable<People> ( );
        }
        public List<PostsResponseModel> GetAllPostsData ( )
        {
            return (from data in sqliteconnection.Table<PostsResponseModel> ( )
                    select data).ToList ( );
        }
        public void DeleteAllPostsData ( )
        {
            sqliteconnection.DeleteAll<PostsResponseModel> ( );
        }
        public void InsertPost ( PostsResponseModel post )
        {
            sqliteconnection.Insert ( post );
        }
        public List<People> GetAllPeopleData ( )
        {
            return (from data in sqliteconnection.Table<People> ( )
                    select data).ToList ( );
        }
        public void DeleteAllPeopleData ( )
        {
            sqliteconnection.DeleteAll<People> ( );
        }
        public void InsertPeople ( People people )
        {
            sqliteconnection.Insert ( people );
        }
    }
}
