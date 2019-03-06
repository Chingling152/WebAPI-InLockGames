using System.Collections.Generic;
using Senai.InLock.Games.Domains;

namespace Senai.InLock.Games.Interfaces {
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
        /// <param name="ID">ID do jogo que será removido</param>
        void Remover(int ID);

        /// <summary>
        /// Altera os valores de um jogo no banco de dados
        /// </summary>
        /// <param name="jogo">Jogo com os valores ja alterados</param>
        void Alterar(Jogos jogo);

        /// <summary>
        /// Retorna o jogo que tenha ID seleciona
        /// </summary>
        /// <param name="ID">ID do jogo</param>
        /// <returns>Retorna o jogo que exista no registro inserido , se não existir , retorna null ou uma excessão</returns>
        Jogos ListarPorID(int ID);
    }

}
