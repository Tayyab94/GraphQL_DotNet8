using GraphQLDemo.API.Models;

namespace GraphQLDemo.API.Schema
{



    public class CourseType
    {
        public Guid Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }


         
        [GraphQLNonNullType] // its mean which property should not be not nullable
        public InstructorType Instructor { get; set; }
        public IEnumerable<StudentType> Students { get; set; }
    }
}
