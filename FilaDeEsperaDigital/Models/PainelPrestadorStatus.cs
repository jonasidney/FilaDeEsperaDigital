namespace FilaEsperaDigital.Models
{
   public class PainelPrestadorStatus
    {
        public int PessoasNaFila { get; set; }
        public int Atendidos { get; set; }
        public TimeSpan TempoMedio { get; set; }
        public string TempoMedioFormatado => $"{TempoMedio:mm\\:ss}";
    }
}
