using System;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;
using Senai.InLock.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogosRepository repositorio;

        public JogosController() {
            repositorio = new JogosRepository();
        }
        
        [HttpGet]
        public IActionResult ListarJogos() {
            try {
                return Ok(repositorio.Listar());
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult CadastrarJogos(JogoModel jogo) {
            try {
                repositorio.Cadastrar(jogo);
                return Ok(repositorio.Listar());
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

    }
}