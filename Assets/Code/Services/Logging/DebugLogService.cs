using UnityEngine;

public class DebugLogService : ILogService
{
    public void Log(object message, object sender = null) => Debug.Log($"{GetSenderInfo(sender)} {message}");
    public void LogError(object message, object sender = null) => Debug.LogError($"{GetSenderInfo(sender)} {message}");
    public void LogWarning(object message, object sender = null) => Debug.LogWarning($"{GetSenderInfo(sender)} {message}");

    private static string GetSenderInfo(object sender)
    {
        return sender switch
        {
            null => "",
            string senderMessage => $"<b>[{senderMessage}]</b>",
            _ => $"<b><color={GetHexColor(sender)}>[{sender.GetType().Name}]</color></b>"
        };
    }

    private static string GetHexColor(object obj)
    {
        var hexColor = "#";
        var intColor = obj.GetHashCode() % 0xFFFFFF;

        for (var i = 16; i >= 0; i -= 8)
        {
            var colorValue = (intColor >> i) & 0xFF;
            hexColor += colorValue.ToString("X2");
        }
            
        return hexColor;
    }
}