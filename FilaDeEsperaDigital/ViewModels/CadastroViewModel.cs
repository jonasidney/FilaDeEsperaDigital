using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FilaEsperaDigital.ViewModels
{
    public class CadastroViewModel : INotifyPropertyChanged
    {
        private bool _isConsumidor = true;

        public bool IsConsumidor
        {
            get => _isConsumidor;
            set
            {
                if (_isConsumidor != value)
                {
                    _isConsumidor = value;
                    OnPropertyChanged(nameof(IsConsumidor));
                    OnPropertyChanged(nameof(IsPrestador));
                    OnPropertyChanged(nameof(CampoNomeLabel));
                    OnPropertyChanged(nameof(CampoNomePlaceholder));
                    OnPropertyChanged(nameof(CampoExtraLabel));
                    OnPropertyChanged(nameof(CampoExtraPlaceholder));
                }
            }
        }

        public bool IsPrestador => !_isConsumidor;

        // Campos sensíveis
        public string CampoNomeLabel => IsConsumidor ? "Nome" : "Nome do Estabelecimento";
        public string CampoNomePlaceholder => IsConsumidor ? "Nome" : "Nome do Estabelecimento";
        public string CampoExtraLabel => IsConsumidor ? "Sobrenome" : "Ramo de Atividade";
        public string CampoExtraPlaceholder => IsConsumidor ? "Sobrenome" : "Ramo de Atividade";

        public string NomeOuEstabelecimento { get; set; }
        public string SobrenomeOuRamo { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfirmarSenha { get; set; }

        public ICommand GravarCommand { get; }
        public ICommand CancelarCommand { get; }

        public CadastroViewModel()
        {
            GravarCommand = new Command(OnGravar);
            CancelarCommand = new Command(OnCancelar);
        }

        private async void OnGravar()
        {
            // Simulação básica de validação
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Senha) || string.IsNullOrWhiteSpace(ConfirmarSenha))
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Preencha e-mail e senha!", "OK");
                return;
            }
            if (Senha != ConfirmarSenha)
            {
                await Application.Current.MainPage.DisplayAlert("Erro", "Senhas não conferem!", "OK");
                return;
            }
            await Application.Current.MainPage.DisplayAlert("Sucesso", $"Cadastro ({(IsConsumidor ? "Consumidor" : "Prestador")}) realizado!", "OK");
        }

        private async void OnCancelar()
        {
            // Neste protótipo, apenas simula o retorno
            await Application.Current.MainPage.DisplayAlert("Cancelar", "Cadastro cancelado!", "OK");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
