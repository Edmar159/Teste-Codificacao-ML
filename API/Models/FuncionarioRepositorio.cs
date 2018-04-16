using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class FuncionarioRepositorio : IFuncionarioRepositorio
    {
        private List<Funcionario> funcionarios = new List<Funcionario>();
        private int _nextId = 1;
 
        public FuncionarioRepositorio()
        { // Insere funcionarios em memória
            Add(new Funcionario { Nome = "Rodrigo Carvalho", Email = "rodrigo@luizalabs.com", Department = "IntegraCommerce" });
            Add(new Funcionario { Nome = "Renato Pedigoni", Email = "renato@luizalabs.com", Department = "Digital Plataform" });
            Add(new Funcionario { Nome = "Thiago Catoto", Email = "catoto@luizalabs.com", Department = "Mobile" });
        }
 
        public Funcionario Add(Funcionario funcionario)
        {
            if(funcionario == null)
            {
                throw new ArgumentNullException("funcionario");
            }
            funcionario.Id = _nextId++;
            funcionarios.Add(funcionario);
            return funcionario;
        }
 
        public Funcionario Get(int id)
        {
            return funcionarios.Find(p => p.Id == id);
        }
 
        public IEnumerable<Funcionario> GetAll()
        {
            return funcionarios;
        }
 
        public void Remove(int id)
        {
            funcionarios.RemoveAll(p => p.Id == id);
        }

    public bool Update(Funcionario funcionario)
        {
            if(funcionario == null)
            {
                throw new ArgumentNullException("funcionario");
            }
 
            int index = funcionarios.FindIndex(p => p.Id == funcionario.Id);
 
            if(index == -1)
            {
                return false;
            }
            funcionarios.RemoveAt(index);
            funcionarios.Add(funcionario);
            return true;
        }
    }

}