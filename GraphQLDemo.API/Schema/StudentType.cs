namespace GraphQLDemo.API.Schema
{
    public class StudentType
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        // This will help to display the name in graphql query
        [GraphQLName("Gpa")]
        public double GPA { get; set; }
    }
}
