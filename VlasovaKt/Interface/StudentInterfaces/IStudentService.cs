using Microsoft.EntityFrameworkCore;
using VlasovaKt.Database;
using VlasovaKt.Filters.StudentFilters;
using VlasovaKt.Models;

namespace VlasovaKt.Interface.StudentInterfaces
{
    public interface IStudentService
    {
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken);
    }
    public class StudentService : IStudentService
    {
        private readonly VlasovaDbContext _dbContext;
        public StudentService(VlasovaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Student[]> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = _dbContext.Set<Student>().Where(w => w.Group.GroupName == filter.GroupName).ToArrayAsync(cancellationToken);
            return students;
        }
    }
}
