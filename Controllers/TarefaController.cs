using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Tarefas.Models;
using WebApi_Tarefas.Service.TarefaService;

namespace WebApi_Tarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaInterface _tarefaInterface;
        public TarefaController(ITarefaInterface tarefaInterface)
        {
            _tarefaInterface = tarefaInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> GetTarefas()
        {
            return Ok( await _tarefaInterface.GetTarefas());            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<TarefaModel>>> GetTarefaById(int id)
        {
            ServiceResponse<TarefaModel> serviceResponse = await _tarefaInterface.GetTarefaById(id);

            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> CreateTarefas(TarefaModel novaTarefa)
        {
            return Ok(await _tarefaInterface.CreateTarefa(novaTarefa));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> UpdateTarefas(TarefaModel editadaTarefa)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.UpdateTarefa(editadaTarefa);

            return Ok(serviceResponse);
        }
        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<TarefaModel>>>> DeleteTarefa(int id)
        {
            ServiceResponse<List<TarefaModel>> serviceResponse = await _tarefaInterface.DeleteTarefa(id);

            return Ok(serviceResponse);
        }
    }
}
