using AppGerenciamentoFrota.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppGerenciamentoFrota.Interfaces
{
    public interface IVeiculoRepository
    {
        void InserirNovoVeiculo(Veiculo veiculo);
        IEnumerable<Veiculo> ListarVeiculos();
        Veiculo PesquisarVeiculoPorChassi(string chassi);
        void DeletarVeiculo(Veiculo veiculo);

        void EditarCorVeiculo(Veiculo veiculo);
    }

}
