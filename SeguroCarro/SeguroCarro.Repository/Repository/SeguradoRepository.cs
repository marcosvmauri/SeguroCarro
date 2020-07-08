using SeguroCarro.Domain.Models;
using SeguroCarro.Repository.Context;
using SeguroCarro.Repository.Repository.Interfaces;

namespace SeguroCarro.Repository.Repository
{
    public class SeguradoRepository : Repository<Segurado>, ISeguradoRepository
    {
        public SeguradoRepository(SeguroCarroContext context) : base(context)
        {
        }
    }
}
