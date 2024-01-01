using Organizarty.Identity.Adapters.Cryptographies;

namespace Organizarty.Identity.Infra.Providers.Cryptographys;

public class BCryptProvider : ICryptographys
{
    public byte[] GenenateSalt() { throw new NotImplementedException(); }
    public (string HashedPassword, string Salt) Hash(string password, byte[] salt) { throw new NotImplementedException(); }

    public bool VerifyPassword(string password, string storedHashedPassword, string storedSalt)
      => BCrypt.Net.BCrypt.Verify(password, storedHashedPassword);

    (string HashedPassword, string Salt) ICryptographys.HashPassword(string password)
    {
        var hash = BCrypt.Net.BCrypt.HashPassword(password); ;

        return (hash, "<not-used>");
    }
}
