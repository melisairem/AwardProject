using AwardProjectEntity;
using Dal;
using System.Linq.Expressions;
using Utility.Security;

namespace AwardProjectService
{
    public class UserService : BaseCrudDal<User>
    {
        public override void Add(User entity)
        {
            User? user = GetAll(predicates: new List<Expression<Func<User, bool>>>
            {
               user => user.Email == entity.Email
            }).FirstOrDefault();

            if (user == null)
            {
                //TODOhata mesajı gelecek.
                return;
            }

            entity.Password = PasswordHash.Hash(entity.Password);
            base.Add(entity);
        }

        //user entity formdan gelen data , userOld veritabanından gelen data
        //TODO form alanından email güncelleme işlemi kapatılırsa sorun çözülecek.
        public override void Update(User entity)
        {
            User userOld = GetById(entity.Id)!;

            if (entity.Email != userOld.Email)
            {
                User? otherUser = GetAll(predicates: new List<Expression<Func<User, bool>>>
                {
                    user => user.Email == entity.Email,
                    user => user.Id == entity.Id
                }).FirstOrDefault();

                if (otherUser != null)
                {
                    //hata mesajı gelecek.
                    return;
                }
            }



            base.Update(entity);
        }

    }
}
