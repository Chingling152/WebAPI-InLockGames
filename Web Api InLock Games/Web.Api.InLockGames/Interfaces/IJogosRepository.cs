using System.Collections.Generic;
using Web.Api.InLockGames.Domains;

namespace Web.Api.InLockGames.Interfaces {
    /// <summary>
    /// Interface com os metodos de Procura , Alteração , Cadastro e remoção de Jogos
    /// </summary>
    public interface IJogosRepository {

        /// <summary>
        /// Retorna todos os jogos registrados no banco de dados
        /// </summary>
        /// <returns>Retorna uma lista com todos os jogos no banco de dados</returns>
        List<Jogos> Listar();

        /// <summary>
        /// Adciona um novo jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Jogo a ser adicionado no banco de dados</param>
        void Cadastrar(Jogos jogo);

        /// <summary>
        /// Remove permanentemente um jogo do banco de dados
        /// </summary>
        /// <param name="jogo">Jogo que será removido</param>
        void Remover(Jogos jogo);

        /// <summary>
        /// Altera os valores de um jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Jogo com os valores ja alterados</param>
        void Alterar(Jogos jogo);
    }

}
