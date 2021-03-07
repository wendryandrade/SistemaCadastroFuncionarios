using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroFuncionarios.Models
{
    public class Funcionario
    {
        public int CodFuncionario { get; set; }

        [Required(ErrorMessage = "O preenchimento do nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O preenchimento da data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O preenchimento do salário é obrigatório")]
        public decimal Salario { get; set; }

        [Required(ErrorMessage = "O preenchimento das atividades é obrigatório")]
        public string Atividades { get; set; }
    }
}
