using Microsoft.EntityFrameworkCore;
using WebApi_Tarefas.DataContext;
using WebApi_Tarefas.Models;

namespace WebApi_Tarefas.Service.TarefaService
{
    public class TarefaService : ITarefaInterface
    {
        private readonly ApplicationDbContext _context;
        public TarefaService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ServiceResponse<List<TarefaModel>>> CreateTarefa(TarefaModel novaTarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                if (novaTarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar dados!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }
                _context.Add(novaTarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();

            }catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> DeleteTarefa(int id)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                TarefaModel tarefa = _context.Tarefas.FirstOrDefault(x => x.Id == id);
               
                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada!";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TarefaModel>> GetTarefaById(int id)
        {
            ServiceResponse<TarefaModel> serviceResponse = new ServiceResponse<TarefaModel>();

            try
            {
                TarefaModel tarefa = _context.Tarefas.FirstOrDefault(x => x.Id == id);
                
                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = tarefa;
                
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefaModel>>> GetTarefas()
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                serviceResponse.Dados = _context.Tarefas.ToList();
                if(serviceResponse.Dados.Count == 0) 
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";             
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        
        public async Task<ServiceResponse<List<TarefaModel>>> UpdateTarefa(TarefaModel editadaTarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = new ServiceResponse<List<TarefaModel>>();

            try
            {
                TarefaModel tarefa = _context.Tarefas.AsNoTracking().FirstOrDefault(x => x.Id == editadaTarefa.Id);

                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Tarefa não localizada!";
                    serviceResponse.Sucesso = false;
                }

                _context.Tarefas.Update(editadaTarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
