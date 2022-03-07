using crudapijwtdelete.Interfaces;
using crudapijwtdelete.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace crudapijwtdelete.Repositorys
{
    public class PessoaRepository : IPessoa
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Pessoa> GetPessoas()
        {
            return _context.Pessoas.ToList();
        }

        public Pessoa Get(int id)
        {
            return _context.Pessoas.Find(id);
        }

        public void Add(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
        }

        public void Update(Pessoa pessoa)
        {
            _context.Entry(pessoa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Pessoa Remove(int id)
        {
            Pessoa pessoa = _context.Pessoas.Find(id);
            
            if(pessoa != null)
            {
                _context.Pessoas.Remove(pessoa);
                _context.SaveChanges();
            }
            return pessoa;
        }
    }
}
