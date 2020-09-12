namespace NewGame4.Users
{
    public interface IUserUnitModel
    {
        string Id { get;  }
        string UserId { get;  }
        string Name { get; }
        string SecondName { get; }
        string Email { get; }
        string Password { get; }
        string Session { get; set; }
        bool IsNew { get; set; }
        int IsAuthorisation { get; set; }
        int CurrentScreen { get; set; }
    }
}