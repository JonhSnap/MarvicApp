using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Hubs
{
    public interface IActionHub
    {
        Task Add_Comment();
        Task Update_Comment();
        Task Remove_Comment();
    }
}
