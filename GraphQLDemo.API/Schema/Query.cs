using Bogus;

namespace GraphQLDemo.API.Schema
{
    public class Query
    {

        private readonly Faker<InstructorType> instractorFaker;
      private readonly  Faker<StudentType> studentFaker;
        private readonly Faker<CourseType> courseFaker;

        public Query()
        {

            // For faker, we have installed Bogus Library

            instractorFaker = new Faker<InstructorType>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                    .RuleFor(s => s.LastName, f => f.Name.LastName());


            studentFaker = new Faker<StudentType>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.FirstName, f => f.Name.FirstName())
                    .RuleFor(s => s.LastName, f => f.Name.LastName())
                    .RuleFor(s => s.GPA, f => f.Random.Double(1, 4));


            courseFaker = new Faker<CourseType>()
                .RuleFor(s => s.Id, f => Guid.NewGuid())
                .RuleFor(s => s.Name, f => f.Name.JobTitle())
                .RuleFor(s => s.Subject, f => f.PickRandom<Subject>())
                .RuleFor(s => s.Instructor, f => instractorFaker.Generate())
                .RuleFor(s => s.Students, f => studentFaker.Generate(2));
        }
        public IEnumerable<CourseType> GetCourses()
        {

            List<CourseType> courses = courseFaker.Generate(5);

            return courses;
        }

        public async Task<CourseType>GetCourseByIdAsync(Guid id)
        {
            await Task.Delay(1000); 
            var courseType = courseFaker.Generate();
            courseType.Id = id;

            return courseType;
        }
        // we will no longer to display this in our query
        [GraphQLDeprecated("This query is deprecated now")]
        public string Instruction => "Hit the Button and see the resutl";
    }
}
