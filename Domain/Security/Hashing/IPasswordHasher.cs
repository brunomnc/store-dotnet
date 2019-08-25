namespace meetapp_dotnet.Domain.Security.Hashing
{
  public interface IPasswordHasher
  {
    string HashPassword(string password);
    bool PasswordMatches(string providedPassword, string passwordHash);

  }
}