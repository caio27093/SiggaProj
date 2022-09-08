using SiggaProj.Interface;
using SiggaProj.Models;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency ( typeof ( IGets ) )]
namespace SiggaProj.Services
{
    public class DBClient : IGets
    {
        public static DBHelper _database;
        public List<PostsResponseModel> GetPostsFromUsers ( int id )
        {
            return _database.GetAllPostsData ( ).Where ( post => id == post.userId ).ToList ( );
        }

        public List<UsersResponseModel> GetUsers ( )
        {
            List<People> pessoa = _database.GetAllPeopleData ( );
            List<UsersResponseModel> result = new List<UsersResponseModel> ( );
            foreach (People item in pessoa)
            {
                Geo geolocalizacao = new Geo { lat = item.lat, lng = item.lng };

                Address endereco = new Address { city = item.city, geo = geolocalizacao, street = item.street, suite = item.suite, zipcode = item.zipcode };

                Company empresa = new Company { name = item.name_emp, bs = item.bs, catchPhrase = item.catchPhrase };


                result.Add ( new UsersResponseModel 
                { 
                    address = endereco,
                    company = empresa,
                    id = item.id,
                    name = item.name,
                    username = item.username,
                    email = item.email,
                    phone = item.phone,
                    website = item.website
                } );
            }
            return result;
        }
    }
}
