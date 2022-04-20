namespace FominosPizza;

enum NotificationType
{
  Error,
  Success,
  Warning,
}

class NotificationProps
{
  public string Message { get; set; }
  public NotificationType Type { get; set; }
}

public class Notification
{
  private static Notification instance = null;
  private static List<NotificationProps> Notifications;
  private static readonly object padlock = new object();

  private Notification() { }

  public static Notification Instance
  {
    get
    {
      lock (padlock)
      {
        if (instance == null)
        {
          instance = new Notification();
        }
        return instance;
      }
    }
  }

  public void Add(string message, NotificationType type)
  {
    Notifications.Add(new NotificationProps()
    {
      Message = message,
      Type = type
    });
  }

  public bool HasErrors()
  {
    return Notifications.Any(n => n.Type == NotificationType.Error);
  }

  public string GetErrorMessages()
  {
    return Notifications.Where(n => n.Type == NotificationType.Error)
      .Select(n => n.Message)
      .Aggregate((a, b) => a + "," + b);
  }
}
