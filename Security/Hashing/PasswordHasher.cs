using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using meetapp_dotnet.Domain.Security.Hashing;

namespace meetapp_dotnet.Security.Hashing
{
  public class PasswordHasher : IPasswordHasher
  {
    public string HashPassword(string password)
    {
      byte[] salt;
      byte[] buffer;
      if (string.IsNullOrEmpty(password))
      {
        throw new ArgumentException("password");
      }
      using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(password, 0x10, 0x3e8))
      {
        salt = bytes.Salt;
        buffer = bytes.GetBytes(0x20);
      }
      byte[] dst = new byte[0x31];
      Buffer.BlockCopy(salt, 0, dst, 1, 0x10);
      Buffer.BlockCopy(buffer, 0, dst, 0x11, 0x20);
      return Convert.ToBase64String(dst);
    }

    public bool PasswordMatches(string providedPassword, string passwordHash)
    {
      byte[] buffer;
      if (passwordHash == null)
      {
        return false;
      }
      if (providedPassword == null)
      {
        throw new ArgumentNullException("providedPassword");
      }
      byte[] src = Convert.FromBase64String(passwordHash);
      if ((src.Length != 0x31) || (src[0] != 0))
      {
        return false;
      }
      byte[] dst = new byte[0x10];
      Buffer.BlockCopy(src, 1, dst, 0, 0x10);
      byte[] buffer2 = new byte[0x20];
      Buffer.BlockCopy(src, 0x11, buffer2, 0, 0x20);
      using (Rfc2898DeriveBytes bytes = new Rfc2898DeriveBytes(providedPassword, dst, 0x3e8))
      {
        buffer = bytes.GetBytes(0x20);
      }
      return ByteArraysEqual(buffer, buffer2);
    }

    [MethodImpl(MethodImplOptions.NoOptimization)]
    private bool ByteArraysEqual(byte[] a, byte[] b)
    {
      if (ReferenceEquals(a, b))
      {
        return true;
      }

      if (a == null || b == null || a.Length != b.Length)
      {
        return false;
      }
      bool same = true;
      for (int i = 0; i < a.Length; i++)
      {
        same &= (a[i] == b[i]);
      }
      return same;
    }


  }
}