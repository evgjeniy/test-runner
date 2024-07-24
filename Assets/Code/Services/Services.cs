public interface IService {}

public class Services
{
    private static Services _instance;

    public static Services All => _instance ??= new Services();

    public TService Register<TService>(TService implementation) where TService : IService
    {
        Implementation<TService>.ServiceInstance = implementation;
        return implementation;
    }

    public TService Resolve<TService>() where TService : IService
    {
        return Implementation<TService>.ServiceInstance;
    }

    private static class Implementation<TService> where TService : IService
    {
        public static TService ServiceInstance;
    }
}