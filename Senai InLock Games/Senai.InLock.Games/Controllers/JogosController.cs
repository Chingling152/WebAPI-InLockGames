using System;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.Games.Domains;
using Senai.InLock.Games.Interfaces;
using Senai.InLock.Games.Repositories;

namespace Web.Api.InLockGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        /// <summary>
        /// Instancia do banco de dados
        /// </summary>
        private readonly IJogosRepository repositorio;

        public JogosController() {
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

        [HttpGet("Listar/{ID}")]
        public IActionResult ListarPorID(int ID) {
            try {
                return Ok(repositorio.ListarPorID(ID));
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

        [HttpPut("Alterar")]
        public IActionResult Alterar(Jogos jogo) {
            try {
                repositorio.Alterar(jogo);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpDelete("Remover/{ID}")]
        public IActionResult Remover(int ID) {
            try {
                repositorio.Remover(ID);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

    }
}