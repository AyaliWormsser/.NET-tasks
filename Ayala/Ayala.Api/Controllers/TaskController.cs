using System.Threading.Tasks;
using Ayala.Core.Entitie;
using Ayala.Core.Services;
using Microsoft.AspNetCore.Mvc;


namespace Ayala.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: api/<TaskController>
        [HttpGet]
        public IEnumerable<Core.Entitie.Task> Get()
        {
            return _taskService.GetAll().ToList();
        }

        // GET api/<TaskController>/5
        [HttpGet("{id}")]
        public Core.Entitie.Task Get(int id)
        {
            return _taskService.GetById(id);
        }

        [HttpPost]
        public  void Post([FromBody] Core.Entitie.Task task)
        {
            _taskService.Add(task);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Core.Entitie.Task task)
        {
            _taskService.Update(id, task);
        }

        // DELETE api/<TaskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _taskService.Remove(id);
        }
            
    }
}
