using System.Collections.Generic;
using Web.Api.InLockGames.Domains;

namespace Web.Api.InLockGames.Interfaces {

    public interface IJogosRepository {

        List<Jogos> Listar();

        List<Jogos> ListarComEstudio();

        void Cadastrar(Jogos jogo);

        void Remover(Jogos jogo);

        void Alterar(Jogos jogo);
    }

}
