using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Models
{
    interface IFuncionarioRepositorio
    {
        IEnumerable<Funcionario> GetAll();
       Funcionario Get(int id);
       Funcionario Add(Funcionario funcionario);
       void Remove(int id);
       bool Update(Funcionario funcionario);
    }
}
