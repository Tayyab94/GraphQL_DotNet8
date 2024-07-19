using Bogus;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services.Course;

namespace GraphQLDemo.API.Schema.Qeries
{
    public class Query
    {

        private readonly CourseRepository courseRepository;
        public Query(CourseRepository course)
        {
            courseRepository = course;
        }


        public async Task<IEnumerable<CourseType>> GetCourses()
        {
            var course = await courseRepository.GetAllCourses();

            return course.Select(s=>new CourseType()
            {
                Id=s.Id,
                 Name=s.Name,
                  Subject=s.Subject,
                InstructorId  = s.InstructorId,
            });
        }

        public async Task<CourseType> GetCourseByIdAsync(Guid id)
        {
            var course = await courseRepository.GetCourseById(id);
            return new CourseType()
            {
                Id = course.Id,
                Name = course.Name,
                Subject = course.Subject,
                InstructorId=course.InstructorId,
                //Instructor = new InstructorType()
                //{
                //    Id = course.Instructor.Id,
                //    FirstName = course.Instructor.FirstName,
                //    LastName = course.Instructor.LastName,
                //}

            };
        }
        // we will no longer to display this in our query
        [GraphQLDeprecated("This query is deprecated now")]
        public string Instruction => "Hit the Button and see the resutl";
    }
}
