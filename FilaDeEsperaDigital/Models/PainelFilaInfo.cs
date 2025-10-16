namespace FilaEsperaDigital.Models
{
    public class PainelFilaInfo
    {
        public string NomeEstabelecimento { get; set; }
        public int PessoasNaFila { get; set; }
        public TimeSpan TempoMedio { get; set; }
        public string TempoFormatado => $"{TempoMedio:mm\\:ss}";
    }
    public class FilaStatus
    {
        public int SuaPosicao { get; set; }
        public TimeSpan TempoEstimado { get; set; }
        public string TempoEstimadoFormatado => $"{TempoEstimado:mm\\:ss}";
    }
}