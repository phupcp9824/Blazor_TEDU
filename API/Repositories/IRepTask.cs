using API.Data;
using API.Entities;
using Data;
using Microsoft.EntityFrameworkCore;
using Task = API.Entities.Task;

namespace API.Repositories
{
    public interface IRepTask
    {
        Task<IEnumerable<Task>> GetAll(TaskListSearch taskListSearch);
        Task<Task> GetById(Guid id);
        Task<Task> Create(Task task);
        Task<Task> Update(Guid id, Task task);
        Task<Task> Delete(Guid id);

        Task<List<User>> Getuserlist();
    }

    public class RepTask : IRepTask
    {
        private readonly BlazorDbContext _db;

        public RepTask(BlazorDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Task>> GetAll(TaskListSearch taskListSearch)
        {
            var Query = _db.Tasks.Include(x => x.Assignee).AsQueryable();
            if (!string.IsNullOrEmpty(taskListSearch.name))
            {
                Query = Query.Where(x => x.Name.ToLower().Trim().Contains(taskListSearch.name.ToLower().Trim()));
            }   
            if (taskListSearch.AssigneeId.HasValue)
            {
                Query = Query.Where(x => x.AssigneeId == taskListSearch.AssigneeId.Value);
            }   
            if (taskListSearch.Priority.HasValue)
            {
                Query = Query.Where(x => x.priority == taskListSearch.Priority.Value);
            }
            return await Query.ToListAsync();
        }

        public async Task<Task> GetById(Guid id)
        {
            return await _db.Tasks
                .Include(t => t.Assignee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Task> Create(Task task)
        {
            task.Id = Guid.NewGuid(); // Tạo ID mới nếu chưa có
            task.CreatedDate = DateTime.UtcNow; // Gán ngày tạo
            _db.Tasks.Add(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<Task> Update(Guid id, Task task)
        {
            var existingTask = await _db.Tasks.FindAsync(id);
            if (existingTask == null)
            {
                return null; 
            }

            existingTask.Name = task.Name;
            existingTask.AssigneeId = task.AssigneeId;
            existingTask.priority = task.priority;
            existingTask.status = task.status;

            await _db.SaveChangesAsync();
            return existingTask;
        }

        public async Task<Task> Delete(Guid id)
        {
            var task = await _db.Tasks.FindAsync(id);
            if (task == null)
            {
                return null; 
            }

            _db.Tasks.Remove(task);
            await _db.SaveChangesAsync();
            return task;
        }

        public async Task<List<User>> Getuserlist()
        {
            return await _db.Users.ToListAsync();
        }
    }
}
