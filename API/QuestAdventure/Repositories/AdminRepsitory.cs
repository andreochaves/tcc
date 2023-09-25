using Microsoft.EntityFrameworkCore;
using QuestAdventure.Data;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Repositories
{
    public class AdminRepsitory : IAdminRepository
    {
        private readonly DataContext _context;

        public AdminRepsitory(DataContext context)
        {
            _context = context;
        }

        public async Task<Admin> BuscarPorEmail(string email)
        {
            return await _context.UsuarioMaster.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<Admin> Login(string email, string password)
        {
            Admin admin = await BuscarPorEmail(email);
            if (admin == null)
            {
                throw new ArgumentNullException("Email inválido!");
            }
            if (admin.Senha != password)
            {
                throw new Exception("Senha Inválida!");
            }
            return admin;
        }
    }
}
