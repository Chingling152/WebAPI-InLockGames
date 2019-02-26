using System;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;
using Senai.InLock.WebApi.Repositories;
using Senai.InLock.WebApi.ViewModel;

using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Senai.InLock.WebApi.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase{

        IUsuariosRepository repositorio;

        public UsuariosController() {
            repositorio = new UsuariosRepository();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(UsuariosModel login) {
            try {
                UsuariosModel usuario = repositorio.Validar(login.Email, login.Senha);

                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Email,usuario.Email),         //Email
                    new Claim(JwtRegisteredClaimNames.Jti,usuario.ID.ToString()),   //ID
                    new Claim(ClaimTypes.Role,usuario.TipoUsuario)                  //Nivel de privilegio
                };

                var chave = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Chave-InLockGames"));

                var credenciais = new SigningCredentials(chave,SecurityAlgorithms.HmacSha256);

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
                return BadRequest(exc);
            }
        }
    }
}
