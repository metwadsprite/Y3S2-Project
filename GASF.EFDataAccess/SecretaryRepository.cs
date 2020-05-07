using GASF.ApplicationLogic.Abstractions;
using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GASF.EFDataAccess.Migrations
{
   public class SecretaryRepository :  BaseRepository<Secretary>, ISecretaryRepository
    {

        public SecretaryRepository(StudentRecordDbContext dbContext) : base(dbContext)
        {

        }
        public Secretary GetSecretaryByUserId(Guid UserId)
        {
                return dbContext.Secretaries
                                .Where(secretary => secretary.UserId == UserId)
                                .SingleOrDefault();
            
        }

        public Secretary GetSecretaryById(Guid Id)
        {
            return dbContext.Secretaries
                            .Where(secretary => secretary.Id == Id)
                            .SingleOrDefault();

        }
    }
}
