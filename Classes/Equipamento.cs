using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEstoque.Classes
{
    public class Equipamento
    {
        public Equipamento[] arrayEquipamento = new Equipamento[1000];

        private int idEquipamento { get; set; }

        private int pesquisa { get; set; }

        private string nomeEquipamento;
        private int nSerieEquipamento { get; set; }
        private string fabricanteEquipamento { get; set; }
        private DateTime dataFabricacaoEquipamento { get; set; }
        private double precoEquipamento { get; set; }
        public string NomeEquipamento { get => nomeEquipamento; set => nomeEquipamento = value; }





        // COnstrutor para isntaciar o equipamento
        public Equipamento()
        {

        }

        //Construtor para receber informcaçãos do equipamento 
        public Equipamento(int id, string nome, int Nserie, string fabricante, DateTime dataFabricacao, double preco)
        {

            idEquipamento = id;
            nomeEquipamento = nome;
            nSerieEquipamento = Nserie;
            fabricanteEquipamento = fabricante;
            dataFabricacaoEquipamento = dataFabricacao;
            precoEquipamento = preco;

        }

        public void Create(int contador, Equipamento equipamento)
        {
            arrayEquipamento[contador] = equipamento;
        }


        public void Read(int contador)
        {
            for (int i = 0; i < contador; i++)
            {
                if (arrayEquipamento[i] != null)
                {

                    Console.WriteLine(arrayEquipamento[i].listarEquipamentos());

                }
            }
        }

        public void ReadEditarExcluir()
        {
            for (int i = 0; i < arrayEquipamento.Length; i++)
            {
                if (arrayEquipamento[i] != null)
                {
                    Console.WriteLine(arrayEquipamento[i].selecionarEquipamento());
                }
            }


        }


        public void Edit(int idPesquisa, Equipamento equipamento)
        {


            for (int i = 0; i < arrayEquipamento.Length; i++)
            {


                arrayEquipamento[idPesquisa] = equipamento;

            }
        }

        public void Delete(int idPesquisa)
        {


            for (int i = 0; i < arrayEquipamento.Length; i++)
            {


                arrayEquipamento[idPesquisa] = null;

            }
        }

        public bool verificaIdValido(int idPesquisa)
        {
            for (int i = 0; i < arrayEquipamento.Length; i++)
            {
                if (arrayEquipamento[i].idEquipamento == idPesquisa)
                {
                    return true;

                }
            }
            return false;

        }

        public Equipamento RetornaEquipamento(int idPesquisado,Equipamento equipamento)
        {
            for (int i = 0; i < arrayEquipamento.Length; i++)
            {
                if (arrayEquipamento[i].idEquipamento == idPesquisado)
                {
                    equipamento = arrayEquipamento[i];
                    return equipamento;
                }
            }

            return equipamento;

        }

        // Metodo para listar os equipamentos 
        public String listarEquipamentos()
        {
            // String para formatar data dd/MM/yyyy
            string formataData = Convert.ToString(dataFabricacaoEquipamento.ToString("dd/MM/yyyy"));

            return "------------------------------" + "\n" +

                    " ID: " + idEquipamento + "\n" +
                    " NOME: " + nomeEquipamento + "\n" +
                    " NUMERO DE SERIE: " + nSerieEquipamento + "\n" +
                    " FABRICANTE: " + fabricanteEquipamento + "\n" +
                    " DATA FABRICAÇÃO: " + formataData + "\n" +
                    " PREÇO: " + precoEquipamento + "\n" +

                    "------------------------------" + "\n";

        }

        // Metodo para retornar só o id e o nome 

        public String selecionarEquipamento()
        {


            return "------------------------------" + "\n" +

                    " ID: " + idEquipamento + "\n" +
                    " NOME: " + nomeEquipamento + "\n" +

                    "------------------------------" + "\n";

        }


        public bool VerificaNome(string nome)
        {
            nomeEquipamento = nome;

            if(nomeEquipamento.Length < 6) { return false; }

            return true;
        }

        public bool VerificaCampos(int id, string nome, int Nserie, string fabricante, DateTime dataFabricacao, double preco)
        {


            idEquipamento = id;
            nomeEquipamento = nome;
            nSerieEquipamento = Nserie;
            fabricanteEquipamento = fabricante;
            dataFabricacaoEquipamento = dataFabricacao;
            precoEquipamento = preco;

           

            if (idEquipamento  < 0 || nomeEquipamento == "" || nSerieEquipamento <  0 || fabricanteEquipamento == "" || 
                dataFabricacaoEquipamento == DateTime.MinValue || precoEquipamento < 0)
            {
                return false;
            }

            return true;
        }

        

    }
}





















