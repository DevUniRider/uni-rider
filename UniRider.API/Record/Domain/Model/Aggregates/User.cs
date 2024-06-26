using System.Text.Json.Serialization;
namespace UniRider.API.Record.Domain.Model.Aggregates;

public class User(string username, string passwordHash)
{
    public User() : this(string.Empty, string.Empty){}

    public int Id { get; }
    public string Username { get; private set; } = username;
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string Dni{ get; private set; }
    
    

    [JsonIgnore] public string PasswordHash { get; private set; } = passwordHash;
    
    
    public User UpdateUsername(string username)
    {
        Username = username;
        return this;
    }
    public User UpdatePasswordHash(string passwordHash)
    {
        PasswordHash = passwordHash;
        return this;
    }
    
}