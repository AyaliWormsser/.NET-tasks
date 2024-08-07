using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ayala.Core.Repositories
{
    public interface ITaskRepository
    {
        public DbSet<Core.Entitie.Task> GetList();
        public Core.Entitie.Task GetById(int id);
        public void Add(Core.Entitie.Task task);
        public void Update(int id, Core.Entitie.Task task);
        public void Remove(int id);



    }
}
