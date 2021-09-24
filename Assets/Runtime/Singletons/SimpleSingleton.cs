namespace Fp.ObjectModels.Singletons
{
    public abstract class SimpleSingleton<T>
        where T : class, new()
    {
        private static T _instance;

        public static T Instance => _instance ??= new T();
    }
}