namespace Snailbird.Utilities;

public struct PostgresConnection : IEquatable<PostgresConnection>
{
    public string? Host { get; set; }
    public int Port { get; set; }
    public string? Database { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public bool Equals(PostgresConnection other)
    {
        return Host == other.Host && Port == other.Port && Database == other.Database && Username == other.Username && Password == other.Password;
    }

    public override bool Equals(object? obj)
    {
        return obj is PostgresConnection other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Host, Port, Database, Username, Password);
    }
}