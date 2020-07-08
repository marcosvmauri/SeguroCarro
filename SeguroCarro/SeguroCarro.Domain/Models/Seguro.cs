namespace SeguroCarro.Domain.Models
{
    public class Seguro : EntidadeBase
    {
        public double PrecoSeguro { get; set; }
        public int CarroId { get; set; }
        public Carro Carro { get; set; }
        public int SeguradoId { get; set; }
        public Segurado Segurado { get; set; }
    }
}
