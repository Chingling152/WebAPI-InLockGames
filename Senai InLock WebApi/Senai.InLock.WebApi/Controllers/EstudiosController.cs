using System;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Senai.InLock.WebApi.Controllers
{
    public class EstudiosController : Controller
    {
        private readonly IEstudiosRepository repositorio;

        public EstudiosController() {
            repositorio = new EstudiosRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            try {
                return Ok(repositorio.ListarJogos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
    }
}