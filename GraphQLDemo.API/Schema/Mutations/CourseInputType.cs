using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class CourseInputType
    {

        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }
        public Guid InstructorId { get; set; }
    }
}
