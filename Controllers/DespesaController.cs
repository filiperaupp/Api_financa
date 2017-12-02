

using System.Collections.Generic;
using financa_domain;
using financa_repository;
using Microsoft.AspNetCore.Mvc;

namespace financa_api.Controllers
{
    [Route("api/[controller]")]
    public class DespesaController : Controller
    {
        private readonly IDespesaRepository repository;

        public DespesaController (IDespesaRepository repository) 
        {
            this.repository = repository;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var lista = repository.GetAll();
            return Ok(lista);
        }

        // GET api/todo/5
        [HttpGet("{id}")]
        public Despesa Get(int id)
        {
            return repository.GetById(id);
        }

        // POST api/todo
        [HttpPost]
        public IActionResult Post([FromBody]Despesa despesa)
        {
            if (despesa == null)
                return BadRequest();

            repository.Create(despesa);

            return CreatedAtAction("Get", new { id = despesa.id}, despesa);
        }

        // PUT api/todo
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Despesa despesa)
        {
            if (despesa == null)
                return BadRequest();

            repository.Update(despesa);

            return Ok(despesa);
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