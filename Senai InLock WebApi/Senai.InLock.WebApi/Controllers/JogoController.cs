using System;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;
using Senai.InLock.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoRepository repositorio;

        public JogoController() {
            repositorio = new JogoRepository();
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