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
    public class CarroTest
    {
        SeguroCarroContext _context = new SeguroCarroContext(new DbContextOptionsBuilder<SeguroCarroContext>()
                                                        .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);

        CarroRepository _mockCarroRepository;
        CarroService _carroServices;

        public  CarroTest()
        {
            _context.Carros.AddRange(CriarEntidade.CriarBaseCarros());
            _context.SaveChanges();
            _mockCarroRepository = new CarroRepository(_context);
            _carroServices = new CarroService(_mockCarroRepository);
        }

        [Test]
        public void TestGetId()
        {
            var retorno = _carroServices.GetById(1);

            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Id > 0);
        }

        [Test]
        public void TestGetAll()
        {
            var retorno = _carroServices.Get();

            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Count() > 0);
        }

        [Test]
        public void Add()
        {
            var carro = new Carro()
            {
                Id = 15,
                Marca = "Toyota",
                ValorCarro = 5000
            };

            _carroServices.Add(carro);

            Assert.Pass();
        }

    }
}