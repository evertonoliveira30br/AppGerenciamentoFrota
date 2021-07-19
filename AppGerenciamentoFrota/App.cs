using AppGerenciamentoFrota.Commons;
using AppGerenciamentoFrota.Data.Entities;
using AppGerenciamentoFrota.Enums;
using AppGerenciamentoFrota.Infra;
using System;
using System.Linq;
using System.Threading;

namespace AppGerenciamentoFrota
{
    public class App
    {
        private readonly IGerenciamentoFrotaBll _frotaBll;
                
        public App(IGerenciamentoFrotaBll frotaBll)
        {
            _frotaBll = frotaBll;
        }

        public void Run()
        {
            MontarMenu();
        }

        private void MontarMenu()
        {
            Thread.Sleep(1000);
            LimparConsole();
            ListarOpcoes();
        }

        private void ListarOpcoes()
        {
            
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir Veiculo");
            Console.WriteLine("2 - Editar Veiculo");
            Console.WriteLine("3 - Deletar Veiculo");
            Console.WriteLine("4 - Listar Todos Veiculos");
            Console.WriteLine("5 - Pesquisar Veiculo Por Chassi");
            Console.WriteLine("6 - Sair do Sistema");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    InserirNovoVeiculo();
                    break;

                case "2":
                    EditarVeiculo();
                    break;

                case "3":
                    DeletarVeiculo();
                    break;

                case "4":
                    ListarVeiculos();
                    break;

                case "5":
                    LocalizarVeiculoPorChassi();
                    break;

                case "6":
                    SairAplicacao();
                    break;

                default:
                    Console.WriteLine("Opção Inválida!");                    
                    MontarMenu();
                    break;
            }
        }

        private void InserirNovoVeiculo()
        {           

            LimparConsole();

            try
            {
                Console.Write("Informe o Chassi do Veiculo:");
                var chassi = Console.ReadLine();

                if (_frotaBll.PesquisarVeiculoPorChassi(chassi) != null)
                {
                    Console.WriteLine("O chassi do veículo informado ja existe!");
                    MontarMenu();
                }

                Console.Write("Informe o Tipo do Veiculo (1 = Ônibus; 2 = Caminhão):");
                var tipo = Console.ReadLine();
                Console.Write("Informe a Cor do Veiculo:");
                var cor = Console.ReadLine();

                _frotaBll.InserirVeiculo(new Veiculo
                {
                    Chassi = chassi,
                    Tipo = EnumHelper.GetEnumValue<ETipoVeiculo>(int.Parse(tipo)),
                    Cor = cor
                });

                Console.WriteLine("Veiculo adicionado com Sucesso!");                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao Inserir Novo Veículo.{ex.Message}");
            }
            finally { MontarMenu(); }

        }

        private void ListarVeiculos()
        {
            LimparConsole();

            try
            {
                var veiculos = _frotaBll.ListarVeiculos();

                if (veiculos.Count.Equals(0))
                {
                    Console.WriteLine("Não existem nenhum veículo cadastrado");
                    MontarMenu();
                }

                veiculos.ForEach(v => {
                    Console.WriteLine($"CHASSI: {v.Chassi};COR: {v.Cor};TIPO: {v.Tipo.GetDescription()};NÚMERO PASSAGEIROS: {v.NumeroPassageiro}");
                });

                Console.ReadKey();                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao Listar Veículos.{ex.Message}");
            }
            finally { MontarMenu(); }

            

        }

        private void LimparConsole() => Console.Clear();

        private void LocalizarVeiculoPorChassi()
        {
            
            LimparConsole();

            try
            {
                Console.Write("Informe o número do Chassi:");
                var chassi = Console.ReadLine();

                var veiculo = _frotaBll.PesquisarVeiculoPorChassi(chassi);

                if (veiculo == null)
                {
                    Console.WriteLine("Não existe nenhum veículo para o chassi informado.");
                }
                else
                {
                    Console.WriteLine($"CHASSI: {veiculo.Chassi};COR: {veiculo.Cor};TIPO: {veiculo.Tipo.GetDescription()};NÚMERO PASSAGEIROS: {veiculo.NumeroPassageiro}");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao Listar Veículos.{ex.Message}");
            }
            finally { MontarMenu(); }          
                      
        }
        
        private void DeletarVeiculo()
        {
            LimparConsole();

            try
            {
                Console.Write("Informe o número do Chassi:");
                var chassi = Console.ReadLine();

                var veiculo = _frotaBll.PesquisarVeiculoPorChassi(chassi);

                if (veiculo == null)
                {
                    Console.WriteLine("Não existe nenhum veículo para o chassi informado.");
                }
                else
                {
                    Console.WriteLine($"CHASSI: {veiculo.Chassi};COR: {veiculo.Cor};TIPO: {veiculo.Tipo.GetDescription()};NÚMERO PASSAGEIROS: {veiculo.NumeroPassageiro}");
                    Console.Write("Deseja realmente Excluir este veículo?(S/N)");
                    var opcao = Console.ReadLine();

                    switch (opcao.ToUpper())
                    {
                        case "S":
                            _frotaBll.DeletarVeiculo(veiculo);
                            Console.WriteLine("Veiculo excluído com Sucesso");
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao Listar Veículos.{ex.Message}");
            }
            finally { MontarMenu(); }

           
        }

        private void EditarVeiculo()
        {
            LimparConsole();

            try
            {
                Console.Write("Informe o número do Chassi:");
                var chassi = Console.ReadLine();

                var veiculo = _frotaBll.PesquisarVeiculoPorChassi(chassi);

                if (veiculo == null)
                {
                    Console.WriteLine("Não existe nenhum veículo para o chassi informado.");
                }
                else
                {
                    Console.WriteLine($"CHASSI: {veiculo.Chassi};COR: {veiculo.Cor};TIPO: {veiculo.Tipo.GetDescription()};NÚMERO PASSAGEIROS: {veiculo.NumeroPassageiro}");
                    Console.Write("Só é possivel alterar a Cor do Veiculo, qual a nova cor:");
                    var cor = Console.ReadLine();

                    veiculo.Cor = cor;
                    _frotaBll.EditarVeiculo(veiculo);
                    Console.WriteLine("Cor alterado com sucesso!");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao Listar Veículos.{ex.Message}");
            }
            finally { MontarMenu(); }         

           
        }

        private void SairAplicacao()
        {
            Console.Write("Deseja Realmente sair da Aplicação (S/N)?");
            var resposta = Console.ReadLine();

            switch (resposta.ToUpper())
            {
                case "S":
                    Environment.ExitCode = 1;
                    break;

                case "N":
                    MontarMenu();
                    break;

                default:
                    Console.WriteLine("Opção Inválida!");                    
                    MontarMenu();
                    break;
            }
        }
    }
}
