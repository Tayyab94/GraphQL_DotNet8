using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Schema.Subscriptions;
using GraphQLDemo.API.Services.Course;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Mutations
{
    public class Mutattion
    {
        private readonly CourseRepository _courseRepo;

        public Mutattion(CourseRepository repository)
        {
            _courseRepo = repository;
        }

        public async Task<CourseResult> CreateCourse(CourseInputType model, [Service]ITopicEventSender topicEventSender)
        {

            CourseDTO data = new CourseDTO()
            {
                Id= Guid.NewGuid(),
                Name = model.Name,
                Subject = model.Subject,
                //InstructorId = model.InstructorId,
                Instructor= new InstructorDTO()
                {
                    Id= model.InstructorId
                }
            };
            await _courseRepo.Create(data);

            var course = new CourseResult
            {
                Id = data.Id,
                Name = model.Name,

                Subject = model.Subject,
                InstructorId = model.InstructorId
            };
            await topicEventSender.SendAsync(nameof(Subscription.CourseCreated), course);
            return course;

        }


        public async Task<CourseResult> UpdateCourse(Guid id, CourseInputType model, [Service] ITopicEventSender topicEventSender)
        {

            CourseDTO data = new CourseDTO()
            {
                Id= id,
                Name = model.Name,
                Subject = model.Subject,
                Instructor = new InstructorDTO()
                {
                    Id= model.InstructorId
                },
            };
            await _courseRepo.Update(data);


            var course = new CourseResult
            {
                Id = data.Id,
                Name = model.Name,

                Subject = model.Subject,
                InstructorId = model.InstructorId
            };

            string UpdateCourseTopic = $"{course.Id}_{nameof(Subscription.CourseUpdated)}";
            await topicEventSender.SendAsync(UpdateCourseTopic, course);
            return course;
        }


        public async Task<bool> DeleteCourse(Guid Id)
        {
            return await _courseRepo.Delete(Id);
        }
    }
}
