using FilaEsperaDigital.Views;

namespace FilaEsperaDigital.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Navega��o para CadastroPage
        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroPage());
        }
    }
}
