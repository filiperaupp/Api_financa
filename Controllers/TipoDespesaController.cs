

using System.Collections.Generic;
using financa_domain;
using financa_repository;
using Microsoft.AspNetCore.Mvc;

namespace financa_api.Controllers
{
    [Route("api/[controller]")]
    public class TipoDespesaController : Controller
    {
        private readonly ITipoDespesaRepository repository;

        public TipoDespesaController (ITipoDespesaRepository repository) 
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<TipoDespesa> Get()
        {
            return repository.GetAll();
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public TipoDespesa Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody]TipoDespesa tipoDespesa)
        {
            if (tipoDespesa == null)
                return BadRequest();

            repository.Create(tipoDespesa);

            return CreatedAtAction("Get", new { id = tipoDespesa.id}, tipoDespesa);
        }

        // PUT api/todo
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TipoDespesa tipoDespesa)
        {
            if (tipoDespesa == null)
                return BadRequest();

            repository.Update(tipoDespesa);

            return Ok(tipoDespesa);
        }

        // DELETE api/todo
        [HttpDelete("{id}")]
        public IActionResult Delete (int id) 
        {
            repository.Delete(id);

            return Ok(
                new {retorno = "Deletado com sucesso", id = id}
            );
        }
    }
}