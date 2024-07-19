using GraphQLDemo.API.Models;
using GraphQLDemo.API.Schema;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLDemo.API.DTOs
{
    public class CourseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Subject Subject { get; set; }

       
        public InstructorDTO Instructor { get; set; }
        public IEnumerable<StudentDTO> Students { get; set; }
    }
}
