using System.Collections.Generic;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Models;

namespace Senai.InLock.WebApi.Repositories {
    public class EstudiosRepository : IEstudiosRepository {
        private const string Conexao = "";
        public List<EstudioModel> Listar() {
            throw new System.NotImplementedException();
        }

        public Dictionary<JogoModel, EstudioModel> ListarJogos() {
            throw new System.NotImplementedException();
        }
    }
}
