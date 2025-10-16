using FilaEsperaDigital.ViewModels;

namespace FilaEsperaDigital.Views
{
    public partial class EstabelecimentosPage : ContentPage
    {
        public EstabelecimentosPage()
        {
            InitializeComponent();
            this.BindingContext = new EstabelecimentosViewModel();
        }
    }
}
