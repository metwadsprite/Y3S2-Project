using GASF.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GASF.ApplicationLogic.Services
{
    public interface ISecretaryService
    {
        Secretary GetSecretaryByUserId(string userId);

        Secretary GetSecretaryById(Guid Id);
    }
}
