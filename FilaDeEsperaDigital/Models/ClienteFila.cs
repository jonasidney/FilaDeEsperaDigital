namespace FilaEsperaDigital.Models
{
    public class ClienteFila
    {
        public string Nome { get; set; }
        public string Servico { get; set; }
        public DateTime Horario { get; set; }

        // Propriedade formatada usada no XAML para exibir o horário em formato HH:mm
        public string HorarioFormatado => Horario.ToString("HH:mm");
    }
}
