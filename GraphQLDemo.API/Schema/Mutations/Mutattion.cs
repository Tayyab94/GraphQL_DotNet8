namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutattion
    {

        private readonly List<CourseResult> _courses;

        public Mutattion()
        {
            _courses = new List<CourseResult>();
        }

        public CourseResult CreateCourse(CourseInputType model)
        {
            var course = new CourseResult
            {
                Id = Guid.NewGuid(),
                Name = model.Name,

                Subject = model.Subject,
                InstructorId = model.InstructorId
            };
            _courses.Add(course);

            return course;

        }


        public CourseResult UpdateCourse(Guid id, CourseInputType model)
        {
            var result = _courses.FirstOrDefault(s => s.Id == id);

            if (result == null)
            {
                throw new GraphQLException(new Error("Course Not found", "403"));
            }

            result.Name = model.Name;
            result.Subject = model.Subject;
            result.InstructorId = model.InstructorId;

            return result;
        }


        public bool DeleteCourse(Guid Id)
        {
            return 
                _courses.RemoveAll(s=>s.Id == Id)>1;
        }
    }
}
