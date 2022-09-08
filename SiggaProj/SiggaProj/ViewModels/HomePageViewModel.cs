using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using SiggaProj.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using SiggaProj.Interface;
using System.Collections.Generic;

namespace SiggaProj.ViewModels
{
    public class HomePageViewModel
    {
        public ObservableCollection<UsersResponseModel> UsersList { get; }

        public HomePageViewModel ( )
        {
            UsersList = new ObservableCollection<UsersResponseModel> ( );
            ExecuteLoadUsersCommand ( );
        }

        private void ExecuteLoadUsersCommand ( )
        {

            try
            {
                List<UsersResponseModel> listUsers = DependencyService.Get<IGets> ( ).GetUsers ( );
                foreach (UsersResponseModel item in listUsers)
                {
                    UsersList.Add ( item );
                }
            }
            catch (Exception ex)
            {
                //
            }
        }

    }
}
