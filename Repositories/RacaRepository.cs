using APIPets.Context;
using APIPets.Domains;
using APIPets.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
namespace APIPets.Repositories
{
    public class RacaRepository : IRaca
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();

        public racas Alterar(int id, racas a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE racas SET " +
                "Nome = @nome, " +
                "IdTipoPets = @idtipopets WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@nome", a.Nome);

            cmd.Parameters.AddWithValue("@idtipopets", a.IdTipoPets);

            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public racas BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM racas WHERE IdRaca = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            racas a = new racas();

            while (dados.Read())
            {
                a.IdRaca = Convert.ToInt32(dados.GetValue(0));
                a.Nome = dados.GetValue(1).ToString();
                a.IdTipoPets = Convert.ToInt32(dados.GetValue(2));
            }

            conexao.Desconectar();

            return a;
        }

        public racas Cadastrar(racas a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO racas (Nome) " +
                "VALUES" +
                "(@nome)";
            cmd.Parameters.AddWithValue("@nome", a.Nome);

            cmd.ExecuteNonQuery();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM racas WHERE IdRaca = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public List<racas> Listar()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM racas";

            SqlDataReader dados = cmd.ExecuteReader();

            List<racas> raca = new List<racas>();

            while (dados.Read())
            {
                raca.Add(
                    new racas()
                    {
                        IdRaca = Convert.ToInt32(dados.GetValue(0)),
                        Nome = dados.GetValue(1).ToString(),
                        IdTipoPets= Convert.ToInt32(dados.GetValue(2)),
                    }
                );
            }

            conexao.Desconectar();

            return raca;
        }
    }
}
