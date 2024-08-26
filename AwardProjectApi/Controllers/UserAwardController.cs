using AwardProjectEntity;
using AwardProjectEntity.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AwardProjectApi.Controllers
{
    [ApiController]
    public class UserAwardController : ControllerBase
    {
        private readonly ModelContext _context;

        public UserAwardController(ModelContext context)
        {
            _context = context;
        }

        [Route("Api/GetList")]
        [HttpGet]
        public List<UserAward> GetList()
        {
            List<UserAward> userAwards = _context.UserAward
                .Include(ua => ua.User)
                .Include(ua => ua.Award)
                .ToList();
            return userAwards;
        }
    }
}
