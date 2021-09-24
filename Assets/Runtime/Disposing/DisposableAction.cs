using System;

namespace Fp.ObjectModels.Disposing
{
    public class DisposableAction : IDisposable
    {
        private Action _dispose;

        public DisposableAction(Action dispose)
        {
            _dispose = dispose ?? throw new ArgumentNullException(nameof(dispose));
        }

        public DisposableAction(Action construct, Action dispose)
        {
            if (construct == null)
            {
                throw new ArgumentNullException(nameof(construct));
            }

            if (dispose == null)
            {
                throw new ArgumentNullException(nameof(dispose));
            }

            construct();

            _dispose = dispose;
        }

#region IDisposable Implementation

        public void Dispose()
        {
            if (_dispose == null)
            {
                throw new ObjectDisposedException(GetType().Name);
            }

            try
            {
                _dispose();
            }
            finally
            {
                _dispose = null;
            }
        }

#endregion
    }
}