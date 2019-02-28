using System;
using System.Linq;
using System.Collections.Generic;

using Web.Api.InLockGames.Domains;
using Web.Api.InLockGames.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Web.Api.InLockGames.Repositories {
    public class EstudiosRepository : IEstudiosRepository {
        /// <summary>
        /// Altera os valores de um estudio
        /// </summary>
        /// <param name="estudio"></param>
        public void Alterar(Estudios estudio) {
            using (InLockContext ctx = new InLockContext()) {

                if (ctx.Estudios.Find(estudio.EstudioId) == null) {
                    throw new NullReferenceException("Não existe Estudio nesse ID para ser alterado");
                }
                
                ctx.Estudios.Update(estudio);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Estudios estudio) => new InLockContext().Estudios.Add(estudio);

        public List<Estudios> Listar() => new InLockContext().Estudios.ToList();

        public List<Estudios> ListarJogos() => new InLockContext().Estudios.Include("Jogo").ToList();

        public Estudios ListarJogos(int ID) => new InLockContext().Estudios.Find(ID);
    }
}
