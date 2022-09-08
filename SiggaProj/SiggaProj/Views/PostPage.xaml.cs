using SiggaProj.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiggaProj.Views
{
    [XamlCompilation ( XamlCompilationOptions.Compile )]
    public partial class PostPage : ContentPage
    {
        PostPageViewModel _viewModel;
        public PostPage (int id, string nome )
        {
            InitializeComponent ( );
            this.Title = "Posts do(a) " + nome;
            BindingContext = _viewModel = new PostPageViewModel ( id );
        }

        private void Voltar ( object sender, System.EventArgs e )
        {
            Application.Current.MainPage = new NavigationPage ( new HomePage () );
        }
    }
}