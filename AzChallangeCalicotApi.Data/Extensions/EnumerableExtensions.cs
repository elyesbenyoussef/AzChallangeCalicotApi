using AzChallangeCalicotApi.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AzChallangeCalicotApi.Data.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Actifs<T>(this IEnumerable<T> str) where T : EntiteBase
        {
            return str?.Where(x => !x.DateHeureSuppression.HasValue);
        }
    }
}
