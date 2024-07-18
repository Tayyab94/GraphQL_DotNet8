namespace GraphQLDemo.API.DTOs
{
    public class StudentDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public double GPA { get; set; }

        public IEnumerable<CourseDTO> Courses { get; set; }
    }
}
