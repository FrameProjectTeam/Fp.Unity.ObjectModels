namespace Fp.ObjectModels.Singletons
{
    public abstract class SingletonC<T, TFactory>
        where T : class
        where TFactory : class, ISingletonFactory<T>, new()
    {
        private static T _instance;

        public static T Instance => _instance ??= (new TFactory().Create());
    }
}