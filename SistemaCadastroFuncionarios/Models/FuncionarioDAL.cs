using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCadastroFuncionarios.Models
{
    public class FuncionarioDAL : IFuncionarioDAL
    {
        string connectionString = "Data Source=LAPTOP-OPUL213H;Database=BDFuncionario;Integrated Security=SSPI;Initial Catalog=BDFuncionario;User ID=sa;Password=andrade24";

        //Obter todos funcionários
        public IEnumerable<Funcionario> GetAllFuncionarios()
        {
            List<Funcionario> lstfuncionario = new List<Funcionario>();
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand("select CodFuncionario, Nome, DataNascimento, Salario, Atividades from Funcionario", conexao);
                comando.CommandType = CommandType.Text;
                conexao.Open();

                SqlDataReader ler = comando.ExecuteReader();
                while (ler.Read())
                {
                    Funcionario funcionario = new Funcionario();

                    funcionario.CodFuncionario = Convert.ToInt32(ler["CodFuncionario"]);
                    funcionario.Nome = ler["Nome"].ToString();
                    funcionario.DataNascimento = Convert.ToDateTime(ler["DataNascimento"]);
                    funcionario.Salario = Convert.ToDecimal(ler["Salario"]);
                    funcionario.Atividades = ler["Atividades"].ToString();

                    lstfuncionario.Add(funcionario);
                }
                conexao.Close();
            }
            return lstfuncionario;
        }


        //Obter funcionário pelo cod
        public Funcionario GetFuncionario(int? cod)
        {
            Funcionario funcionario = new Funcionario();
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string sqlQuery = "select * from Funcionario where CodFuncionario = " + cod;
                SqlCommand comando = new SqlCommand(sqlQuery, conexao);
                conexao.Open();

                SqlDataReader ler = comando.ExecuteReader();
                while (ler.Read())
                {
                    funcionario.CodFuncionario = Convert.ToInt32(ler["CodFuncionario"]);
                    funcionario.Nome = ler["Nome"].ToString();
                    funcionario.DataNascimento = Convert.ToDateTime(ler["DataNascimento"]);
                    funcionario.Salario = Convert.ToDecimal(ler["Salario"]);
                    funcionario.Atividades = ler["Atividades"].ToString();
                }
            }
            return funcionario;
        }


        //Adicionar funcionário
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string comandoSQL = "insert into Funcionario (Nome, DataNascimento, Salario, Atividades) " +
                                                            "values(@Nome, @DataNascimento, @Salario, @Atividades)";

                SqlCommand comando = new SqlCommand(comandoSQL, conexao);

                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@Atividades", funcionario.Atividades);
                conexao.Open();

                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }


        //Editar funcionário
        public void EditarFuncionario(Funcionario funcionario)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string comandoSQL = "update Funcionario set Nome = @Nome, DataNascimento = @DataNascimento, Salario = @Salario, " +
                                                            "Atividades = @Atividades where CodFuncionario = @CodFuncionario";
                SqlCommand comando = new SqlCommand(comandoSQL, conexao);

                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@CodFuncionario", funcionario.CodFuncionario);
                comando.Parameters.AddWithValue("@Nome", funcionario.Nome);
                comando.Parameters.AddWithValue("@DataNascimento", funcionario.DataNascimento);
                comando.Parameters.AddWithValue("@Salario", funcionario.Salario);
                comando.Parameters.AddWithValue("@Atividades", funcionario.Atividades);
                conexao.Open();

                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }


        //Excluir funcionário
        public void ExcluirFuncionario(int? cod)
        {
            using (SqlConnection conexao = new SqlConnection(connectionString))
            {
                string comandoSQL = "delete from Funcionario where CodFuncionario = @CodFuncionario";

                SqlCommand comando = new SqlCommand(comandoSQL, conexao);

                comando.CommandType = CommandType.Text;

                comando.Parameters.AddWithValue("@CodFuncionario", cod);
                conexao.Open();

                comando.ExecuteNonQuery();
                conexao.Close();
            }
        }
    }
}
