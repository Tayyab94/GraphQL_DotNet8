using GraphQLDemo.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace GraphQLDemo.API.Services.Course
{
    public class CourseRepository
    {
       private readonly IDbContextFactory<SchoolDbContext> _dbContextFactory;


        public CourseRepository(IDbContextFactory<SchoolDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Courses.ToListAsync();
            }
        }

        public async Task<CourseDTO> GetCourseById(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                
                var course = await context.Courses.FirstOrDefaultAsync(s=>s.Id== id);

                return course;
            }
        }

        public async
            Task<CourseDTO> Create(CourseDTO model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                try
                {
                    var instr = context.Instructors.FirstOrDefault(s => s.Id == model.Instructor.Id);
                    model.Instructor = instr;
                    context.Courses.Add(model);
                    await context.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    throw;
                }
             

                return model;
            }
        }

        public async Task<CourseDTO> Update(CourseDTO model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Courses.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
        }

        public async Task<bool> Delete(Guid id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                CourseDTO model = new CourseDTO
                {
                    Id = id
                };
                context.Courses.Remove(model);
                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}
