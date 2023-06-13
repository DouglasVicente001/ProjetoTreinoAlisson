using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorTarefas_Api.Models
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength (40, MinimumLength = 3, ErrorMessage = "O campo título deve ter entre 3/40 caracteres")] 
        public string ?Titulo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength (40, MinimumLength = 3, ErrorMessage = "O campo descrição deve ter entre 3/40 caracteres")] 
        public string ?Descricao { get; set; }
        public bool Status { get; set; }
    }
}