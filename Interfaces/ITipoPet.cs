using APIPets.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Interfaces
{
    interface ITipoPet
    {
        List<tipopet> Listar();

        tipopet BuscarPorId(int id);

        tipopet Cadastrar(tipopet a);

        tipopet Alterar(int id, tipopet a);

        void Excluir(int id);
    }
}
