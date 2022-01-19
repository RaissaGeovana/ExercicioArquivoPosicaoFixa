using System;
using System.Text;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace ExercicioArquivoPosicaoFixa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            string arquivo = File.ReadAllText("C:\\Users\\rageo\\OneDrive\\Área de Trabalho\\Clientes.txt");

            string [] linhas = arquivo.Split("\r\n");
            {
                List<Pessoa> pessoas = new List<Pessoa>();

                foreach (var linha in linhas)
                {
                    var cpf = Convert.ToInt64(linha.Substring(0, 11));
                    var nome = linha.Substring(11, 80);
                    var sexo = linha.Substring(91, 1);
                    var idade = Convert.ToInt16(linha.Substring(92, 3));
                    var nacionalidade = linha.Substring(95, 20);

                    var pessoa = new Pessoa();
                     
                    pessoa.cpf = cpf;
                    pessoa.nome = nome;
                    pessoa.sexo = sexo;
                    pessoa.idade = idade;
                    pessoa.nacionalidade = nacionalidade;

                    pessoas.Add(pessoa);

                }

                foreach(var pessoa in pessoas)
                {
                    var sql = new Sql();
                    sql.InserirCliente(pessoa);
                }
            }
        }
    }
}
