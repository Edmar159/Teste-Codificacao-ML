using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class FuncionariosController : ApiController
    {
        static readonly IFuncionarioRepositorio repositorio = new FuncionarioRepositorio();
 
        public IEnumerable<Funcionario> GetAllFuncionarios()
        { // Busca todos os funcionarios cadastrados.
            return repositorio.GetAll();
        }
 
        public Funcionario GetFuncionarios(int id)
        {   // busca funcionário por ID
            Funcionario funcionario = repositorio.Get(id);
            if (funcionario == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return funcionario;
        }
 
        public IEnumerable<Funcionario> GetFuncionariosPorEmail(string email)
        {  // Busca funcionários por E-mail
            return repositorio.GetAll().Where(
                p => string.Equals(p.Email, email, StringComparison.OrdinalIgnoreCase));
        }
 
        public HttpResponseMessage PostFuncionario(Funcionario funcionario)
        {   // Cadastra novo funcionário
            funcionario = repositorio.Add(funcionario);
            var response = Request.CreateResponse<Funcionario>(HttpStatusCode.Created, funcionario);
 
            string uri = Url.Link("DefaultApi", new { id = funcionario.Id });
            response.Headers.Location = new Uri(uri);
            return response;
        }
 
        public void PutFuncionarios(int id, Funcionario funcionario)
        {   // Atualiza dados de um funcionário, de acordo com o ID
            funcionario.Id = id;
            if (!repositorio.Update(funcionario))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
 
        public void DeleteFuncionarios(int id)
        {  // Deleta funcionários de acordo com o ID
            Funcionario funcionario = repositorio.Get(id);
 
            if (funcionario == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
 
            repositorio.Remove(id);
        }
    }

}
