using AppGerenciamentoFrota.Data.Entities;
using AppGerenciamentoFrota.Domain;
using AppGerenciamentoFrota.Enums;
using AppGerenciamentoFrota.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Runtime.Serialization;
using Xunit;

namespace TesteGerenciamentoFrota
{
    public class TesteGerenciamentoFrotaBll
    {
        private readonly Mock<IVeiculoRepository> _repository;

        public TesteGerenciamentoFrotaBll()
        {
            _repository = new Mock<IVeiculoRepository>();
        }

        [Fact]
        public void ListarVeiculos_Sucesso()
        {            
            List<Veiculo> veiculos = new List<Veiculo>() { new Veiculo() { Chassi = "TESTE123", Cor = "AZUL", Tipo = ETipoVeiculo.Onibus, NumeroPassageiro = 42 } };           
            _repository.Setup(c => c.ListarVeiculos()).Returns(veiculos);

            GerenciamentoFrotaBll gerenciamentoFrota = new GerenciamentoFrotaBll(_repository.Object);
            Assert.True(gerenciamentoFrota.ListarVeiculos().Count > 0);
        }

        [Fact]
        public void ListarVeiculos_Erro()
        {
            var ex = FormatterServices.GetUninitializedObject(typeof(SqlException)) as SqlException;

            _repository.Setup(c => c.ListarVeiculos()).Throws(ex);

            GerenciamentoFrotaBll gerenciamentoFrota = new GerenciamentoFrotaBll(_repository.Object);
            Assert.Throws<SqlException>(() => gerenciamentoFrota.ListarVeiculos());
        }

        [Fact]
        public void RetornaNumeroPassageiroOnibus_Sucesso()
        {
            var onibus = ETipoVeiculo.Onibus;

            GerenciamentoFrotaBll gerenciamentoFrota = new GerenciamentoFrotaBll(_repository.Object);

            var numeroPassageiro = gerenciamentoFrota.RetornaNumeroPassageiro(onibus);
            byte numeroPassageiroEsperado = 42;

            Assert.Equal(numeroPassageiroEsperado, numeroPassageiro);
        }

        [Fact]
        public void RetornaNumeroPassageiroCaminhao_Sucesso()
        {
            var caminhao = ETipoVeiculo.Caminhao;

            GerenciamentoFrotaBll gerenciamentoFrota = new GerenciamentoFrotaBll(_repository.Object);

            var numeroPassageiro = gerenciamentoFrota.RetornaNumeroPassageiro(caminhao);
            byte numeroPassageiroEsperado = 2;

            Assert.Equal(numeroPassageiroEsperado, numeroPassageiro);
        }
    }
}
