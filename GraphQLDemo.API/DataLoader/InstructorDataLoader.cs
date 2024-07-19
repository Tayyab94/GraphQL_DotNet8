using GraphQLDemo.API.DTOs;
using GraphQLDemo.API.Schema;
using GraphQLDemo.API.Services.Course;

namespace GraphQLDemo.API.DataLoader
{
    public class InstructorDataLoader : BatchDataLoader<Guid, InstructorDTO>
    {
        private readonly InstructorRepository _instructorRepository;
        public InstructorDataLoader(InstructorRepository instructorRepository,IBatchScheduler batchScheduler, DataLoaderOptions? options = null) : base(batchScheduler, options)
        {
            _instructorRepository= instructorRepository;
        }

        protected override async Task<IReadOnlyDictionary<Guid, InstructorDTO>> LoadBatchAsync(IReadOnlyList<Guid> keys, CancellationToken cancellationToken)
        {
            IEnumerable<InstructorDTO> instructors= await _instructorRepository.GetManyById(keys);

            return instructors.ToDictionary(s => s.Id);
        }
    }
}
