using System;
using System.Linq;
using System.Collections.Generic;
//using organizados :3
using Web.Api.InLockGames.Domains;
using Web.Api.InLockGames.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Web.Api.InLockGames.Repositories {
    public class EstudiosRepository : IEstudiosRepository {

        /// <summary>
        /// Altera os valores de um estudio , se não existir nenhum no id selecionado , joga uma exceção
        /// </summary>
        /// <param name="estudio">Estudio com os valores já alterados</param>
        public void Alterar(Estudios estudio) {
            using (InLockContext ctx = new InLockContext()) {

                if (ctx.Estudios.Find(estudio.EstudioId) == null) {
                    throw new NullReferenceException("Não existe Estudio nesse ID para ser alterado");
                }
                
                ctx.Estudios.Update(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Cadastra um estudio no banco de dados
        /// </summary>
        /// <param name="estudio">Estudio a sert cadastrado</param>
        public void Cadastrar(Estudios estudio) {
            using (InLockContext ctx = new InLockContext()) {
                ctx.Estudios.Add(estudio);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Lista todos os estudios do banco de dados
        /// </summary>
        /// <returns>Uma lista contendo todos os Estudios registrados no banco de dados</returns>
        public List<Estudios> Listar() => new InLockContext().Estudios.ToList();

        /// <summary>
        /// Lista todos os estudios do banco de dados e seus jogos
        /// </summary>
        /// <returns>Uma lista com todos os estudios e todos os jogos</returns>
        public List<Estudios> ListarJogos() => new InLockContext().Estudios.Include("Jogos").ToList();

        /// <summary>
        /// Lista todos os jogos de um determinado estudio
        /// </summary>
        /// <param name="ID">ID do estudio a ser retornados</param>
        /// <returns>Retorna um estudio e todos os seus jogos , se o Estudio não existir , retorna uma exceção </returns>
        public Estudios ListarJogos(int ID) {
            using (InLockContext ctx = new InLockContext()) {
                Estudios estudio = ctx.Estudios.Find(ID);

                if (estudio == null) {
                    throw new NullReferenceException("Não existe Estudio nesse ID para ser alterado");
                }

                return estudio;
            }
        }
    }
}
