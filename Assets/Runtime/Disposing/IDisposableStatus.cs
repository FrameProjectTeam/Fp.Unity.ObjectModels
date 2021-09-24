namespace Fp.ObjectModels.Disposing
{
    public interface IDisposableStatus
    {
        bool IsDisposed { get; }
        bool IsDisposing { get; }
        bool IsActive { get; }
    }
}