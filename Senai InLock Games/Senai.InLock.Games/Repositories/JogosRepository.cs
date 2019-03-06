using System.Linq;
using System.Collections.Generic;
using Senai.InLock.Games.Domains;
using Senai.InLock.Games.Interfaces;
using System;

namespace Senai.InLock.Games.Repositories {
    /// <summary>
    /// Classe que lida com dados relativos a Jogos
    /// </summary>
    public class JogosRepository : IJogosRepository {

        /// <summary>
        /// Altera os valores de um jogo no banco de dados , se não existir nenhum com o mesmo ID , joga uma exceção
        /// </summary>
        /// <param name="jogo">Jogo com os valores ja alterados</param>
        public void Alterar(Jogos jogo) {
            using (InLock_Games_ManhaContext ctx = new InLock_Games_ManhaContext()) {
                ctx.Jogos.Update(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cadastra um jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Jogo cadastrado </param>
        public void Cadastrar(Jogos jogo) {
            using (InLock_Games_ManhaContext ctx = new InLock_Games_ManhaContext()) {
                ctx.Jogos.Add(jogo);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna uma lista com todos os jogos do banco de dados (Sem o nome dos estudios por agora ;-;)
        /// </summary>
        /// <returns>Uma lista com todos os Jogos</returns>
        public List<Jogos> Listar() => new InLock_Games_ManhaContext().Jogos.ToList();

        /// <summary>
        /// Procura um Jogo no ID selecionado
        /// </summary>
        /// <param name="ID">ID do Jogo selecionado</param>
        /// <returns>Retorna um jogo no ID selecionado , se ele não existir , retorna uma NullReferenceException</returns>
        public Jogos ListarPorID(int ID) {
            using (InLock_Games_ManhaContext ctx = new InLock_Games_ManhaContext()) {
                Jogos jogo = ctx.Jogos.Find(ID);

                if (jogo == null) {
                    throw new NullReferenceException("Não existe pacote no ID selecionado");
                }

                return jogo;
            }
        }

        /// <summary>
        /// Remove um jogo no ID selecionado
        /// </summary>
        /// <param name="ID">ID do jogo removido</param>
        public void Remover(int ID) {
            using (InLock_Games_ManhaContext ctx = new InLock_Games_ManhaContext()) {
                ctx.Jogos.Remove(ctx.Jogos.Find(ID));
                ctx.SaveChanges();
            }
        }

    }
}
