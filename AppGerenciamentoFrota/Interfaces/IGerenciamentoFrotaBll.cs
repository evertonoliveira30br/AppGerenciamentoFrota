using AppGerenciamentoFrota.Data.Entities;
using System.Collections.Generic;

namespace AppGerenciamentoFrota.Infra
{
    public interface IGerenciamentoFrotaBll
    {
        void InserirVeiculo(Veiculo veiculo);
        void EditarVeiculo(Veiculo veiculo);
        void DeletarVeiculo(Veiculo veiculo);
        List<Veiculo> ListarVeiculos();
        Veiculo PesquisarVeiculoPorChassi(string chassi);
    }
}
