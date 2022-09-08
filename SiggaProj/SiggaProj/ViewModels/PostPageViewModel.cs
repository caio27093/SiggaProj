using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SiggaProj.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using SiggaProj.Interface;
using System.Collections.Generic;
using System.Linq;

namespace SiggaProj.ViewModels
{
    public class PostPageViewModel
    {
        public ObservableCollection<PostsResponseModel> PostsList { get; set; }

        public PostPageViewModel ( int id )
        {
            PostsList = new ObservableCollection<PostsResponseModel> ( );
            ExecuteLoadUsersCommand (id);
        }

        private void ExecuteLoadUsersCommand ( int id )
        {
            var hasInternet = Connectivity.NetworkAccess;

            try
            {
                List<PostsResponseModel> listPosts = DependencyService.Get<IGets> ( ).GetPostsFromUsers ( id );

                foreach (PostsResponseModel item in listPosts)
                {
                    PostsList.Add ( item );
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

    }
}
