using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Newtonsoft.Json;
using SiggaProj.Interface;
using SiggaProj.Models;
using Xamarin.Forms;

[assembly: Dependency ( typeof ( IGets ) )]
namespace SiggaProj.Services
{
    public class APIClient : IGets
    {
        public static DBHelper _database;
        public T GetDataFromAPI<T>(string endpoint )
        {
            T result;
            JsonSerializer serializer = new JsonSerializer ( );
            try
            {
                HttpClient apiClient = new HttpClient ( );
                HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get, "https://jsonplaceholder.typicode.com/" + endpoint );
                using (HttpResponseMessage response = apiClient.SendAsync(request).GetAwaiter().GetResult())
                {
                    if (true)
                    {
                        using (Stream stream = response.Content.ReadAsStreamAsync().GetAwaiter().GetResult())
                        using (StreamReader reader = new StreamReader(stream))
                        using (JsonTextReader json = new JsonTextReader(reader))
                        {
                            result = serializer.Deserialize<T> ( json );
                        }
                    }
                    else
                    {
                        //erro na requisição
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }

        public List<UsersResponseModel>  GetUsers ( ) 
        {
            List<UsersResponseModel> response = GetDataFromAPI< List<UsersResponseModel>> ( "users" );

            if (response == null)
                return new List<UsersResponseModel> ( );

            //Validação dos dados que estão gravados no celular em comparação aos dados vindos da api
            if (_database.GetAllPeopleData ( ).Count != response.Count)
            {
                _database.DeleteAllPeopleData ( );

                foreach (UsersResponseModel item in response)
                {
                    People pessoa = new People
                    {
                        name_emp = item.company.name,
                        bs = item.company.bs,
                        catchPhrase = item.company.catchPhrase,
                        city = item.address.city,
                        street = item.address.street,
                        suite = item.address.suite,
                        zipcode = item.address.zipcode,
                        lat = item.address.geo.lat,
                        lng = item.address.geo.lng,
                        id = item.id,
                        name = item.name,
                        username = item.username,
                        email = item.email,
                        phone = item.phone,
                        website = item.website
                    };

                    _database.InsertPeople ( pessoa );
                }
            }


            return response;
        }

        public List<PostsResponseModel> GetPostsFromUsers (int id )
        {
            List < PostsResponseModel> response = GetDataFromAPI<List<PostsResponseModel>> ( "posts" );

            if (response == null)
                return new List<PostsResponseModel> ( );

            
            if (_database.GetAllPostsData ( ).Count != response.Count)
            {
                _database.DeleteAllPostsData ( );

                foreach (PostsResponseModel item in response)
                {
                    _database.InsertPost ( item );
                }
            }

            return response.Where ( post => id == post.userId ).ToList ( );

        }
    }
}
