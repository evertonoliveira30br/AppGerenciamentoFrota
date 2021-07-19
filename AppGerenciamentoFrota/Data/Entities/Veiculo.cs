using AppGerenciamentoFrota.Enums;

namespace AppGerenciamentoFrota.Data.Entities
{
    public class Veiculo
    {
        public long Id { get; set; }
        public string Chassi { get; set; }
        public string Cor { get; set; }
        public ETipoVeiculo Tipo { get; set; }     
        public byte NumeroPassageiro { get; set; }
    }
}
