using FilaEsperaDigital.ViewModels;

namespace FilaEsperaDigital.Views
{
    public partial class PainelConsumidorPage : ContentPage
    {
        public PainelConsumidorPage()
        {
            InitializeComponent();
            BindingContext = new PainelConsumidorViewModel();
        }
    }
}
