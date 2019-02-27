using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Web.Api.InLockGames.Domains;
using Web.Api.InLockGames.Interfaces;

namespace Web.Api.InLockGames.Repositories {
    /// <summary>
    /// Classe que lida com dados relativos a Jogos
    /// </summary>
    public class JogosRepository : IJogosRepository {

        public void Alterar(Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        public List<Jogos> Listar() => new InLockContext().Jogos.ToList();

        public void Remover(Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Remove(jogo);
                ctx.SaveChanges();
            }
        }
    }
}
