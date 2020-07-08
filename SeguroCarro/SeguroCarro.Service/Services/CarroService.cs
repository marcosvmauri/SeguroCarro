using SeguroCarro.Domain.Models;
using SeguroCarro.Repository.Repository.Interfaces;
using SeguroCarro.Service.Interfaces;

namespace SeguroCarro.Service.Services
{
    public class CarroService : Service<Carro>, ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        public CarroService(ICarroRepository carroRepository) : base(carroRepository)
        {
            _carroRepository = carroRepository;
        }
    }
}
