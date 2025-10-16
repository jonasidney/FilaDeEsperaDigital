using FilaEsperaDigital.ViewModels;

namespace FilaEsperaDigital.Views
{
    public partial class PainelPrestadorPage : ContentPage
    {
        public PainelPrestadorPage()
        {
            InitializeComponent();
            BindingContext = new PainelPrestadorViewModel();
        }
    }
}
