using Mapster;
using System.Collections.Generic;
using System.Linq;

namespace Grader.Api.Business
{
    public static class MapExtensions
    {
        public static IEnumerable<TOut> Project<TIn, TOut>(this IEnumerable<TIn> collection)
        {
            return collection.Select(i => i.Adapt<TOut>());
        }
    }
}
