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
    public class JogosController : ControllerBase
    {

        private readonly IJogosRepository repositorio;

        public JogosController() {
            repositorio = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Listar() {
            try {
                return Ok(repositorio.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost]
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

        [HttpDelete("{ID}")]
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