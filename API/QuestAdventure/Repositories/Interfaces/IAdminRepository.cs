using QuestAdventure.Models;

namespace QuestAdventure.Repositories.Interfaces
{
    public interface IAdminRepository
    {
        Task<Admin> BuscarPorEmail(string email);
        Task<Admin> Login(string email, string password);
    }
}
