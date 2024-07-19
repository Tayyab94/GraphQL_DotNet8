using GraphQLDemo.API.DataLoader;
using GraphQLDemo.API.Models;
using GraphQLDemo.API.Services.Course;

namespace GraphQLDemo.API.Schema
{



    public class CourseType
    {
        public Guid Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }
        public Guid InstructorId { get;set; }


        [GraphQLNonNullType] // its mean which property should not be not nullable
        public async Task<InstructorType> Instructor([Service] InstructorDataLoader instructorDataLoader)
        {
            var instructor = await instructorDataLoader.LoadAsync(InstructorId,CancellationToken.None);

            return new InstructorType()
            {
                Id = instructor.Id,
                LastName = instructor.LastName,
                FirstName = instructor.FirstName
            };
        }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
