namespace FilaEsperaDigital.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoServico { get; set; } // Ex: Restaurante, Barbearia, Clínica
        public string ImagemUrl { get; set; }
        public int PessoasNaFila { get; set; }
        public TimeSpan TempoMedioAtendimento { get; set; }
        public bool Ativo { get; set; } = true;

        // Formatação para exibição
        public string TempoMedioFormatado => $"{TempoMedioAtendimento:mm\\:ss}";
        public string IconeServico => TipoServico switch
        {
            "Restaurante" => "🍔",
            "Barbearia" => "✂️",
            "Clínica" => "🏥",
            "Padaria" => "🥖",
            _ => "🏪"
        };
    }
}