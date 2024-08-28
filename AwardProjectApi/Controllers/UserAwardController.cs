using AwardProjectEntity;
using AwardProjectService;
using Microsoft.AspNetCore.Mvc;

namespace AwardProjectApi.Controllers
{
    [ApiController]
    public class UserAwardController : ControllerBase
    {
        private readonly UserAwardService _userAwardService;

        public UserAwardController(UserAwardService userAwardService)
        {
            _userAwardService = userAwardService;
        }

        [Route("Api/GetList")]
        [HttpGet]
        public List<UserAward> GetList()
        {
            List<UserAward> userAwards = _userAwardService.GetAll(new List<string>
            {
                nameof(UserAward.User),
                nameof(UserAward.Award),
            }).ToList(); 

            return userAwards;
        }
    }
}
