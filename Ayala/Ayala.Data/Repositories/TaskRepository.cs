using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ayala.Core.Entitie;
using Ayala.Core.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Ayala.Data.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly DataContext _context;

        public TaskRepository(DataContext context)
        {
            _context = context;
        }
        public DbSet<Core.Entitie.Task> GetList() 
        { 
            return _context.Tasks;
        }

        public Core.Entitie.Task GetById(int id)
        {
            return _context.Tasks.FirstOrDefault(t => t.Id == id);
        }

        public void Add(Core.Entitie.Task task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void Update(int id, Core.Entitie.Task task)
        {
            var existTask =GetById(id);
            task.Id = id;
            _context.Entry(existTask).CurrentValues.SetValues(task);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            Core.Entitie.Task temp = _context.Tasks.Find(id);
            if (temp == null)
                return;
            _context.Tasks.Remove(temp);
            _context.SaveChanges();
        }
    }
}
