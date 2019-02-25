using Senai.InLock.WebApi.Models;
using System.Collections.Generic;

namespace Senai.InLock.WebApi.Interfaces {
    public interface IEstudioRepository {

        List<EstudioModel> Listar();

        Dictionary<JogoModel,EstudioModel> ListarJogos();// ??
    }
}
