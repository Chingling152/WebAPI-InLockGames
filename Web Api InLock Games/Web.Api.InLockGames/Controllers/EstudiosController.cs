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
        private readonly IEstudiosRepository repositorio;

        public EstudiosController() {
            repositorio = new EstudiosRepository();
        }

        [HttpGet]
        public IActionResult Listar() {
            try {
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("Jogos")]
        public IActionResult ListarJogos() {
            try {
                return Ok(repositorio.ListarJogos());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpGet("{ID}")]
        public IActionResult ListarJogos(int ID) {
            try {
                return Ok(repositorio.ListarJogos(ID));
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Estudios estudio) {
            try {
                repositorio.Cadastrar(estudio);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPut("Alterar")]
        public IActionResult Alterar(Estudios estudio) {
            try {
                repositorio.Alterar(estudio);
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }
    }
}