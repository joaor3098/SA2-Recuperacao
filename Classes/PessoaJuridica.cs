using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SA2.Classes
{
    // Classe
    public class PessoaJuridica : Pessoa
    {
        // Atributos
        public string? Cnpj { get; set; }

        //Validar CNPJ
        // Validar se tem 18 caracteres
        // Validar formato XX.XXX.XXX/0001-XX
        public bool ValidarCnpj(string cnpj)
        {
            if (cnpj.Length == 18)
            {
                if (cnpj.Substring(11,4) == "0001")
                return true;
            }
            return false;
        }

        //Ler os dados de uma PJ de um arquivo .txt
        public PessoaJuridica Ler(string nomeArquivo)
        {
            PessoaJuridica pj = new PessoaJuridica();

            using(StreamReader sr = new StreamReader(nomeArquivo+".txt"))
            {
                string[] atributos = sr.ReadLine()!.Split(",");

                pj.Nome = atributos[0];
                pj.Rendimento = float.Parse(atributos[1]); ;
                pj.Cnpj = atributos[2];
            }
            return pj;
        }

        //Grava o arquivo txt com as informações da Pessoa Juridica
        public void Inserir(PessoaJuridica pj)
        {
            using(StreamWriter sw = new StreamWriter(pj.Nome+".txt"))
            {
                sw.WriteLine($"{pj.Nome},{pj.Rendimento},{pj.Cnpj}");
            }
        }
    }
}