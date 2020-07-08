using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using SeguroCarro.Repository.Context;
using SeguroCarro.Repository.Repository;
using SeguroCarro.Service.Services;
using SeguroCarro.Test.Helpers;
using SeguroCarro.Domain.Models;

namespace SeguroSegurado.Test
{


    [TestFixture]
    public class SeguradoTest
    {
        SeguroCarroContext _context = new SeguroCarroContext(new DbContextOptionsBuilder<SeguroCarroContext>()
                                                       .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);


        SeguradoRepository _mockSeguradoRepository;
        SeguradoService _seguradoServices;


        public SeguradoTest()
        {
            _context.Segurados.AddRange(CriarEntidade.CriarBaseSegurados());
            _context.SaveChanges();
            _mockSeguradoRepository = new SeguradoRepository(_context);
            _seguradoServices = new SeguradoService(_mockSeguradoRepository);

        }

        [Test]
        public void TestGetId()
        {
            var retorno = _seguradoServices.GetById(1);
           
            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Id > 0);
        }

        [Test]
        public void TestGetAll()
        {
            var retorno = _seguradoServices.Get();
           
            Assert.NotNull(retorno);
            Assert.NotNull(retorno.Count() > 0);
        }

        [Test]
        public void Add()
        {
            var segurado = new Segurado()
            {
                Id = 20,
                Nome = "Maria",
                Cpf = "09876543212",
                Idade = 47
            };
            _seguradoServices.Add(segurado);
            
            Assert.Pass();
        }

    }
}