using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroFuncionarios.Models
{
    public interface IFuncionarioDAL
    {
        IEnumerable<Funcionario> GetAllFuncionarios();

        void AdicionarFuncionario(Funcionario funcionario);
        void EditarFuncionario(Funcionario funcionario);
        void ExcluirFuncionario(int? cod);

        Funcionario GetFuncionario(int? cod);
    }
}
