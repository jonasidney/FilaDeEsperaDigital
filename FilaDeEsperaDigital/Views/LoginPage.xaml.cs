using FilaEsperaDigital.Views;

namespace FilaEsperaDigital.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        // Navegação para CadastroPage
        private async void OnCadastrarClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CadastroPage());
        }

        // Simulação de login - navegação para EstabelecimentosPage
        private async void OnEntrarClicked(object sender, EventArgs e)
        {
            // Simula login de consumidor
            await Navigation.PushAsync(new EstabelecimentosPage());
        }

        // *** NOVO: Evento simulado para o painel do prestador ***
        private async void OnPainelPrestadorClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PainelPrestadorPage());
        }

    }
}
