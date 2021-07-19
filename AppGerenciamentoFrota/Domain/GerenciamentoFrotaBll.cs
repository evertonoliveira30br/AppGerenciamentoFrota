using AppGerenciamentoFrota.Data.Entities;
using AppGerenciamentoFrota.Enums;
using AppGerenciamentoFrota.Infra;
using AppGerenciamentoFrota.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AppGerenciamentoFrota.Domain
{
    public class GerenciamentoFrotaBll : IGerenciamentoFrotaBll
    {
        private readonly IVeiculoRepository _frotaRepository;
        public GerenciamentoFrotaBll(IVeiculoRepository frotaRepository)
        {
            _frotaRepository = frotaRepository;
        }

        public void DeletarVeiculo(Veiculo veiculo)
        {
            _frotaRepository.DeletarVeiculo(veiculo);
        }

        public void EditarVeiculo(Veiculo veiculo)
        {
            _frotaRepository.EditarCorVeiculo(veiculo);
        }

        public void InserirVeiculo(Veiculo veiculo)
        {
            veiculo.NumeroPassageiro = RetornaNumeroPassageiro(veiculo.Tipo);

            _frotaRepository.InserirNovoVeiculo(veiculo);
        }

        public List<Veiculo> ListarVeiculos()
        {
            return _frotaRepository.ListarVeiculos().ToList();
        }

        public Veiculo PesquisarVeiculoPorChassi(string chassi)
        {
            return _frotaRepository.PesquisarVeiculoPorChassi(chassi);
        }
        
        public byte RetornaNumeroPassageiro(ETipoVeiculo tipo)
        {
            if (tipo.Equals(ETipoVeiculo.Onibus)) return 42;

            if (tipo.Equals(ETipoVeiculo.Caminhao)) return 2;

            return 0;
        }
    }
}
