using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Hubs
{
    public interface IActionHub
    {
        Task Comment();
        Task Issue();
    }
}
