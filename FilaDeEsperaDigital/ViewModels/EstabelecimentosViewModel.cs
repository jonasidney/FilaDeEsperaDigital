using FilaEsperaDigital.Models;
using FilaEsperaDigital.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FilaEsperaDigital.ViewModels
{
    public class EstabelecimentosViewModel : INotifyPropertyChanged
    {
        private string _textoBusca = string.Empty;

        // Inicializar os campos diretamente na declaração
        private ObservableCollection<Estabelecimento> _estabelecimentos = new();
        private ObservableCollection<Estabelecimento> _estabelecimentosDisponiveis = new();

        public string TextoBusca
        {
            get => _textoBusca;
            set
            {
                _textoBusca = value;
                OnPropertyChanged();
                FiltrarEstabelecimentos();
            }
        }

        public ObservableCollection<Estabelecimento> EstabelecimentosDisponiveis
        {
            get => _estabelecimentosDisponiveis;
            set
            {
                _estabelecimentosDisponiveis = value;
                OnPropertyChanged();
            }
        }

        public ICommand EntrarFilaCommand { get; }
        public ICommand SairCommand { get; }

        public EstabelecimentosViewModel()
        {
            EntrarFilaCommand = new Command<Estabelecimento>(OnEntrarFila);
            SairCommand = new Command(OnSair);

            CarregarEstabelecimentos();
        }

        private void CarregarEstabelecimentos()
        {
            // Dados mock para teste - depois substituir por chamada ao backend
            _estabelecimentos = new ObservableCollection<Estabelecimento>
            {
                new Estabelecimento
                {
                    Id = 1,
                    Nome = "Restaurante Sabor Brasileiro",
                    TipoServico = "Restaurante",
                    PessoasNaFila = 2,
                    TempoMedioAtendimento = TimeSpan.FromMinutes(0).Add(TimeSpan.FromSeconds(15))
                },
                new Estabelecimento
                {
                    Id = 2,
                    Nome = "Barbearia Corte & Estilo",
                    TipoServico = "Barbearia",
                    PessoasNaFila = 4,
                    TempoMedioAtendimento = TimeSpan.FromMinutes(0).Add(TimeSpan.FromSeconds(30))
                },
                new Estabelecimento
                {
                    Id = 3,
                    Nome = "Clínica Médica Saúde Total",
                    TipoServico = "Clínica",
                    PessoasNaFila = 3,
                    TempoMedioAtendimento = TimeSpan.FromMinutes(0).Add(TimeSpan.FromSeconds(40))
                },
                new Estabelecimento
                {
                    Id = 4,
                    Nome = "Padaria Pão Dourado",
                    TipoServico = "Padaria",
                    PessoasNaFila = 6,
                    TempoMedioAtendimento = TimeSpan.FromMinutes(0).Add(TimeSpan.FromSeconds(5))
                }
            };

            EstabelecimentosDisponiveis = new ObservableCollection<Estabelecimento>(_estabelecimentos);
        }

        private void FiltrarEstabelecimentos()
        {
            if (string.IsNullOrWhiteSpace(TextoBusca))
            {
                EstabelecimentosDisponiveis = new ObservableCollection<Estabelecimento>(_estabelecimentos);
            }
            else
            {
                var filtrados = _estabelecimentos
                    .Where(e => e.Nome.Contains(TextoBusca, StringComparison.OrdinalIgnoreCase) ||
                               e.TipoServico.Contains(TextoBusca, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                EstabelecimentosDisponiveis = new ObservableCollection<Estabelecimento>(filtrados);
            }
        }

        private async void OnEntrarFila(Estabelecimento estabelecimento)
        {
            if (estabelecimento == null) return;

            await Application.Current.MainPage.DisplayAlert(
                "Entrar na Fila",
                $"Você entrou na fila do {estabelecimento.Nome}!\nPessoas na sua frente: {estabelecimento.PessoasNaFila}",
                "OK");

            // Aqui futuramente navegará para PainelConsumidorPage
            await Application.Current.MainPage.Navigation.PushAsync(new PainelConsumidorPage());
        }

        private async void OnSair()
        {
            // Retorna para LoginPage
            await Application.Current.MainPage.Navigation.PopToRootAsync();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
