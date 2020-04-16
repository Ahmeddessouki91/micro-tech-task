using System;

namespace PCTASK.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}