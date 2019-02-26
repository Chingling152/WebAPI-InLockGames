using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Models {
    public class JogoModel {
        
        public int JogoId;

        [Required(ErrorMessage = "O jogo precisa ter um nome")]
        [StringLength(maximumLength: 200,MinimumLength = 0, ErrorMessage = "O nome inserido excede a quantidade de caracteres aceitas")]
        public string NomeJogo;

        [Required(ErrorMessage = "O jogo precisa ter uma descrição")]
        public string Descricao;

        [Required(ErrorMessage = "Insira uma data de Lançamento")]
        [DataType(DataType.Date,ErrorMessage ="O valor inserido não é uma data")]
        public DateTime DataLancamento;

        [Required(ErrorMessage = "Insira um valor para o jogo")]
        public double Valor;

        public int EstudioId;

        public EstudioModel Estudio;
    }
}
