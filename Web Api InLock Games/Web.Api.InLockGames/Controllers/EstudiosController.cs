using System;
using Microsoft.AspNetCore.Mvc;
using Web.Api.InLockGames.Domains;
using Web.Api.InLockGames.Interfaces;
using Web.Api.InLockGames.Repositories;

namespace Web.Api.InLockGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private readonly IJogosRepository repositorio;

        public EstudiosController() {
            repositorio = new JogosRepository();
        }

        [HttpGet("Listar")]
        public IActionResult Listar() {
            try {
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("ListarComEstudios")]
        public IActionResult ListarEstudios() {
            try {
                return Ok(repositorio.ListarComEstudio());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Jogos jogo) {
            try {
                repositorio.Cadastrar(jogo);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut]
        public IActionResult Alterar(Jogos jogo) {
            try {
                repositorio.Alterar(jogo);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut]
        public IActionResult Remover(Jogos jogo) {
            try {
                repositorio.Remover(jogo);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
    }
}