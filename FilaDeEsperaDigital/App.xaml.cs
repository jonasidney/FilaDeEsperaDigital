using FilaEsperaDigital.Views;

namespace FilaDeEsperaDigital
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
        }
    }
}
