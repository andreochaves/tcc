using Microsoft.AspNetCore.Mvc;
using QuestAdventure.Models;
using QuestAdventure.Repositories.Interfaces;

namespace QuestAdventure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;

        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Admin>> Login(string email, string password)
        {
            Admin admin = await _adminRepository.Login(email, password);
            return Ok(admin);
        }

    }
}
