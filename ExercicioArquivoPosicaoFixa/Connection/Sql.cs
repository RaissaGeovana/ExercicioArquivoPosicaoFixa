using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ExercicioArquivoPosicaoFixa
{
    public class Sql
    {
        private readonly SqlConnection _conexao;

        public Sql ()
       
        {

        this._conexao = new SqlConnection(@"Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;");
        
        }
      public void InserirCliente (Pessoa pessoas)
    {
        try

        {
            _conexao.Open();

            string sql = @" INSERT INTO Cliente
                            (Nome, Cpf, Genero, Idade, Nacionalidade)
                             VALUES
                             (@nome, @cpf, @sexo, @idade, @nacionalidade);";

            using (SqlCommand cmd = new SqlCommand(sql, _conexao))

            {
                cmd.Parameters.AddWithValue("nome", pessoas.nome);
                cmd.Parameters.AddWithValue("cpf", pessoas.cpf);
                cmd.Parameters.AddWithValue("sexo", pessoas.sexo);
                cmd.Parameters.AddWithValue("idade", pessoas.idade);
                cmd.Parameters.AddWithValue("nacionalidade", pessoas.nacionalidade);
                cmd.ExecuteNonQuery();
            }
        }

        finally
        {
            _conexao.Close();
        }
    } }
}

