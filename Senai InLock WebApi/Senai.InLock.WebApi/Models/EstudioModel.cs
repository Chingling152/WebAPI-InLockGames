using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Models {

    public class EstudioModel {

        public int ID;

        [Required(ErrorMessage = "O estudio precisa ter um nome")]
        [StringLength(maximumLength: 200,MinimumLength = 0,ErrorMessage ="Nome do estudio muito grande")]
        public string Nome;
    }
}
