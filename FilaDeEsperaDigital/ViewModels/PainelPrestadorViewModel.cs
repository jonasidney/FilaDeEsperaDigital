using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FilaEsperaDigital.ViewModels
{
    public class PainelPrestadorStatus
    {
        public int PessoasNaFila { get; set; }
        public int Atendidos { get; set; }
        public TimeSpan TempoMedio { get; set; }
        public string TempoMedioFormatado => $"{TempoMedio:mm\\:ss}";
    }

    public class ClienteFila
    {
        public string Nome { get; set; }
        public DateTime Horario { get; set; }
        public string HorarioFormatado => Horario.ToString("HH:mm");
    }

    public class PainelPrestadorViewModel : INotifyPropertyChanged
    {
        // Dados do prestador
        public string NomePrestador { get; set; } = "Nome Prestador";
        public string Avatar { get; set; } = "🍔";

        // Indicadores de status da fila
        public PainelPrestadorStatus Status { get; set; }

        // Cliente em atendimento, próximo e aguardando
        public ClienteFila ClienteEmAtendimento { get; set; }
        public ClienteFila ProximoCliente { get; set; }
        public ObservableCollection<ClienteFila> ClientesAguardando { get; set; }

        // Commands - ações dos botões
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
                TempoMedio = TimeSpan.FromSeconds(15)
            };

            ClienteEmAtendimento = new ClienteFila
            {
                Nome = "Carlos Oliveira",
                Horario = DateTime.Today.AddHours(14).AddMinutes(30),
            };
            ProximoCliente = new ClienteFila
            {
                Nome = "André Santos",
                Horario = DateTime.Today.AddHours(15),
            };
            ClientesAguardando = new ObservableCollection<ClienteFila>
            {
                new ClienteFila {Nome = "Marcos Pereira", Horario = DateTime.Today.AddHours(15).AddMinutes(15)},
                new ClienteFila {Nome = "Lucas Mendes", Horario = DateTime.Today.AddHours(15).AddMinutes(30)},
                new ClienteFila {Nome = "Rafael Costa", Horario = DateTime.Today.AddHours(15).AddMinutes(45)}
            };

            ConcluirCommand = new Command(OnConcluir);
            IniciarCommand = new Command(OnIniciar);
            CancelarProximoCommand = new Command(OnCancelarProximo);
            CancelarAguardandoCommand = new Command<ClienteFila>(OnCancelarAguardando);
            SairCommand = new Command(OnSair);
            EditarPerfilCommand = new Command(OnEditarPerfil);
        }

        // Lógica básica para protótipo/demo
        private async void OnConcluir()
        {
            await Application.Current.MainPage.DisplayAlert("Concluído", $"Atendimento de {ClienteEmAtendimento.Nome} concluído!", "OK");
        }

        private async void OnIniciar()
        {
            await Application.Current.MainPage.DisplayAlert("Iniciar Atendimento", $"Você iniciou atendimento de {ProximoCliente.Nome}.", "OK");
        }

        private async void OnCancelarProximo()
        {
            await Application.Current.MainPage.DisplayAlert("Cancelado", $"Atendimento de {ProximoCliente.Nome} foi cancelado.", "OK");
        }

        private async void OnCancelarAguardando(ClienteFila cliente)
        {
            await Application.Current.MainPage.DisplayAlert("Cancelado", $"Atendimento de {cliente.Nome} foi cancelado.", "OK");
        }

        private async void OnSair()
        {
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        private async void OnEditarPerfil()
        {
            await Application.Current.MainPage.DisplayAlert("Perfil", "Funcionalidade de editar perfil em breve!", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
