using Xamarin.Forms;
using SiggaProj.Views;
using SiggaProj.Services;
using SiggaProj.Interface;
using Xamarin.Essentials;

namespace SiggaProj
{
    public partial class App : Application
    {
        public App ( )
        {
            InitializeComponent ( );

            DBHelper db = new DBHelper ( );

            #region REGISTO DE DEPENDENCIAS

            var hasInternet = Connectivity.NetworkAccess;

            if (hasInternet == NetworkAccess.Internet)
            {
                APIClient._database = db;
                DependencyService.Register<IGets, APIClient> ( );
            }
            else
            {
                DBClient._database = db;
                DependencyService.Register<IGets, DBClient> ( );
            }
                
            #endregion

            MainPage = new NavigationPage (new HomePage() );
        }

        protected override void OnStart ( )
        {
        }

        protected override void OnSleep ( )
        {
        }

        protected override void OnResume ( )
        {
        }
    }
}
