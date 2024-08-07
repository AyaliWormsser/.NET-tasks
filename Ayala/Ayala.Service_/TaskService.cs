using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ayala.Core.Entitie;
using Ayala.Core.Repositories;
using Ayala.Core.Services;
using Microsoft.EntityFrameworkCore;
namespace Ayala.Service
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public DbSet<Core.Entitie.Task> GetAll()
        {
            return _taskRepository.GetList();
        }

        public Core.Entitie.Task GetById(int id)
        {
            return _taskRepository.GetById(id);
        }

        public void Add(Core.Entitie.Task task)
        {

            _taskRepository.Add(task);
        }

        public void Update(int id, Core.Entitie.Task task)
        {
            _taskRepository.Update(id, task);
        }


        public void Remove(int id)
        {
            _taskRepository.Remove(id);
        }




    }
}

