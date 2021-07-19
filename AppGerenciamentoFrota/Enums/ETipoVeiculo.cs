using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace AppGerenciamentoFrota.Enums
{
   public enum ETipoVeiculo : byte
    {
        [Description("Ônibus")]
        Onibus = 1,
        [Description("Caminhão")]
        Caminhao = 2
    }
}
