using Enexure.MicroBus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.QueryDemo
{
    public class MeaningOfLife : IQuery<MeaningOfLife, int>
    {
        public readonly IEnumerable<int> Numbers;

        public MeaningOfLife(params int[] numbers)
        {
            Numbers = numbers;
        }
    }

    public class DeepThought
        : IQueryHandler<MeaningOfLife, int>
    {
        public Task<int> Handle(MeaningOfLife query)
        {
            if (query.Numbers.Count() == 0)
                return Task.FromResult(42);
            else
                return Task.FromResult(query.Numbers.Sum());
        }
    }
}