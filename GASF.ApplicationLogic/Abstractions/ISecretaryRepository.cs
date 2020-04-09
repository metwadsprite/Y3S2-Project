using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Abstractions
{
    public interface ISecretaryRepository : IRepository<Secretary>
    {
        ICollection<Secretary> GetSecretaryById(Guid Id);

    }
}
