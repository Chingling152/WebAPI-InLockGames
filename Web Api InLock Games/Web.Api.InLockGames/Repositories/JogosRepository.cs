using System.Linq;
using System.Collections.Generic;
using Web.Api.InLockGames.Domains;
using Web.Api.InLockGames.Interfaces;

namespace Web.Api.InLockGames.Repositories {
    /// <summary>
    /// Classe que lida com dados relativos a Jogos
    /// </summary>
    public class JogosRepository : IJogosRepository {

        /// <summary>
        /// Altera os valores de um jogo no banco de dados , se não existir nenhum com o mesmo ID , joga uma exceção
        /// </summary>
        /// <param name="jogo">Jogo com os valores ja alterados</param>
        public void Alterar(Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cadastra um jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Jogo cadastrado </param>
        public void Cadastrar(Jogos jogo) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna uma lista com todos os jogos do banco de dados (Sem o nome dos estudios por agora ;-;)
        /// </summary>
        /// <returns>Uma lista com todos os Jogos</returns>
        public List<Jogos> Listar() => new InLockContext().Jogos.ToList();

        /// <summary>
        /// Remove um jogo no ID selecionado
        /// </summary>
        /// <param name="ID">ID do jogo removido</param>
        public void Remover(int ID) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Jogos.Remove(ctx.Jogos.Find(ID));
                ctx.SaveChanges();
            }
        }

    }
}
