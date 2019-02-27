using System.Collections.Generic;
using Web.Api.InLockGames.Domains;

namespace Web.Api.InLockGames.Interfaces {
    /// <summary>
    /// Interface com metodos para lidar com Estudios no banco de dados
    /// </summary>
    public interface IEstudiosRepository {

        /// <summary>
        /// Retorna todos os estudios registrados no banco de dados
        /// </summary>
        /// <returns>Uma lista com todos os Estudios</returns>
        List<Estudios> Listar();
        
        /// <summary>
        /// Retorna todos os Estudios do banco de dados e todos os jogos de cada estudio
        /// </summary>
        /// <returns>Uma lista com todos os estudios , onde cada estudio tera uma lista de jogos lançados</returns>
        List<Estudios> ListarJogos();

        /// <summary>
        /// Lista todos os jogos de um determinado Estudio
        /// </summary>
        /// <param name="ID">ID do estudio a ser procurado</param>
        /// <returns>Um Estudio e todos os seus jogos</returns>
        Estudios ListarJogos(int ID);

        /// <summary>
        /// Insere um novo Estudio no banco de dado 
        /// </summary>
        /// <param name="estudio">Estudio que será salvo no banco de dados</param>
        void Cadastrar(Estudios estudio);
          
        /// <summary>
        /// Altera os registros de um Estudio no banco de dados
        /// </summary>
        /// <param name="estudio">Estudio com os valores já alterados</param>
        void Alterar(Estudios estudio);
    }
}
