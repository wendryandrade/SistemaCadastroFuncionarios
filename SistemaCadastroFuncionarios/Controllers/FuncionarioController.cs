using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroFuncionarios.Models;

namespace SistemaCadastroFuncionarios.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioDAL func;
        public FuncionarioController(IFuncionarioDAL funcionario)
        {
            func = funcionario;
        }

        //Início
        public IActionResult Index()
        {
            List<Funcionario> listaFuncionarios = new List<Funcionario>();
            listaFuncionarios = func.GetAllFuncionarios().ToList();
            return View(listaFuncionarios);
        }

        //Detalhes de funcionário específico
        [HttpGet]
        public IActionResult Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = func.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        //Adicionar funcionário
        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar([Bind] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                func.AdicionarFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        //Editar funcionário específico
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = func.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind] Funcionario funcionario)
        {
            if (id != funcionario.CodFuncionario)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                func.EditarFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        //Excluir funcionário específico
        [HttpGet]
        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Funcionario funcionario = func.GetFuncionario(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public IActionResult ExcluirConfirmaçao(int? id)
        {
            func.ExcluirFuncionario(id);
            return RedirectToAction("Index");
        }
    }
}
