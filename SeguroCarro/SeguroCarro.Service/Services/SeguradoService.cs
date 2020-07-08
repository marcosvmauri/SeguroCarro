using SeguroCarro.Domain.Models;
using SeguroCarro.Repository.Repository.Interfaces;
using SeguroCarro.Service.Interfaces;

namespace SeguroCarro.Service.Services
{
    public   class SeguradoService : Service<Segurado>, ISeguradoService
    {
        private readonly ISeguradoRepository _seguradoRepository;
        public SeguradoService(ISeguradoRepository seguradoRepository) : base(seguradoRepository)
        {
            _seguradoRepository = seguradoRepository;
        }
    }
}
