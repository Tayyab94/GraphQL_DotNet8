using GraphQLDemo.API.Schema.Subscriptions;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutattion
    {

        private readonly List<CourseResult> _courses;

        public Mutattion()
        {
            _courses = new List<CourseResult>();
        }

        public async Task<CourseResult> CreateCourse(CourseInputType model, [Service]ITopicEventSender topicEventSender)
        {
            var course = new CourseResult
            {
                Id = Guid.NewGuid(),
                Name = model.Name,

                Subject = model.Subject,
                InstructorId = model.InstructorId
            };
            _courses.Add(course);

            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);
            return course;

        }


        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType model, [Service] ITopicEventSender topicEventSender)
        {
            var result = _courses.FirstOrDefault(s => s.Id == id);

            if (result == null)
            {
                throw new GraphQLException(new Error("Course Not found", "403"));
            }

            result.Name = model.Name;
            result.Subject = model.Subject;
            result.InstructorId = model.InstructorId;

            string UpdateCourseTopic = $"{result.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(UpdateCourseTopic, result);
            return result;
        }


        public bool DeleteCourse(Guid Id)
        {
            return 
                _courses.RemoveAll(s=>s.Id == Id)>1;
        }
    }
}
