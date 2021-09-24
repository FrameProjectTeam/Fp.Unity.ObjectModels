namespace Fp.ObjectModels.Singletons
{
    public abstract class SingletonS<T, TFactory>
        where T : class
        where TFactory : struct, ISingletonFactory<T>
    {
        private static T _instance;

        public static T Instance => _instance ??= (default(TFactory).Create());
    }
}