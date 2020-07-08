using SeguroCarro.Domain.Models;
using System.Collections.Generic;

namespace SeguroCarro.Service.Interfaces
{
    public interface ISeguroService : IService<Seguro>
    {
        Seguro CalcularSeguro(Seguro seguro);
        Seguro AddSeguroCalculado(Seguro seguro);
        double GetMedia();
        IEnumerable<Seguro> GetAll();
        Seguro GetById(int id);
    }

}
