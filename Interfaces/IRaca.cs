using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface IRaca
    {
        List<racas> Listar();

        racas BuscarPorId(int id);

        racas Cadastrar(racas a);

        racas Alterar(int id, racas a);

        void Excluir(int id);
    }
}


