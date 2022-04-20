
namespace FominosPizza;

public class User
{
  public string Id { get; set; }
  public string Email { get; set; }
  public string Password { get; set; }

  public User(string email, string password)
  {

    var notification = Notification.Instance;


    this.Id = Guid.NewGuid().ToString();

    var isEmailValid = this.validateEmail(email);
    var isPasswordValid = this.validatePassword(password);

    if (!isEmailValid)
    {
      notification.Add("use a valid email address", NotificationType.Error);
    }

    if (!isPasswordValid)
    {
      notification.Add("password should have at least 8 characters", NotificationType.Error);
    }
  }

  private bool validateEmail(string email)
  {
    return email.Contains("@");
  }

  private bool validatePassword(string password)
  {
    return password.Length >= 8;
  }

}