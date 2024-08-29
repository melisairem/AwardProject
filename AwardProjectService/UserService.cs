﻿using AwardProjectEntity;
using Dal;

namespace AwardProjectService
{
    public class UserService : BaseCrudDal<User>
    {
        public override void Add(User entity)
        {
            base.Add(entity);

            UserAward userAward = new()
            {
                UserId = entity.Id,
                AwardId = 1
            };

            UserAwardService userAwardService = new();
            userAwardService.Add(userAward);
        }
    }
}