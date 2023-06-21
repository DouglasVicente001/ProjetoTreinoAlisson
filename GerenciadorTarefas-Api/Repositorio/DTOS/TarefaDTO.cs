using System.ComponentModel.DataAnnotations;
using Entidade;

namespace Repositorio.DTOS
{
    public class TarefaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O campo título deve ter entre 3 e 40 caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "O campo descrição deve ter entre 3 e 40 caracteres")]
        public string? Descricao { get; set; }

        public bool Status { get; set; }

        public static TarefaDTO ConvertToDTO(Tarefa tarefa)
        {
            return new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Status = tarefa.Status
            };
        }

        public static Tarefa ConvertToEntity(TarefaDTO tarefaDTO)
        {
            return new Tarefa
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Status = tarefaDTO.Status
            };
        }
        
    }
}
