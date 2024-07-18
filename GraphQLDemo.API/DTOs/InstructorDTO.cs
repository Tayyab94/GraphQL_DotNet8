namespace GraphQLDemo.API.DTOs
{
    public class InstructorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;


        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
