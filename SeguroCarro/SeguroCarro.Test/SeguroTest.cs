using NUnit.Framework;
using Moq;
using SeguroCarro.WebAPI.Controllers;
using SeguroCarro.Service.Interfaces;
using SeguroCarro.Domain.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeguroCarro.Repository.Context;
using SeguroCarro.Test.Helpers;
using System.Linq;
using SeguroCarro.Repository.Repository.Interfaces;
using SeguroCarro.Service.Services;
using System;
using SeguroCarro.Repository.Repository;

namespace SeguroCarro.Test
{


    [TestFixture]
    public class SeguroTest
    {
        SeguroCarroContext _context = new SeguroCarroContext(new DbContextOptionsBuilder<SeguroCarroContext>()
                                                        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
        SeguroRepository _mockSeguroRepository;
        SeguroService _seguroServices;

        CarroRepository _mockCarroRepository;
        CarroService _carroServices;

        SeguradoRepository _mockSeguradoRepository;
        SeguradoService _seguradoServices;
        public SeguroTest()
        {
            _context.Carros.AddRange(CriarEntidade.CriarBaseCarros());
            _context.Segurados.AddRange(CriarEntidade.CriarBaseSegurados());
            _context.Seguros.AddRange(CriarEntidade.CriarBaseSeguros());
            _context.SaveChanges();
            _mockSeguroRepository = new SeguroRepository(_context);
            _seguroServices = new SeguroService(_mockSeguroRepository);
            _mockCarroRepository = new CarroRepository(_context);
            _carroServices = new CarroService(_mockCarroRepository);
            _mockSeguradoRepository = new SeguradoRepository(_context);
            _seguradoServices = new SeguradoService(_mockSeguradoRepository);
        }

        [Test]
        public void TestCalculo()
        {
            double valorSeguro = 270.37;

            var carro = _carroServices.GetById(1);
            var segurado = _seguradoServices.GetById(1);

            var seguro = new Seguro()
            {
                Id = 10,
                CarroId = carro.Id,
                SeguradoId = segurado.Id,
                Carro = carro,
                Segurado = segurado
            };
            _seguroServices.CalcularSeguro(seguro);

            Assert.AreEqual(seguro.PrecoSeguro, valorSeguro);
        }

        [Test]
        public void TestMedia()
        {
            var retorno = _seguroServices.GetMedia();
            Assert.NotNull(retorno);
            Assert.IsTrue(retorno > 0);
        }

        [Test]
        public void TestGetId()
        {
            var retorno = _seguroServices.GetById(1);

            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Id > 0);
        }

        [Test]
        public void TestGetAll()
        {
            var retorno = _seguroServices.GetAll();

            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Count() > 0);
        }

        [Test]
        public void AddSeguroCalculado()
        {
            var carro = _carroServices.GetById(6);
            var segurado = _seguradoServices.GetById(5);

            var seguro = new Seguro()
            {
                Id = 50,
                CarroId = carro.Id,
                SeguradoId = segurado.Id,
                Carro = carro,
                Segurado = segurado
            };

            var retorno = _seguroServices.AddSeguroCalculado(seguro);

            Assert.NotNull(retorno);
            Assert.NotNull(retorno.PrecoSeguro > 0);
        }

    }
}