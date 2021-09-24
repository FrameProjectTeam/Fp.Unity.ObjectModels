using System;

namespace Fp.ObjectModels.Disposing
{
    public interface IDisposableObject
        : IDisposable, IDisposableStatus
    { }
}