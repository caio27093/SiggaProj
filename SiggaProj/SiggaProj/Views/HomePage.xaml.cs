using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SiggaProj.ViewModels;
using System;
using SiggaProj.Models;

namespace SiggaProj.Views
{
    [XamlCompilation ( XamlCompilationOptions.Compile )]
    public partial class HomePage : ContentPage
    {
        HomePageViewModel _viewModel;
        public HomePage ( )
        {
            InitializeComponent ( );
            BindingContext = _viewModel = new HomePageViewModel ( );
        }

        private void VerPosts ( object sender, EventArgs e )
        {
            UsersResponseModel item = ((Button)sender).CommandParameter as UsersResponseModel;
            Application.Current.MainPage = new NavigationPage ( new PostPage ( item.id,item.name ) );
        }
    }
}