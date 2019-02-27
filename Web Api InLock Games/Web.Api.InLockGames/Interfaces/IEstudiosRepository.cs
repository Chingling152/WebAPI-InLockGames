using System.Collections.Generic;
using Web.Api.InLockGames.Domains;

namespace Web.Api.InLockGames.Interfaces {
    public interface IEstudiosRepository {

        List<Estudios> Listar();
        
        List<Estudios> ListarComJogos();

        Estudios ListarDe(int ID);

        void Cadastrar(Estudios estudio);
           
        void Alterar(Estudios estudio);
    }
}
