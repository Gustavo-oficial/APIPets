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
    public class TipodePetRepository : ITipoPet
    {
        PetsContext conexao = new PetsContext();

        SqlCommand cmd = new SqlCommand();

        public tipopet Alterar(int id, tipopet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "UPDATE tipopet SET " +
                "Descricao = @descricao WHERE IdTipoPets = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@descricao", a.Descricao);


            cmd.ExecuteNonQuery();

            conexao.Desconectar();

            return a;
        }

        public tipopet BuscarPorId(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipopet WHERE IdTipoPets = @id";
            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader dados = cmd.ExecuteReader();

            tipopet a = new tipopet();

            while (dados.Read())
            {
                a.IdTipoPets = Convert.ToInt32(dados.GetValue(0));
                a.Descricao = dados.GetValue(1).ToString();
            }

            conexao.Desconectar();

            return a;
        }

        public tipopet Cadastrar(tipopet a)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "INSERT INTO tipopet (Descricao) " +
                "VALUES" +
                "(@descricao)";
            cmd.Parameters.AddWithValue("@descricao", a.Descricao);

            cmd.ExecuteNonQuery();

            return a;
        }

        public void Excluir(int id)
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "DELETE FROM tipopet WHERE IdTipoPets = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public List<tipopet> Listar()
        {
            cmd.Connection = conexao.Conectar();

            cmd.CommandText = "SELECT * FROM tipopet";

            SqlDataReader dados = cmd.ExecuteReader();

            List<tipopet> pets = new List<tipopet>();

            while (dados.Read())
            {
                pets.Add(
                    new tipopet()
                    {
                        IdTipoPets = Convert.ToInt32(dados.GetValue(1)),
                        Descricao = dados.GetValue(2).ToString(),
                    }
                );
            }

            conexao.Desconectar();

            return pets;
        }
    }
}
