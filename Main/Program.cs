using GerenciamentoEstoque.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEstoque
{
    class Program
    {
        static void Main(string[] args)
        {
            int nSerieEquipamento = 0;

            //Opcao para menu principal,chamado,equipamento
            string opcao = "";
            string opcaoEquipamento, opcaoChamado = "";

            //Contadores Id
            int idChamadosAutoIncrement = 0;
            int idEquipamentosAutoIncrement = 0;

            int selecionaEquipamentos = 0;
            string tituloChamado, descricaoChamado = "";

            string nomeEquipamento, fabricanteEquipamento = "";
            double precoFabricacaoEquipamento = 0;
            DateTime dataFabricacaoEquipamento, dataAberturaChamado;

            //Declarando o objeto
            Equipamento equipamento = new Equipamento();
            Chamados chamados = new Chamados();
            Equipamento equipamentoChamado = new Equipamento();

            while (opcao != "S")
            {
                opcao = MenuEquipamentoChamado();

                if (opcao == "1")
                {
                    opcaoEquipamento = menuEquipamento();

                    switch (opcaoEquipamento)
                    {
                        case "1":
                            {

                                Console.WriteLine("Informe o nome do equipamento");
                                nomeEquipamento = Console.ReadLine();

                                if (equipamento.VerificaNome(nomeEquipamento)) {}

                                else
                                {
                                    Console.WriteLine("QUANTIDADE DE CARACTERES INVALIDA, TENTE NOVAMENTE");
                                    Console.ReadLine();
                                    Console.Clear();
                                    continue;
                                }

                                Console.WriteLine("Informe a fabricante do equipamento");
                                fabricanteEquipamento = Console.ReadLine();

                                Console.WriteLine("Informe o numero de serie do equipamento");
                                nSerieEquipamento = Convert.ToInt32(Console.ReadLine());

                                Console.WriteLine("Informe a data de fabricacao do equipamento");
                                dataFabricacaoEquipamento = Convert.ToDateTime(Console.ReadLine());

                                Console.WriteLine("Informe a o preço do fabricação do equipamento");
                                precoFabricacaoEquipamento = Convert.ToDouble(Console.ReadLine());
                                Console.ReadLine();

                                equipamento.Create(idEquipamentosAutoIncrement,
                                new Equipamento(idEquipamentosAutoIncrement, nomeEquipamento, nSerieEquipamento, fabricanteEquipamento,
                                dataFabricacaoEquipamento, precoFabricacaoEquipamento));
                                

                                idEquipamentosAutoIncrement++;

                                Console.WriteLine("Equipamento cadastrado com sucesso");
                                Console.ReadLine();
                                Console.Clear();

                                break;

                            }
                        case "2":
                            {
                                equipamento.Read(idEquipamentosAutoIncrement);
                                Console.WriteLine();
                                Console.ReadLine();
                                Console.Clear();
                                break;
                            }
                        case "3":
                            {
                                int idEquipamentoPesquisa = 0;

                                equipamento.ReadEditarExcluir();

                                Console.WriteLine("Informe o id do equipamento pra ser editado ");
                                idEquipamentoPesquisa = Convert.ToInt32(Console.ReadLine());


                                if (equipamento.verificaIdValido(idEquipamentoPesquisa))
                                {

                                    Console.WriteLine("Informe o nome do equipamento");
                                    nomeEquipamento = Console.ReadLine();

                                    Console.WriteLine("Informe a fabricante do equipamento");
                                    fabricanteEquipamento = Console.ReadLine();

                                    Console.WriteLine("Informe o numero de serie do equipamento");
                                    nSerieEquipamento = Convert.ToInt32(Console.ReadLine());

                                    Console.WriteLine("Informe a data de fabricacao do equipamento");
                                    dataFabricacaoEquipamento = Convert.ToDateTime(Console.ReadLine());

                                    Console.WriteLine("Informe a o preço do fabricação do equipamento");
                                    precoFabricacaoEquipamento = Convert.ToDouble(Console.ReadLine());
                                    Console.ReadLine();


                                    equipamento.Edit(idEquipamentoPesquisa,
                                    new Equipamento(idEquipamentoPesquisa, nomeEquipamento, nSerieEquipamento, fabricanteEquipamento,
                                    dataFabricacaoEquipamento, precoFabricacaoEquipamento));


                                    Console.WriteLine("Equipamento editado com sucesso");
                                    Console.ReadLine();
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine("ID INVALIDO, TENTE NOVAMENTE");
                                    Console.ReadLine();
                                    Console.Clear();
                                    continue;
                                }
                                break;
                            }

                        case "4":
                            {
                                equipamento.ReadEditarExcluir();
                                int idEquipamentoExclui = 0;
                                Console.WriteLine("Informe o Id do respectivo equipamento para ser excluído");
                                idEquipamentoExclui = Convert.ToInt32(Console.ReadLine());

                                if (equipamento.verificaIdValido(idEquipamentoExclui))
                                {

                                    equipamento.Delete(idEquipamentoExclui);

                                    Console.WriteLine("Equipamento deletado com sucesso");
                                    Console.ReadLine();
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine("ID INVALIDO, TENTE NOVAMENTE");
                                    Console.ReadLine();
                                    Console.Clear();
                                    continue;
                                }

                            }
                            break;
                    }
                }

                else if (opcao == "2")
                {
                    opcaoChamado = menuChamado();

                    switch (opcaoChamado)
                    {
                        case "1":
                            {
                                

                                Console.WriteLine("Informe o título do chamado");
                                tituloChamado = Console.ReadLine();

                                Console.WriteLine("Informe a descrição do chamado");
                                descricaoChamado = Console.ReadLine();

                                Console.WriteLine("Informe a data de abertura do chamado");
                                dataAberturaChamado = Convert.ToDateTime(Console.ReadLine());

                                Console.WriteLine("Selecione o equipamento que deseja");

                                equipamento.ReadEditarExcluir();

                                Console.WriteLine("Escolha o equipamento desejado pelo seu respectivo id");
                                selecionaEquipamentos = Convert.ToInt32(Console.ReadLine());

                                equipamentoChamado = equipamento.RetornaEquipamento(selecionaEquipamentos, equipamento);

                                chamados.Create(idChamadosAutoIncrement,
                                new Chamados(idChamadosAutoIncrement, tituloChamado, descricaoChamado, equipamentoChamado, dataAberturaChamado));
                                

                                Console.WriteLine("Chamado cadastrado com sucesso");
                                Console.ReadLine();
                                Console.Clear();


                                idChamadosAutoIncrement++;
                                break;
                            }

                        case "2":
                            {
                                chamados.Read(idChamadosAutoIncrement);
                                Console.WriteLine();
                                Console.ReadLine();
                                Console.Clear();
                                break;

                            }

                        case "3":
                            {

                                int idChamadoPesquisa = 0;
                                chamados.ReadEditarExcluir();
                                Console.WriteLine("Informe o id do chamado que respectivamente vai ser editado");
                                idChamadoPesquisa = Convert.ToInt32(Console.ReadLine());

                                if (chamados.verificaIdValido(idChamadoPesquisa))
                                {

                                    Console.WriteLine("Informe o título do chamado");
                                    tituloChamado = Console.ReadLine();

                                    Console.WriteLine("Informe a descrição do chamado");
                                    descricaoChamado = Console.ReadLine();

                                    Console.WriteLine("Informe a data de abertura do chamado");
                                    dataAberturaChamado = Convert.ToDateTime(Console.ReadLine());

                                    equipamentoChamado = equipamento.RetornaEquipamento(idChamadoPesquisa, equipamento);

                                    chamados.Edit(idChamadoPesquisa,
                                    new Chamados(idChamadoPesquisa, tituloChamado, descricaoChamado, equipamentoChamado, dataAberturaChamado));


                                    Console.WriteLine("Chamado editado com sucesso");
                                    Console.ReadLine();
                                    Console.Clear();

                                    break;

                                }
                                else

                                {
                                    Console.WriteLine("ID INVALIDO, TENTE NOVAMENTE");
                                    Console.ReadLine();
                                    continue;

                                }

                            }
                        case "4":
                            { 
                                
                                int idChamadoExclui = 0;
                                chamados.ReadEditarExcluir();
                                Console.WriteLine("Informe o Id do respectivo chamado para ser excluído");
                                idChamadoExclui = Convert.ToInt32(Console.ReadLine());

                                if (chamados.verificaIdValido(idChamadoExclui))
                                {

                                    chamados.Delete(idChamadoExclui);

                                    Console.WriteLine("Chamado deletado com sucesso");
                                    Console.ReadLine();
                                    Console.Clear();

                                }
                                else
                                {
                                    Console.WriteLine("ID INVALIDO, TENTE NOVAMENTE");
                                    Console.ReadLine();
                                    Console.Clear();
                                    continue;
                                }

                                break;
                            }
                            
                    }
                }
                else if (EhOpcaoSair(opcao))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opção invalida, tente novamente");
                    Console.ReadLine();
                    continue;
                }
            }
        }


        private static string menuChamado()
        {
            string opcaoChamado;
            Console.WriteLine("1 - Para cadastrar chamados");
            Console.WriteLine("2 - Para listar chamados");
            Console.WriteLine("3 - Para editar chamados");
            Console.WriteLine("4 - Para excluir chamados");
            opcaoChamado = Console.ReadLine();
            return opcaoChamado;
        }

        private static string menuEquipamento()
        {
            string opcaoEquipamento;
            Console.WriteLine("1 - Para cadastrar equipamentos");
            Console.WriteLine("2 - Para listar equipamentos");
            Console.WriteLine("3 - Para editar equipamentos");
            Console.WriteLine("4 - Para excluir equipamentos");
            opcaoEquipamento = Console.ReadLine();
            return opcaoEquipamento;
        }

        private static string MenuEquipamentoChamado()
        {
            string opcao;
            Console.WriteLine(" Gerenciamento de Estoque");
            Console.WriteLine("1 - Para equipamentos");
            Console.WriteLine("2 - Para chamados");
            Console.WriteLine("S - Para sair");
            opcao = Console.ReadLine();
            return opcao;
        }

        private static bool EhOpcaoSair(string opcao)
        {
            return opcao.Equals("s", StringComparison.OrdinalIgnoreCase);
        }
    }
}






