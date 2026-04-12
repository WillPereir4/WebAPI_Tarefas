namespace WebApi_Tarefas.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public String Mensagem { get; set; } = string.Empty;
        public bool Sucesso { get; set; } = true;
    }
}
