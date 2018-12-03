using AutoMapper;
using Core;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace UI.MVCWeb.Mappings
{
    [DebuggerStepThrough]
    public class AutoMapperMappingService : IMappingService
    {
        private readonly IMapper mapper;

        [DebuggerHidden]
        public AutoMapperMappingService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [DebuggerHidden]
        public async Task<TOut> Map<TOut>(object inModel)
        {
            return await Task.FromResult(mapper.Map<TOut>(inModel));
        }

        [DebuggerHidden]
        public async Task Map<TOut>(TOut outModel, params object[] inModels)
        {
            List<Task> tasks = new List<Task>();
            foreach (object model in inModels)
            {
                tasks.Add(Task.Run(() => mapper.Map(model, outModel)));
            }

            await Task.WhenAll(tasks);
        }
    }
}
