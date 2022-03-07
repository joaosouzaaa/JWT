using crudapijwtdelete.Interfaces;
using crudapijwtdelete.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace crudapijwtdelete.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoa _pessoa;

        public PessoasController(IPessoa pessoa)
        {
            _pessoa = pessoa;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pessoa>>> GetAll()
        {
            return await Task.FromResult(_pessoa.GetPessoas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            return await Task.FromResult(_pessoa.Get(id));
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Post(Pessoa pessoa)
        {
            _pessoa.Add(pessoa);
            return Ok(pessoa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pessoa>> Put(Pessoa pessoa, int id)
        {
            if(pessoa.Id != id)
            {
                return BadRequest();
            }

            _pessoa.Update(pessoa);
            return Ok(pessoa);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> Delete(int id)
        {
            Pessoa pessoa = _pessoa.Remove(id);
            return await Task.FromResult(pessoa);
        }
    }
}
