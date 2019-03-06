using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

using Senai.InLock.Games.Domains;
using Senai.InLock.Games.Interfaces;
using Senai.InLock.Games.Repositories;
using Senai.InLock.Games.ViewModels;

namespace Web.Api.InLockGames.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository Usuarios;

        public UsuariosController() {
            Usuarios = new UsuariosRepository();
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("ListarTodos")]
        public IActionResult ListarTodos() {
            try {
                return Ok(Usuarios.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Listar/{ID}")]
        public IActionResult Listar(int ID) {
            try {
                return Ok(Usuarios.ListarPorID(ID));
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar(Usuarios usuario) {
            try {
                Usuarios.Cadastrar(usuario);
                return Ok(Usuarios.Listar());
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Logar(LoginViewModel usuario) {
            try {
                Usuarios user = Usuarios.Logar(usuario.Email, usuario.Senha);
                if (user == null)
                    return NotFound("Email ou senha incorretos");

                var claims = new[] {
                    //new Claim(JwtRegisteredClaimNames.Email,user.Email), como o email não é unico acho que não tem necessidade
                    new Claim(JwtRegisteredClaimNames.Jti,user.UsuarioId.ToString()),
                    new Claim(ClaimTypes.Role,user.TipoUsuario.ToString())
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-InLockGames"));

                var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "InLockApi",
                    audience: "InLockApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: credenciais
                );

                return Ok(new {
                    Token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            } catch (Exception exc) {
                return BadRequest(exc.Message);
            }
        }

    }
}