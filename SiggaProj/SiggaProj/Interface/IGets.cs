using SiggaProj.Models;
using System.Collections.Generic;

namespace SiggaProj.Interface
{
    public interface IGets
    {
        List<UsersResponseModel> GetUsers ( );
        List<PostsResponseModel> GetPostsFromUsers (int id );
    }
}
