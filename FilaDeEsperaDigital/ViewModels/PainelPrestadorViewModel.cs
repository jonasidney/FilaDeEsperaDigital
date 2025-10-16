using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using FilaEsperaDigital.Models;

namespace FilaEsperaDigital.ViewModels
{
    public class PainelPrestadorViewModel : INotifyPropertyChanged
    {
        public string NomePrestador { get; set; } = "Nome Prestador";
        public string Avatar { get; set; } = "🍔"; // Adaptar para cada atividade

        public PainelPrestadorStatus Status { get; set; }

        public ClienteFila ClienteEmAtendimento { get; set; }
        public ClienteFila ProximoCliente { get; set; }
        public ObservableCollection<ClienteFila> ClientesAguardando { get; set; }

        public ICommand ConcluirCommand { get; }
        public ICommand IniciarCommand { get; }
        public ICommand CancelarProximoCommand { get; }
        public ICommand CancelarAguardandoCommand { get; }
        public ICommand SairCommand { get; }
        public ICommand EditarPerfilCommand { get; }

        public PainelPrestadorViewModel()
        {
            Status = new PainelPrestadorStatus
            {
                PessoasNaFila = 4,
                Atendidos = 6,
                TempoMedio = TimeSpan.FromMinutes(0).Add(TimeSpan.FromSeconds(15))
            };

            ClienteEmAtendimento = new ClienteFila
            {
                Nome = "Carlos Oliveira",
                Servico = "Corte + Barba",
                Horario = DateTime.Today.AddHours(14).AddMinutes(30),
            };
            ProximoCliente = new ClienteFila
            {
                Nome = "André Santos",
                Servico = "Corte",
                Horario = DateTime.Today.AddHours(15),
            };
            ClientesAguardando = new ObservableCollection<ClienteFila>
            {
                new ClienteFila {Nome = "Marcos Pereira", Servico = "Corte", Horario = DateTime.Today.AddHours(15).AddMinutes(15)},
                new ClienteFila {Nome = "Lucas Mendes", Servico = "Corte + Barba", Horario = DateTime.Today.AddHours(15).AddMinutes(30)},
                new ClienteFila {Nome = "Rafael Costa", Servico = "Barba", Horario = DateTime.Today.AddHours(15).AddMinutes(45)}
            };

            ConcluirCommand = new Command(OnConcluir);
            IniciarCommand = new Command(OnIniciar);
            CancelarProximoCommand = new Command(OnCancelarProximo);
            CancelarAguardandoCommand = new Command<ClienteFila>(OnCancelarAguardando);
            SairCommand = new Command(OnSair);
            EditarPerfilCommand = new Command(OnEditarPerfil);
        }

        private async void OnConcluir() =>
            await Application.Current.MainPage.DisplayAlert("Concluído", $"Atendimento de {ClienteEmAtendimento.Nome} concluído!", "OK");

        private async void OnIniciar() =>
            await Application.Current.MainPage.DisplayAlert("Iniciar Atendimento", $"Você iniciou atendimento de {ProximoCliente.Nome}.", "OK");

        private async void OnCancelarProximo() =>
            await Application.Current.MainPage.DisplayAlert("Cancelado", $"Atendimento de {ProximoCliente.Nome} foi cancelado.", "OK");

        private async void OnCancelarAguardando(ClienteFila cliente) =>
            await Application.Current.MainPage.DisplayAlert("Cancelado", $"Atendimento de {cliente.Nome} foi cancelado.", "OK");

        private async void OnSair() =>
            await Application.Current.MainPage.Navigation.PopToRootAsync();

        private async void OnEditarPerfil() =>
            await Application.Current.MainPage.DisplayAlert("Perfil", "Funcionalidade de editar perfil em breve!", "OK");

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string prop = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
