using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Amigos {
        private DateTime dataDeAniversario;

        public int Id { get; set; }
        [Required(ErrorMessage = "Campo 'Nome' é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo 'Sobrenome' é obrigatório.")]
        public string Sobrenome { get; set; }

        [Display(Name = "Data de Aniversário")]
        [Required(ErrorMessage = "Campo 'Data de Aniversário' é obrigatório.")]
        public DateTime DataDeAniversario { get => dataDeAniversario; set => dataDeAniversario = value; }
    }
}
