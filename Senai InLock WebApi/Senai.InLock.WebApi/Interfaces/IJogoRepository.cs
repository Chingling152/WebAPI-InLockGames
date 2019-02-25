using System.Collections.Generic;
using Senai.InLock.WebApi.Models;

namespace Senai.InLock.WebApi.Interfaces {
    public interface IJogoRepository {

        List<JogoModel> Listar();

        void Cadastrar(JogoModel jogo);

    }
}
