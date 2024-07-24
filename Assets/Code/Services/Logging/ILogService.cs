public interface ILogService : IService
{
    void Log(object message, object sender = null);
    void LogError(object message, object sender = null);
    void LogWarning(object message, object sender = null);
}