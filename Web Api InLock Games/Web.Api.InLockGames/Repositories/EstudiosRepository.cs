using System;
using System.Linq;
using System.Collections.Generic;

using Web.Api.InLockGames.Domains;
using Web.Api.InLockGames.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Web.Api.InLockGames.Repositories {
    public class EstudiosRepository : IEstudiosRepository {

        public void Alterar(Estudios estudio) {
            throw new Exception("Metodo ainda não adcionado");
        }

        public void Cadastrar(Estudios estudio) => new InLockContext().Estudios.Add(estudio);

        public List<Estudios> Listar() => new InLockContext().Estudios.ToList();

        public List<Estudios> ListarJogos() => new InLockContext().Estudios.Include("Jogos").ToList();

        public Estudios ListarJogos(int ID) => new InLockContext().Estudios.Find(ID);
    }
}
