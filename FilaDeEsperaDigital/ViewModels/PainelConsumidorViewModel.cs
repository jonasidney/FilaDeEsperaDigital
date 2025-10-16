using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FilaEsperaDigital.Models;

namespace FilaEsperaDigital.ViewModels
{
    public class PainelConsumidorViewModel : INotifyPropertyChanged
    {
        // Mock: substitua por dados reais depois
        public string NomeConsumidor { get; set; } = "Nome Consumidor";
        public string Avatar { get; set; } = "👤";

        public PainelFilaInfo InfoFila { get; set; }
        public FilaStatus StatusFila { get; set; }

        public ICommand SairDaFilaCommand { get; }
        public ICommand EditarPerfilCommand { get; }

        public PainelConsumidorViewModel()
        {
            InfoFila = new PainelFilaInfo
            {
                NomeEstabelecimento = "Restaurante Sabor Brasileiro",
                PessoasNaFila = 2,
                TempoMedio = TimeSpan.FromSeconds(15)
            };

            StatusFila = new FilaStatus
            {
                SuaPosicao = 3,
                TempoEstimado = TimeSpan.FromSeconds(30)
            };

            SairDaFilaCommand = new Command(OnSairDaFila);
            EditarPerfilCommand = new Command(OnEditarPerfil);
        }

        private async void OnSairDaFila()
        {
            var confirm = await Application.Current.MainPage.DisplayAlert(
                "Sair da Fila", "Tem certeza que deseja sair da fila?",
                "Sim", "Não");
            if (confirm)
                await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void OnEditarPerfil()
        {
            // Futuro: Navegar para edicao de perfil/cadastro
            await Application.Current.MainPage.DisplayAlert(
                "Perfil", "Funcionalidade de editar perfil em breve!", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
