using SeguroCarro.Domain.Models;
using SeguroCarro.Repository.Repository.Interfaces;
using SeguroCarro.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeguroCarro.Service.Services
{
    public class SeguroService : Service<Seguro>, ISeguroService
    {
        private readonly ISeguroRepository _seguroRepository;
        private const int margemSeguranca = 3;
        private const int lucro = 5;
        public SeguroService(ISeguroRepository seguroRepository) : base(seguroRepository)
        {
            _seguroRepository = seguroRepository;
        }
        public Seguro CalcularSeguro(Seguro seguro)
        {
            double taxaRisco, premioRisco, premioPuro, premioComercial;
            taxaRisco = ((seguro.Carro.ValorCarro * 5) / (2 * seguro.Carro.ValorCarro));
            premioRisco = (taxaRisco / 100.00) * seguro.Carro.ValorCarro;
            premioPuro = premioRisco * (1 + (margemSeguranca / 100.00));
            premioComercial = (lucro / 100.00) * premioPuro;
            seguro.PrecoSeguro = premioComercial + premioPuro;
            seguro.PrecoSeguro = Math.Truncate(100 * seguro.PrecoSeguro) / 100;
            return seguro;
        }

        public Seguro AddSeguroCalculado(Seguro seguro)
        {
           var seguroCalculado = CalcularSeguro(seguro);
             _seguroRepository.Add(seguroCalculado);
            return seguroCalculado;
        }

        public double GetMedia()
        {
            return Math.Round(_seguroRepository.Get().Average(i => i.PrecoSeguro), 2);
        }

        public IEnumerable<Seguro> GetAll()
        {
            return _seguroRepository.Get(new List<string> { "Carro", "Segurado" }).ToList();
        }

    }
}
