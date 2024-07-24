public class EmptyLogService : ILogService
{
    public void Log(object message, object sender = null) {}
    public void LogError(object message, object sender = null) {}
    public void LogWarning(object message, object sender = null) {}
}