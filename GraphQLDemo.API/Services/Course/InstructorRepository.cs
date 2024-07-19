using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Course
{
    public class InstructorRepository
    {
        private readonly IDbContextFactory<SchoolDbContext> _dbContextFactory;


        public InstructorRepository(IDbContextFactory<SchoolDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<InstructorDTO>> GetAllInstructors()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Instructors.ToListAsync();
            }
        }

        public async Task<InstructorDTO> GetInstructorById(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {

                var instructor = await context.Instructors.FirstOrDefaultAsync(s => s.Id == id);

                return instructor;
            }
        }

        public async Task<IEnumerable<InstructorDTO>> GetManyById(IReadOnlyList<Guid> id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {

                var instructor = await context.Instructors.Where
                    (s=> id.Contains(s.Id)).ToListAsync();

                return instructor;
            }
        }
        
    }
}
