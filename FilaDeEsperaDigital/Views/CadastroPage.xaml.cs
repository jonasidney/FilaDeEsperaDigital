using FilaEsperaDigital.ViewModels;

namespace FilaEsperaDigital.Views
{
    public partial class CadastroPage : ContentPage
    {
        public CadastroPage()
        {
            InitializeComponent();
            this.BindingContext = new CadastroViewModel();
        }

        // Alternância entre radio buttons
        private void OnConsumidorChecked(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
                ((CadastroViewModel)BindingContext).IsConsumidor = true;
        }

        private void OnPrestadorChecked(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value)
                ((CadastroViewModel)BindingContext).IsConsumidor = false;
        }

        // Navegar de volta para LoginPage
        private async void OnCancelarClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
