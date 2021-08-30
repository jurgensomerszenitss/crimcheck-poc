using Mapster;
using System.Collections.Generic;
using System.Linq;

namespace Grader.Api.Business
{
    public static class MapExtensions
    {
        private static IDictionary<string, string> _mapConstants = new Dictionary<string,string>();

        public static IEnumerable<TOut> Project<TIn, TOut>(this IEnumerable<TIn> collection)
        {
            return collection.Select(i => i.Adapt<TOut>());
        }
    }
}
