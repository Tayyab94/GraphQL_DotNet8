using GraphQLDemo.API.Schema.Mutations;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace GraphQLDemo.API.Schema.Subscriptions
{
    public class Subscription
    {
        [Subscribe]
        public CourseResult CourseCreated([EventMessage] CourseResult course) => course;

        [SubscribeAndResolve]
        public ValueTask<ISourceStream<CourseResult>>CourseUpdated(Guid id ,[Service]ITopicEventReceiver topicEventReceiver)
        {
            string topicName = $"{id}_{nameof(Subscription.CourseUpdated)}";

            return topicEventReceiver.SubscribeAsync<CourseResult>(topicName);
        }
    }
}
