namespace SeguroCarro.Domain.Models
{
    public class Segurado : EntidadeBase
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
    }
}
