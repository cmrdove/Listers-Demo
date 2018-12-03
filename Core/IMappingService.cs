using System.Threading.Tasks;

namespace Core
{
    public interface IMappingService
    {
        Task<TOut> Map<TOut>(object inModel);
        Task Map<TOut>(TOut outModel, params object[] inModel);
    }
}
