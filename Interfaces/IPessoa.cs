using crudapijwtdelete.Models;
using System.Collections.Generic;

namespace crudapijwtdelete.Interfaces
{
    public interface IPessoa
    {
        public List<Pessoa> GetPessoas();

        public Pessoa Get(int id);

        public void Add(Pessoa pessoa);

        public void Update(Pessoa pessoa);

        public Pessoa Remove(int id);
    }
}
