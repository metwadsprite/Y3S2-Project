using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface ISecretaryRepository : IRepository<Secretary>
    {
        Secretary GetSecretaryByUserId(Guid UserId);
        Secretary GetSecretaryById(Guid Id);
    }
}
