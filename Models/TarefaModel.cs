using System.ComponentModel.DataAnnotations;
using WebApi_Tarefas.Enums;

namespace WebApi_Tarefas.Models
{
    public class TarefaModel
    {
        [Key]
        public int Id { get; set; }
        public String Titulo { get; set; }
        public String Descricao { get; set; }
        public StatusEnum Status { get; set; }
        public DateTime DataDeCriacao { get; set; } = DateTime.Now.ToLocalTime();
    }
}
