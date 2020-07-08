using SeguroCarro.Domain.Models;
using SeguroCarro.Repository.Context;
using SeguroCarro.Repository.Repository.Interfaces;

namespace SeguroCarro.Repository.Repository
{
    public class CarroRepository : Repository<Carro>, ICarroRepository
    {
        public CarroRepository(SeguroCarroContext context) : base(context)
        {
        }
    }
}
