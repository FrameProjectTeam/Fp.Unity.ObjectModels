namespace Fp.ObjectModels.Singletons
{
    public interface ISingletonFactory<out T>
        where T : class
    {
        T Create();
    }
}