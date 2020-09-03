using APIPets.Domains;
using APIPets.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIPets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipodePetController : ControllerBase
    {
        TipodePetRepository reposi = new TipodePetRepository();

        // GET: api/<TipodePetController>
        [HttpGet]
        public List<tipopet> Get()
        {
            return reposi.Listar();
        }

        // GET api/<TipodePetController>/5
        [HttpGet("{id}")]
        public tipopet Get(int id)
        {
            return reposi.BuscarPorId(id);
        }

        // POST api/<TipodePetController>
        [HttpPost]
        public tipopet Post([FromBody] tipopet a)
        {
            return reposi.Cadastrar(a);
        }

        // PUT api/<TipodePetController>/5
        [HttpPut("{id}")]
        public tipopet Put(int id, [FromBody] tipopet a)
        {
            return reposi.Alterar(id, a);
        }

        // DELETE api/<TipodePetController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            reposi.Excluir(id);
        }
    }
}

