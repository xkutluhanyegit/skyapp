using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EF
{
    public class EfUserDal:EfEntityRepositoryBase<User,AppDbContext>,IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new AppDbContext())
            {
                var result = from operationClaim in context.OperationClaims
                    join userOperationClaim in context.UserOperationClaims
                        on operationClaim.Id equals userOperationClaim.OperationClaimId
                    where userOperationClaim.UserId == user.id
                    select new OperationClaim {Id = operationClaim.Id, Name = operationClaim.Name};
                return result.ToList();

            }
        }
    }
}