using Microsoft.EntityFrameworkCore;
using Moq;
using SeguroCarro.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeguroCarro.Test.Helpers
{
    public static class CriarEntidade
    {

        public static List<Carro> CriarBaseCarros()
        {
            var carros = new List<Carro>();
            carros.Add(
                new Carro()
                {
                    Id = 1,
                    Marca = "BMW",
                    ValorCarro = 10000
                });
            carros.Add(
                new Carro()
                {
                    Id = 2,
                    Marca = "AUDI",
                    ValorCarro = 80000
                });
            carros.Add(
              new Carro()
              {
                  Id = 3,
                  Marca = "Mercedes",
                  ValorCarro = 150000
              });
            carros.Add(
              new Carro()
              {
                  Id = 4,
                  Marca = "Volvo",
                  ValorCarro = 180000
              });
            carros.Add(
              new Carro()
              {
                  Id = 5,
                  Marca = "Honda",
                  ValorCarro = 180000
              });
            carros.Add(
            new Carro()
            {
                Id = 6,
                Marca = "FIAT",
                ValorCarro = 180000
            });

            return carros;
        }

        public static List<Segurado> CriarBaseSegurados()
        {
            var segurados = new List<Segurado>();
            segurados.Add(new Segurado()
            {
                Id = 1,
                Nome = "Marcos",
                Cpf = "12345667890",
                Idade = 29
            });
            segurados.Add(new Segurado()
            {
                Id = 2,
                Nome = "Mauri",
                Cpf = "12345667890",
                Idade = 30
            });
            segurados.Add(new Segurado()
            {
                Id = 3,
                Nome = "Vinicius",
                Cpf = "12345667890",
                Idade = 40
            });
            segurados.Add(new Segurado()
            {
                Id = 4,
                Nome = "Pedro",
                Cpf = "12345667890",
                Idade = 40
            });
            segurados.Add(new Segurado()
            {
                Id = 5,
                Nome = "João",
                Cpf = "12345667890",
                Idade = 40
            });

            return segurados;
        }

        public static List<Seguro> CriarBaseSeguros()
        {
           
            var seguros = new List<Seguro>();
            seguros.Add(new Seguro()
            {
                Id = 1,
                CarroId = 2,
                SeguradoId = 1,
                PrecoSeguro = 2163
            });
            seguros.Add(new Seguro()
            {
                Id = 2,
                CarroId = 3,
                SeguradoId = 1,
                PrecoSeguro = 4055.62,
            });
            seguros.Add(new Seguro()
            {
                Id = 3,
                CarroId = 4,
                SeguradoId = 1,
                PrecoSeguro = 4866.75
            });

            return seguros;

        }
    }
}
