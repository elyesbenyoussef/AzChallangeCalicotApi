using AutoMapper;

namespace AzChallangeCalicotApi.Type.Helpers
{
    public class MapHelper
    {
        private static IMapper _mapper;
        public MapHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static TResult MapModel<TResult, TInput>(TInput origin) where TResult : new()
        {
            return _mapper.Map<TResult>(origin);
        }

        public static TResult MapModel<TResult, TInput>(TResult destination, TInput origin)
        {
            return _mapper.Map<TInput, TResult>(origin, destination);
        }
    }
}
