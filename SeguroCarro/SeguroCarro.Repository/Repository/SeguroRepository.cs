using SeguroCarro.Domain.Models;
using SeguroCarro.Repository.Context;

namespace SeguroCarro.Repository.Repository.Interfaces
{
    public class SeguroRepository : Repository<Seguro>, ISeguroRepository
    {
        public SeguroRepository(SeguroCarroContext context) : base(context)
        {
        }
    }
}
