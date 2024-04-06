using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public interface IUserCreditService : IDisposable
    {
        void Dispose();
        int GetCreditLimit(string lastName);
    }
}