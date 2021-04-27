using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoEstoque.Classes
{
    public class Chamados
    {

        public Equipamento equipamentoChamados = new Equipamento();
        
        public Chamados[] arrayChamados = new Chamados[1000];

        private int idChamado { get; set; }

        public string tituloChamado { get; set; }

        public string descricaoChamados { get; set; }

        public DateTime dataAberturaChamados { get; set; }

        



        public Chamados()
        {

        }

        public Chamados(int id, string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {

            idChamado = id;
            tituloChamado = titulo;
            descricaoChamados = descricao;
            equipamentoChamados = equipamento;
            dataAberturaChamados = dataAbertura;
            

        }

        public void Create(int contador, Chamados chamados)
        {
            arrayChamados[contador] = chamados;
        }

        public void Read(int contador)
        {
            for (int i = 0; i < contador; i++)
            {
                if (arrayChamados[i] != null)
                {

                    Console.WriteLine(arrayChamados[i].listarChamados());

                }
            }
        }

        public void ReadEditarExcluir()
        {
            for (int i = 0; i < arrayChamados.Length; i++)
            {
                if (arrayChamados[i] != null)
                {
                    Console.WriteLine(arrayChamados[i].selecionarChamados());
                }
            }


        }

        

        public void Edit(int idPesquisa, Chamados chamados)
        {

            for (int i = 0; i < arrayChamados.Length; i++)
            {

                arrayChamados[idPesquisa] = chamados;

            }
        }

        public void Delete(int idPesquisa)
        {


            for (int i = 0; i < arrayChamados.Length; i++)
            {


                arrayChamados[idPesquisa] = null;

            }
        }

        public bool verificaIdValido(int idPesquisa)
        {
            for (int i = 0; i < arrayChamados.Length; i++)
            {
                if (arrayChamados[i].idChamado == idPesquisa)
                {
                    return true;

                }
            }
            return false;

        }


        public string listarChamados()
        {
            // String para formatar data dd/MM/yyyy
            string formataData = Convert.ToString(dataAberturaChamados.ToString("dd/MM/yyyy"));
            
            TimeSpan calculaDiferenca = DateTime.Now.Subtract(dataAberturaChamados);
            
            
            int dias = calculaDiferenca.Days;
            
            
            
            return "------------------------------" + "\n" +
                    " ID:  " + idChamado  + "\n" +
                    " TITULO DO CHAMADO: " + tituloChamado + "\n" +
                    " EQUIPAMENTO: " + equipamentoChamados.NomeEquipamento + "\n" +
                    " DATA DE ABERTURA: " + formataData + "\n" +
                    " DIAS ABERTOS: " + dias + "\n" +
                    
                    "------------------------------" + "\n";
        }

        public String selecionarChamados()
        {


            return "------------------------------" + "\n" +

                    " ID: " + idChamado + "\n" +
                    " TITULO: " + tituloChamado + "\n" +
                    " NOME EQUIPAMENTO: " + equipamentoChamados.NomeEquipamento + "\n" +
                    "------------------------------" + "\n";

        }
    }
}
