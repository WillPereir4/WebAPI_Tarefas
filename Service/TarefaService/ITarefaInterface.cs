using WebApi_Tarefas.Models;

namespace WebApi_Tarefas.Service.TarefaService
{
    public interface ITarefaInterface
    {
        Task<ServiceResponse<List<TarefaModel>>> GetTarefas();
        Task<ServiceResponse<List<TarefaModel>>> CreateTarefa(TarefaModel novaTarefa);
        Task<ServiceResponse<TarefaModel>> GetTarefaById(int id);
        Task<ServiceResponse<List<TarefaModel>>> UpdateTarefa(TarefaModel editadaTarefa);
        Task<ServiceResponse<List<TarefaModel>>> DeleteTarefa(int id);
    }
}
